using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_entity_framework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            using (var db = new EntityDBEntities1())
            {
                var select = from s in db.students
                             join f in db.Faculties on s.FacultyID equals f.FacultyID
                             where s.StudentAge >=18 && s.StudentAge <=20 && f.FacultyID == 1
                             select new {student = s, faculty = f};
                Console.WriteLine("thông tin Student thuộc khoa CNTT và có tuổi từ 18 đến 20:");
                foreach (var item in select)
                {
                    Console.WriteLine(" ID: {0}",item.student.StudentID);
                    Console.WriteLine(" Name: {0}", item.student.StudentName);
                    Console.WriteLine(" Age: {0}", item.student.StudentAge);
                    Console.WriteLine(" Gender: {0}", item.student.StudentGender);
                    Console.WriteLine(" Address: {0}", item.student.StudentAddress);
                    Console.WriteLine(" Faculty: {0}", item.faculty.FacultyName);

                }
            }
            Console.ReadKey();
        }
    }
}
