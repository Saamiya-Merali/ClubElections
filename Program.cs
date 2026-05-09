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

        static string getColor(int id)
        {
            foreach (Student individual in studentList)
            {
                if (individual.StudentId == id)
                {
                    if (individual.Color == null)
                    {
                        return "None";
                    }
                    else
                    {
                        return individual.Color;
                    }
                }
            }
            return "None";
        }

        static int getChoice(int id)
        {
            foreach (ElectionRecord record in recordList)
            {
                if (record.SubmitterId == id)
                {
                    return record.PickedCandidateId;
                }
            }
            return 0;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("1. Who is member 5: " + getName(5));
            Console.WriteLine("2. What is their color: " + getColor(5));

            Console.Write("3. Who likes Blue: ");
            foreach (Student individual in studentList)
            {
                if (individual.Color == "Blue")
                {
                    Console.Write(individual.FullName + " ");
                }
            }
            Console.WriteLine();

            Console.Write("4. Who has no color: ");
            foreach (Student individual in studentList)
            {
                if (individual.Color == null)
                {
                    Console.Write(individual.FullName + " ");
                }
            }
            Console.WriteLine();

            Console.WriteLine("5. How many members: " + studentList.Count);

            int gradeTenCount = 0;
            foreach (Student individual in studentList)
            {
                if (individual.GradeLevel == 10)
                {
                    gradeTenCount = gradeTenCount + 1;
                }
            }
            Console.WriteLine("6. How many in 10th grade: " + gradeTenCount);

            int giaVoteId = getChoice(6);
            Console.WriteLine("8. Who did member 6 vote for: " + getName(giaVoteId));

            int bethIdNumber = 0;
            foreach (Student individual in studentList)
            {
                if (individual.FullName == "Beth")
                {
                    bethIdNumber = individual.StudentId;
                }
            }

            int bethVoteId = getChoice(bethIdNumber);
            Console.WriteLine("9. Who did Beth vote for: " + getName(bethVoteId));

            Console.Write("10. Who voted for Beth: ");
            foreach (ElectionRecord record in recordList)
            {
                if (record.PickedCandidateId == bethIdNumber)
                {
                    Console.Write(getName(record.SubmitterId) + " ");
                }
            }
            Console.WriteLine();

            Console.Write("11. Who voted for themselves: ");
            foreach (ElectionRecord record in recordList)
            {
                if (record.SubmitterId == record.PickedCandidateId)
                {
                    Console.Write(getName(record.SubmitterId) + " ");
                }
            }
            Console.WriteLine();

            Console.Write("12. Who did not vote: ");
            foreach (Student individual in studentList)
            {
                bool hasVoted = false;
                foreach (ElectionRecord record in recordList)
                {
                    if (record.SubmitterId == individual.StudentId)
                    {
                        hasVoted = true;
                    }
                }
                if (hasVoted == false)
                {
                    Console.Write(individual.FullName + " ");
                }
            }
            Console.WriteLine();

            int highestVoteCount = 0;
            int winnerId = 0;
            foreach (Student candidate in studentList)
            {
                int currentCandidateVotes = 0;
                foreach (ElectionRecord record in recordList)
                {
                    if (record.PickedCandidateId == candidate.StudentId)
                    {
                        currentCandidateVotes = currentCandidateVotes + 1;
                    }
                }
                if (currentCandidateVotes > highestVoteCount)
                {
                    highestVoteCount = currentCandidateVotes;
                    winnerId = candidate.StudentId;
                }
            }
            Console.WriteLine("13. Who won: " + getName(winnerId) + " with " + highestVoteCount + " votes");

            Console.WriteLine();
            Console.WriteLine("--- Operations ---");

            Student isabel = new Student();
            isabel.StudentId = 9;
            isabel.FullName = "Isabel";
            isabel.GradeLevel = 8;
            isabel.Color = "Purple";
            studentList.Add(isabel);
            Console.WriteLine("14. Added Isabel");

            ElectionRecord isabelVote = new ElectionRecord();
            isabelVote.SubmitterId = 9;
            isabelVote.PickedCandidateId = bethIdNumber;
            recordList.Add(isabelVote);
            Console.WriteLine("15. Isabel voted for: " + getName(getChoice(9)));

            foreach (ElectionRecord record in recordList)
            {
                if (record.SubmitterId == 9)
                {
                    record.PickedCandidateId = 3;
                }
            }
            Console.WriteLine("16. Isabel changed vote to: " + getName(getChoice(9)));

            for (int i = recordList.Count - 1; i >= 0; i--)
            {
                if (recordList[i].SubmitterId == 9)
                {
                    recordList.RemoveAt(i);
                }
            }
            Console.WriteLine("17. Isabel's vote removed. Choice is now: " + getName(getChoice(9)));
        }
    }
}
