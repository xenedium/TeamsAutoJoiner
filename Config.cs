using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TeamsAutoJoiner
{
    public class Config
    {
        [JsonProperty("emailId")] public string EmailId;
        [JsonProperty("passwordId")] public string PasswordId;
        [JsonProperty("submitId")] public string SubmitId;
        [JsonProperty("email")] public string Email;
        [JsonProperty("password")] public string Password;
        [JsonProperty("timeout")] public int Timeout;
        
        public static async Task<Config> CreateAsync(string filename)
        {
            
            using (var json = new StreamReader(filename))
            {
                return JsonConvert.DeserializeObject<Config>(await json.ReadToEndAsync());
            }
            
        }
        public Config(string emailId, string passwordId, string submitId, string email, string password, int timeout)
        {
            EmailId = emailId;
            PasswordId = passwordId;
            SubmitId = submitId;
            Email = email;
            Password = password;
            Timeout = timeout;
        }
    }
}