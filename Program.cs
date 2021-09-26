using System;

namespace TPB2S1Revision
{
    class Program
    {
        static void Main(string[] args)
        {
            //On initialise d'abord les données pour chaque problème que l'on souhaite résoudre

            //1 : Il nous faut le dividende et le diviseur pour calculer le reste de leur division
            int a = 3; //a est le dividende
            int b = 2; //b est le diviseur

            //2 : Il nous faut le rayon de la sphère dont on veut calculer le volume
            double ray = 1.2;

            //3 : Il nous faut le prix initial et le taux de réduction pour calculer le rabais
            double price = 180; //price est le prix initial du produit
            int discount = 30; //discount est le taux de réduction

            //4 : On crée les tableaux dont on va avoir besoin pour calculer si les prix sont au dessus du prix seuil ou non
            double[] tabPrice = new double[] { 120, 150, 70 };
            int[] tabDiscount = new int[] { 20, 50,70 };
            double sillValue = 50;

            //Ensuite on exécute les fonctions
            Console.WriteLine("Ex 1");
            Console.WriteLine("Pgcd de "+a+" et "+b+" : "+Math.PGCD(a, b));
            Console.WriteLine("Ex 2");
            Console.WriteLine("Volume de la sphere de rayon "+ray+" : "+Math.VolumeSphere(ray));
            Console.WriteLine("Ex 3");
            Console.WriteLine("Rabais de "+discount+"% de "+price+" : "+ Math.DiscountPrice(price,discount));

            //Ex 4
            Console.WriteLine("Ex 4");
            Double[] tabResult = Math.ComputeTabPrice(tabPrice, tabDiscount, sillValue);
            Console.WriteLine("valeurs du tableau retourné");
            foreach (double d in tabResult)
            {
                Console.WriteLine(d);
            }

            Math.MapType[,] map = new Math.MapType[,] { { Math.MapType.VOID, Math.MapType.VOID, Math.MapType.VOID, Math.MapType.VOID , Math.MapType.VOID},
                                                        { Math.MapType.VOID, Math.MapType.VOID, Math.MapType.VOID, Math.MapType.SEA , Math.MapType.SEA},
                                                        { Math.MapType.VOID, Math.MapType.LAND, Math.MapType.LAND, Math.MapType.VOID , Math.MapType.VOID},
                                                        { Math.MapType.VOID, Math.MapType.LAND, Math.MapType.LAND, Math.MapType.VOID , Math.MapType.SEA},
                                                        { Math.MapType.VOID, Math.MapType.VOID, Math.MapType.VOID, Math.MapType.VOID , Math.MapType.VOID}
            };
            //Ex 5
            Console.WriteLine("Ex 5");
            Math.DisplayMap(map);
            Console.WriteLine();

            //Ex 6 
            Console.WriteLine("Ex 6");
            Math.DiscountPriceValues values = Math.ComputeTabPriceV2(tabPrice, tabDiscount, sillValue);
            Console.WriteLine("valeurs du tableau retourné");
            foreach (double d in values.tabResult)
            {
                Console.WriteLine(d);
            }

            //Ex 7 
            Console.WriteLine("Ex 7");
            int[] unsortedTab = new int[] { 18, 5, 25, 157, 8, 6, 0, 25478, 58, 15, 1 };
            Tri tri = new Tri(unsortedTab);

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Reset();
            sw.Start();
            var tSelection = tri.TriSelection();
            sw.Stop();
            Console.WriteLine("Temps du tri par selection : "+sw.Elapsed.ToString());

            sw.Reset();
            sw.Start();
            var tBulle = tri.TriBulle();
            sw.Stop();
            Console.WriteLine("Temps du tri a bulle : " + sw.Elapsed.ToString());

            foreach (int nb in tSelection)
            {
                Console.WriteLine(nb);
            }
            Console.WriteLine("=================================");
            foreach (int nb in tSelection)
            {
                Console.WriteLine(nb);
            }
            Console.WriteLine();
            Console.WriteLine("fibonacci de 8 : "+Math.fibonacci(8));

            //Ex 9

            Math.TreeNode tree = new Math.TreeNode(5);
            tree.left = new Math.TreeNode(16);
            tree.right = new Math.TreeNode(8);
            tree.left.left = new Math.TreeNode(125);
            tree.right.left = new Math.TreeNode(14);
            tree.left.right = new Math.TreeNode(28);
            tree.right.right = new Math.TreeNode(32);
            Math.Print(tree);

        }
    }
}
