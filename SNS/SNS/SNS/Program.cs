
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using SNS;
using System.Text.Json;

var newStudent = new StudentCreated
{
    Id = Guid.NewGuid(),
    FullName = "John Cena 2",
    GitHubUserName = "johncena2",
    Email = "johncena2@gmail.com",
    DOB = new DateTime(2000, 03, 23)
};

var snsClient = new AmazonSimpleNotificationServiceClient();
var snsTopicResponse = await snsClient.FindTopicAsync("Customers-London");

var publishRequest = new PublishRequest
{
    TopicArn = snsTopicResponse.TopicArn,
    Message = JsonSerializer.Serialize(newStudent),
    MessageAttributes = new Dictionary<string, MessageAttributeValue>
    {
        {
            "MessageType", new MessageAttributeValue
            {
                DataType = "String",
                StringValue = nameof(StudentCreated)
            }
        }
    }
};

var response = await snsClient.PublishAsync(publishRequest);

Console.WriteLine(response);