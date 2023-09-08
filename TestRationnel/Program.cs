using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRationnel
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Construction de 2 objets de type Rationnel
                Rationnel.Rationnel premierRationnel = new Rationnel.Rationnel(5, -8);
                Rationnel.Rationnel secondRationnel = new Rationnel.Rationnel(-2, -4);

                // Test de la surcharge de la méthode ToString();
                Console.WriteLine("*** TEST DE LA METHODE ToString() ***");
                Console.WriteLine("Voici le premier Rationnel : " + premierRationnel.ToString());
                Console.WriteLine("Voici le second Rationnel : " + secondRationnel.ToString() + "\n");

                // Test des propriétés sur les deux objets Rationnel
                Console.WriteLine("*** TEST DES PROPRIETES DES OBJETS ***");
                Console.WriteLine("Le numérateur du premier Rationnel vaut : " + premierRationnel.Numerateur);
                Console.WriteLine("Le dénominateur du second Rationnel vaut : " + secondRationnel.Denominateur + "\n");

                // Test de la conversion explicite d'un rationnel en double
                Console.WriteLine("*** TEST CONVERSION EXPLICITE ***");
                double monDouble = (double)premierRationnel;
                Console.WriteLine("Mon double ainsi crée vaut : " + monDouble + "\n");

                // Test de la conversion implicite d'un int en rationnel
                Console.WriteLine("*** TEST CONVERSION IMPLICITE ***");
                int monInt = 6;
                Rationnel.Rationnel impliciteRationnel = monInt;
                Console.WriteLine("Mon Rationnel ainsi crée correspond à : " + impliciteRationnel + "\n");

                // Test de la surcharge de l'opérateur '+'
                Console.WriteLine("*** TEST DE LA SURCHARGE DE L'ADDITION ***");
                Rationnel.Rationnel additionRationnel = premierRationnel + secondRationnel;
                Console.WriteLine("Mon rationnel additionné vaut ainsi : " + additionRationnel + "\n");

                // Test de la méthode Réduit
                Console.WriteLine("*** TEST DE LA METHODE REDUIT ***");
                Rationnel.Rationnel reduitRationnel = Rationnel.Rationnel.Reduit(additionRationnel);
                Console.WriteLine("Le rationnel précédemment additioné vaut réduit : " + reduitRationnel + "\n");

                // Test de la surcharge de la méthode Equals()
                Console.WriteLine("*** TEST DE LA SURCHARGE DE LA METHODE Equals() ***");
                Rationnel.Rationnel identique1 = new Rationnel.Rationnel(5, 8);
                Rationnel.Rationnel identique2 = new Rationnel.Rationnel(5, 8);
                bool egalite = identique1.Equals(identique2);
                Console.WriteLine("L'égalité entre " + identique1 + " et " + identique2 + " est " + egalite + "\n");

                // Test de la surcharge de l'opérateur '=='
                Console.WriteLine("*** TEST DE LA SURCHARGE DE L'OPERATEUR == ***");
                bool egalite2 = (identique1 == identique2);
                Console.WriteLine("L'égalité entre " + identique1 + " et " + identique2 + " est " + egalite2 + "\n");

                // Test de la surcharge de l'opérateur '!='
                Console.WriteLine("*** TEST DE LA SURCHARGE DE L'OPERATEUR != ***");
                bool difference = (identique1 != identique2);
                Console.WriteLine("La différence entre " + identique1 + " et " + identique2 + " est " + difference + "\n");

                // Test de la méthode chercheOccurence
                Console.WriteLine("*** TEST DE LA METHODE CHERCHEOCCURENCE ***");
                Rationnel.Rationnel occurence = new Rationnel.Rationnel(2, 3);
                Rationnel.Rationnel[] tableau = new Rationnel.Rationnel[] {
                new Rationnel.Rationnel(1, 3), new Rationnel.Rationnel(2, 3), new Rationnel.Rationnel(4, 5),
                new Rationnel.Rationnel(4, 6)};
                int[] positionoccurences = occurence.chercheOccurence(tableau);
                Console.WriteLine("Le Rationnel " + occurence + " est présent dans le tableau au positions : ");
                foreach(int position in positionoccurences)
                {
                    Console.WriteLine(position);
                }
                Console.WriteLine();

                // Test de la méthode processusRationnel
                Console.WriteLine("*** TEST DE LA METHODE PROCESSUSRATIONNEL ***");
                occurence.processRationnel(Rationnel.Rationnel.methode, tableau);
                Console.WriteLine();

                // Test de la construction d'un objet Rationnel avec un dénominateur nul
                Rationnel.Rationnel nulRationnel = new Rationnel.Rationnel(8, 0);
            }
            catch(Exception e) { Console.WriteLine(e.Message + "\n"); }
        }
    }
}
