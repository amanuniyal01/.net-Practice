namespace demoAPI.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }

        public Gender StudentGender { get; set; }=Gender.Male;
        public bool isActive { get; set; } = false;
    }

    public enum Gender
    {
        Male,Female,Others
    }
}
