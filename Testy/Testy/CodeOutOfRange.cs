using System;
using System.Collections.Generic;
using System.Text;

namespace Testy
{
    public class CodeOutOfRange :Exception
    {
        public CodeOutOfRange():base("Kod spoza zakresu")
        {
           
        }
    }
}
