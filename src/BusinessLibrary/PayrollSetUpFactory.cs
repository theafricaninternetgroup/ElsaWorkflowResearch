using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;

namespace Elsa.RD.BusinessLibrary
{
    [Serializable]
    public class PayrollSetUpFactory :ReadOnlyBase<PayrollSetUpFactory>
    {
        public static readonly PropertyInfo<CompanyEdit> CompanyProperty =
            RegisterProperty<CompanyEdit>(nameof(Company));
        public CompanyEdit Company
        {
            get => GetProperty(CompanyProperty);
            private set=>LoadProperty(CompanyProperty, value);
        }
        public static readonly PropertyInfo<PersonEdit> EmployeeProperty =
            RegisterProperty<PersonEdit>(nameof(Employee));
        public PersonEdit Employee
        {
            get=> GetProperty(EmployeeProperty);
            private set => LoadProperty(EmployeeProperty, value);
        }

        [Fetch]
        private void Fetch([Inject]IDataPortalFactory factory)
        {
            Company = factory.GetPortal<CompanyEdit>().Create();
            Employee=factory.GetPortal<PersonEdit>().Create();
        }
        [Fetch]
        private void Fetch(int id, [Inject]IDataPortalFactory factory)
        {
            Company = factory.GetPortal<CompanyEdit>().Fetch(id);
            Employee = factory.GetPortal<PersonEdit>().Create();

        }
    }
}
