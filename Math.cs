using System;
using System.Collections.Generic;
using System.Text;

namespace TPB2S1Revision
{
    class Math
    {
        public enum MapType { SEA, LAND, VOID }
        public const double PI = 3.1415926535897931;

        //Ex 1 reste d'une divsion euclidienne
        public static int PGCD(int nA, int nB)
        {
            // Variables temporaires
            int nC = 0;
            int nPGCD = 0;
            // Regarde les valeurs de A et de B et effectue un swap si nA < nB dans le cas ou la premier valeur sera inferieur a la seconde 
            if (nA < nB)
            {
                // Récupère la valeur de nB
                nC = nB;
                // Change la valeur de nB en nA
                nB = nA;
                // Change la valeur de nA en nB (donc, en utilisant la variable nC)
                nA = nC;
            }
            // Lance une boucle qui ne s'arrete que si nA % nB = 0
            while (true)
            {
                // Récupère le reste de la division nA / nB
                nC = nA % nB;
                // Teste si nC vaut 0
                if (nC == 0)
                {
                    // nC vaut 0, donc le calcul est terminé, nPGCD = nB
                    nPGCD = nB;
                    // Termine la boucle
                    break;
                }
                nA = nB;
                nB = nC;
            }
            // Retourne le résultat
            return nPGCD;
            //Si nPGCD = 1, c'est que les deux nombre sont indivisibles
        }

        //Ex 2 volume d'une sphere
        public static double VolumeSphere(double radius)
        {
            return 4 / 3 * PI * System.Math.Pow(radius, 3);
        }

        //Ex 3 calcule du rabais
        public static double DiscountPrice(double price, int int_discount)
        {
            double discount = Convert.ToDouble(int_discount);
            return price - price * discount / 100;
        }

        //Ex 4 calcule du prix des tabelaux et de leur rabais
        public static double[] ComputeTabPrice(double[] tabPrice, int[] tabDiscount, double sillValue)
        {
            int IsOverSillValue = 0;

            // on créé un premier tableaux de la taille de notre tableau de prix
            double[] TabFinalPrice = new double[tabPrice.Length];
            for (int i = 0; i < tabPrice.Length; i++)
            {
                // on calcule le discount des valeur 2 par 2
                double tempPrice = DiscountPrice(tabPrice[i], tabDiscount[i]);
                // si le prix est inf ou égale a notre seuille alors
                if (TabFinalPrice[i] <= sillValue)
                {
                    // on incrémente notre compteur de valeur et on met dans notre tableau intermédaire
                    IsOverSillValue++;
                    TabFinalPrice[i] = tempPrice;
                }
            }

            // on instencie un nouveaux tableau de la bonne taille 
            double[] TabOverSillValue = new double[IsOverSillValue];
            // on le replie de nos valeur
            for (int i = 0; i < TabOverSillValue.Length; i++)
            {
                TabOverSillValue[i] = TabFinalPrice[i];
            }
            return TabOverSillValue;
        }

        //Ex 5 affichage d'une map en console
        public static void DisplayMap(MapType[,] map)
        {
            for (int i = 0; i < map.GetUpperBound(0); i++) //parcourt les ordonnées
            {
                for (int j = 0; j < map.GetUpperBound(1); j++)
                { //parcourt les abscisses puis passe à la prochaine ordonnée
                    // pour chaque case on dessine l'element corespondant
                    switch (map[i, j])
                    {
                        case MapType.VOID:
                            Console.Write(".");
                            break;
                        case MapType.SEA:
                            Console.Write("S");
                            break;
                        case MapType.LAND:
                            Console.Write("L");
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        //Ex 6 amelioration de L'Ex 4 
        public struct DiscountPriceValues
        {
            public double[] tabPrice;
            public int[] tabDiscount;
            public double sillValue;
            public double[] tabDiscountAll;
            public Double[] tabResult;
        }
        public static DiscountPriceValues ComputeTabPriceV2(double[] tabPrice, int[] tabDiscount, double sillValue)
        {
            DiscountPriceValues values = new DiscountPriceValues();
            values.tabPrice = tabPrice;
            values.tabDiscount = tabDiscount;
            values.sillValue = sillValue;
            int IsOverSillValue = 0;

            // on créé un premier tableaux de la taille de notre tableau de prix
            double[] TabFinalPrice = new double[tabPrice.Length];
            values.tabDiscountAll = new double[tabPrice.Length];
            for (int i = 0; i < tabPrice.Length; i++)
            {
                // on calcule le discount des valeur 2 par 2
                double tempPrice = DiscountPrice(tabPrice[i], tabDiscount[i]);
                values.tabDiscountAll[i] = tempPrice;
                // si le prix est inf ou égale a notre seuille alors
                if (TabFinalPrice[i] <= sillValue)
                {
                    // on incrémente notre compteur de valeur et on met dans notre tableau intermédaire
                    IsOverSillValue++;
                    TabFinalPrice[i] = tempPrice;
                }
            }

            // on instencie un nouveaux tableau de la bonne taille 
            double[] TabOverSillValue = new double[IsOverSillValue];
            // on le replie de nos valeur
            for (int i = 0; i < TabOverSillValue.Length; i++)
            {
                TabOverSillValue[i] = TabFinalPrice[i];
            }
            values.tabResult = TabOverSillValue;

            return values;
        }

        //Ex 8
        public static int fibonacci(int entree)
        {
            if (entree <= 1)
                return 1;
            else
                return fibonacci(entree - 2) + fibonacci(entree - 1);
        }

        //Ex 9
        public class TreeNode{
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }
            public int value{ get; set; }

            public TreeNode(int value)
            {
                this.value = value;
            }
        }

        class NodeInfo
        {
            public TreeNode Node;
            public string Text;
            public int StartPos;
            public int Size { get { return Text.Length; } }
            public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
            public NodeInfo Parent, Left, Right;
        }

        public static void Print(TreeNode root, string textFormat = "0", int spacing = 1, int topMargin = 2, int leftMargin = 2)
        {
            if (root == null) return;
            int rootTop = Console.CursorTop + topMargin;
            var last = new List<NodeInfo>();
            var next = root;
            for (int level = 0; next != null; level++)
            {
                var item = new NodeInfo { Node = next, Text = next.value.ToString(textFormat) };
                if (level < last.Count)
                {
                    item.StartPos = last[level].EndPos + spacing;
                    last[level] = item;
                }
                else
                {
                    item.StartPos = leftMargin;
                    last.Add(item);
                }
                if (level > 0)
                {
                    item.Parent = last[level - 1];
                    if (next == item.Parent.Node.left)
                    {
                        item.Parent.Left = item;
                        item.EndPos = System.Math.Max(item.EndPos, item.Parent.StartPos - 1);
                    }
                    else
                    {
                        item.Parent.Right = item;
                        item.StartPos = System.Math.Max(item.StartPos, item.Parent.EndPos + 1);
                    }
                }
                next = next.left ?? next.right;
                for (; next == null; item = item.Parent)
                {
                    int top = rootTop + 2 * level;
                    Print(item.Text, top, item.StartPos);
                    if (item.Left != null)
                    {
                        Print("/", top + 1, item.Left.EndPos);
                        Print("_", top, item.Left.EndPos + 1, item.StartPos);
                    }
                    if (item.Right != null)
                    {
                        Print("_", top, item.EndPos, item.Right.StartPos - 1);
                        Print("\\", top + 1, item.Right.StartPos - 1);
                    }
                    if (--level < 0) break;
                    if (item == item.Parent.Left)
                    {
                        item.Parent.StartPos = item.EndPos + 1;
                        next = item.Parent.Node.right;
                    }
                    else
                    {
                        if (item.Parent.Left == null)
                            item.Parent.EndPos = item.StartPos - 1;
                        else
                            item.Parent.StartPos += (item.StartPos - 1 - item.Parent.EndPos) / 2;
                    }
                }
            }
            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }

        private static void Print(string s, int top, int left, int right = -1)
        {
            Console.SetCursorPosition(left, top);
            if (right < 0) right = left + s.Length;
            while (Console.CursorLeft < right) Console.Write(s);
        }
    }
}
