using Mono.Data.Sqlite;
using System;
using NodusOperandi.Data.Repository;

namespace NodusOperandi.Data
{
    public class SqliteContext : IDisposable
    {
        
        public static SqliteContext instance;
        public static SqliteContext GetInstance ()
        {

            if (instance == null) {
                instance = new SqliteContext ();
            }

            return instance;

        }

        private SqliteConnection conn;

        public DeviceRepository Device;

        public SqliteContext () : base () {

            conn = new SqliteConnection ("Data Source=data.db;version=3;");
            conn.Open ();

            Device = new DeviceRepository (this);

        }

        public void ExecuteQuery (string sql)
        {
            var cmd = conn.CreateCommand ();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery ();
        }

        public SqliteCommand Prepare (string sql)
        {
            var cmd = conn.CreateCommand ();
            cmd.CommandText = sql;
            return cmd;
        }

        public SqliteDataReader ExecuteReader (string sql)
        {
            var cmd = conn.CreateCommand ();
            cmd.CommandText = sql;
            return cmd.ExecuteReader ();
        }

        public SqliteDataReader ExecuteReader (SqliteCommand cmd)
        {
            return cmd.ExecuteReader ();
        }

        public void Dispose ()
        {

            conn.Close ();

        }

    }

}
