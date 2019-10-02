using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagedDataSet
{
    class EmptyDataSetException:Exception
    { public EmptyDataSetException() : base("Empty Dataset Not Accepted")
        {

        }
    }
}
