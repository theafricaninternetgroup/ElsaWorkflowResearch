using Elsa.RD.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsa.RD.Dal.Mock
{
    public static class MockDb
    {
        public static List<PersonEntity> Persons { get; private set; }
        public static List<CompanyEntity> Companys { get; private set;}

        static MockDb()
        {
            Persons = new List<PersonEntity>();
            Companys = new List<CompanyEntity>();
        }
    }
}
