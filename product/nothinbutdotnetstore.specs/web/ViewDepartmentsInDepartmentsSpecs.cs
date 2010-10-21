﻿using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.domain.stubs;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class ViewDepartmentsInDepartmentsSpecs
    {
        public abstract class concern : Observes<ApplicationCommand,
                                            ViewStoreDirectory>
        {
        }

        [Subject(typeof(ViewStoreDirectory))]
        public class when_processing_departments_in_a_department_request : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                response_engine = the_dependency<ResponseEngine>();
                departments_in_department = new List<Department>
                {
                    new Department {},
                };
                parent_department = new Department {};

                request.Stub(x => x.map<Department>()).Return(parent_department);

                store_directory = the_dependency<StoreDirectory>();

                store_directory.Stub(x => x.get_the_departments_in(parent_department)).Return(departments_in_department);
            };

            Because b = () =>
                sut.process(request);

            It should_tell_the_response_engine_to_display_the_departments = () =>
                response_engine.received(x => x.display(departments_in_department));

            static StoreDirectory store_directory;
            static Request request;
            static ResponseEngine response_engine;
            static Department parent_department;
            static IEnumerable<Department> departments_in_department;
        }
    }
}