using Docusign.IAM;
using Docusign.IAM.SDK;
using Docusign.IAM.SDK.Models.Components;
using Docusign.IAM.SDK.Utils.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsIamTest.AuthMechanisms
{
    public class JWT
    {
        [Fact]
        public async Task getJwtToken()
        {

            string jwtAssertion = JwtAssertionHelper.GenerateJWT(
                 clientId: MyConfig.CLIENT_ID,
                 privateKey: MyConfig.PRIVATE_KEY,
                 userId: MyConfig.USER_ID,
                 oAuthBasePath: OAuthBasePath.Demo,
                 scopes: [AuthScope.Signature.Value(), AuthScope.Impersonation.Value()]
             );

            var client = IamClient.Builder().WithServerUrl(MyConfig.API_URL).Build();
            var tokenResponse = await client.Auth.GetTokenFromJwtGrantAsync(
                new() { Assertion = jwtAssertion }
            );

            Assert.NotNull( tokenResponse );
            var authenticatedSdk = IamClient
                .Builder()
                .WithServerUrl(MyConfig.API_URL)
                .WithAccessToken(tokenResponse?.JWTGrantResponse?.AccessToken)
                .Build();

            var getUserInfo = await authenticatedSdk.Auth.GetUserInfoAsync();
            Assert.NotNull(getUserInfo);
            Assert.NotNull(getUserInfo?.UserInfo?.Email);
        }
    }
}
