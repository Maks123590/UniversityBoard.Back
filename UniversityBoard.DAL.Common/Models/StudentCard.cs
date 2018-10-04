namespace UniversityBoard.DAL.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class StudentCard
    {
        [Key]
        public int Number { get; set; }

        public DateTime IssueDate { get; set; }
    }
}