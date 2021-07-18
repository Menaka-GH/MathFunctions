using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathFunctions
{
    class Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public void ShowDimension()
        {
            Console.WriteLine("Width: " + Width + "Height: " + Height);
        }
    }
}
