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
            using (var db = new EntityDBEntities())
            {
                var select = from s in db.students
                             join d in db.departments on s.DepartmentID equals d.DepartmentID
                             select new {student = s, department = d};

                foreach (var item in select)
                {
                    Console.WriteLine("ID: {0}",item.student.StudentID);
                    Console.WriteLine("Name: {0}", item.student.StudentName);
                    Console.WriteLine("Gender: {0}", item.student.StudentGender);
                    Console.WriteLine("Address: {0}", item.student.StudentAddress);
                    Console.WriteLine("Department: {0}", item.department.DepartmentName);
                }
            }
            Console.ReadKey();
        }
    }
}
