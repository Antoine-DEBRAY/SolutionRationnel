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
            chaine.Append(this.Numerateur);
            chaine.Append(" / ");
            chaine.Append(this.Denominateur);
            return chaine.ToString();
        }
        public static explicit operator double(Rationnel rationnel)
        {
            return (rationnel.Numerateur * 1.0) / (rationnel.Denominateur * 1.0);
        }
    }
}
