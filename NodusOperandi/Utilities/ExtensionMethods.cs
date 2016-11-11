using System;
using Mono.Data.Sqlite;

namespace NodusOperandi.Utilities
{
    
    public static class ExtensionMethods
    {

        public static string GetStringSafe (this SqliteDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull (colIndex)) {
                return reader.GetString (colIndex);
            } else {
                return null;
            }
        }

        public static string GetStringSafe (this SqliteDataReader reader, string colName)
        {
            var idx = reader.GetOrdinal (colName);
            return GetStringSafe (reader, idx);
        }

    }

}
