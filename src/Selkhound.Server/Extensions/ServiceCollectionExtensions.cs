//
//  ServiceCollectionExtensions.cs
//
//  Author:
//       LuzFaltex Contributors
//
//  LGPL-3.0 License
//
//  Copyright (c) 2022 LuzFaltex
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//

using Hangfire;
using Hangfire.PostgreSql;
using Hangfire.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Selkhound.Server.Hangfire;
using Selkhound.Server.Models;

namespace Selkhound.Server.Extensions
{
    /// <summary>
    /// Provides extension methods for the <see cref="IServiceCollection"/> type.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        private const string MigrationsHistoryTableName = "__Selkhound_EFMigrationsHistory";

        /// <summary>
        /// Adds Selkhound-related services to the host.
        /// </summary>
        /// <param name="services">The service provider.</param>
        /// <returns>The current service provider for chaining.</returns>
        public static IServiceCollection AddSelkhound(this IServiceCollection services)
        {
            var sqlServerNames = string.Join(", ", Enum.GetNames<SqlServerType>().Select(x => $"'{x}'"));
            services.AddOptions<RuntimeConfiguration>()
                    .Configure<IConfiguration>
                    (
                        (options, config) =>
                        {
                            config.Bind(RuntimeConfiguration.ConfigSectionName, options);
                        }
                    )
                    .Validate
                    (
                        config => Enum.IsDefined(config.SqlServerType),
                        $"The value for '{nameof(RuntimeConfiguration)}.{nameof(RuntimeConfiguration.SqlServerType)}' must be one of {{ {sqlServerNames} }}"
                    );

            services.AddMemoryCache();

            services.AddDbContext<SelkhoundContext>
            (
                (serviceProvider, options) =>
                {
                    var config = serviceProvider.GetRequiredService<IConfiguration>();
                    var selkhoundConfig = serviceProvider.GetRequiredService<RuntimeConfiguration>();
                    var environment = serviceProvider.GetRequiredService<IHostEnvironment>();

                    var builder = selkhoundConfig.SqlServerType switch
                    {
                        SqlServerType.PostgreSQL => options.UseNpgsql
                        (
                            config.GetConnectionString(environment.EnvironmentName),
                            x => x.MigrationsHistoryTable(MigrationsHistoryTableName)
                        ),
                        SqlServerType.SqlServer => options.UseSqlServer
                        (
                            config.GetConnectionString(environment.EnvironmentName),
                            x => x.MigrationsHistoryTable(MigrationsHistoryTableName)
                        ),
                        _ => throw new InvalidOperationException()
                    };
                    builder.ConfigureWarnings
                    (
                        c =>
                            c.Log
                            (
                                (RelationalEventId.CommandExecuted, LogLevel.Debug),
                                (CoreEventId.ContextInitialized, LogLevel.Debug)
                            )
                    );
                },
                ServiceLifetime.Transient
            );

            services.AddHangfire
            (
                (serviceProvider, config) =>
                {
                    var baseConfig = serviceProvider.GetRequiredService<IConfiguration>();
                    var selkhoundConfig = serviceProvider.GetRequiredService<RuntimeConfiguration>();
                    var environment = serviceProvider.GetRequiredService<IHostEnvironment>();

                    config.UseActivator(new TransientJobActivator(serviceProvider));
                    config.UseSimpleAssemblyNameTypeSerializer()
                          .UseRecommendedSerializerSettings()
                          .UseSerilogLogProvider();

                    if (selkhoundConfig.SqlServerType == SqlServerType.SqlServer)
                    {
                        config.UseSqlServerStorage
                        (
                            baseConfig.GetConnectionString(environment.EnvironmentName),
                            new SqlServerStorageOptions()
                            {
                                CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                                SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                                QueuePollInterval = TimeSpan.Zero,
                                UseRecommendedIsolationLevel = true,
                                DisableGlobalLocks = true
                            }
                        );
                    }
                    else
                    {
                        config.UsePostgreSqlStorage
                        (
                            baseConfig.GetConnectionString(environment.EnvironmentName)
                        );
                    }
                }
            );

            return services;
        }
    }
}
