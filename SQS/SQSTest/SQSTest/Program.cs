
using Amazon.SQS;
using Amazon.SQS.Model;
using SQSResponse;
using System.Text.Json;

var client = new AmazonSQSClient();

var studentDetails = new StudentCreation
{
    Id = Guid.NewGuid(),
    FullName = "John Cena",
    DOB = new DateTime(2000, 02, 13),
    Email = "johncena@gmail.com",
    GitHubUserName = "johncena"
};

var queueURLResponse = await client.GetQueueUrlAsync("Customer-London");

var sendMsgReq = new SendMessageRequest
{
    QueueUrl = queueURLResponse.QueueUrl,
    MessageBody = JsonSerializer.Serialize(studentDetails)
};

var sentMsgResponse = await client.SendMessageAsync(sendMsgReq);

Console.WriteLine(sentMsgResponse);
