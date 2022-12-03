using Conductor.Client;
using Tests.Util;
using Xunit;

namespace Tests.Examples
{
    public abstract class ApiTest<T> where T : IApiAccessor, new()
    {
        protected T _client;

        public ApiTest()
        {
            _client = ApiUtil.GetClient<T>();
        }

        [Fact]
        public abstract void TestMethods();
    }
}