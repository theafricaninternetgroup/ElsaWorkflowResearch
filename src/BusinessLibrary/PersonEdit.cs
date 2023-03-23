using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;
using Elsa.RD.Dal.DataTransferObjects;
using Elsa.RD.Dal;
using System.ComponentModel.DataAnnotations;

namespace Elsa.RD.BusinessLibrary
{
    [Serializable]
    public class PersonEdit :BusinessBase<PersonEdit>
    {
        public static readonly PropertyInfo<int> IdProperty =
            RegisterProperty<int>(nameof(Id));
        public int Id
        {
            get => GetProperty(IdProperty);
            private set=>LoadProperty(IdProperty, value);
        }

        public static readonly PropertyInfo<string> FirstNameProperty =
            RegisterProperty<string>(nameof(FirstName));

        [Required]
        public string FirstName
        {
            get => GetProperty(FirstNameProperty);
            set => SetProperty(FirstNameProperty, value);
        }

        public static readonly PropertyInfo<string> LastNameProperty =
            RegisterProperty<string>(nameof(LastName));
        [Required]
        public string LastName
        {
            get => GetProperty(LastNameProperty);
            set => SetProperty(LastNameProperty, value);
        }

        public static readonly PropertyInfo<int> GenderProperty =
           RegisterProperty<int>(nameof(Gender));
        public int Gender
        {
            get => GetProperty(GenderProperty);
            set => SetProperty(GenderProperty, value);
        }

        public static readonly PropertyInfo<DateTime> DateOfBirthProperty =
          RegisterProperty<DateTime>(nameof(DateOfBirth));
        public DateTime DateOfBirth
        {
            get => GetProperty(DateOfBirthProperty);
            set => SetProperty(DateOfBirthProperty, value);
        }

        public static readonly PropertyInfo<string> AddressLine1Property =
            RegisterProperty<string>(nameof(AddressLine1));
        [Required]
        public string AddressLine1
        {
            get => GetProperty(AddressLine1Property);
            set => SetProperty(AddressLine1Property, value);
        }

        public static readonly PropertyInfo<string> AddressLine2Property =
            RegisterProperty<string>(nameof(AddressLine2));
        public string AddressLine2
        {
            get => GetProperty(AddressLine2Property);
            set => SetProperty(AddressLine2Property, value);
        }

        public static readonly PropertyInfo<string> MobilePhoneNoProperty =
            RegisterProperty<string>(nameof(MobilePhoneNo));
        [Required]
        public string MobilePhoneNo
        {
            get => GetProperty(MobilePhoneNoProperty);
            set => SetProperty(MobilePhoneNoProperty, value);
        }

        public static readonly PropertyInfo<string> EmailAddressProperty =
           RegisterProperty<string>(nameof(EmailAddress));
        [Required]
        public string EmailAddress
        {
            get => GetProperty(EmailAddressProperty);
            set => SetProperty(EmailAddressProperty, value);
        }

        public static readonly PropertyInfo<double> SalaryProperty =
           RegisterProperty<double>(nameof(Salary));
        public double Salary
        {
            get => GetProperty(SalaryProperty);
            set => SetProperty(SalaryProperty, value);
        }

        public static readonly PropertyInfo<int> SalaryScaleProperty =
           RegisterProperty<int>(nameof(SalaryScale));
        public int SalaryScale
        {
            get => GetProperty(SalaryScaleProperty);
            set => SetProperty(SalaryScaleProperty, value);
        }

        public static readonly PropertyInfo<int> JobTitleProperty =
           RegisterProperty<int>(nameof(JobTitle));
        public int JobTitle
        {
            get => GetProperty(JobTitleProperty);
            set => SetProperty(JobTitleProperty, value);
        }

        public static readonly PropertyInfo<DateTime> HireDateProperty =
         RegisterProperty<DateTime>(nameof(HireDate));
        public DateTime HireDate
        {
            get => GetProperty(HireDateProperty);
            set => SetProperty(HireDateProperty, value);
        }

        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();
        }

        [Create]
        private void Create()
        {
            using (BypassPropertyChecks)
            {
                Id = -1;
            }
            BusinessRules.CheckRules();
        }

        [Insert]
        private void Insert([Inject]IPersonEditDal dal)
        {
            using(BypassPropertyChecks)
            {
                var data = new PersonDto
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Gender = Gender,
                    DateOfBirth = DateOfBirth,
                    AddressLine1 = AddressLine1,
                    AddressLine2 = AddressLine2,
                    MobilePhoneNo = MobilePhoneNo,
                    EmailAddress = EmailAddress,
                    Salary = Salary,
                    SalaryScale = SalaryScale,
                    JobTitle = JobTitle,
                    HireDate = HireDate

                };
                dal.Insert(data);
                Id = data.Id;
            }
        }

        [Fetch]
        private void Fetch(int id,[Inject]IPersonEditDal dal)
        {
            var data=dal.Fetch(id);
            using (BypassPropertyChecks)
            {
                Id=data.Id;
                FirstName = FirstName;
                LastName = data.LastName;
                Gender = data.Gender;
                DateOfBirth = data.DateOfBirth;
                AddressLine1 = data.AddressLine1;
                AddressLine2 = data.AddressLine2;
                MobilePhoneNo = data.MobilePhoneNo;
                EmailAddress = data.EmailAddress;
                Salary = data.Salary;
                SalaryScale = data.SalaryScale;
                JobTitle = data.JobTitle;
                HireDate = data.HireDate;
            }
        }









    }
}
