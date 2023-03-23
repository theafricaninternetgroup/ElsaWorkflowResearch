using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsa.RD.Dal.Entities
{
    public class CompanyEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }=default!;
        public string Address { get; set; }=default!;
    }
}
