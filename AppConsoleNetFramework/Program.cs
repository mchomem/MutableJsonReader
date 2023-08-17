using AppConsoleNetFramework.Models;
using AppConsoleNetFramework.Services;
using System;

namespace AppConsoleNetFramework
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Mutable Json - Net Framework";

            string json1 = @"{
                                ""Costumer"": {
                                    ""Name"": ""João Gilberto"",
                                    ""Contract"": {
                                        ""Id"": 1,
                                        ""Name"": ""Contract ABC"",
                                        ""Value"": 100.23
                                    }
                                }
                            }";

            string json2 = @"{
                                ""Costumer"": {
                                    ""Name"": ""Dias Neves"",
                                    ""Contract"": [
                                        {
                                            ""Id"": 20,
                                            ""Name"": ""Contract ABC"",
                                            ""Value"": 1000.50
                                        },
                                        {
                                            ""Id"": 30,
                                            ""Name"": ""Contract MAT"",
                                            ""Value"": 1000.50
                                        },
                                        {
                                            ""Id"": 40,
                                            ""Name"": ""Contract OBJ"",
                                            ""Value"": 1000.50
                                        },
                                        {
                                            ""Id"": 50,
                                            ""Name"": ""Contract TNT"",
                                            ""Value"": 1000.50
                                        },
                                        {
                                            ""Id"": 60,
                                            ""Name"": ""Contract AZV"",
                                            ""Value"": 1000.50
                                        }
                                    ]
                                }
                            }";

            // Obtem do MokaApiRest o objeto tratado.
            Costumer costumer1 = new GetJsonService().GetCostumerFromApiRestV1(json1);
            Costumer costumer2 = new GetJsonService().GetCostumerFromApiRestV1(json2);

            // Leitura.
            Console.WriteLine($"Costumer: {costumer1.Name}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\tContract");
            Console.WriteLine($"\t\tID: {costumer1.ContractObject.Id}");
            Console.WriteLine($"\t\tNAME: {costumer1.ContractObject.Name}");
            Console.WriteLine($"\t\tVALUE: {costumer1.ContractObject.Value}");
            Console.ForegroundColor = ConsoleColor.Gray;

            /*------------------------------------------------------------*/
            Console.WriteLine();
            /*------------------------------------------------------------*/

            Console.WriteLine($"Costumer: {costumer2.Name}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\tContract");

            foreach (var contract in costumer2.ContractList)
            {
                Console.WriteLine($"\t\tID: {contract.Id}");
                Console.WriteLine($"\t\tNAME: {contract.Name}");
                Console.WriteLine($"\t\tVALUE: {contract.Value}");
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }
    }
}
