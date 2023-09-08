using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationnel
{
    class ExceptionsRationnel : Exception
    {
        public override string Message
        {
            get
            {
                return "Impossible de diviser par 0";
            }
        }
    }
}
