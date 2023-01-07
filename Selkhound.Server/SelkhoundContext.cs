//
//  SelkhoundContext.cs
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

using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Selkhound.Server
{
    /// <summary>
    /// Provides the database context for Selkhound.
    /// </summary>
    public sealed class SelkhoundContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelkhoundContext"/> class.
        /// </summary>
        /// <param name="contextOptions">
        /// The <see cref="DbContextOptions{TContext}"/> for building this instance.
        /// </param>
        public SelkhoundContext(DbContextOptions<SelkhoundContext> contextOptions)
            : base(contextOptions)
        {
            // Body left intentionally blank.
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
