//
//  IChannel.cs
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

using System.Collections.Generic;
using JetBrains.Annotations;
using OneOf;
using Remora.Rest.Core;

namespace Selkhound.API.Abstractions.Objects
{
    /// <summary>
    /// Represents a channel.
    /// </summary>
    [PublicAPI]
    public interface IChannel
    {
        /// <summary>
        /// Gets the unique id of this channel.
        /// </summary>
        Snowflake Id { get; }

        /// <summary>
        /// Gets the type of channel.
        /// </summary>
        ChannelType ChannelType { get; }

        /// <summary>
        /// Gets the id of the last message sent in the channel.
        /// </summary>
        Snowflake? LastMessageId { get; }

        /// <summary>
        /// Gets the icon of the channel.
        /// </summary>
        OneOf<IImageHash, IEmoji> Icon { get; }

        /// <summary>
        /// Gets the unique id of the user, bot, or club that owns this channel.
        /// </summary>
        Snowflake OwnerId { get; }

        /// <summary>
        /// Gets a list of the messages which have been pinned to the channel.
        /// </summary>
        IReadOnlyList<IPinnedMessage> PinnedMessages { get; }
    }
}
