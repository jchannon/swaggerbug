using Nancy;
using Nancy.Metadata.Module;
using Nancy.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => "Hello";
        }
    }

    public class TestModule : NancyModule
    {
        public TestModule()
            : base("/test")
        {
            Get["Test","/"] = _ => "Test";
        }
    }
}

//Make this namespace WebApplication2 and you'll see the Metadata
namespace WebApplication2.Test
{
    public class TestMetadataModule : MetadataModule<SwaggerRouteData>
    {
        public TestMetadataModule()
        {
            Describe["Test"] = description => description.AsSwagger(with =>
            {
                with.ResourcePath("/test");
                with.Summary("This is pretty");
                with.Notes("We rock!");
            });


        }
    }
}