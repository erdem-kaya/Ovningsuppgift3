using Bussiness.Dtos;
using Bussiness.Helpers;
using Bussiness.Models;

namespace Bussiness.Factories
{
    public static class UserFactory
    {
        public static UserRegistrationForm Create()
        {
            return new UserRegistrationForm();
        }

        public static UserModel Create(UserRegistrationForm form)
        {
            return new UserModel
            {
                Id = UniqIdGenerator.Generate(),
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email,
                Password = SecurePasswordGenerator.Generate(form.Password),
                CreatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
        }

    }
}
