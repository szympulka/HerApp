using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System.Threading.Tasks;
using Her.ViewModel.MailModels;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage.Auth;

namespace Her.Services.AzureServices
{
    public class QueueServcie: IQueueServcie
    {
	    private readonly CloudQueueClient queueClient;

	    private readonly string conn =
			"DefaultEndpointsProtocol=https;AccountName=herstorage;AccountKey=3hgVDRVErABFD79t5ZUTQD0dAPdqhjQ+QoB1kBJBekUoR38Ld/hTvpZ9QI7Yq4abAivKCFUJDrUJpMl+9B0vog==;EndpointSuffix=core.windows.net";

		public QueueServcie()
		{
			CloudStorageAccount storageAccount = CloudStorageAccount.Parse(conn);
			queueClient = storageAccount.CreateCloudQueueClient();
		}
		public void AddMailsToMailNotification()
		{
			CloudQueue queue = queueClient.GetQueueReference("notificationmailqueue");
			queue.CreateIfNotExistsAsync();

			var asd = new MailTaskReminderViewModel()
			{
				CategoryName = "sdfa",
				UserBot = "sadda"
			};
			var asdd = Newtonsoft.Json.JsonConvert.SerializeObject(asd);
			// Create a message and add it to the queue.
			CloudQueueMessage message = new CloudQueueMessage("Hello, World");
			message.SetMessageContent(asdd);
			queue.AddMessageAsync(message);
		}

	    public void AddRemindTaskToQueue(List<MailTaskReminderViewModel> daily)
	    {
		    CloudQueue queue = queueClient.GetQueueReference("notificationtaskqueue");
		    queue.CreateIfNotExistsAsync();

		    foreach (var model in daily)
		    {
				var asdd = Newtonsoft.Json.JsonConvert.SerializeObject(model);
			    CloudQueueMessage message = new CloudQueueMessage("TaskNotification");
			    message.SetMessageContent(asdd);
			    queue.AddMessageAsync(message);
			}
		} 
	}
}
