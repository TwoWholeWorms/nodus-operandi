/**
 * Based on Nancy.Demo.Samples.Data.IDemoRepository by Andreas Håkansson
 */

namespace NodusOperandi.Data
{

    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Defines the functionality for retrieving and storing <see cref="AbstractNodusOperandiModel"/> instances in
    /// an underlying data store.
    /// </summary>
    public interface INodusOperandiRepository
    {
    
        /// <summary>
        /// Deletes all demos.
        /// </summary>
        void DeleteAll();

        /// <summary>
        /// Deletes an entity by its id.
        /// </summary>
        /// <param name="id">The id of the entity to delete from the database.</param>
        void DeleteById(string id);

        /// <summary>
        /// Persists a new demo in the data store.
        /// </summary>
        /// <param name="model">The <see cref="AbstractNodusOperandiModel"/> instance to persist</param>
        void Persist(AbstractNodusOperandiModel model);

    }

}
