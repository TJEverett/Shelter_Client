using System.Threading.Tasks;
using RestSharp;

namespace ShelterClient.Models
{
  class ApiHelper
  {
    private static string apiRoute = "http://localhost:5000/api";

    // Login Routes
    public static async Task<string> Login(string userInfo)
    {
      RestClient client = new RestClient(apiRoute);
      RestRequest request = new RestRequest("login/login", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(userInfo);
      IRestResponse response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task LoginPost(string userInfo, string token)
    {
      RestClient client = new RestClient(apiRoute);
      RestRequest request = new RestRequest("login/new", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", $"Bearer {token}");
      request.AddJsonBody(userInfo);
      IRestResponse response = await client.ExecuteTaskAsync(request);
    }

    public static async Task LoginDelete(string userInfo, string token)
    {
      RestClient client = new RestClient(apiRoute);
      RestRequest request = new RestRequest("login/delete", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", $"Bearer {token}");
      request.AddJsonBody(userInfo);
      IRestResponse response = await client.ExecuteTaskAsync(request);
    }

    // Cat Routes
    public static async Task<string> CatGetAllGendered(string gender)
    {
      RestClient client = new RestClient(apiRoute);
      RestRequest request = new RestRequest($"cats?gender={gender}", Method.GET);
      IRestResponse response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> CatGetAllBoth(string gender, bool isKitten)
    {
      RestClient client = new RestClient(apiRoute);
      RestRequest request = new RestRequest($"cats?gender={gender}&isKitten={isKitten}", Method.GET);
      IRestResponse response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> CatGetDetails(int id)
    {
      RestClient client = new RestClient(apiRoute);
      RestRequest request = new RestRequest($"cats/{id}", Method.GET);
      IRestResponse response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task CatPost(string newCat, string token)
    {
      RestClient client = new RestClient(apiRoute);
      RestRequest request = new RestRequest("cats", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", $"Bearer {token}");
      request.AddJsonBody(newCat);
      IRestResponse response = await client.ExecuteTaskAsync(request);
    }

    public static async Task CatPut(int id, string newCat, string token)
    {
      RestClient client = new RestClient(apiRoute);
      RestRequest request = new RestRequest($"cats/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", $"Bearer {token}");
      request.AddJsonBody(newCat);
      IRestResponse response = await client.ExecuteTaskAsync(request);
    }

    public static async Task CatDelete(int id, string token)
    {
      RestClient client = new RestClient(apiRoute);
      RestRequest request = new RestRequest($"cats/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", $"Bearer {token}");
      IRestResponse response = await client.ExecuteTaskAsync(request);
    }

    // Dog Routes
    public static async Task<string> DogGetAllGendered(string gender)
    {
      RestClient client = new RestClient(apiRoute);
      RestRequest request = new RestRequest($"dogs?gender={gender}", Method.GET);
      IRestResponse response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> DogGetAllBoth(string gender, bool isPuppy)
    {
      RestClient client = new RestClient(apiRoute);
      RestRequest request = new RestRequest($"dogs?gender={gender}&isPuppy={isPuppy}", Method.GET);
      IRestResponse response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> DogGetDetails(int id)
    {
      RestClient client = new RestClient(apiRoute);
      RestRequest request = new RestRequest($"dogs/{id}", Method.GET);
      IRestResponse response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task DogPost(string newDog, string token)
    {
      RestClient client = new RestClient(apiRoute);
      RestRequest request = new RestRequest("dogs", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", $"Bearer {token}");
      request.AddJsonBody(newDog);
      IRestResponse response = await client.ExecuteTaskAsync(request);
    }
  }
}