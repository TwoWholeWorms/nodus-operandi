/**
 * Based on Nancy.Demo.Samples.Models.DemoModel by Andreas Håkansson
 */

namespace NodusOperandi.Models
{

    using System;
    using System.Collections.Generic;
    using Data;

    /// <summary>
    /// Stores information about a NodusOperandi entity.
    /// </summary>
    abstract public class AbstractNodusOperandiModel
    {

        /// <summary>
        /// Gets or sets the ID of the entity.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the date that the entity was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets when the entity was last modified.
        /// </summary>
        public DateTime LastModifiedAt { get; set; }

        /// <summary>
        /// Gets or sets whether the entity is active in the system.
        /// </summary>
        public string IsActive { get; set; }

        /// <summary>
        /// Gets or sets whether the entity is deleted in the system. (We [almost] never hard-delete actual data, only soft-delete it.)
        /// </summary>
        public string IsDeleted { get; set; }
    
    }

}
