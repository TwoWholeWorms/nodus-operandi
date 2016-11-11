/**
 * Based on Nancy.Demo.Samples.Data.MongoDbDemoRepository by Andreas Håkansson
 */

namespace NodusOperandi.Data.MongoDb
{
    using System.Collections.Generic;
    using Models;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;

    /// <summary>
    /// MongoDB based implementation of the <see cref="IStatisticsRepository"/> interface.
    /// </summary>
    public class MongoDbStatisticsRepository : IStatisticsRepository
    {

        private readonly MongoCollection<StatisticsModel> collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbStatisticsRepository"/> class, with
        /// the provided <see cref="MongoDatabase"/>.
        /// </summary>
        /// <param name="database">The <see cref="MongoDatabase"/> instance that should be used by the repository.</param>
        public MongoDbStatisticsRepository(MongoDatabase database)
        {
            collection = database.GetCollection<StatisticsModel>(Configuration.DatabaseName);
        }

        /// <summary>
        /// Deletes all statisticss.
        /// </summary>
        public void DeleteAll()
        {
            collection.Drop();
        }

        /// <summary>
        /// Deletes a statistics by its id
        /// </summary>
        /// <param name="id">The id of the statistics to delete from the database.</param>
        public void DeleteById(string id)
        {
            collection.Remove(Query<StatisticsModel>.Where(statistics => statistics.Id == id));
        }

        /// <summary>
        /// Gets all the statisticss in the data store.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/>, of <see cref="StatisticsModel"/> instances.</returns>
        public IEnumerable<StatisticsModel> GetAll()
        {
            return collection.FindAll();
        }

        /// <summary>
        /// Persists a new statistics in the data store.
        /// </summary>
        /// <param name="statistics">The <see cref="StatisticsModel"/> instance to persist</param>
        public void Persist(AbstractNodusOperandiModel statistics)
        {
            collection.Insert(statistics);
        }

    }

}
