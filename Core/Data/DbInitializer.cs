using Javeriana.Pica.Core.Data;
using Javeriana.Pica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Data
{
    public static class  DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            var students = new Student[]
            {
                new Student { FisrtName = "Pepito", LastName = "Pereaz", EnrollmentDate = DateTime.Now },
                new Student { FisrtName = "Juanita", LastName = "Juarez", EnrollmentDate = DateTime.Now },
                new Student { FisrtName = "Jhon", LastName = "Johanson", EnrollmentDate = DateTime.Now }
            };

     


            foreach (Student s in students)
            {
                context.Students.Add(s);
            }

            context.SaveChanges();

            var courses = new Course[]
            {
                new Course { CourseID = 101, Title = "PICA", Credits = 3 },
                new Course { CourseID = 102, Title = "Modelado", Credits = 5 },
                new Course { CourseID = 103, Title = "Cloud computing", Credits = 3 },
                new Course { CourseID = 104, Title = "Gerencia de proyectos", Credits = 2 },
                new Course { CourseID = 105, Title = "Arquitectura Empresarial", Credits = 3 },
                new Course { CourseID = 106, Title = "Costura en la nube", Credits = 7 }
            };

            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }

            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID=1,CourseID=101,Grade=Grade.A},
                new Enrollment{StudentID=2,CourseID=101,Grade=Grade.B},
                new Enrollment{StudentID=2,CourseID=102,Grade=Grade.C},
                new Enrollment{StudentID=3,CourseID=101,Grade=Grade.A},
                new Enrollment{StudentID=2,CourseID=103,Grade=Grade.C},
                new Enrollment{StudentID=1,CourseID=104,Grade=Grade.A},
                new Enrollment{StudentID=3,CourseID=105,Grade=Grade.F},
                new Enrollment{StudentID=3,CourseID=106,Grade=Grade.C}
            };

            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }

            context.SaveChanges();
        }
    }
}
