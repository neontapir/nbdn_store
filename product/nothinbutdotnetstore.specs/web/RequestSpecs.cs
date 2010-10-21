using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class RequestSpecs
    {
        public abstract class concern : Observes<Request,
                                            BasicRequest>
        {

        }

        [Subject(typeof(RequestHandler))]
        public class when_mapping_an_object : concern
        {
            Establish c = () =>
                              {
                                  myObject = new MyObject();
                                  provide_a_basic_sut_constructor_argument(myObject);
                              };

            Because b = () =>
                        result = sut.map<MyObject>();

            private It should_return_an_instance_of_the_object_contained_in_the_request = () => result.ShouldEqual(myObject);

            static MyObject myObject;
            static object result;
        }

        public class MyObject
        {
        }

        public class BasicRequest : Request
        {
            private object model;

            public BasicRequest(object model)
            {
                this.model = model;
            }

            public InputModel map<InputModel>()
            {
                return (InputModel)model;
            }
        }
    }
}