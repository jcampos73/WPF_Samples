using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using Microsoft.Practices.Prism.Commands;

namespace WpfApplication1
{
    public class CustomerViewModel : INotifyPropertyChanged // Point 1
    {

        private Customer obj = new Customer();
        //private ButtonCommand objCommand;
        private DelegateCommand objCommand;

        public CustomerViewModel()
        {
            //objCommand = new ButtonCommand(this.Calculate,obj.IsValid);
            objCommand = new DelegateCommand(this.Calculate, obj.IsValid);
        }

        public string TxtCustomerName
        {
            get { return obj.CustomerName; }
            set { obj.CustomerName = value; }
        }

        public string TxtAmount
        {
            get {
                RaisePropertyChanged("LblAmountColor");
                return Convert.ToString(obj.Amount);
            }
            set { obj.Amount = Convert.ToDouble(value); }
        }

        public string TxtTax
        {
            get {
                return Convert.ToString(obj.Tax);
            }
        }

        public string LblAmountColor
        {
            get
            {
                if (obj.Amount > 2000)
                {
                    return "Blue";
                }
                else if (obj.Amount > 1500)
                {
                    return "Red";
                }
                return "Yellow";
            }
        }

        public bool IsMarried
        {
            get
            {
                if (obj.Married == "Married")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                if (value) obj.Married = "Married";
                else obj.Married = "Single";
            }
        }

        public void Calculate()
        {
            obj.CalculateTax();

            RaisePropertyChanged("TxtTax");

            /*
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("TxtTax"));
                // Point 3
            }
            */
        }

        public void RaisePropertyChanged(string propertyName)
        {

            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));

        }

        public ICommand btnClick // Point 3
        {
            get
            {
                return objCommand;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


    }
}
