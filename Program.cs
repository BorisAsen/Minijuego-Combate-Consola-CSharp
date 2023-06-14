// ************* LIBRARIES ************* //
using System;
using static System.Math;
using System.Globalization;
using CSharp_Combat_Minigame;

namespace CSharp_Combat_Minigame
{
    class MainClass
    {
        // ************* MAIN CODE ************* //
        // Main characters list
        static List<Character> characters = new List<Character>();
        // CSV FilePath
        static string pathCSV = "./Files/Characters.csv";

        static Random rand = new Random();

        public static void Main(string[] args)
        {
            // Get characters from csv
            FileHelper.FromCsvToList(characters, pathCSV);

            // Game Menu
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("*** MINIJUEGO DE COMBATE EN CONSOLA CON C# ***");
                Console.Write("\nSelecciona una opcion: \n");
                Console.WriteLine("1. Iniciar un combate");
                Console.WriteLine("2. Agregar un Personaje");
                Console.WriteLine("3. Modificar Personajes");
                Console.WriteLine("4. Buscar Personajes");
                Console.WriteLine("5. Salir del Juego");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        MenuItem_Fight();
                        break;
                    case "2":
                        MenuItem_AddCharacter();
                        break;
                    case "3":

                        break;
                    case "4":

                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opcion invalida, intenta nuevamente");
                        break;
                }
            }

            // Exiting the game
            Console.Clear();
            Console.WriteLine("Saliendo del juego...");



        }

        // ************* FUNCTIONS ************* //

        // Menu Item - (Fight)
        public static void MenuItem_Fight ()
        {
            // Update characters from csv
            FileHelper.FromCsvToList(characters, pathCSV);

            // Show characters list
            ShowCharacters(characters);

            // Chose a character
            Console.WriteLine("PRESIONA UNA TECLA PARA SELECCIONAR UN PERSONAJE");
            Console.ReadKey();
            Console.Clear();
            Console.Write("Ingresa el id del personaje elegido para pelear: ");
            int chosenCharacterId = int.Parse(Console.ReadLine());
            Character character1 = FindCharacterById(characters, chosenCharacterId);

            // Generate opponent (it could be the same chosen character)
            int randId = rand.Next(characters.First().Id, characters.Last().Id + 1);
            Character character2 = FindCharacterById(characters, randId);

            // Show versus animation
            Animations.Versus(character1, character2);

            // Fight
            Character winner = Fight(character1, character2);

            // Show the winner
            Console.WriteLine("GANADOR: \n");
            winner.ShowCharacter();

            // Go back to menu
            Console.WriteLine("PRESIONA UNA TECLA PARA VOLVER AL MENU");
            Console.ReadKey();
        }

        // Menu Item - (Add Character)
        public static void MenuItem_AddCharacter ()
        {
            Console.Clear();
            Console.Write("CONSTRUYE TU PERSONAJE: \n");
            int id = characters.Last().Id + 1; // Get the last id to increment 1
            Console.Write("Nombre: ");
            string fullName = Console.ReadLine();
            Console.Write("Elige una clase (1.Mago, 2.Luchador, 3.Tanque): ");
            string classNumber = Console.ReadLine();
            Character.CharacterClass chClas;
            switch (classNumber)
            {
                case "1":
                    chClas = Character.CharacterClass.Mago;
                    break;
                case "2":
                    chClas = Character.CharacterClass.Luchador;
                    break;
                case "3":
                    chClas = Character.CharacterClass.Tanque;
                    break;
                default:
                    chClas = Character.CharacterClass.Mago;
                    break;
            }
            Console.Write("Ataque (0 - 200): ");
            double attack = double.Parse(Console.ReadLine());
            Console.Write("Vida (0 - 1500): ");
            double life = double.Parse(Console.ReadLine());
            Console.Write("Probabilidad de Golpe Critico (1.0 - 2.0): ");
            double criticalHitProbability = double.Parse(Console.ReadLine());

            Character newCharacter = new Character(id, fullName, chClas, attack, life, criticalHitProbability);
            Console.WriteLine("\nNuevo personaje agregado a la lista: ");
            newCharacter.ShowCharacter();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Deseas guardar el personaje en el archivo csv? (S/N)");
                string save = Console.ReadLine();
                switch (save)
                {
                    case "S":
                        FileHelper.SaveCharacter_Append(newCharacter, pathCSV);
                        Console.WriteLine("SE GUARDO EL PERSONAJE");
                        exit = true;
                        break;
                    case "N":
                        Console.WriteLine("NO SE GUARDO EL PERSONAJE");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opcion Incorrecta, intenta nuevamente");
                        break;
                }
            }

            // Go back to menu
            Console.WriteLine("PRESIONA UNA TECLA PARA VOLVER AL MENU");
            Console.ReadKey();
        }

        // Show characters list
        public static void ShowCharacters (List<Character> characters)
        {
            // Iterate over the list of characters
            foreach (Character character in characters)
            {
                // Show character
                character.ShowCharacter();
            }
        }

        // Find character by id
        public static Character FindCharacterById (List<Character> characters, int id)
        {
            // Iterate over the list of characters
            foreach (Character character in characters)
            {
                if (character.Id == id)
                {
                    return character;
                }
            }
            return null;
        }

        // Fight (return the winner)
        public static Character Fight(Character character1, Character character2)
        {
            // Defines first to attack
            Character first, second, winner = null;
            if (rand.Next(2) == 0) // Generate 0 or 1
            {
                first = character1;
                second = character2;
            }
            else
            {
                first = character2;
                second = character1;
            }
            Console.WriteLine("Comienza el jugador " + first.Id + " (" + first.FullName + "). Presiona una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

            // Variables for attack damage
            double attackDamage1, attackDamage2;

            // 3 rounds or reach 0 life points
            int i = 0;
            while (i < 3)
            {
                // First Player turn
                Console.WriteLine("TURNO " + (i+1) + "\n");
                Console.WriteLine("(" + first.FullName + ") Presiona una tecla para atacar");
                Console.ReadKey();
                // Animate the attack
                Animations.AnimateAttack(first, second);
                // Calculate attack damage based on rand for critical hit probability
                attackDamage1 = Math.Round( first.Attack * (rand.NextDouble() * (first.CriticalHitProbability - 1.0) + 1.0), 2); // Random number between 1.0 and the value of critical hit probability
                // Calculate effectiviness between classes
                double effectiveness1 = CalculateAttackEffectiveness(first, second);
                // Calculate second player life points
                second.Life -= (attackDamage1 * effectiveness1);
                Console.WriteLine("El ataque hizo un daño de " + attackDamage1.ToString("0.00"));
                Console.WriteLine("La vida restante de (" + second.FullName + ") es " + second.Life.ToString("0.00"));
                Console.WriteLine("Presiona una tecla para continuar...");
                Console.ReadKey();
                Console.Clear();

                // Check if a player reaches 0 life points
                if (second.Life <= 0)
                {
                    winner = first;
                    break;
                }

                // Second Player turn
                Console.WriteLine("TURNO " + (i+1) + "\n");
                Console.WriteLine("(" + second.FullName + ") Presiona una tecla para atacar");
                Console.ReadKey();
                // Animate the attack
                Animations.AnimateAttack(second, first);
                // Calculate attack damage based on rand for critical hit probability
                attackDamage2 = Math.Round( second.Attack * (rand.NextDouble() * (second.CriticalHitProbability - 1.0) + 1.0), 2); // Random number between 1.0 and the value of critical hit probability
                // Calculate effectiviness between classes
                double effectiveness2 = CalculateAttackEffectiveness(second, first);
                // Calculate first player life points
                first.Life -= (attackDamage2 * effectiveness2);
                Console.WriteLine("El ataque hizo un daño de " + attackDamage2.ToString("0.00"));
                Console.WriteLine("La vida restante de (" + first.FullName + ") es " + first.Life.ToString("0.00"));
                Console.WriteLine("Presiona una tecla para continuar...");
                Console.ReadKey();
                Console.Clear();

                // Check if a player reaches 0 life points
                if (first.Life <= 0)
                {
                    winner = second;
                    break;
                }

                i++;
            }

            // Determine the winner based on remaining life points
            if (winner == null)
            {
                if (first.Life > second.Life)
                    winner = first;
                else if (first.Life < second.Life)
                    winner = second;
            }

            return winner;
        }

        // Return a modified value according to the effectiveness of the attack
        public static double CalculateAttackEffectiveness(Character attacker, Character target)
        {
            double effectiveness = 1.0; // Initial value

            if (attacker.ChClass == Character.CharacterClass.Mago && target.ChClass == Character.CharacterClass.Tanque)
            {
                effectiveness += 0.05;
                Console.WriteLine("¡El ataque de Mago es 5% mas efectivo contra Tanques!");
            }
            else if (attacker.ChClass == Character.CharacterClass.Tanque && target.ChClass == Character.CharacterClass.Mago)
            {
                effectiveness += 0.1;
                Console.WriteLine("¡El ataque de Tanque es 10% mas dañino contra Magos!");
            }
            else if (attacker.ChClass == Character.CharacterClass.Luchador && target.ChClass == Character.CharacterClass.Tanque)
            {
                effectiveness += 0.06;
                Console.WriteLine("¡El ataque de Luchador es 6% mas efectivo contra Tanques!");
            }
            else if (attacker.ChClass == Character.CharacterClass.Luchador && target.ChClass == Character.CharacterClass.Mago)
            {
                effectiveness -= 0.08;
                Console.WriteLine("¡El ataque de Luchador es 8% menos efectivo contra Magos!");
            }

            return effectiveness;
        }













        
    }


}


