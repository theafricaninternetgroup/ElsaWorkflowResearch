using Elsa.RD.Dal.DataTransferObjects;
using Elsa.RD.Dal.Entities;
using Elsa.RD.Dal.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsa.RD.Dal
{
    public class CompanyEditDal : ICompanyEditDal
    {
        public CompanyDto Fetch(int id)
        {
            var company = (from r in MockDb.Companys where r.Id == id select new CompanyDto
            {
                Id = r.Id,
                Name = r.Name,
                Address = r.Address,
            }).FirstOrDefault();
            if (company == null)
                throw new Exception();
            return company;
        }

        public void Insert(CompanyDto data)
        {
            var nextId = (from r in MockDb.Companys select r.Id).Count() + 1;
            data.Id = nextId;
            var newCompany = new CompanyEntity
            {
                Id = data.Id,
                Name = data.Name,
                Address = data.Address,
            };
            MockDb.Companys.Add(newCompany);
        }
    }
}
