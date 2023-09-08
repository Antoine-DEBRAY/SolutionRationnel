using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationnel
{
    public struct Rationnel
    {
        private int denominateur;
        private int numerateur;

        public int Denominateur { get => this.denominateur; }
        public int Numerateur { get => this.numerateur; }
        public Rationnel(int n, int d)
        {
            if (d == 0)
            {
                throw new DivideByZeroException("Le dénominateur ne peut pas être nul");
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
            return new Rationnel(valeur, denominateur);
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
    }
}
