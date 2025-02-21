﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericMachine.DataModels;

namespace GenericMachine.Interfaces
{
    public interface ICoffeMachineControl
    {
        CoffeeMachineData Data { get; set; }

        void Brew(BeverageData BeverageData);
  
    }
}
