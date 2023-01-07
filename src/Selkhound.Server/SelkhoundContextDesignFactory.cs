//
//  SelkhoundContextDesignFactory.cs
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

using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Selkhound.Server.Models;

namespace Selkhound.Server
{
    /// <summary>
    /// A design factory for building manual migrations.
    /// </summary>
    [UsedImplicitly]
    public class SelkhoundContextDesignFactory : IDesignTimeDbContextFactory<SelkhoundContext>
    {
        /// <inheritdoc />
        public SelkhoundContext CreateDbContext(string[] args)
        {
            var pathToAppSettings = Directory.GetCurrentDirectory();

            var configuration = new ConfigurationBuilder()
                                .SetBasePath(pathToAppSettings)
                                .AddUserSecrets<Program>()
                                .AddEnvironmentVariables("Selkhound_")
                                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<SelkhoundContext>();
            var connectionString = configuration.GetConnectionString("Production");

            RuntimeConfiguration appConfig = configuration
                            .GetSection(RuntimeConfiguration.ConfigSectionName)
                            .Get<RuntimeConfiguration>()!;
            if (appConfig.SqlServerType == SqlServerType.PostgreSQL)
            {
                optionsBuilder.UseNpgsql(connectionString);
            }
            else
            {
                optionsBuilder.UseSqlServer(connectionString);
            }

            return new SelkhoundContext(optionsBuilder.Options);
        }
    }
}
