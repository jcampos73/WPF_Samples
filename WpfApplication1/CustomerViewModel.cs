using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;

namespace WpfApplication1
{
    public class CustomerViewModel : INotifyPropertyChanged // Point 1
    {
        private Customer obj = new Customer();

        private ButtonCommand objCommand; //  Point 1
        public CustomerViewModel()
        {
            objCommand = new ButtonCommand(this); // Point 2
           
        }

        public string TxtCustomerName
        {
            get { return obj.CustomerName; }
            set { obj.CustomerName = value; }
        }

        public string TxtAmount
        {
            get { return Convert.ToString(obj.Amount); }
            set { obj.Amount = Convert.ToDouble(value); }
        }

        public string TxtTax
        {
            get {
                
                //RaisePropertyChanged("TxtTax");

                return Convert.ToString(obj.Tax);
            }
            set

            {

                //_firstName = value;

                //RaisePropertyChanged("TxtTax");

            }
        }

        public void RaisePropertyChanged(string propertyName)
        {

            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));

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

        }

        public void Calculate()
        {
            obj.CalculateTax();

            RaisePropertyChanged("TxtTax");

            if (PropertyChanged != null) // Point 2
            {
                PropertyChanged(this, new PropertyChangedEventArgs("TxtTax"));
                // Point 3
            }
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
