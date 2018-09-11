namespace UniversityBoard.DAL.Common.Models
{
    using System.Collections.Generic;

    public class Group
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public int HeadId { get; set; }

        public IEnumerable<Student> Students { get; set; }
    }
}