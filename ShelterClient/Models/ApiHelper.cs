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
  }
}