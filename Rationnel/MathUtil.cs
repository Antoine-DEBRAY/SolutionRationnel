/// <summary>
/// Bibliothèque de mathématiques
/// </summary>
public class MathUtil
{	
	/// <summary>
	/// Calcul récursif du plus grand commun diviseur
	/// </summary>
	/// <param name="a">entier1</param>
	/// <param name="b">entier2</param>
	/// <returns>Le plus grand commun diviseur</returns>
	public static int PGCD(int a, int b)
	{
        if (a == 0)
            return 1;
        if (b == 0)
            return 1;
        a = System.Math.Abs(a);
        b = System.Math.Abs(b);
		// On échange si nécessaire
		int max, min;
		if(a < b)
		{
			min = a;
			max = b;
		}
		else
		{
			min=b;
			max=a;
		}
		int reste = max % min;
		if (reste == 0)
			return min;
		else
			return (PGCD(min , reste));
	}
    
    
}