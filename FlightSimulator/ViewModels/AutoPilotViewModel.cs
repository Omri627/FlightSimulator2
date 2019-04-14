using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    class AutoPilotViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private AutoPilotModel model;
        private string code;
        private string color;
        public AutoPilotViewModel()
        {
            model = new AutoPilotModel();
        }
        public string Code {
            get {
                return code;
            }
            set {
                code = value;
                if (code != string.Empty)
                    Color = "Salmon";
                else
                    Color = "White";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Code"));
            }
        }
        public string Color
        {
            get {
                return color;
            }
            set {
                color = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Color"));
            }
        }
        #region Commands
        #region CancelCommand
        private ICommand _cancelCommand;
        public ICommand CancelCommand
        {
            get {
                return _cancelCommand ?? (_cancelCommand = new CommandHandler(() => OnCancel()));
            }
        }
        private void OnCancel()
        {
            Code = "";
            Color = "White";
        }
        #endregion
        #region
        private ICommand _okCommand;
        public ICommand OkCommand
        {
            get
            {
                return _okCommand ?? (_okCommand = new CommandHandler(() => OnOk()));
            }
        }
        private void OnOk()
        {
            model.ExecuteCode(code);
            Color = "White";
            Code = "";
        }

        #endregion
        #endregion
    }
}
