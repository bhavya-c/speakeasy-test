using Docusign.IAM;
using Docusign.IAM.SDK;
using Docusign.IAM.SDK.Models.Components;
using Docusign.IAM.SDK.Models.Requests;
using Docusign.IAM.SDK.Utils.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsIamTest.AuthMechanisms
{
    public class AuthCodeGrant
    {
        [Fact]
        public async Task getAutoCodeUrl()
        {
            string consentUrl = AuthorizationUrlBuilder.Create()
                .WithBasePath(OAuthBasePath.Demo)
                .WithResponseType(AuthorizationUrlResponseType.Code)
                .WithClientId(MyConfig.CLIENT_ID)
                .WithRedirectUri(MyConfig.REDIRECT_URI)
                .Build();
            Assert.NotNull(consentUrl);
            Console.WriteLine(consentUrl);
        }


        [Fact]
        public async Task ExchangeCodeForToken() //ConfidentialAuthToken
        {
            var anonClient = IamClient.Builder().Build();

            var request = new ConfidentialAuthCodeGrantRequestBody()
            {
                Code = MyConfig.AUTH_CODE,
            };

            // Get token using client credentials
            var res = await anonClient.Auth.GetTokenFromConfidentialAuthCodeAsync(
                security: new GetTokenFromConfidentialAuthCodeSecurity()
                {
                    ClientId = MyConfig.CLIENT_ID,
                    SecretKey = MyConfig.CLIENT_SECRET,
                },
                request: request
            );


            Assert.NotNull(res);
            var accessToken = res?.AuthorizationCodeGrantResponse?.AccessToken;
            Assert.NotNull(accessToken);
            var authenticatedSdk = IamClient
               .Builder()
               .WithServerUrl(MyConfig.API_URL)
               .WithAccessToken(accessToken)
               .Build();

            var getUserInfo = await authenticatedSdk.Auth.GetUserInfoAsync();
            Assert.NotNull(getUserInfo);
            Assert.False(string.IsNullOrEmpty(getUserInfo?.UserInfo?.Email));

        }
    }
}
