namespace UniversityBoard.BLL.Dtos.Student
{
    using System;

    using UniversityBoard.DAL.Common.Enums;

    public class StudentBaseDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDay { get; set; }

        public int StudentCardNumber { get; set; }

        public int GroupId { get; set; }
    }
}