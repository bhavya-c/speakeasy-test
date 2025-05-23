using Docusign.IAM;
using Docusign.IAM.Models.Components;
using Docusign.IAM.Models.Requests;
using Docusign.IAM.Utils.Auth;
using Org.BouncyCastle.Bcpg;
using System.Net.Http;

namespace DsIamTest
{
    public class Auth
    {
       
        [Fact]
        public async Task JWT()
        {

            string jwtAssertion = JwtAssertionHelper.GenerateJWT(
                 clientId: MyConfig.CLIENT_ID,
                 privateKey: MyConfig.PRIVATE_KEY,
                 userId: MyConfig.USER_ID,
                 oAuthBasePath: OAuthBasePath.Demo,
                 scopes: [AuthScope.Signature.Value(), AuthScope.Impersonation.Value()]
             );

            var client = DocusignIamSDK.Builder().WithServerUrl(MyConfig.API_URL).Build();
            var tokenResponse = await client.Auth.GetTokenFromJwtGrantAsync(
                new() { Assertion = jwtAssertion }
            );

            if (tokenResponse != null)
            {
                var authenticatedSdk = DocusignIamSDK
                .Builder()
                .WithServerUrl(MyConfig.API_URL)
                .WithAccessToken(tokenResponse.JWTGrantResponse.AccessToken)
                .Build();

                var getUserInfo = await authenticatedSdk.Auth.GetUserInfoAsync();
                Assert.NotNull(getUserInfo);
                Assert.False(string.IsNullOrEmpty(getUserInfo?.UserInfo.Email));
            }
            else
            {
                throw new Exception("token response null");
            }
        }


        [Fact]
        public async Task GetPublicToken() {
            var sdk = DocusignIamSDK.Builder().WithServerUrl(MyConfig.SERVER_URL).Build();

            PublicAuthCodeGrantRequestBody req = new PublicAuthCodeGrantRequestBody()
            {
                ClientId = MyConfig.CLIENT_ID,
                Code = MyConfig.AUTH_CODE,
                CodeVerifier = "R8zFoqs0yey29G71QITZs3dK1YsdIvFNBfO4D1bukBw",
            };

            var res = await sdk.Auth.GetTokenFromPublicAuthCodeAsync(req);
            var authenticatedClient = DocusignIamSDK
                .Builder()
                .WithServerUrl(MyConfig.API_URL)
                .WithAccessToken(MyConfig.ACCESS_TOKEN)
                .Build();

            var getUserInfoResponse = await authenticatedClient.Auth.GetUserInfoAsync();
            Assert.NotNull(getUserInfoResponse.UserInfo);
        }


        [Fact]
        public async Task getAutoCodeUrl()
        {
            String consentUrl = AuthorizationUrlBuilder.Create()
                .WithBasePath(OAuthBasePath.Demo)
                .WithResponseType(AuthorizationUrlResponseType.Code)
                .WithClientId(MyConfig.CLIENT_ID)
                .WithRedirectUri(MyConfig.REDIRECT_URI)
                .Build();
            Assert.NotNull(consentUrl);
        }


        [Fact]
        public async Task ExchangeCodeForToken() //ConfidentialAuthToken
        {
            var anonClient = DocusignIamSDK.Builder().Build();

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
            var accessToken = res?.AuthorizationCodeGrantResponse.AccessToken;
            var authenticatedSdk = DocusignIamSDK
               .Builder()
               .WithServerUrl(MyConfig.API_URL)
               .WithAccessToken(accessToken)
               .Build();

            var getUserInfo = await authenticatedSdk.Auth.GetUserInfoAsync();
            Assert.NotNull(getUserInfo);
            Assert.False(string.IsNullOrEmpty(getUserInfo?.UserInfo.Email));

        }

        //[Fact]
        //public async Task RefreshToken() {
        //    var tokenCache = new TokenCache();
        //    tokenCache.StoreToken("new-test", MyConfig.ACCESS_TOKEN, MyConfig.REFRESH_TOKEN, DateTime.Now.AddYears(-1));
        //    var httpClient = new HttpClient();

        //    var authService = new DocusignConfidentialAuthService(
        //       MyConfig.CLIENT_ID,
        //       MyConfig.CLIENT_SECRET,
        //       MyConfig.SERVER_URL,
        //       tokenCache,
        //       httpClient,
        //       "new-test"
        //   );
        //    Assert.True(tokenCache.GetToken("new-test")?.IsExpired); // check if token is expired
        //    var token = await authService.GetAccessTokenAsync();
        //    Assert.False(tokenCache.GetToken("new-test")?.IsExpired); // check if token has been refreshed
        //}

        [Fact]
        public async Task BadToken()
        {

            var authenticatedSdk = DocusignIamSDK
                .Builder()
                .WithServerUrl(MyConfig.API_URL)
                .WithAccessToken(MyConfig.EXPIRED_ACCESSTOKEN)
                .Build();

            var getUserInfo = await authenticatedSdk.Auth.GetUserInfoAsync();
            Assert.Null(getUserInfo);
        }


        //[Fact]
        //public async Task ExpiredToken()
        //{

        //    var sdk = new DocusignIamSDK(accessToken: MyConfig.EXPIRED_ACCESSTOKEN);

        //    try
        //    {
        //        var userInfo = await sdk.Auth.GetUserInfoAsync();
        //        Assert.NotNull(userInfo);
        //        Assert.False(string.IsNullOrEmpty(userInfo.UserInfo.Email));
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

    }
}