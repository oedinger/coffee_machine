using GenericMachine.DataModels;
using GenericMachine.Implementation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace GenericMachine.ViewModels
{
    public class CoffeMachineViewModel : ViewModelBase
    {
        #region Private Members

        private CoffeMachineControl _coffeMachineControl;

        #endregion

        #region Constructor

        public CoffeMachineViewModel(CoffeMachineControl CoffeMachineControl)
        {
            _coffeMachineControl = CoffeMachineControl;
            
            _orderHistory = new ObservableCollection<string>();
            _beverages = new List<BeverageData>(_coffeMachineControl.Data.Beverages.Values);
            _ingredients = new List<IngredientData>(_coffeMachineControl.Data.IngredientsInventory.Values);

            SelectedBeverage = Beverages.FirstOrDefault(p => p.IsEnabled);

            Brew = new Prism.Commands.DelegateCommand(OnBrew, CanBrew)
                .ObservesProperty(()=>SelectedBeverage);
        }

        #endregion

        #region Properties
                
        private List<BeverageData> _beverages;
        public List<BeverageData> Beverages 
        {
            get
            {                
                return _beverages;
            } 
        }

        private List<IngredientData> _ingredients;
        public List<IngredientData> Ingredients
        {
            get
            {
                return _ingredients;
            }
        }

        private BeverageData _selectedBeverage;
        public BeverageData SelectedBeverage 
        { 
            get
            {
                return _selectedBeverage;
            }
            set
            {
                if (_selectedBeverage != value)
                {
                    _selectedBeverage = value;
                    OnPropertyChanged("SelectedBeverage");
                }
            }
        }

        private ObservableCollection<string> _orderHistory;
        public ObservableCollection<string> OrderHistory 
        {
            get
            {
                return _orderHistory;
            }
            set
            {
                if (_orderHistory != value)
                {
                    _orderHistory = value;
                    OnPropertyChanged("OrderHistory");
                }
            }
        }

        #endregion

        #region Commands Handlers

        private void OnBrew()
        {
            try
            {
                _coffeMachineControl.Brew(SelectedBeverage);
                _orderHistory.Add($"{DateTime.Now} --- {SelectedBeverage.ToString()}");
                if (!SelectedBeverage.IsEnabled)
                {
                    var currSelectedBeverage = SelectedBeverage;
                    SelectedBeverage = Beverages.FirstOrDefault(p => p.IsEnabled);
                    currSelectedBeverage.IsEnabled = true;
                    currSelectedBeverage.IsEnabled = false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Order failure : {e.Message}");
            }
            
        }

        private bool CanBrew()
        {
            return SelectedBeverage != null;
        }

        #endregion

        #region ICommands

        public ICommand Brew { get; set; }

        #endregion
    }
}
