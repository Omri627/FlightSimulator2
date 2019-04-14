using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    class ManualViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private SymbolTable symbolTable;
        public ManualViewModel() {
            symbolTable = SymbolTable.Instance;
            symbolTable.PropertyChanged += delegate(object sender, PropertyChangedEventArgs args)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(args.PropertyName));
            };
        }
        public double Rudder
        {
            get {
                return symbolTable[SymbolTable.RUDDER];
            }
            set {
                if (value >= 0 && value <= 1)
                {
                    symbolTable[SymbolTable.RUDDER] = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Rudder"));

                }
            }
        }
        public double Elevator
        {
            get {
                return symbolTable[SymbolTable.ALEVATOR];
            }
            set {
                if (value >= 0 && value <= 1)
                {
                    symbolTable[SymbolTable.ALEVATOR] = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Elevator"));
                }
            }
        }
        public double Throttle
        {
            get {
                return symbolTable[SymbolTable.THROTTLE];
            }
            set {
                if (value >= 0 && value <= 1)
                {
                    symbolTable[SymbolTable.THROTTLE] = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Throttle"));
                }
            }
        }
        public double Aileron
        {
            get {
                return symbolTable[SymbolTable.AILERON];
            }
            set {
                if (value >= 0 && value <= 1)
                {
                    symbolTable[SymbolTable.AILERON] = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Aileron"));
                }
            }
        }
    }
}