

using Amazon.SQS;

var client = new AmazonSQSClient();
var cts =  new CancellationTokenSource();

var queueURLResponse = await client.GetQueueUrlAsync("Customer-London");


while (!cts.IsCancellationRequested)
{
    var messageReceived = await client.ReceiveMessageAsync(queueURLResponse.QueueUrl, cts.Token);
    foreach (var message in messageReceived.Messages)
    {
        Console.WriteLine($"Message Body : {message.Body}");
        await client.DeleteMessageAsync(queueURLResponse.QueueUrl, message.ReceiptHandle);
    }
    await Task.Delay(1000);
}