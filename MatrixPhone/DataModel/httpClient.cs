using MatrixApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MatrixPhone.DataModel
{
    class appHttpClient : HttpClient
    {
        public appHttpClient()
        {
            this.BaseAddress = new Uri("http://localhost:16185/api/");
            this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var user = UserDataSource.GetUser();

            var auth = UserDataSource.Auth();

            this.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);
        }
    }
}
