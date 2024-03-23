using Azure;
using Azure.Data.Tables;
using AzureTables.Connector.Enuns;
using StockMarketSimulator.Common.Extensions;
using System.Linq.Expressions;

namespace AzureTables.Connector
{
    public abstract class AzureTablesRepositoryBase
    {
        private readonly TableClient _tableClient;

        public AzureTablesRepositoryBase(Dictionary<ClientNames, TableServiceClient> tableServiceClients, ClientNames serviceClientName, string tableName)
        {
            var serviceClient = tableServiceClients[serviceClientName];
            _tableClient = serviceClient.GetTableClient(tableName);
        }
        //ToDo: use cancelationToken
        protected async Task AddEditEntity<T>(T entity, CancellationToken cancellationToken = default) where T : ITableEntity// BaseAzureTableModel?
        {
            //Todo:  The table specified does not exist.
            await _tableClient.UpsertEntityAsync(entity, cancellationToken: cancellationToken);
        }

        protected async Task AddEntity<T>(T entity, CancellationToken cancellationToken = default) where T : ITableEntity// BaseAzureTableModel?
        {
            //Todo:  The table specified does not exist.
            await _tableClient.AddEntityAsync(entity, cancellationToken: cancellationToken);
        }

        protected async Task<T?> GetByExpression<T>(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default) where T : class, ITableEntity, new()
        {
            var query = _tableClient.QueryAsync(expression, cancellationToken: cancellationToken);
            T? result = null;

            await foreach (Page<T> page in query.AsPages())
            {
                foreach (T qEntity in page.Values)
                {
                    result = qEntity;
                    break;
                }
            }

            return result;
        }

        protected async Task<Page<T>?> GetByFilter<T>(Expression<Func<T, bool>> expression, int maxPerPage, string continuationToken, CancellationToken cancellationToken) where T : class, ITableEntity, new()
        {
            var query = _tableClient.QueryAsync(expression, maxPerPage, cancellationToken: cancellationToken);

            await foreach (Page<T> page in query.AsPages(continuationToken))
            {
                return page;
            }

            return null;
        }

        protected async Task<Page<T>?> GetByFilter<T>(string filter, int maxPerPage, string continuationToken, CancellationToken cancellationToken) where T : class, ITableEntity, new()
        {
            var query = _tableClient.QueryAsync<T>(filter, maxPerPage, cancellationToken: cancellationToken);
            await foreach (Page<T> page in query.AsPages(continuationToken))
            {
                return page;
            }

            return null;
        }

        protected async Task DeleteEntity<T>(T entity, CancellationToken cancellationToken) where T : ITableEntity
        {
            await _tableClient.DeleteEntityAsync(entity.PartitionKey, entity.RowKey, cancellationToken: cancellationToken);
        }
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