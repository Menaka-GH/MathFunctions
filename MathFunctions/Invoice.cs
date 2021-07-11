using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace MathFunctions
{

    public class RootObject
    {
        public Invoice[] Invoice { get; set; }
    }

    public class Invoice
    {
        public string AccountNo { get; set; }
        public string Month { get; set; }
        public int Usage { get; set; }
        public double Cost { get; set; }
    }

}
