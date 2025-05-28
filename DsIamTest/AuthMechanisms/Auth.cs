using Docusign.IAM;
using Docusign.IAM.SDK;
using Docusign.IAM.SDK.Models.Requests;
using Org.BouncyCastle.Bcpg;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace DsIamTest.AuthMechanisms
{
    public class Auth
    {

        [Fact]
        public async Task RefreshToken()
        {
            var sdk = IamClient.Builder().Build();

            AuthorizationCodeGrant req = new AuthorizationCodeGrant()
            {
                RefreshToken = MyConfig.REFRESH_TOKEN,
                ClientId = MyConfig.CLIENT_ID,
            };

            try
            {
                var res = await sdk.Auth.GetTokenFromRefreshTokenAsync(
                   security: new GetTokenFromRefreshTokenSecurity()
                   {
                       ClientId = MyConfig.CLIENT_ID,
                       SecretKey = MyConfig.CLIENT_SECRET,
                   },
                   request: req
                 );
                Assert.Null(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine(ex.Message); //Message is just APIError occured
            }


        }

        [Fact]
        public async Task BadToken()
        {

            var authenticatedSdk = IamClient
                .Builder()
                .WithServerUrl(MyConfig.API_URL)
                .WithAccessToken(MyConfig.EXPIRED_ACCESSTOKEN)
                .Build();

            try
            {
                var getUserInfo = await authenticatedSdk.Auth.GetUserInfoAsync();
                Assert.Null(getUserInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine(ex.Message); //Message is just APIError occured
            }
        }

    }
}