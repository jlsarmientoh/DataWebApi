using System;
using System.Collections.Generic;
using System.Text;

namespace Javeriana.Pica.Core.Entities
{
    public class Student
    {
        public int ID { get; set; }

        public string LastName { get; set; }

        public string FisrtName { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
