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

        public AzureTablesRepositoryBase(Dictionary<string, TableServiceClient> tableServiceClients, ClientNames serviceClientName, string tableName)
        {
            var serviceClient = tableServiceClients[serviceClientName.GetDescription()];
            _tableClient = serviceClient.GetTableClient(tableName);
        }

        protected async Task AddEditEntity<T>(T entity, CancellationToken cancellationToken = default) where T : ITableEntity
        {
            //Todo:  The table specified does not exist.
            await _tableClient.UpsertEntityAsync(entity, cancellationToken: cancellationToken);
        }

        protected async Task<T?> GetByExpression<T>(Expression<Func<T, bool>> expression, CancellationToken cancellationToken) where T : class, ITableEntity, new()
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