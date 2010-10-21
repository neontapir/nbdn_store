using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubSetOfCommands : IEnumerable<WebCommand>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<WebCommand> GetEnumerator()
        {
            yield return new DefaultWebCommand(x => true,
                                               new ViewStoreDirectory());

            //yield return new DefaultWebCommand(x=> x.Url.EndsWith("Departments.Store"),
            //                                   new ViewStoreDirectory());

            //yield return new DefaultWebCommand(x => x.Url.Contains("Departments.Store") && x.QueryString.Any(),
            //                                   new ViewStoreDirectory());


            //yield return new DefaultWebCommand(x => x.Url.Contains("?"),
            //                                   new ViewStoreDirectory());

             //yield return new DefaultWebCommand(x => x.Url.Contains("Departartments/AllDepartments.Store"),
             //                                  new ViewProductsInADepartment());
        
        }
    }
}