using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagedDataSet
{
    class IncorrectPageNoException:Exception
    {
        public IncorrectPageNoException() : base("Page No may be zero or less than zero that causes error")
        {

        }
       
    }
}
