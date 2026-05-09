using System;
using System.Collections.Generic;

namespace ClubElections
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public int GradeLevel { get; set; }
        public string Color { get; set; }
    }

    public class ElectionRecord
    {
        public int SubmitterId { get; set; }
        public int PickedCandidateId { get; set; }
    }

    class Program
    {
        static List<Student> studentList = new List<Student>
        {
            new Student { StudentId = 1, FullName = "Beth", GradeLevel = 10, Color = "Blue" },
            new Student { StudentId = 2, FullName = "Charlie", GradeLevel = 11, Color = "Red" },
            new Student { StudentId = 3, FullName = "Dana", GradeLevel = 10, Color = "Green" },
            new Student { StudentId = 4, FullName = "Eli", GradeLevel = 9, Color = "Blue" },
            new Student { StudentId = 5, FullName = "Frank", GradeLevel = 12, Color = null },
            new Student { StudentId = 6, FullName = "Gia", GradeLevel = 10, Color = "Yellow" }
        };

        static List<ElectionRecord> recordList = new List<ElectionRecord>
        {
            new ElectionRecord { SubmitterId = 1, PickedCandidateId = 3 },
            new ElectionRecord { SubmitterId = 2, PickedCandidateId = 1 },
            new ElectionRecord { SubmitterId = 3, PickedCandidateId = 1 },
            new ElectionRecord { SubmitterId = 4, PickedCandidateId = 4 },
            new ElectionRecord { SubmitterId = 6, PickedCandidateId = 1 }
        };

        static string getName(int id)
        {
            foreach (Student individual in studentList)
            {
                if (individual.StudentId == id)
                {
                    return individual.FullName;
                }
            }
            return "Unknown";
        }
