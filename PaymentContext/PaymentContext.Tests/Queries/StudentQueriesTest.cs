using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Queries;

[TestClass]
public class StudentQueriesTest
{
    private IList<Student> _students;

    public StudentQueriesTest()
    {
        _students = new List<Student>();
        for (var i = 0; i < 10; i++)
        {
            _students.Add(new Student(
                new Name($"Student {i}", $"LastName {i}"),
                new Document($"1233211233{i}", EDocumentType.CPF),
                new Email($"student{i}@email.com")
            ));
        }
    }

    [TestMethod]
    public void ShouldReturnNullWhenDocumentNotExists()
    {
        var exp = StudentQueries.GetStudentInfo("123321123X");
        var student = _students.AsQueryable().Where(exp).FirstOrDefault();

        Assert.AreEqual(null, student);
    }

    [TestMethod]
    public void ShouldReturnStudentWhenDocumentExists()
    {
        var exp = StudentQueries.GetStudentInfo("12332112330");
        var student = _students.AsQueryable().Where(exp).FirstOrDefault();

        Assert.AreNotEqual(null, student);
    }
}
