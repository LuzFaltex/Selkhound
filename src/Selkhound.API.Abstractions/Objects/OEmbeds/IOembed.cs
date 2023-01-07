//
//  IOembed.cs
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

using System;
using JetBrains.Annotations;
using Remora.Rest.Core;

namespace Selkhound.API.Abstractions.Objects
{
    /// <summary>
    /// Represents an OEmbed object.
    /// </summary>
    [PublicAPI]
    public interface IOEmbed
    {
        /// <summary>
        /// Gets the resource type.
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Gets the OEmbed version number.
        /// </summary>
        Version Version { get; }

        /// <summary>
        /// Gets the title of the resource.
        /// </summary>
        Optional<string> Title { get; }

        /// <summary>
        /// Gets the name of the author or owner of the resource.
        /// </summary>
        Optional<string> AuthorName { get; }

        /// <summary>
        /// Gets the url of the author or owner of the resource.
        /// </summary>
        Optional<string> AuthorUrl { get; }

        /// <summary>
        /// Gets the name of the provider of the resource.
        /// </summary>
        Optional<string> ProviderName { get; }

        /// <summary>
        /// Gets the url of the provider of the resource.
        /// </summary>
        Optional<string> ProviderUrl { get; }

        /// <summary>
        /// Gets the suggested cache lifetime for this resource, in seconds.
        /// </summary>
        Optional<int> CacheAge { get; }

        /// <summary>
        /// Gets the url to a thumbnail image representing the resource.
        /// </summary>
        Optional<string> ThumbnailUrl { get; }

        /// <summary>
        /// Gets the width of the thumbnail. Must be present if the <see cref="ThumbnailUrl"/> is present.
        /// </summary>
        Optional<int> ThumbnailWidth { get; }

        /// <summary>
        /// Gets the width of the thumbnail. Must be present if the <see cref="ThumbnailUrl"/> is present.
        /// </summary>
        Optional<int> ThumbnailHeight { get; }

        /// <summary>
        /// Gets the photo contained by this resource, if any.
        /// </summary>
        Optional<IPhoto> Photo { get; }

        /// <summary>
        /// Gets the video contained by this resource, if any.
        /// </summary>
        Optional<IVideo> Video { get; }
    }
}
