using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IS.Client
{
    static class DMWebClient
    {
        /// <summary>
        /// 向IdentityServer请求令牌
        /// </summary>
        /// <returns></returns>
        public static TokenResponse GetClientToken()
        {
            //初始化TokenClient, 授权地址，客户Id，客户密码
            var client = new TokenClient("http://localhost:5000/connect/token", "dm.web", "f4189a35-1c49-474b-91d0-2110452cc9fc");
            return client.RequestClientCredentialsAsync("api").Result;
        }


        /// <summary>
        /// 使用令牌向资源服务器，获取数据
        /// </summary>
        /// <param name="token"></param>
        public static void CallApi(TokenResponse token)
        {
            var client = new HttpClient();
            client.SetBearerToken(token.AccessToken);

            Console.WriteLine(client.GetStringAsync("http://localhost:40767/test").Result);
        }
    }
}
