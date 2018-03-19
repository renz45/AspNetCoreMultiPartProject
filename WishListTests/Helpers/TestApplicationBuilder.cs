using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace WishListTests.Helpers
{
    public class TestApplicationBuilder : IApplicationBuilder
    {
        public IServiceProvider ApplicationServices { get; set; } = new TestServiceProvider();

        public IFeatureCollection ServerFeatures { get; set; } = new FeatureCollection();

        public IDictionary<string, object> Properties { get; set; } = new Dictionary<string,object>();

        public RequestDelegate Build()
        {
            throw new NotImplementedException();
        }

        public IApplicationBuilder New()
        {
            return this;
        }

        public IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware)
        {
            Properties.Add(middleware.Target.GetType().Name, middleware.Target.GetType());
            return this;
        }
    }
}
