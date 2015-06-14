using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Customer
    {
        private String CustomerName_ ;

        public String CustomerName
        {
            get { return CustomerName_; }
            set { CustomerName_ = value; }
        }
        private double Amount_;

        public double Amount
        {
            get { return Amount_; }
            set { Amount_ = value; }
        }
        private String Married_;

        public String Married
        {
            get { return Married_; }
            set { Married_ = value; }
        }

        private double _Tax;
        public double Tax
        {
            get { return _Tax; }
        }
        public void CalculateTax()
        {
            if (Amount > 2000)
            {
                _Tax = 20;
            }
            else if (Amount > 1000)
            {
                _Tax = 10;
            }
            else
            {
                _Tax = 5;
            }
        }

        public bool IsValid()
        {
            if (Amount == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
