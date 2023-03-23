using Csla;
using Elsa.RD.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsa.RD.BusinessLibrary
{
    [Serializable]
    public class PersonList :ReadOnlyListBase<PersonList,PersonInfo>
    {
        [Fetch]
        private void Fetch([Inject]IPersonEditDal dal, [Inject]IChildDataPortal<PersonInfo>portal)
        {
            var list = dal.Fetch();
            IsReadOnly = false;
            foreach(var person  in list)
                this.Add(portal.FetchChild(person));
            IsReadOnly= true;

        }
    }
}
