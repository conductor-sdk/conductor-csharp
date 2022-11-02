using Conductor.Authentication;
using Conductor.Api;

namespace Tests.Util
{
    public abstract class IntegrationTest
    {
        private static OrkesApiClient _orkesApiClient;

        protected static MetadataResourceApi _metadataClient;

        static IntegrationTest()
        {
            _orkesApiClient = ApiUtil.GetApiClient();
            _metadataClient = (MetadataResourceApi)_orkesApiClient.GetMetadataClient();
        }
    }
}