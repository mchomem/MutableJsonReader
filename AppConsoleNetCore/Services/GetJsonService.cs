using AppConsoleNetCore.Models;
using System.Text.Json;

namespace AppConsoleNetFramework.Services
{
    public class GetJsonService
    {
        public Costumer GetCostumerFromApiRestV1(string json)
        {
            ApiResponse? response = JsonSerializer.Deserialize<ApiResponse>(json);
            Costumer costumer = response.Costumer;

            if (((JsonElement)response.Costumer.Contract).ValueKind == JsonValueKind.Array)
                costumer.ContractList = ((JsonElement)response.Costumer.Contract).Deserialize<List<Contract>>();
            else
                costumer.ContractObject = ((JsonElement)response.Costumer.Contract).Deserialize<Contract>();

            return costumer;
        }
    }
}
