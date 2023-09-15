using System;
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
        public override string ToString()
        {
            StringBuilder chaine = new StringBuilder();
            if ((this.Numerateur > 0 && this.Denominateur < 0) || (this.Numerateur < 0 && this.Denominateur < 0))
            {
                chaine.Append(this.Numerateur * -1);
                chaine.Append(" / ");
                chaine.Append(this.Denominateur * -1);
            }
            else { 
            chaine.Append(this.Numerateur);
            chaine.Append(" / ");
            chaine.Append(this.Denominateur);
            }
            return chaine.ToString();
        }
        public static explicit operator double(Rationnel rationnel)
        {
            return (rationnel.Numerateur * 1.0) / (rationnel.Denominateur * 1.0);
        }
        public static implicit operator Rationnel(int valeur)
        {
            int numerateur = valeur;
            int denominateur = 1;
            return new Rationnel(numerateur, denominateur);
        }
        static public Rationnel operator +(Rationnel premier, Rationnel second)
        {
            int denominateurCommun = premier.Denominateur * second.Denominateur;
            int numerateurPremier = premier.Numerateur * second.Denominateur;
            int numerateurSecond = second.Numerateur * premier.Denominateur;
            int numerateur = numerateurPremier + numerateurSecond;
            return new Rationnel(numerateur, denominateurCommun);
        }
        public static Rationnel Reduit(Rationnel rationnel)
        {
            int PGDC = MathUtil.PGCD(rationnel.Numerateur, rationnel.Denominateur);
            int numerateur = rationnel.Numerateur / PGDC;
            int denominateur = rationnel.Denominateur / PGDC;
            return new Rationnel(numerateur, denominateur);
        }
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
        static public bool operator ==(Rationnel premier, Rationnel second)
        {
            if (premier.Equals(second))
            {
                return true;
            }
            return false;
        }
        static public bool operator !=(Rationnel premier, Rationnel second)
        {
            if (premier.Equals(second))
            {
                return false;
            }
            return true;
        }
        public override int GetHashCode()
        {
            return Convert.ToInt32(Math.Pow(this.Numerateur, this.Denominateur));
        }
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
        public void processRationnel(processusRationel process, Rationnel[] objs)
        {
            foreach (Rationnel obj in objs)
            {
                if (obj.Equals(this)){
                    process(obj);
                }
            }
        }
        public static void methode(Rationnel obj)
        {
            Console.WriteLine(obj.ToString());
        }

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
