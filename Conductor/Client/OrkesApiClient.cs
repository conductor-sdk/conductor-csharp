using Conductor.Client.Authentication;

namespace Conductor.Client
{
    public class OrkesApiClient
    {
        private Configuration _configuration = null;

        public OrkesApiClient(Configuration configuration, OrkesAuthenticationSettings orkesAuthenticationSettings)
        {
            _configuration = configuration;
            if (orkesAuthenticationSettings != null)
            {
                configuration.AuthenticationSettings = orkesAuthenticationSettings;
            }
        }

        public T GetClient<T>() where T : IApiAccessor, new()
        {
            return _configuration.GetClient<T>();
        }
    }
}
