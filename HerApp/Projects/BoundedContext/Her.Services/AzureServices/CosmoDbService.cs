using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Her.Services.AzureServices
{
	public class CosmoDbService : ICosmoDbService
	{
		private readonly string EndpointUri;
		private readonly string PrimaryKey;
		private DocumentClient client;
		public CosmoDbService(IConfiguration config)
		{
			PrimaryKey = config.GetSection("CosmoDBSettings")["Key"];
			EndpointUri = config.GetSection("CosmoDBSettings")["Endpoint"];

		}
		//public async Task AddJsonAsync(List<WrocItemsViewModel> wrocItems, string Database, string Document)
		//{
		//	client = new DocumentClient(new Uri(EndpointUri), PrimaryKey);
		//	await client.CreateDatabaseIfNotExistsAsync(new Database { Id = Database });
		//	await client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(Database), new DocumentCollection { Id = Document });
		//	foreach (var item in wrocItems)
		//	{
		//		await client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(Database, Document), item);
		//	}
		//}
		public async Task RemoveDocument(string Database, string Document)
		{
			client = new DocumentClient(new Uri(EndpointUri), PrimaryKey);
			await client.CreateDatabaseIfNotExistsAsync(new Database { Id = Database });
			await client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(Database), new DocumentCollection { Id = Document });
			await client.DeleteDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(Database, Document));
		}
	}
}
