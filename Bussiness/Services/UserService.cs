using Bussiness.Dtos;
using Bussiness.Factories;
using Bussiness.Models;

namespace Bussiness.Services;

public class UserService
{
    private List<UserModel> _users = [];
    private readonly FileService _fileService = new();

    public void Add(UserRegistrationForm form)
    {
        // Create a new user from the form and add it to the list of users.
        var user = UserFactory.Create(form);
        _users.Add(user);
        _fileService.SaveListToFile(_users);
    }

    public IEnumerable<UserModel> GetAll()
    {
        // Load the list of users from the file and return it.
        _users = _fileService.LoadListFromFile();
        return _users;
    }

    public void RemoveAll()
    {
        // Clear the list of users and save it to the file.
        _users = [];
        _fileService.SaveListToFile(_users);
    }
}
