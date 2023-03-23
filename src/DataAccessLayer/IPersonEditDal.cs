using Elsa.RD.Dal.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsa.RD.Dal
{
    public interface IPersonEditDal
    {
        public void Insert(PersonDto data);
        public PersonDto Fetch(int id);
        public List<PersonDto> Fetch();
    }
}
