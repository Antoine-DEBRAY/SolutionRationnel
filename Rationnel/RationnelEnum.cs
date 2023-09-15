using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationnel
{   /// <summary>
/// Classe Enumerator pour la classe RationnelCollection
/// </summary>
    public class RationnelEnum : IEnumerator
    {/// <summary>
    /// Tableau de rationnel
    /// </summary>
        public Rationnel[] _rationnel;

        int position = -1;

        /// <summary>
        /// Constructeur de la classe RationnelEnum
        /// </summary>
        /// <param name="list">Tableau de rationnel</param>
        public RationnelEnum(Rationnel[] list)
        {
            _rationnel = list;
        }

        /// <summary>
        /// Méthode permettant de passer au suivant dans le tableau de rationnel
        /// </summary>
        /// <returns>true or false</returns>
        public bool MoveNext()
        {
            position++;
            return (position < _rationnel.Length);
        }

        /// <summary>
        /// Méthode permettant de reset la position dans la tableau
        /// </summary>
        public void Reset()
        {
            position = -1;
        }

        /// <summary>
        /// Méthode retournant l'objet courant
        /// </summary>
        public object Current
        {
            get
            {
                try
                {
                    return _rationnel[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
