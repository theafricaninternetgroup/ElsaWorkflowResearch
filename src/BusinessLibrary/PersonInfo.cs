using Csla;
using Elsa.RD.Dal.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsa.RD.BusinessLibrary
{
    [Serializable]
    public class PersonInfo :ReadOnlyBase<PersonInfo>
    {
        public static readonly PropertyInfo<int> IdProperty =
            RegisterProperty<int>(nameof(Id));
        public int Id
        {
            get => GetProperty(IdProperty);
            private set => LoadProperty(IdProperty, value);
        }
        public static readonly PropertyInfo<string> FirstNameProperty =
            RegisterProperty<string>(nameof(FirstName));

       
        public string FirstName
        {
            get => GetProperty(FirstNameProperty);
            private set => LoadProperty(FirstNameProperty, value);
        }

        public static readonly PropertyInfo<string> LastNameProperty =
            RegisterProperty<string>(nameof(LastName));
      
        public string LastName
        {
            get => GetProperty(LastNameProperty);
            private set => LoadProperty(LastNameProperty, value);
        }

        [FetchChild]
        private void Fetch(PersonDto person)
        {
            Id=person.Id;
            FirstName=person.FirstName;
            LastName=person.LastName;
        }
    }
}

