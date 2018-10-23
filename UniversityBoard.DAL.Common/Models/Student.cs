namespace UniversityBoard.DAL.Common.Models
{
    using System;

    using System.ComponentModel.DataAnnotations;

    using MongoDB.Bson.Serialization.Attributes;

    using UniversityBoard.DAL.Common.Enums;

    public class Student
    {
        [Key]
        [BsonId]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDay { get; set; }

        public int StudentCardNumber { get; set; }

        public DateTime StudentCardIssueDate { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }
    }
}