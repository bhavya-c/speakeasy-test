using Docusign.IAM;
using Docusign.IAM.Models.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace DsIamTest
{
    public class ConnectedFieldApi
    {

        [Fact]
        public static async Task GetTabInfo()
        {
            //var tokenCache = new TokenCache();
            var httpClient = new HttpClient();

            var sdk = DocusignIamSDK.Builder().WithServerUrl(MyConfig.API_URL+"/v1").WithAccessToken(MyConfig.ACCESS_TOKEN).Build();

            try
            {

                var res = await sdk.ConnectedFields.TabInfo.GetConnectedFieldsTabGroupsAsync(
                    accountId: MyConfig.ACCOUNT_ID
                );
                Console.Write("Finished");
                Assert.NotNull(res);
            }
            catch (Exception error) {
                Console.WriteLine(error.GetType().Name);
                Console.WriteLine(error.ToString());
            }
            

        }

        [Fact]
        public static async Task CustomGetTabInfo()
        {
            var customClient = new CustomHttpClient();

            //var sdk = new DocusignIamSDK(
            //    accessToken: MyConfig.ACCESS_TOKEN,
            //    client: customClient
            //);

            var sdk = DocusignIamSDK
                .Builder()
                .WithServerUrl(MyConfig.API_URL+"/v1")
                .WithAccessToken(MyConfig.ACCESS_TOKEN)
                .WithClient(customClient)
                .Build();

            try
            {
                var res = await sdk.ConnectedFields.TabInfo.GetConnectedFieldsTabGroupsAsync(
                    accountId: MyConfig.ACCOUNT_ID
                );

                Assert.NotNull(res);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.GetType().Name);
                Console.WriteLine(error.ToString());
            }
        }

        //    [Fact]
        //    public static async Task GetParallelTabInfo()
        //    {
        //        var tokenCache = new TokenCache();
        //        tokenCache.StoreToken("parallel-test", MyConfig.ACCESS_TOKEN, MyConfig.REFRESH_TOKEN, DateTime.Now.AddHours(1));
        //        var httpClient = new HttpClient();

        //        var authService = new DocusignConfidentialAuthService(
        //           MyConfig.CLIENT_ID,
        //           MyConfig.CLIENT_SECRET,
        //           MyConfig.SERVER_URL,
        //           tokenCache,
        //           httpClient,
        //           "parallel-test"
        //       );

        //        var token = await authService.GetAccessTokenAsync();
        //        var sdk = new DocusignIamSDK(accessToken: MyConfig.ACCESS_TOKEN);

        //        var tasks = new List<Task>();

        //        int numberOfCalls = 5;
        //        try
        //        {
        //            for (int i = 0; i < numberOfCalls; i++)
        //            {
        //                var task = Task.Run(async () =>
        //                {
        //                    try
        //                    {
        //                        var res = await sdk.ConnectedFields.TabInfo.GetConnectedFieldsTabGroupsAsync(
        //                            accountId: MyConfig.ACCOUNT_ID
        //                        );

        //                        Console.WriteLine($"Finished request {i + 1}");
        //                        Assert.NotNull(res);
        //                    }
        //                    catch (Exception error)
        //                    {
        //                        Console.WriteLine($"Error in request {i + 1}: {error.GetType().Name}");
        //                        Console.WriteLine(error.ToString());
        //                    }
        //                });

        //                tasks.Add(task);
        //            }

        //            await Task.WhenAll(tasks);

        //            Console.WriteLine("All requests finished.");
        //        }
        //        catch (Exception error)
        //        {
        //            Console.WriteLine("An error occurred: " + error.GetType().Name);
        //            Console.WriteLine(error.ToString());
        //        }
        //    }

    }
}
