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

                // Test de la construction d'un objet Rationnel avec un dénominateur nul
                Rationnel.Rationnel nulRationnel = new Rationnel.Rationnel(8, 0);
            }
            catch(Exception e) { Console.WriteLine(e.Message + "\n"); }
        }
    }
}
