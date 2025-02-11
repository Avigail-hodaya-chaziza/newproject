using FinalGradesProject.Configuration;
using FinalGradesProject.Exceptions;
using Microsoft.Extensions.Options;

namespace FinalGradesProject.Services
{
    public class PasswordManager:IPasswordManager
    {
        DataSource studentsList = new DataSource();
        IConfiguration configuration;
        private Password valuePassword;
        public PasswordManager(IOptions<Password> password)
        {
            valuePassword = password.Value;
        }
        public bool IntegrityCheck(string name, string password) {
            if (valuePassword.password==password)
            {
                if (valuePassword.name==name)
                    return true;
            }
            if (!studentsList.Students.Any(stu => stu.Name == name))
                throw new StudentNotExsistException(name);
            if (!studentsList.Students.Any(stu => stu.Password == password))
                throw new StudentNotExsistException(password);
            return true;
        }


    }
}
