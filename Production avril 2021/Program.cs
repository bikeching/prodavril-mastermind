using System;
using System.Linq;
using System.Collections.Generic;

namespace Production_avril_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Bonjour, vous aller jouer ****Master Technobel mind****");
            Console.WriteLine("Régle du jeu : En debut de partie, parmi 8 couleurs, l'ordinateur sélectionne 4 couleurs différentes pour commencer");
            
            foreach (string x in Couleurs.GetNames(typeof(Couleurs))) //liste des couleurs par le nom **Couleurs**
            {
                Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), x);
                Console.BackgroundColor = Enum.Parse<ConsoleColor>(x);
                Console.WriteLine($"{(int)Console.BackgroundColor} {x}");
            }
            
            Console.WriteLine("Entrer 4 différents nombres de 1 à 8"); // test de l'aléatoire des nombres de 1 à 8
            Random rnd = new Random();
            int[] target = new int[4];
            while (target.Distinct().Count() != 4) //random en route, l'algo choisi 4 différents nombres
            {
                for (int x = 0; x < 4; x++)
                {
                    target[x] = rnd.Next(8);
                }
            }
            int attempts = 0;
            while (true)
            {
                string userInput = Console.ReadLine(); // Attente du joueur qui tape 4 nombres
                attempts++;
                int[] userNumber = userInput.Select(ValueTuple => ValueTuple - '0').ToArray();
                int countCorrect = 0;
                int positionCorrect = 0;
                for (int c = 0; c < 4; c++) //verification des nombres place juste
                {
                    if (target.Contains(userNumber[c]))
                    {
                        countCorrect++;
                    }
                    if (target[c] == userNumber[c])
                    {
                        positionCorrect++;
                    }
                }
                if (positionCorrect == 4) //4 nombres juste il sort de  la boucle par break
                {
                    Console.WriteLine($"tous les nombres sont correct ! Nombre de tentatives : {attempts} ");
                    break;
                }
                Console.WriteLine($"{countCorrect} correct mais pas en bon endroit");
                Console.WriteLine($"{positionCorrect} au bon endroit. Essayez à nouveau: ");
            }
        }
    }
}
