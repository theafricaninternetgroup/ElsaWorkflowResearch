using Elsa.RD.Dal.DataTransferObjects;
using Elsa.RD.Dal.Entities;
using Elsa.RD.Dal.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Elsa.RD.Dal
{
    public class PersonEditDal : IPersonEditDal
    {
        public PersonDto Fetch(int id)
        {
            var person = (from r in MockDb.Persons
                          where r.Id == id
                          select new PersonDto
                          {
                              Id = r.Id,
                              FirstName = r.FirstName,
                              LastName = r.LastName,
                              Gender = r.Gender,
                              DateOfBirth = r.DateOfBirth,
                              AddressLine1 = r.AddressLine1,
                              AddressLine2 = r.AddressLine2,
                              MobilePhoneNo = r.MobilePhoneNo,
                              EmailAddress = r.EmailAddress,
                              Salary = r.Salary,
                              SalaryScale = r.SalaryScale,
                              JobTitle = r.JobTitle,
                              HireDate = r.HireDate
                          }).FirstOrDefault();
            if (person == null)
                throw new Exception();
            return person;

        }

        public List<PersonDto> Fetch()
        {
            var persons = (from r in MockDb.Persons
                           select new PersonDto
                           {
                               Id = r.Id,
                               FirstName = r.FirstName,
                               LastName = r.LastName
                           }).ToList();
            return persons;
        }

        public void Insert(PersonDto data)
        {
            var nextId = (from r in MockDb.Persons select r.Id).Count() + 1;
            data.Id = nextId;
            var newPerson = new PersonEntity
            {
                Id = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Gender = data.Gender,
                DateOfBirth = data.DateOfBirth,
                AddressLine1 = data.AddressLine1,
                AddressLine2 = data.AddressLine2,
                MobilePhoneNo = data.MobilePhoneNo,
                EmailAddress = data.EmailAddress,
                Salary = data.Salary,
                SalaryScale = data.SalaryScale,
                JobTitle = data.JobTitle,
                HireDate = data.HireDate
            };
            MockDb.Persons.Add(newPerson);
        }
    }
}
