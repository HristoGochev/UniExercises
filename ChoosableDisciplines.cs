using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseForUniAboutChoosableDisciplines
{
    class Program
    {
        private static List<Student> RecordedStudents { get; set; } = new List<Student>();

        static void Main(string[] args)
        {
            string temp = null;
            Student tempStudent = null;
            do
            {
                tempStudent=CreateStudent();
                if (!RecordedStudentsContainStudentByNameAndFacultyNumber(tempStudent.Name,tempStudent.FacultyNumber))
                {
                    RecordedStudents.Add(tempStudent);
                }
                Console.Write(@"If you wish to stop adding students to their chosen disciplines type 'end', otherwise press Enter");
                Console.WriteLine();
                temp = Console.ReadLine();
            } while (temp!="end");
            SortAllRecordedStudentsByTheirMarks();
            ListAllRecordedStudents();
            Console.ReadLine();
        }

      

        private static Student CreateStudent()
        {
            Console.WriteLine("Creating new student");
            Console.WriteLine();
            Console.Write("Chosen discipline: ");
            string TempChosenDisciplineName = Console.ReadLine();
            Console.Write("Name: ");
            string TempName = Console.ReadLine();
            Console.Write("Faculty number: ");
            int TempFacultyNumber = int.Parse(Console.ReadLine());
            Console.Write("Mark: ");
            double TempMark = double.Parse(Console.ReadLine());
            Console.WriteLine();
            return new Student(TempName, TempFacultyNumber, TempMark, TempChosenDisciplineName);
        }
        private static bool RecordedStudentsContainStudentByNameAndFacultyNumber(string StudentName,int FacultyNumber)
        {
            bool output = false;
            for (int i = 0; i < RecordedStudents.Count; i++)
            {
                if (RecordedStudents[i].Name==StudentName&&RecordedStudents[i].FacultyNumber==FacultyNumber)
                {
                    output = true;
                    break;
                }
            }
            return output;
        } 
        private static void SortAllRecordedStudentsByTheirMarks()
        {
            Student tempStudent = null;
            for (int j = 0; j <= RecordedStudents.Count - 2; j++)
            {
                for (int i = 0; i <= RecordedStudents.Count - 2; i++)
                {
                    if (RecordedStudents[i].Mark < RecordedStudents[i + 1].Mark)
                    {
                        tempStudent = RecordedStudents[i + 1];
                        RecordedStudents[i + 1] = RecordedStudents[i];
                        RecordedStudents[i] = tempStudent;
                    }
                }
            }
        }
        private static void ListAllRecordedStudents()
        {
            for (int i = 0; i < RecordedStudents.Count; i++)
            {
                Console.WriteLine($"{RecordedStudents[i].Name} {RecordedStudents[i].ChosenDisciplineName} {RecordedStudents[i].Mark}");
            }
        }
    }
    public class Student
    {
        public string Name { get; private set; }
        public int FacultyNumber { get; private set; }
        public double Mark { get;private set;}
        public string ChosenDisciplineName { get; private set; }

        public Student(string name, int facultyNumber, double mark, string chosenDisciplineName)
        {
            Name = name;
            FacultyNumber = facultyNumber;
            Mark = mark;
            ChosenDisciplineName = chosenDisciplineName;
        }
    }
}
