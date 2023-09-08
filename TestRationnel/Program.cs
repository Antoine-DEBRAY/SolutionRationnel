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
                Rationnel.Rationnel premierRationnel = new Rationnel.Rationnel(5, 8);
                Rationnel.Rationnel secondRationnel = new Rationnel.Rationnel(2, 4);

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

                // Test de la construction d'un objet Rationnel avec un dénominateur nul
                Rationnel.Rationnel nulRationnel = new Rationnel.Rationnel(8, 0);
            }
            catch(Exception e) { Console.WriteLine(e.Message + "\n"); }
        }
    }
}
