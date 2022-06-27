//
//  IEmoji.cs
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
using Remora.Rest.Core;

namespace Selkhound.API.Abstractions.Objects
{
    /// <summary>
    /// Represents an emoji.
    /// </summary>
    [PublicAPI]
    public interface IEmoji
    {
        /// <summary>
        /// Gets the unique id of the emoji.
        /// </summary>
        Snowflake? Id { get; }

        /// <summary>
        /// Gets the name of the emoji.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the user that created this emoji.\n
        /// This value is null if the emoji is built-in.
        /// </summary>,
        IUser Creator { get; }

        /// <summary>
        /// Gets a value indicating whether this emoji is animated.
        /// </summary>
        bool IsAnimated { get; }
    }
}
