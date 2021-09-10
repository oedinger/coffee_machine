using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace GenericMachine.DataModels
{
    public class IngredientData: ViewModelBase
    {
        public string Name { get; set; }

        public int LowLevelIndicatorAmount { get; set; }
        
        private int _availableAmount;
        public int AvailableAmount
        {
            get
            {
                return _availableAmount;
            }
            set
            {
                if (_availableAmount != value)
                {
                    _availableAmount = value;
                    OnPropertyChanged("AvailableAmount");
                    OnPropertyChanged("IsLowLevel");
                }
            }
        }

        [JsonIgnore]
        public bool IsLowLevel
        {
            get
            {
                return _availableAmount <= LowLevelIndicatorAmount;
            }
        }


    }


    public class BeverageData : ViewModelBase
    {
        public string Name { get; set; }

        public string ImagePath { get; set; }

        public Dictionary<string, int> Recipe { get; set; }
        
        private bool _isEnabled = false;        
        [JsonIgnore]
        public bool IsEnabled 
        {
            get
            {
                return _isEnabled;
            } 
            set
            {
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                    OnPropertyChanged("IsEnabled");
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Name);
            sb.Append(" : ");

            foreach (var recipeItem in Recipe)
            {
                sb.Append($"{recipeItem.Value} x {recipeItem.Key},");
            }
            var str = sb.Remove(sb.Length - 1, 1).ToString();
            return str;
        }
    }
}
