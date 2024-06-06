using Microsoft.Data.Sqlite;

namespace Ejercicio01.Datos
{
    public static class DatabaseVerifier
    {
        public static void VerifyDatabase(string databasePath)
        {
            if (!File.Exists(databasePath))
            {
                throw new FileNotFoundException($"Database file not found: {databasePath}");
            }

            using (var connection = new SqliteConnection($"Data Source={databasePath}"))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        SELECT name 
                        FROM sqlite_master 
                        WHERE type='table' AND name IN ('Equipos', 'Jugadores');";

                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            throw new Exception("Required tables not found in the database.");
                        }
                    }
                }
            }
        }
    }
}
