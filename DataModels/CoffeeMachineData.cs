using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GenericMachine.DataModels
{
    public class CoffeeMachineData
    {        
        public Dictionary<string, BeverageData> Beverages { get; set; }

        public Dictionary<string,IngredientData> IngredientsInventory { get; set; }

    }

}
