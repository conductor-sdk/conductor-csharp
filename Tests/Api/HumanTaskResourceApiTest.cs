using Conductor.Api;
using Conductor.Client;
using Conductor.Client.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace conductor_csharp.test.Api
{
    public class HumanTaskResourceApiTest
    {
        private readonly HumanTaskResourceApi _humanTaskResourceApi;
        private readonly OrkesApiClient _orkesApiClient;
        private const string UserFormName = "USER_FORM_NAME_TEST";
        private readonly ITestOutputHelper _testOutputHelper;

        public HumanTaskResourceApiTest(ITestOutputHelper testOutputHelper)
        {
            // dev local testing
            //_orkesApiClient = new OrkesApiClient(new Configuration(), new OrkesAuthenticationSettings(Constants.KEY_ID, Constants.KEY_SECRET));
            //_humanTaskResourceApi = _orkesApiClient.GetClient<HumanTaskResourceApi>();

            _testOutputHelper = testOutputHelper;
            _humanTaskResourceApi = ApiExtensions.GetClient<HumanTaskResourceApi>();
        }

        /// <summary>
        /// Test case for HumanTaskResourceApi using  BaseUrl:- 'https://sdkdev.orkesconductor.io/'
        /// Get templates of user form based on name
        /// </summary>
        [Fact]
        public void TestUserForm()
        {
            var templates = _humanTaskResourceApi.GetAllTemplates(UserFormName, null);
            if (templates != null && templates.Count > 0)
            {
                _testOutputHelper.WriteLine($"UserFormName --> {UserFormName} and result count of templates --> {templates.Count}");
                Assert.NotEmpty(templates);
            }
            else
            {
                _testOutputHelper.WriteLine($"UserFormName --> {UserFormName} and result count of templates is 0");
                Assert.Empty(templates);
            }
        }
    }
}
