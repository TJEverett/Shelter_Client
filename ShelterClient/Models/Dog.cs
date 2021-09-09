using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ShelterClient.Models
{
  public class Dog : Animal
  {
    public int DogId { get; set; }
    public string Breed { get; set; }

    public static List<Dog> GetDogs(string gender, string isPuppy)
    {
      string result;
      if(isPuppy.ToLower() == "true")
      {
        Task<string> apiCallTask = ApiHelper.DogGetAllBoth(gender, true);
        result = apiCallTask.Result;
      }
      else if(isPuppy.ToLower() == "false")
      {
        Task<string> apiCallTask = ApiHelper.DogGetAllBoth(gender, false);
        result = apiCallTask.Result;
      }
      else
      {
        Task<string> apiCallTask = ApiHelper.DogGetAllGendered(gender);
        result = apiCallTask.Result;
      }

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Dog> dogsList = JsonConvert.DeserializeObject<List<Dog>>(jsonResponse.ToString());
      return dogsList;
    }

    public static Dog GetDetails(int id)
    {
      Task<string> apiCallTask = ApiHelper.DogGetDetails(id);
      string result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Dog dog = JsonConvert.DeserializeObject<Dog>(jsonResponse.ToString());
      return dog;
    }

  }
}