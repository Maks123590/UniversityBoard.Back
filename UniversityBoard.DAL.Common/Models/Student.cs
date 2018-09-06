namespace UniversityBoard.DAL.Common.Models
{
    using System;

    using UniversityBoard.DAL.Common.Enums;

    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LustName { get; set; }

        public string MiddleName { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDay { get; set; }

        public int StudentCardNumber { get; set; }

        public int GroupId { get; set; }
    }
}