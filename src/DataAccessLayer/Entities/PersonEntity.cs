using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsa.RD.Dal.Entities
{
    public class PersonEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AddressLine1 { get; set; } = string.Empty;
        public string AddressLine2 { get; set; } = string.Empty;
        public string MobilePhoneNo { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public double Salary { get; set; }
        public int SalaryScale { get; set; }
        public int JobTitle { get; set; }
        public DateTime HireDate { get; set; }
    }
}
