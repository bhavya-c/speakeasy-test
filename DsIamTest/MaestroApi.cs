using Docusign.IAM;
using Docusign.IAM.Models.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsIamTest
{
    public class Maestro
    {

        [Fact]
        public static async Task GetWorkflows()
        {
            var sdk = DocusignIamSDK.Builder().WithServerUrl(MyConfig.API_URL+"/v1").WithAccessToken(MyConfig.ACCESS_TOKEN).Build();

            var res = await sdk.Maestro.Workflows.GetWorkflowsListAsync(accountId: MyConfig.ACCOUNT_ID);
            Assert.NotNull(res);

        }

        [Fact]
        public static async Task TrggerWorkflows() {
            var sdk = DocusignIamSDK.Builder().WithAccessToken(MyConfig.ACCESS_TOKEN).Build();
            try
            {
                var res = await sdk.Maestro.Workflows.TriggerWorkflowAsync(
                    accountId: MyConfig.ACCOUNT_ID,
                    workflowId: "ae232f1f-8efc-4b8c-bb08-626847fad8bb",
                    triggerWorkflow: new TriggerWorkflow()
                    {
                        InstanceName = "My Instance",
                        TriggerInputs = new Dictionary<string, TriggerInputs>() {
                { "name", TriggerInputs.CreateStr(
                    "Jon Doe"
                ) },
                { "email", TriggerInputs.CreateStr(
                    "jdoe@example.com"
                ) },
                    },
                    }
                );
            }
            catch (Exception ex)
            {   
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine( ex.ToString() );
            }
        }
    }
}
