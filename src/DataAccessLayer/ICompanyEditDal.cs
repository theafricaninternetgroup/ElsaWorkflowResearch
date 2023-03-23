using Elsa.RD.Dal.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsa.RD.Dal
{
    public interface ICompanyEditDal
    {
        public void Insert(CompanyDto data);
        public CompanyDto Fetch(int  id);
    }
}
