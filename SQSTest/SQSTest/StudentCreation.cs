
namespace SQSResponse
{
    public class StudentCreation
    {
        public required Guid Id { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string GitHubUserName { get; set; }
        public required DateTime DOB { get; set; }
    }
}
