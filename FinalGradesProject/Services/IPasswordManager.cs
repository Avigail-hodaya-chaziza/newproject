namespace FinalGradesProject.Services
{
    public interface IPasswordManager
    {
        public bool IntegrityCheck(string name, string password);
    }
}
