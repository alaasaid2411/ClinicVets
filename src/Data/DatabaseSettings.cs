namespace ClinicVets.Data;

/// <summary>
/// Contains database configuration used by the data layer.
/// </summary>
public static class DatabaseSettings
{
    public const string DatabaseFileName = "clinicvets.db";

    /// <summary>
    /// Builds the SQLite connection string for the local application database.
    /// </summary>
    public static string ConnectionString
    {
        get
        {
            string databasePath = Path.Combine(AppContext.BaseDirectory, DatabaseFileName);
            return $"Data Source={databasePath}";
        }
    }
}
