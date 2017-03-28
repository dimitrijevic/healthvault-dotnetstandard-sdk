// Copyright(c) Microsoft Corporation.
// This content is subject to the Microsoft Reference Source License,
// see http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.

using Microsoft.HealthVault.Thing;

namespace Microsoft.HealthVault.ItemTypes
{
    /// <summary>
    /// Determines how BLOB information will be returned when fetching a
    /// <see cref="ThingBase"/>.
    /// </summary>
    ///
    public enum BlobFormat
    {
        /// <summary>
        /// The requested BLOB format is unknown.
        /// </summary>
        Unknown,

        /// <summary>
        /// Only BLOB information is returned.
        /// </summary>
        ///
        Information,

        /// <summary>
        /// The BLOB information and data is returned inline with the response XML.
        /// </summary>
        ///
        Inline,

        /// <summary>
        /// Information about the BLOB sufficient to be able to retrieve the BLOB through the
        /// streaming interfaces.
        /// </summary>
        ///
        Streamed,

        /// <summary>
        /// The default format is Streamed.
        /// </summary>
        Default = Streamed
    }
}
