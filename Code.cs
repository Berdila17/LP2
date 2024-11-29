using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeManagement
{
    public class Subject
    {
        public string Name { get; set; }
        public List<int> Grades { get; set; } = new List<int>();

        public double AverageGrade()
        {
            return Grades.Count > 0 ? Grades.Average() : 0.0;
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public string ClassName { get; set; }
        public List<Subject> Subjects { get; set; } = new List<Subject>();

        public void AddSubject(string subjectName)
        {
            if (Subjects.Any(s => s.Name == subjectName))
            {
                Console.WriteLine("This subject already exists for the student.");
            }
            else
            {
                Subjects.Add(new Subject { Name = subjectName });
                Console.WriteLine($"Subject '{subjectName}' has been successfully added.");
            }
        }

        public void AddGrade(string subjectName, int grade)
        {
            try
            {
                Subject subject = Subjects.FirstOrDefault(s => s.Name == subjectName);
                if (subject != null)
                {
                    if (grade >= 1 && grade <= 6)
                    {
                        subject.Grades.Add(grade);
                        Console.WriteLine($"Grade {grade} added to '{subjectName}'.");
                    }
                    else
                    {
                        Console.WriteLine("The grade must be between 1 and 6.");
                    }
                }
                else
                {
                    Console.WriteLine("The subject does not exist. Please add the subject first.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding the grade: " + ex.Message);
            }
        }

        public void DisplayGrades(string subjectName)
        {
            try
            {
                Subject subject = Subjects.FirstOrDefault(s => s.Name == subjectName);
                if (subject != null)
                {
                    if (subject.Grades.Count > 0)
                    {
                        Console.WriteLine($"Grades in '{subjectName}': {string.Join(", ", subject.Grades)}");
                    }
                    else
                    {
                        Console.WriteLine($"No grades available in '{subjectName}'.");
                    }
                }
                else
                {
                    Console.WriteLine("The subject does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error displaying grades: " + ex.Message);
            }
        }

        public void DisplayAverageGrade(string subjectName)
        {
            try
            {
                Subject subject = Subjects.FirstOrDefault(s => s.Name == subjectName);
                if (subject != null)
                {
                    double average = subject.AverageGrade();
                    Console.WriteLine($"Average grade in '{subjectName}': {average:0.00}");
                }
                else
                {
                    Console.WriteLine("The subject does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error calculating the average grade: " + ex.Message);
            }
        }

        public double OverallAverage()
        {
            var allGrades = Subjects.SelectMany(s => s.Grades).ToList();
            return allGrades.Count > 0 ? allGrades.Average() : 0.0;
        }

        public void DisplayOverallAverage()
        {
            try
            {
                double overallAverage = OverallAverage();
                Console.WriteLine($"Overall average grade for all subjects: {overallAverage:0.00}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error calculating the overall average: " + ex.Message);
            }
        }
    }

    class Program
    {
        static List<Student> studentList = new List<Student>();

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("----- Grade Management System -----");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Subject");
                Console.WriteLine("3. Add Grade");
                Console.WriteLine("4. Display Grades");
                Console.WriteLine("5. Display Average Grade");
                Console.WriteLine("6. Display Overall Average");
                Console.WriteLine("7. Display Best Student in Class");
                Console.WriteLine("8. Display Worst Student in Class");
                Console.WriteLine("9. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        AddSubject();
                        break;
                    case "3":
                        AddGrade();
                        break;
                    case "4":
                        DisplayGrades();
                        break;
                    case "5":
                        DisplayAverageGrade();
                        break;
                    case "6":
                        DisplayOverallAverage();
                        break;
                    case "7":
                        DisplayBestStudentInClass();
                        break;
                    case "8":
                        DisplayWorstStudentInClass();
                        break;
                    case "9":
                        running = false;
                        Console.WriteLine("Program terminated.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddStudent()
        {
            try
            {
                Console.Write("Enter the student's name: ");
                string name = Console.ReadLine();
                Console.Write("Enter the student's class: ");
                string className = Console.ReadLine();

                Student newStudent = new Student
                {
                    Name = name,
                    ClassName = className
                };

                studentList.Add(newStudent);
                Console.WriteLine("Student successfully added.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding student: " + ex.Message);
            }
        }

        static Student FindStudent(string name)
        {
            return studentList.FirstOrDefault(s => s.Name == name);
        }

        static void AddSubject()
        {
            Console.Write("Enter the student's name: ");
            string name = Console.ReadLine();
            Student student = FindStudent(name);

            if (student != null)
            {
                Console.Write("Enter the subject name: ");
                string subjectName = Console.ReadLine();
                student.AddSubject(subjectName);
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        static void AddGrade()
        {
            Console.Write("Enter the student's name: ");
            string name = Console.ReadLine();
            Student student = FindStudent(name);

            if (student != null)
            {
                Console.Write("Enter the subject name: ");
                string subjectName = Console.ReadLine();
                Console.Write("Enter the grade (1-6): ");
                if (int.TryParse(Console.ReadLine(), out int grade))
                {
                    student.AddGrade(subjectName, grade);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
                }
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        static void DisplayGrades()
        {
            Console.Write("Enter the student's name: ");
            string name = Console.ReadLine();
            Student student = FindStudent(name);

            if (student != null)
            {
                Console.Write("Enter the subject name: ");
                string subjectName = Console.ReadLine();
                student.DisplayGrades(subjectName);
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        static void DisplayAverageGrade()
        {
            Console.Write("Enter the student's name: ");
            string name = Console.ReadLine();
            Student student = FindStudent(name);

            if (student != null)
            {
                Console.Write("Enter the subject name: ");
                string subjectName = Console.ReadLine();
                student.DisplayAverageGrade(subjectName);
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        static void DisplayOverallAverage()
        {
            Console.Write("Enter the student's name: ");
            string name = Console.ReadLine();
            Student student = FindStudent(name);

            if (student != null)
            {
                student.DisplayOverallAverage();
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        static void DisplayBestStudentInClass()
        {
            Console.Write("Enter the class name: ");
            string className = Console.ReadLine();

            var studentsInClass = studentList.Where(s => s.ClassName == className).ToList();
            if (studentsInClass.Count > 0)
            {
                var bestStudent = studentsInClass.OrderByDescending(s => s.OverallAverage()).FirstOrDefault();
                Console.WriteLine($"Best student in class '{className}': {bestStudent.Name} with an average of {bestStudent.OverallAverage():0.00}");
            }
            else
            {
                Console.WriteLine("No students found in the specified class.");
            }
        }

        static void DisplayWorstStudentInClass()
        {
            Console.Write("Enter the class name: ");
            string className = Console.ReadLine();

            var studentsInClass = studentList.Where(s => s.ClassName == className).ToList();
            if (studentsInClass.Count > 0)
            {
                var worstStudent = studentsInClass.OrderBy(s => s.OverallAverage()).FirstOrDefault();
                Console.WriteLine($"Worst student in class '{className}': {worstStudent.Name} with an average of {worstStudent.OverallAverage():0.00}");
            }
            else
            {
                Console.WriteLine("No students found in the specified class.");
            }
        }
    }
}
