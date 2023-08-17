using AppConsoleNetFramework.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace AppConsoleNetFramework.Services
{
    public class GetJsonService
    {
        public Costumer GetCostumerFromApiRestV1(string json)
        {
            ApiResponse response = JsonConvert.DeserializeObject<ApiResponse>(json);
            Costumer costumer = response.Costumer;

            // Faz a tratativa por propriedade e define se é array ou objeto json.
            if (response.Costumer.Contract is JArray)
                // CASTING: array.
                costumer.ContractList = ((JArray)response.Costumer.Contract).ToObject<List<Contract>>();
            else
                // CASTING: object
                costumer.ContractObject = ((JObject)response.Costumer.Contract).ToObject<Contract>();

            return costumer;
        }
        public Costumer GetCostumerFromApiRestV2(string json)
        {
            ApiResponse response = JsonConvert.DeserializeObject<ApiResponse>(json);
            Costumer costumer = response.Costumer;

            // Faz a tratativa por propriedade e define se é array ou objeto json.
            if (response.Costumer.Contract is JArray)
                // CASTING array: mais fléxivel.
                costumer.ContractList = ((JArray)response.Costumer.Contract)
                    .Select(jsonToken => new Contract()
                    {
                        // CASTING: mapeando cada propriedade do objeto
                        Id = (int)jsonToken["Id"],
                        Name = (string)jsonToken["Name"],
                        Value = (double)jsonToken["Value"]
                    })
                    .ToList();
            else
                // CASTING: object
                costumer.ContractObject = ((JObject)response.Costumer.Contract).ToObject<Contract>();

            return costumer;
        }
    }
}
