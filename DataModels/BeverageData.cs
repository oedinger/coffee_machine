using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace GenericMachine.DataModels
{
    public class ConfigData
    {
        public static string ConfigDirPath { get; set; }
    }

    public enum AmountLevel { High, Low, Empty }

    public class CommonData : ViewModelBase
    {
        public string Name { get; set; }

        public string ImagePath { get; set; }

        [JsonIgnore]
        public string ImageFullPath { get => File.Exists(ImagePath) ? ImagePath : Path.Combine(ConfigData.ConfigDirPath, ImagePath); }
    }

    public class IngredientData: CommonData
    {
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
                    OnPropertyChanged("AvailableAmountLevel");
                }
            }
        }

        [JsonIgnore]
        public AmountLevel AvailableAmountLevel
        {
            get
            {
                if (_availableAmount == 0)
                    return AmountLevel.Empty;
                if (_availableAmount > 0 && _availableAmount <= LowLevelIndicatorAmount)
                    return AmountLevel.Low;

                return AmountLevel.High;
            }
        }
    }


    public class BeverageData : CommonData
    {     
        public Dictionary<string, int> Ingredients { get; set; }
        
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

            foreach (var IngredientsItem in Ingredients)
            {
                sb.Append($"{IngredientsItem.Value} x {IngredientsItem.Key},");
            }
            var str = sb.Remove(sb.Length - 1, 1).ToString();
            return str;
        }
    }
}
