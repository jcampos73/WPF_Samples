using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Customer
    {
        public String CustomerName="pepito";
        public double Amount = 3000;
        public String Married;

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
    }
}
