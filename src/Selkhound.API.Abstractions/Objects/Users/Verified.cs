//
//  Verified.cs
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

namespace Selkhound.API.Abstractions.Objects
{
    /// <summary>
    /// Ensures the validity of the underlying <typeparamref name="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The underlying type to verify.</typeparam>
    [PublicAPI]
    public readonly struct Verified<TEntity>
        where TEntity : notnull
    {
        /// <summary>
        /// Gets the underlying entity.
        /// </summary>
        public readonly TEntity Entity;

        /// <summary>
        /// Gets a value indicating whether the user
        /// has ensured the validity of the underlying
        /// <typeparamref name="TEntity"/>.
        /// </summary>
        public readonly bool IsVerified;

        /// <summary>
        /// Initializes a new instance of the <see cref="Verified{TEntity}"/> struct.
        /// </summary>
        /// <param name="entity">The underlying entity.</param>
        /// <param name="isVerified">Whether the user has verified the underlying entity's validity.</param>
        public Verified(TEntity entity, bool isVerified)
        {
            Entity = entity;
            IsVerified = isVerified;
        }
    }
}
