using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace WishListTests.Helpers
{
    public class TestServiceProvider : IServiceProvider
    {
        private IServiceProvider _inner;
        private IServiceCollection _services;

        public IServiceCollection Services => _services;

        public object GetService(Type serviceType)
        {
            return _services.FirstOrDefault(e => e.ServiceType == serviceType);
        }

        public void Populate(IServiceCollection services)
        {
            _services = services;
            _services.AddSingleton(this);
        }

        public void Build()
        {
            _inner = _services.BuildServiceProvider();
        }
    }
}
