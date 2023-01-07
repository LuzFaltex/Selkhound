using System.Collections.Generic;
using Remora.Rest.Core;

namespace Selkhound.API.Abstractions.Objects
{
    /// <summary>
    /// Represents a Selkhound Club.
    /// </summary>
    // TODO: Finalize shape.
    public interface IClub
    {
        /// <summary>
        /// Gets the unique id of the club.
        /// </summary>
        Snowflake Id { get; }

        /// <summary>
        /// Gets the name of the club.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the club's icon.
        /// </summary>
        IImageHash? Icon { get; }

        /// <summary>
        /// Gets the club's splash banner.
        /// </summary>
        IImageHash? Splash { get; }

        /// <summary>
        /// Gets the id of the club's owner.
        /// </summary>
        Snowflake OwnerId { get; }

        /// <summary>
        /// Gets the verification level required for this club.
        /// </summary>
        VerificationLevel VerificationLevel { get; }

        /// <summary>
        /// Gets the default notification level for the club.
        /// </summary>
        MessageNotificationLevel DefaultMessageNotifications { get; }

        /// <summary>
        /// Gets the explicit content filter level.
        /// </summary>
        ExplicitContentFilterLevel ExplicitContentFilter { get; }

        /// <summary>
        /// Gets a list of roles in the club.
        /// </summary>
        // TODO: Replace with IRole.
        IReadOnlyList<Snowflake> Roles { get; }
    }
}
