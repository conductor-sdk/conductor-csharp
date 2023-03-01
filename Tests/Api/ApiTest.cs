using Conductor.Client;
using Tests.Util;
using Xunit;

namespace Tests.Examples
{
    public abstract class ApiTest<T> where T : IApiAccessor, new()
    {
        protected T _client;

        protected static string RANDOM_WORKFLOW_NAME;
        protected static string RANDOM_TASK_NAME;

        public ApiTest()
        {
            _client = ApiUtil.GetClient<T>();
            RANDOM_WORKFLOW_NAME = "random_csharp_workflow_" + System.Guid.NewGuid().ToString();
            RANDOM_TASK_NAME = "random_csharp_task_" + System.Guid.NewGuid().ToString();
        }

        [Fact]
        public abstract void TestMethods();
    }
}