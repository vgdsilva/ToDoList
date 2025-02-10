using SQLite;
using ToDoList.Domain.Entities;

namespace ToDoList.Data.Context;

public class SQLiteDatabase
{
    private readonly SQLiteAsyncConnection _database;

    public SQLiteDatabase()
    {
        _database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        _database.CreateTableAsync<ToDoItem>();

        
    }

    public async Task ExecuteAsync(string query, params object[] args) =>
        await _database.ExecuteAsync(query, args);

    public async Task<List<T>> QueryAsync<T>(string query, params object[] args) where T : new() =>
        await _database.QueryAsync<T>(query, args);

    public AsyncTableQuery<T> Table<T>() where T : new() =>
        _database.Table<T>();

    public async Task InserAsync<T>(T entity) where T : new() =>
        await _database.InsertAsync(entity, typeof(T));

    public async Task UpdateAsync<T> (T entity) where T : new() =>
        await _database.UpdateAsync(entity, typeof(T));

    public async Task DeleteAsync<T>(object id) =>
        await _database.DeleteAsync<T>(id);
}

public static class Constants
{
    public const string DatabaseFilename = "database.db";

    public const SQLite.SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache;

    public static string DatabasePath =>
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseFilename);
}
