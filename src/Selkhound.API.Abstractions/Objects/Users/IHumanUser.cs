﻿//
//  IHumanUser.cs
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
    /// Represents a human user.
    /// </summary>
    [PublicAPI]
    public interface IHumanUser : IUser
    {
        /// <summary>
        /// Gets a value indicating whether the user has multi-factor authentication enabled on their account.
        /// </summary>
        bool IsMFAEnabled { get; }

        /// <summary>
        /// Gets the user's profile information.
        /// </summary>
        IUserProfile UserProfile { get; }
    }
}
