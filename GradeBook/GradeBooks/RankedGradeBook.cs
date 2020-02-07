using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook (string name) : base (name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            // Top 20% gets A, next 20% gets B... and so on
            // Figure out how many students it takes to drop a letter grade
            List<double> averageGrades = new List<double>();
            foreach (var student in Students)
            {
                averageGrades.Add(student.AverageGrade);
            }

            // throw exception if less than 5 students.
            if (averageGrades.Count < 5)
            {
                throw new InvalidOperationException();
            }
            else
            {
                averageGrades.Sort();
                bool gradeIsHigher = true;
                int i = 0;
                while (gradeIsHigher)
                {
                    if (averageGrade > averageGrades[i])
                    {
                        i++;
                    }
                    else
                    {
                        gradeIsHigher = false;
                    }
                }
                double percentage = i / averageGrades.Count;
                if (percentage > 0.8)
                {
                    return 'A';
                }
                else if (percentage > 0.6)
                {
                    return 'B';
                }
                else if (percentage > 0.4)
                {
                    return 'C';
                }
                else if (percentage > 0.2)
                {
                    return 'D';
                }
            }          
            return 'F';
        }
    }
}
