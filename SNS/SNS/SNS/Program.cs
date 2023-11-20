
using SNS;

var newStudent = new StudentModel
{
    Id = Guid.NewGuid(),
    FullName = "John Cena 2",
    GitHubUserName = "johncena2",
    Email = "johncena2@gmail.com",
    DOB = new DateTime(2000, 03, 23)
};