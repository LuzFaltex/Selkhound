//
//  SelkhoundAPIVersion.cs
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

namespace Selkhound.API.Abstractions
{
    /// <summary>
    /// Enumerates various released versions of the Selkhound API.
    /// </summary>
    [PublicAPI]
    public enum SelkhoundAPIVersion
    {
        /// <summary>
        /// Version 0 - Prerelease API. Highly unstable.
        /// </summary>
        V0 = 0,

        /// <summary>
        /// The default version, recommended version of the API to use.
        /// </summary>
        Default = V0,

        /// <summary>
        /// The latest stable version of the API.
        /// </summary>
        Stable = V0,

        /// <summary>
        /// The latest version of the API. May not be stable.
        /// </summary>
        Latest = V0
    }
}
