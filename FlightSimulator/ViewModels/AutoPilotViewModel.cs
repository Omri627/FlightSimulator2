using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    class AutoPilotViewModel
    {
        private string code;
        public AutoPilotViewModel()
        {
            code = "Auto pilot text";
        }
        public string Code {
            get {
                return code;
            }
            set {
                code = value;
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
        }
        #endregion
        #endregion
    }
}
