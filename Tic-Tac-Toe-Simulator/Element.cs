using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Tic_Tac_Toe_Simulator
{
    public class Element : INotifyPropertyChanged
    {
        private string _position;
        private int _value;
        public string Position
        {
            get { return _position; }
            set { _position = value; NotifyPropertyChanged(); }
        }
        public int Value
        {
            get { return _value; }
            set { _value = value; NotifyPropertyChanged(); }
        }
        #region INotifyPropertyChanged Members

        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
