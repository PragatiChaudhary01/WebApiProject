using StoreList.Models;
using Microsoft.Extensions.Options;
using Microsoft.Data.SqlClient;
using Dapper;

namespace StoreList.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly string _connectionString;
        public StoreRepository(IOptions<ConnectionString> connectionStrings)
        {
            _connectionString = connectionStrings.Value.STOREDB_DEV;
        }
        public int Create(Store store)
        {
            var query = @"Execute usp_CreateStore @Name, @City, @State, @Phone";
            using var connection = new SqlConnection(_connectionString);
            return (connection.QueryFirstOrDefault<Store>(query, new
            {
                Name = store.Name,
                City = store.City,
                State = store.State,
                Phone = store.Phone
            })).Id;
        }

        public void Delete(int id)
        {
            var query = @"DELETE FROM [dbo].[Stores]
                          WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            connection.Execute(query, new
            {
                Id = id
            });
        }

        public Store Get(int id)
        {
            var query = @"SELECT * FROM [dbo].[Stores]
                          WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Store>(query, new
            {
                Id = id
            });
        }

        public List<Store> GetAll()
        {
            var query = @"SELECT * FROM [dbo].[Stores]";
            using var connection = new SqlConnection(_connectionString);
            return (connection.Query<Store>(query)).ToList();
        }

        public void Update(Store store)
        {
            var query = @"UPDATE [dbo].[Stores]
                          SET [Name] = @Name
                              ,[City] = @City
                              ,[State] = @State
                              ,[Phone] = @Phone
                          WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            connection.Execute(query, new
            {
                Id = store.Id,
                Name = store.Name,
                City = store.City,
                State = store.State,
                Phone = store.Phone
            });
        }
    }
}
