using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ShelterClient.Models
{
  public class Cat : Animal
  {
    public int CatId { get; set; }

    public static List<Cat> GetCats(string gender, string isKitten)
    {
      string result;
      if(isKitten.ToLower() == "true")
      {
        Task<string> apiCallTask = ApiHelper.CatGetAllBoth(gender, true);
        result = apiCallTask.Result;
      }
      else if (isKitten.ToLower() == "false")
      {
        Task<string> apiCallTask = ApiHelper.CatGetAllBoth(gender, false);
        result = apiCallTask.Result;
      }
      else
      {
        Task<string> apiCallTask = ApiHelper.CatGetAllGendered(gender);
        result = apiCallTask.Result;
      }

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Cat> catsList = JsonConvert.DeserializeObject<List<Cat>>(jsonResponse.ToString());
      return catsList;
    }

    public static Cat GetDetails(int id)
    {
      Task<string> apiCallTask = ApiHelper.CatGetDetails(id);
      string result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Cat cat = JsonConvert.DeserializeObject<Cat>(jsonResponse.ToString());
      return cat;
    }

  }
}