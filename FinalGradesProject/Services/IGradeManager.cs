namespace FinalGradesProject.Services
{
    public interface IGradeManager
    {
        public double FinalGrade(string id);
        public Dictionary<string, double> FinalAllGrade();
        public double GradeAverage(int exeNumber);
    }
}
