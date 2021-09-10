﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GenericMachine.DataModels;
using GenericMachine.Implementation;
using GenericMachine.ViewModels;

namespace GenericMachine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }

        private CoffeMachineViewModel _BeveragesVM;
        public CoffeMachineViewModel BeveragesVM 
        {
            get
            {
                return _BeveragesVM;
            } 
            set
            {
                if (_BeveragesVM != value)
                {
                    _BeveragesVM = value;                    
                    NotifyPropertyChanged("BeveragesVM");
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            
            var CoffeMachineControl = new CoffeMachineControl(@"C:\Work\git\coffee_machine\Data\CoffeMachine.json");
            
            BeveragesVM = new CoffeMachineViewModel(CoffeMachineControl);
            this.DataContext = BeveragesVM;

            //var CoffeeMachineData = new CoffeeMachineData();
            //CoffeeMachineData.Beverages = new Dictionary<string, BeverageData>();
            //CoffeeMachineData.Beverages.Add("black_coffee", new BeverageData()
            //{
            //    FullName = "Black Coffee",
            //    Recipe = new Dictionary<string, int>()
            //    {
            //        {"hot_water", 1} ,
            //        {"coffee", 2}
            //    }
            //});
            //CoffeeMachineData.Inventory = new Dictionary<string, IngredientData>()
            //{
            //    {"hot_water", new IngredientData()
            //                  {
            //                    Name = "Hot Water",
            //                    AvailableAmount = 10
            //                  }
            //    }
            //};

            //var str = JsonSerializer.Serialize(CoffeeMachineData, new JsonSerializerOptions
            //{
            //    WriteIndented = true
            //});
            //File.WriteAllText(@"C:\work\Tests\GenericMachine\CoffeMachine1.json", str);
        }
    }
}
