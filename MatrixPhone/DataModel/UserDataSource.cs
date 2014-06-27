using MatrixApi.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;


namespace MatrixPhone.DataModel
{
    public static class UserDataSource
    {
        public static User user = new User();
        public static User GetUser() {
            return user;
        }

        public static async void Login(string Email, string Password)
        {
            user.Email = Email;
            user.Password = Password;

            var httpClient = new appHttpClient();

            var response = await httpClient.GetAsync("Users");
            try
            {
                response.EnsureSuccessStatusCode(); // Throw on error code.
            } catch {
                user = new User();
            }

            var result = await response.Content.ReadAsStringAsync();

            user = JsonConvert.DeserializeObject<User>(result);
        }

        public static string Auth()
        {
            var authText = string.Format("{0}:{1}", user.Email, user.Password);

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(authText));
        }
    }
}
