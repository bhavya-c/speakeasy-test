using Docusign.IAM;
using Docusign.IAM.SDK;
using Docusign.IAM.SDK.Models.Components;
using Docusign.IAM.SDK.Models.Requests;
using Docusign.IAM.SDK.Utils.Auth;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DsIamTest.AuthMechanisms
{
    public  class CodeVerifier{
        [Fact]
        public async Task CodeVerifierFlow()
        {
            var codeChallenge = await GenerateCodeChallenge(MyConfig.CODE_VERIFIER);
            var builder = AuthorizationUrlBuilder.Create()
                .WithClientId(MyConfig.PKCE_CLIENT_ID)
                .WithRedirectUri(MyConfig.REDIRECT_URI)
                .AddScopes(MyConfig.scopes)
                .WithResponseType(AuthorizationUrlResponseType.Code)
                .WithCodeChallenge(codeChallenge);

            var url = builder.Build();

            Console.WriteLine(url);
            Assert.Contains("client_id=", url);
            Assert.Contains("redirect_uri=", url);
        }

        [Fact]
        public async Task ExchangeCodeForToken()
        {
            var sdk = IamClient.Builder().Build();

            PublicAuthCodeGrantRequestBody req = new PublicAuthCodeGrantRequestBody()
            {
                ClientId = MyConfig.PKCE_CLIENT_ID,
                Code = MyConfig.PKCE_AUTH_CODE,
                CodeVerifier = MyConfig.CODE_VERIFIER,
            };

            var res = await sdk.Auth.GetTokenFromPublicAuthCodeAsync(req);

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

        public async Task<string> GenerateCodeChallenge(string codeVerifier)
        {
            return await Task.Run(() =>
            {
                using SHA256 sha256 = SHA256.Create();
                byte[] bytes = Encoding.ASCII.GetBytes(codeVerifier);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash)
                    .TrimEnd('=')
                    .Replace('+', '-')
                    .Replace('/', '_');
            });
        }
    }
}
