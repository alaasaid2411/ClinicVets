using Microsoft.Data.Sqlite;

namespace ClinicVets.Data;

/// <summary>
/// Creates the SQLite schema and required seed data for ClinicVets.
/// </summary>
public class ClinicDatabaseInitializer(string connectionString)
{
    /// <summary>
    /// Creates required tables and seeds fixed lookup data.
    /// </summary>
    public void Initialize()
    {
        using SqliteConnection connection = new(connectionString);
        connection.Open();

        EnableForeignKeys(connection);
        CreateRolesTable(connection);
        CreateEmployeesTable(connection);
        SeedRoles(connection);
    }

    private static void EnableForeignKeys(SqliteConnection connection)
    {
        using SqliteCommand command = connection.CreateCommand();
        command.CommandText = "PRAGMA foreign_keys = ON;";
        command.ExecuteNonQuery();
    }

    private static void CreateRolesTable(SqliteConnection connection)
    {
        using SqliteCommand command = connection.CreateCommand();
        command.CommandText =
            """
            CREATE TABLE IF NOT EXISTS Roles (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL UNIQUE
            );
            """;
        command.ExecuteNonQuery();
    }

    private static void CreateEmployeesTable(SqliteConnection connection)
    {
        using SqliteCommand command = connection.CreateCommand();
        command.CommandText =
            """
            CREATE TABLE IF NOT EXISTS Employees (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Username TEXT NOT NULL UNIQUE,
                PasswordHash TEXT NOT NULL,
                EmployeeNumber TEXT NOT NULL UNIQUE,
                Email TEXT NOT NULL UNIQUE,
                IdentityNumber TEXT NOT NULL UNIQUE,
                RoleId INTEGER NOT NULL,
                FOREIGN KEY (RoleId) REFERENCES Roles(Id)
            );
            """;
        command.ExecuteNonQuery();
    }

    private static void SeedRoles(SqliteConnection connection)
    {
        InsertRoleIfMissing(connection, "Veterinarian");
        InsertRoleIfMissing(connection, "Secretary");
    }

    private static void InsertRoleIfMissing(SqliteConnection connection, string roleName)
    {
        using SqliteCommand command = connection.CreateCommand();
        command.CommandText =
            """
            INSERT OR IGNORE INTO Roles (Name)
            VALUES ($name);
            """;
        command.Parameters.AddWithValue("$name", roleName);
        command.ExecuteNonQuery();
    }
}
