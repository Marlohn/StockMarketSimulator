using Azure.Storage.Queues;
using System.Text.Json;

namespace AzureQueues.Connector
{
    public abstract class AzureQueueRepositoryBase<T>
    {
        private readonly QueueClient _queueClient;

        protected AzureQueueRepositoryBase(string connectionString, string queueName)
        {
            _queueClient = new QueueClient(connectionString, queueName, new QueueClientOptions
            {
                MessageEncoding = QueueMessageEncoding.Base64
            });

            _queueClient.CreateIfNotExists();
        }

        public async Task Send(T message)
        {
            var data = GetData(message);

            // Send a message to the queue
            await _queueClient.SendMessageAsync(new BinaryData(data));

            //var response = await _queueClient.SendMessageAsync(new BinaryData(data));
            //var b = response.Value.MessageId;
        }

        public async Task Send(T message, TimeSpan delay)
        {
            var data = GetData(message);

            // Send a message to the queue with a delay
            await _queueClient.SendMessageAsync(new BinaryData(data), delay);
        }

        private static string GetData(T message)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var json = JsonSerializer.Serialize(message, options);
            return json;
        }
    }
}
