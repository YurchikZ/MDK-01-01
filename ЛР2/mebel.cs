using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace жЕСТЬ
{
    public class mebel
    {
        string mebelname;
        double mebelvalue;

        public void getnames(string n)
        {
            mebelname = n;
        }
        public string getvaluestring()
        {
            return mebelname;
        }
        public void Setvalue(double v)
        {
            v = mebelvalue;
        }
        public mebel(string NAMESS, double PRICEE)
        {
            mebelname = NAMESS;
            mebelvalue = PRICEE;
        }
    }
}
