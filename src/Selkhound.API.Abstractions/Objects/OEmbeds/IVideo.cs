﻿//
//  IVideo.cs
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
    /// Represents a resource containing a playable video.
    /// </summary>
    [PublicAPI]
    public interface IVideo
    {
        /// <summary>
        /// Gets the HTML required to embed a video player.
        /// </summary>
        string Html { get; }

        /// <summary>
        /// Gets the width in pixels of the video player.
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Gets the height in pixels of the video player.
        /// </summary>
        int Height { get; }
    }
}
