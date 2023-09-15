using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationnel
{
    public struct Rationnel : IComparable
    {
        private int denominateur;
        private int numerateur;

        public int Denominateur { get => this.denominateur; }
        public int Numerateur { get => this.numerateur; }

        public delegate void processusRationel(Rationnel obj);
        /// <summary>
        /// Constructeur de la classe Rationnel
        /// </summary>
        /// <param name="n">entier numérateur</param>
        /// <param name="d">entier dénominateur</param>
        public Rationnel(int n, int d)
        {
            if (d == 0)
            {
                throw new ExceptionsRationnel();
            }
            else
            {
                this.numerateur = n;
                this.denominateur = d;
            }
        }
        /// <summary>
        /// Surcharge de la méthode ToString()
        /// </summary>
        /// <returns>Un string représentant le Rationnel</returns>
        public override string ToString()
        {
            StringBuilder chaine = new StringBuilder();
            if ((this.Numerateur > 0 && this.Denominateur < 0) || (this.Numerateur < 0 && this.Denominateur < 0))
            {
                chaine.Append(this.Numerateur * -1);
                chaine.Append(" / ");
                chaine.Append(this.Denominateur * -1);
            }
            else
            {
                chaine.Append(this.Numerateur);
                chaine.Append(" / ");
                chaine.Append(this.Denominateur);
            }
            return chaine.ToString();
        }
        /// <summary>
        /// Conversion explicite d'un Rationnel en double
        /// </summary>
        /// <param name="rationnel">Rationnel à convertir</param>
        public static explicit operator double(Rationnel rationnel)
        {
            return (rationnel.Numerateur * 1.0) / (rationnel.Denominateur * 1.0);
        }
        /// <summary>
        /// Conversion implicite d'un int en Rationnel
        /// </summary>
        /// <param name="valeur">Int à convertir</param>
        public static implicit operator Rationnel(int valeur)
        {
            int numerateur = valeur;
            int denominateur = 1;
            return new Rationnel(numerateur, denominateur);
        }
        /// <summary>
        /// Surcharge de l'opérateur + pour les Rationnel
        /// </summary>
        /// <param name="premier">Premier Rationnel à Additionner</param>
        /// <param name="second">Second Rationnel à Additionner</param>
        /// <returns></returns>
        static public Rationnel operator +(Rationnel premier, Rationnel second)
        {
            int denominateurCommun = premier.Denominateur * second.Denominateur;
            int numerateurPremier = premier.Numerateur * second.Denominateur;
            int numerateurSecond = second.Numerateur * premier.Denominateur;
            int numerateur = numerateurPremier + numerateurSecond;
            return new Rationnel(numerateur, denominateurCommun);
        }
        /// <summary>
        /// Méthode permettant de réduire un Rationnel
        /// </summary>
        /// <param name="rationnel">Le Rationnel à réduire</param>
        /// <returns>Le Rationnel Réduit</returns>
        public static Rationnel Reduit(Rationnel rationnel)
        {
            int PGDC = MathUtil.PGCD(rationnel.Numerateur, rationnel.Denominateur);
            int numerateur = rationnel.Numerateur / PGDC;
            int denominateur = rationnel.Denominateur / PGDC;
            return new Rationnel(numerateur, denominateur);
        }
        /// <summary>
        /// Méthode permettant la comparaison de deux rationnel
        /// </summary>
        /// <param name="rationnel">Le rationnel à comparer avec l'objet courant</param>
        /// <returns>true or false</returns>
        public override bool Equals(object rationnel)
        {
            if (!(rationnel is Rationnel))
            {
                return false;
            }
            Rationnel reduit = Reduit(this);
            Rationnel objReduit = Reduit((Rationnel)rationnel);
            if (reduit.denominateur == objReduit.denominateur && reduit.numerateur == objReduit.numerateur)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Surcharge de l'operateur ==
        /// </summary>
        /// <param name="premier">Premier rationnel à vérifier</param>
        /// <param name="second">Second rationnel à vérifier</param>
        /// <returns>true or false</returns>
        static public bool operator ==(Rationnel premier, Rationnel second)
        {
            if (premier.Equals(second))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Surchage de l'operateur !=
        /// </summary>
        /// <param name="premier">Premier rationnel à vérifier</param>
        /// <param name="second">Second rationnel à vérifier</param>
        /// <returns>true or false</returns>
        static public bool operator !=(Rationnel premier, Rationnel second)
        {
            if (premier.Equals(second))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Méthode permettant de définir un hash d'un Rationnel
        /// </summary>
        /// <returns>Le Hash sous forme d'entier</returns>
        public override int GetHashCode()
        {
            return Convert.ToInt32(Math.Pow(this.Numerateur, this.Denominateur));
        }
        /// <summary>
        /// Méthode permettant de charge l'occurance d'un objet courant dans un tableau
        /// </summary>
        /// <param name="objs">Tableau à chercher</param>
        /// <returns>Les positions des occurences sous forme de tableau</returns>
        public int[] chercheOccurence(Rationnel[] objs)
        {
            List<int> liste = new List<int>();
            int position = 0;
            foreach (Rationnel obj in objs)
            {
                if (this.Numerateur * 1.0 / this.Denominateur == obj.Numerateur * 1.0 / obj.Denominateur)
                {
                    liste.Add(position);
                }
                position++;
            }
            int[] tableau = liste.ToArray();
            return tableau;
        }
        /// <summary>
        /// Méthode permettant l'utilisation d'un processus délégué sur un tableau
        /// </summary>
        /// <param name="process">Le processus délégue</param>
        /// <param name="objs">Le tableau de Rationnel</param>
        public void processRationnel(processusRationel process, Rationnel[] objs)
        {
            RationnelCollection rationnelCollection = new RationnelCollection(objs);
            RationnelEnum rationnelEnum = rationnelCollection.GetEnumerator();
            rationnelEnum.MoveNext();
            for (int i = 0; i < objs.Length; i++)
            {
                if (rationnelEnum.Current.Equals(this))
                {
                    process((Rationnel)rationnelEnum.Current);
                }
                rationnelEnum.MoveNext();
            }
            /*IEnumerator enumerator = objs.GetEnumerator();
            enumerator.MoveNext();
            for (int i = 0; i < objs.Length; i++)
            {
                if (enumerator.Current.Equals(this))
                {
                    process((Rationnel)enumerator.Current);
                }
                enumerator.MoveNext();
            }*/

           /* foreach (Rationnel obj in objs)
            {
                if (obj.Equals(this))
                {
                    process(obj);
                }
            }*/
        }
        /// <summary>
        /// La méthode déléguée de processusRationnel
        /// </summary>
        /// <param name="obj">Un rationnel</param>
        public static void methode(Rationnel obj)
        {
            Console.WriteLine(obj.ToString());
        }
        /// <summary>
        /// Méthode permettant de comparer deux rationnel, nécessaire à IComparable
        /// </summary>
        /// <param name="rationnel">Rationnel à comparer avec l'objet courant</param>
        /// <returns>-1, 0 ou 1</returns>
        public int CompareTo(object rationnel)
        {
            if (!(rationnel is Rationnel))
            {
                return -1;
            }
            Rationnel reduit = Reduit(this);
            Rationnel objReduit = Reduit((Rationnel)rationnel);
            double doublereduit = (double)reduit;
            double doubleObjReduit = (double)objReduit;
            return doublereduit.CompareTo(doubleObjReduit);
        }
    }
}
