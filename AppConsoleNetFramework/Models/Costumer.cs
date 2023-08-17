using System.Collections.Generic;

namespace AppConsoleNetFramework.Models
{
    public class Costumer
    {
        #region Propriedades originais do JSON

        public string Name { get; set; }
        public dynamic Contract { get; set; } // <====

        #endregion

        #region Propriedades computadas a partir de um JSON com retorno dinâmico.

        public Contract ContractObject { get; set; } // TODO: melhorar nome!

        public List<Contract> ContractList { get; set; } // TODO: melhorar nome!

        #endregion
    }
}
