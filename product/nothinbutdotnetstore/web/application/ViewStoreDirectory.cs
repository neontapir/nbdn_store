using System.Linq;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.domain.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application
{
    public class ViewStoreDirectory : ApplicationCommand
    {
        StoreDirectory store_directory;
        ResponseEngine response_engine;

        public ViewStoreDirectory()
            : this(new StubStoreDirectory(),
                   new StubResponseEngine())
        {
        }

        public ViewStoreDirectory(StoreDirectory store_directory, ResponseEngine response_engine)
        {
            this.store_directory = store_directory;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {
            var department = request.map<Department>();
            if (department == Department.MISSING_DEPARTMENT)
                response_engine.display(store_directory.get_all_the_main_departments());
            else if (store_directory.get_the_departments_in(department).Any())
                response_engine.display(store_directory.get_the_departments_in(department));
            else
                response_engine.display(store_directory.get_the_products_in(department));
        }
    }
}