using Azure.Data.Tables;
using AzureTables.Connector;
using AzureTables.Connector.Enuns;
using StockMarketSimulator.Sinks.Kernel.Models;

namespace StockMarketSimulator.Sinks.Kernel.Infrastructure.Repository
{
    public class StockRepository : AzureTablesRepositoryBase, IStockRepository
    {
        public StockRepository(Dictionary<string, TableServiceClient> tableServiceClients) : base(tableServiceClients, ClientNames.Sinks, "Stocks")
        {
        }

        public async Task UpsertStock(AzureTableStockModel azureTableStockModel)
        {
            await AddEditEntity(azureTableStockModel);
        }

        //public async Task<string> GetUserProfileByEmail(string email, CancellationToken cancellationToken)
        //{
        //    //return await GetByExpression<string>(ent => ent.EmailAddress.Equals(email), cancellationToken);
        //    return string.Empty;
        //}
    }
}


//ToDo: Mix both clients can result in a better approach for that service

////AZURE TABLE SAMPLES:
////https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/tables/Azure.Data.Tables/tests/samples

//public class AzureTablesConnector : IAzureTablesConnector
//{
//    private readonly TableServiceClient _tableServiceClient;

//    public AzureTablesConnector(TableServiceClient tableServiceClient)
//    {
//        _tableServiceClient = tableServiceClient;
//    }

//    #region Table Management

//    public async Task<Response<TableItem>> CreateTable(string tableName = "")
//    {
//        var _tableClient = _tableServiceClient.GetTableClient(tableName);
//        return await _tableClient.CreateAsync();
//    }

//    public async Task<Response<TableItem>> CreateIfNotExistsTable(string tableName = "")
//    {
//        var _tableClient = _tableServiceClient.GetTableClient(tableName);
//        return await _tableClient.CreateIfNotExistsAsync();
//    }

//    public async Task<Response> DeleteTable(string tableName = "")
//    {
//        var _tableClient = _tableServiceClient.GetTableClient(tableName);
//        return await _tableClient.DeleteAsync();
//    }

//    #endregion

//    #region Entity Management

//    public async Task<Response> AddEntity<T>(T entity, string tableName = "") where T : class, ITableEntity
//    {
//        var _tableClient = _tableServiceClient.GetTableClient<T>(tableName);
//        return await _tableClient.AddEntityAsync(entity);
//    }

//    public async Task<Response> DeleteEntity(string partitionKey, string rowKey, string tableName = "")
//    {
//        var _tableClient = _tableServiceClient.GetTableClient(tableName);
//        return await _tableClient.DeleteEntityAsync(partitionKey, rowKey);
//    }

//    public async Task<Response<T>> GetEntity<T>(string partitionKey, string rowKey, string tableName = "") where T : class, ITableEntity
//    {
//        var _tableClient = _tableServiceClient.GetTableClient<T>(tableName);
//        return await _tableClient.GetEntityAsync<T>(partitionKey, rowKey);
//    }

//    public async Task<ICollection<T>> GetEntities<T>(string tableName = "") where T : class, ITableEntity
//    {
//        var _tableClient = _tableServiceClient.GetTableClient<T>(tableName);
//        AsyncPageable<T> queryResults = _tableClient.QueryAsync<T>();

//        var results = new List<T>();
//        await foreach (T qEntity in queryResults)
//        {
//            results.Add(qEntity);
//        }
//        return results;
//    }

//    public async Task<NullableResponse<T>> GetEntityIfExists<T>(string partitionKey, string rowKey, string tableName = "") where T : class, ITableEntity
//    {
//        var _tableClient = _tableServiceClient.GetTableClient<T>(tableName);
//        return await _tableClient.GetEntityIfExistsAsync<T>(partitionKey, rowKey);
//    }

//    public async Task<ICollection<T>> Query<T>(string query, string tableName = "") where T : class, ITableEntity
//    {
//        var _tableClient = _tableServiceClient.GetTableClient<T>(tableName);
//        AsyncPageable<T> queryResults = _tableClient.QueryAsync<T>(query);

//        var results = new List<T>();
//        await foreach (T qEntity in queryResults)
//        {
//            results.Add(qEntity);
//        }
//        return results;
//    }

//    public async Task<ICollection<T>> Query<T>(Expression<Func<T, bool>> expression, string tableName = "") where T : class, ITableEntity
//    {
//        var _tableClient = _tableServiceClient.GetTableClient<T>(tableName);
//        AsyncPageable<T> queryResults = _tableClient.QueryAsync(expression);

//        var results = new List<T>();
//        await foreach (T qEntity in queryResults)
//        {
//            results.Add(qEntity);
//        }
//        return results;
//    }

//    public async Task<Response> UpdateEntity<T>(T entity, string tableName = "") where T : class, ITableEntity
//    {
//        var _tableClient = _tableServiceClient.GetTableClient<T>(tableName);
//        return await _tableClient.UpdateEntityAsync(entity, entity.ETag);
//    }

//    public async Task<Response> UpsertEntity<T>(T entity, TableUpdateMode updateMode, string tableName = "") where T : class, ITableEntity
//    {
//        var _tableClient = _tableServiceClient.GetTableClient<T>(tableName);
//        return await _tableClient.UpsertEntityAsync(entity, updateMode);
//    }

//    #endregion
//}