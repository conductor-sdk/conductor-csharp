using Conductor.Api;
using Conductor.Client.Authentication;
using Conductor.Client;

namespace csharp_examples
{
    public class HumanTaskExamples
    {
        public void GetUserFormTemplatesBasedOnName(string name)
        {
            var orkesApiClient = new OrkesApiClient(new Configuration(),
                new OrkesAuthenticationSettings(Constants.KEY_ID, Constants.KEY_SECRET));
            var workflowClient = orkesApiClient.GetClient<HumanTaskResourceApi>();
            var responseTemplate = workflowClient.GetAllTemplates(name, null);
            if (responseTemplate != null && responseTemplate.Count > 0)
            {
                responseTemplate.ForEach(x =>
                {
                    Console.WriteLine(x.Name);
                });
            }
        }
    }
}
