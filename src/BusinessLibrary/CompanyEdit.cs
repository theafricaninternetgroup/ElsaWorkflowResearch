using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;
using Csla.Rules;
using System.ComponentModel.DataAnnotations;
using Elsa.RD.Dal;
using Elsa.RD.Dal.DataTransferObjects;

namespace Elsa.RD.BusinessLibrary
{
    [Serializable]
    public class CompanyEdit :BusinessBase<CompanyEdit>
    {
        public static readonly PropertyInfo<int> IdProperty =
            RegisterProperty<int>(nameof(Id));
        public int Id
        {
            get=>GetProperty(IdProperty);
            private set=>LoadProperty(IdProperty, value);
        }
        public static readonly PropertyInfo<string> NameProperty =
            RegisterProperty<string>(nameof(Name));
        [Required(ErrorMessage ="Company name is required")]
        public string Name
        {
            get=>GetProperty(NameProperty);
            set => SetProperty(NameProperty,value);
        }

        public static readonly PropertyInfo<string> AddressProperty =
            RegisterProperty<string>(nameof(Address));

        [Required(ErrorMessage = "Company address is required")]
        public string Address
        {
            get => GetProperty(AddressProperty);
            set => SetProperty(AddressProperty, value);
        }

        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();
        }

        [Create]
        private void Create()
        {
            BusinessRules.CheckRules();
        }
        [Insert]
        private void Insert([Inject]ICompanyEditDal dal)
        {
            using (BypassPropertyChecks)
            {
                var data = new CompanyDto
                {
                    Name = this.Name,
                    Address = this.Address
                };
                dal.Insert(data);
                this.Id = data.Id;
            }
        }

        [Fetch]
        private void Fetch(int id, [Inject]ICompanyEditDal dal)
        {
            var company = dal.Fetch(id);
            using (BypassPropertyChecks)
            {
                Id= company.Id;
                Name= company.Name;
                Address= company.Address;
            }
        }
        
    }
}
