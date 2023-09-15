using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationnel
{
    public class RationnelCollection : IEnumerable
    {
        private Rationnel[] _rationnelcollection;
        public RationnelCollection(Rationnel[] rArray)
        {
            _rationnelcollection = new Rationnel[rArray.Length];

            for (int i = 0; i < rArray.Length; i++)
            {
                _rationnelcollection[i] = rArray[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }
        public RationnelEnum GetEnumerator()
        {
            return new RationnelEnum(_rationnelcollection);
        }
    }
}
