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

        public int Denominateur { get => denominateur; }
        public int Numerateur { get => numerateur; }
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
            chaine.Append(numerateur);
            chaine.Append(" / ");
            chaine.Append(denominateur);
            return chaine.ToString();
        }
    }
}
