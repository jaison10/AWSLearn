
using Amazon.S3;
using Amazon.S3.Model;

var s3Client = new AmazonS3Client();
using var inputStream = new FileStream("./test.jpg", FileMode.Open, FileAccess.Read);

var objectRequest = new PutObjectRequest
{
    BucketName = "jaison-test-bucket",
    Key = "images/test.jpg",
    ContentType = "image/jpeg",
    InputStream = inputStream
};

await s3Client.PutObjectAsync(objectRequest);