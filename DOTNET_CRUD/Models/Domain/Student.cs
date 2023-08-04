namespace QuadTheoryTestProject.Models
{
    public class Student
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Gender { get; set; }

        public DateTime DOB { get; set; }

        public int ClassId { get; set; }

        public Class Class { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModificationDate { get; set; }


    }
}
