using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ShelterClient.Models
{
  public class Login
  {
    public string Username { get; set; }
    public string Password { get; set; }

    public static string GetToken(Login userInfo)
    {
      string jsonUserInfo = JsonConvert.SerializeObject(userInfo);
      Task<string> apiCallTask = ApiHelper.Login(jsonUserInfo);
      string result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Dictionary<string, string> dictionaryResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse.ToString());
      
      if(dictionaryResponse.ContainsKey("token"))
      {
        return dictionaryResponse["token"];
      }
      else
      {
        return null;
      }
    }

    public static async Task Post(Login userInfo, string token)
    {
      string jsonUserInfo = JsonConvert.SerializeObject(userInfo);
      await ApiHelper.LoginPost(jsonUserInfo, token);
    }

  }
}