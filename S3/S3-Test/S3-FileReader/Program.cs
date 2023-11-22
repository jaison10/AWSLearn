
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.Util;
using System.Text;

var s3Client = new AmazonS3Client();

var getObjectReq = new GetObjectRequest
{
    BucketName = "jaison-test-bucket",
    Key = "images/test.jpg"
};

var respose = await s3Client.GetObjectAsync(getObjectReq);

using var memoryStream = new MemoryStream();
respose.ResponseStream.CopyTo(memoryStream);

var text = Encoding.Default.GetString(memoryStream.ToArray());

Console.WriteLine(text);