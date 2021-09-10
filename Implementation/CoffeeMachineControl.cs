using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GenericMachine.DataModels;
using GenericMachine.Interfaces;

namespace GenericMachine.Implementation
{
    public class CoffeMachineControl : ICoffeMachineControl
    {
        #region Private Members

        private readonly string _jsonPath;

        #endregion

        #region Constructor

        public CoffeMachineControl(string jsonPath)
        {
            _jsonPath = jsonPath;

            ConfigData.ConfigDirPath = Path.GetDirectoryName(jsonPath);
            var json = File.ReadAllText(jsonPath);            
            this.Data = JsonSerializer.Deserialize<CoffeeMachineData>(json);

            ValidateBeveragesAvailability();
        }

        #endregion

        #region Properties

        public CoffeeMachineData Data { get; set; }

        #endregion

        #region Methods

        public void Brew(BeverageData BeverageData)
        {            
            UpdateIngredientsInventory(BeverageData);
        }

        #endregion


        #region Private Methods

        private void UpdateIngredientsInventory(BeverageData BeverageData)
        {
            foreach (var IngredientsItem in BeverageData.Ingredients)
            {
                Data.IngredientsInventory[IngredientsItem.Key].AvailableAmount -= IngredientsItem.Value;
            }

            ValidateBeveragesAvailability();

            var json = JsonSerializer.Serialize(Data, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(_jsonPath, json);
        }

        private void ValidateBeveragesAvailability()
        {
            foreach (var BeverageItem in Data.Beverages)
            {
                var isBeverageEnabled = true;
                var BeverageData = BeverageItem.Value;
                foreach (var IngredientsItem in BeverageData.Ingredients)
                {
                    if (!Data.IngredientsInventory.ContainsKey(IngredientsItem.Key) || 
                         Data.IngredientsInventory[IngredientsItem.Key].AvailableAmount < IngredientsItem.Value)
                    {
                        isBeverageEnabled = false;
                        break;
                    }
                }

                BeverageData.IsEnabled = isBeverageEnabled;
            }
        }


        #endregion
    }
}
