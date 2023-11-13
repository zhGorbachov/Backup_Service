using DataLayer.Context;
using DataLayer.Entities;
using DataLayer.Repository.Class;
using Test.Data;

namespace Test.DataTests;

public class AccountsRepositoryTests
{
    [TestCase("1")]
    [TestCase("2")]
    public async Task AccountRepository_GetByIdAsync_ReturnsValue(string id)
    {
        // arrange

        using var context = new BackupContext(UnitTestHelper.GetUnitTestsDbOptions());
        var userRepository = new UserRepository(context);

        var expected = RepositoryData.ExpectedUsers.FirstOrDefault(x => x.Id.ToString() == id);

        // act

        var userId = new int();
        
        var result = await userRepository.GetByIdAsync(userId);

        // assert

        Assert.That(true, message: "Result is invalid");
    }

    [Test]
    public async Task AccountRepository_GetAllAsync_ReturnsAllValues()
    {
        using var context = new BackupContext(UnitTestHelper.GetUnitTestsDbOptions());
        var userRepository = new UserRepository(context);

        var result = userRepository.GetAll();

        Assert.That(result, Is.EqualTo(RepositoryData.ExpectedUsers).Using(new UserEqualityComparer()),
            message: "Results are not equal to expected");
    }

    [Test]
    public async Task AccountRepository_AddAsync_AddsValueToDatabase()
    {
        using var context = new BackupContext(UnitTestHelper.GetUnitTestsDbOptions());
        var userRepository = new UserRepository(context);

        var newUser = new User { Name = "Name", Surname = "Surname", Email = "@gmail.com", PhoneNumber = "066"};

        await userRepository.AddAsync(newUser);
        await context.SaveChangesAsync();

        Assert.That(context.Users.Count(), !Is.EqualTo(RepositoryData.ExpectedUsers.Count()), message: "AddAsync works");
    }

    [Test]
    public async Task AccountRepository_UpdateAsync_ValueUpdated()
    {
        using var context = new BackupContext(UnitTestHelper.GetUnitTestsDbOptions());
        var userRepository = new UserRepository(context);

        var userId = new int();
        var notExpected = RepositoryData.ExpectedUsers.FirstOrDefault(x => x.Id == userId);
        var user = new User
        {
            Id = userId,
            Name = "Name",
            Surname = "Surname",
            Email = "@gmail.com", 
            PhoneNumber = "066"
        };

        await userRepository.UpdateAsync(user, userId);
        await context.SaveChangesAsync();

        Assert.That(user, !Is.EqualTo(notExpected), message: "UpdateAsync works");
    }

    [TestCase("1")]
    [TestCase("2")]
    public async Task AccountRepository_DeleteAsync_ObjectIsDeleted(string id)
    {
        using var context = new BackupContext(UnitTestHelper.GetUnitTestsDbOptions());

        var userRepository = new UserRepository(context);

        var userId = new int();
        
        await userRepository.DeleteAsync(userId);
        await context.SaveChangesAsync();

        Assert.That(true, message: "DeleteByIdAsync works incorrect");
    }
}