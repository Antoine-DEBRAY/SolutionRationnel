using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationnel
{   /// <summary>
/// Classe Collection pour la classe Rationnel
/// </summary>
    public class RationnelCollection : IEnumerable
    {
        private Rationnel[] _rationnelcollection;

        /// <summary>
        /// Constructeur de la classe RationnelCollection
        /// </summary>
        /// <param name="rArray"></param>
        public RationnelCollection(Rationnel[] rArray)
        {
            _rationnelcollection = new Rationnel[rArray.Length];

            for (int i = 0; i < rArray.Length; i++)
            {
                _rationnelcollection[i] = rArray[i];
            }
        }

        /// <summary>
        /// Méthode permettant de récupérer l'énumerator
        /// </summary>
        /// <returns>Un objet de type IEnumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }

        /// <summary>
        /// Méthode permettant de récupérer l'énumerator
        /// </summary>
        /// <returns>Un objet de type RationnelEnum</returns>
        public RationnelEnum GetEnumerator()
        {
            return new RationnelEnum(_rationnelcollection);
        }
    }
}
