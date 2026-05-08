using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubElections
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public int GradeLevel { get; set; }
        public string ChoiceColor { get; set; }
    }

    public class ElectionRecord
    {
        public int SubmitterId { get; set; }
        public int PickedCandidateId { get; set; }
    }

    
