//
//  TransientJobActivator.cs
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
using Hangfire.Server;

namespace Selkhound.Server.Hangfire
{
    /// <summary>
    /// A simple job activator which provides an IoC container.
    /// </summary>
    public sealed class TransientJobActivator : JobActivator
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransientJobActivator"/> class.
        /// </summary>
        /// <param name="serviceProvider">A service provider for this instance.</param>
        public TransientJobActivator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc />
        public override object? ActivateJob(Type jobType) => _serviceProvider.GetService(jobType);

        /// <inheritdoc />
        public override JobActivatorScope BeginScope(JobActivatorContext context)
        {
            return new ActivatorScope(_serviceProvider.CreateScope());
        }

        /// <inheritdoc />
        public override JobActivatorScope BeginScope(PerformContext context)
        {
            return new ActivatorScope(_serviceProvider.CreateScope());
        }

        private class ActivatorScope : JobActivatorScope
        {
            private readonly IServiceScope _serviceScope;

            public ActivatorScope(IServiceScope scope)
            {
                _serviceScope = scope;
            }

            public override object? Resolve(Type type)
            {
                return _serviceScope.ServiceProvider.GetService(type);
            }

            public override void DisposeScope()
            {
                _serviceScope.Dispose();
                base.DisposeScope();
            }
        }
    }
}
