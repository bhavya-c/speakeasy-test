using Docusign.IAM;
using Docusign.IAM.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsIamTest
{
    public class Agreements
    {

        [Fact]
        public static async Task GetAgreements()
        {
            var sdk = IamClient.Builder().WithServerUrl(MyConfig.API_URL+"/v1").WithAccessToken(MyConfig.ACCESS_TOKEN).Build();

            var res = await sdk.Navigator.Agreements.GetAgreementsListAsync(
                accountId: MyConfig.ACCOUNT_ID,
                limit: 10
            //ctoken: "abc123"
            );
            Assert.NotNull(res.AgreementsResponse);
            Assert.NotNull(res.AgreementsResponse.Data);

        }
    }
}
