// ************* LIBRARIES ************* //
using System;
using static System.Math;
using System.Globalization;

namespace CSharp_Combat_Minigame
{
    class MainClass
    {
        // ************* MAIN CODE ************* //
        // Main characters list
        static List<Character> characters = new List<Character>();
        // CSV FilePath
        static string pathCSV = "./Files/Characters.csv";

        public static void Main(string[] args)
        {
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
                        MenuItem_ShowCharacters();
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

        // Menu Items - (Fight)
        public static void MenuItem_Fight ()
        {
            // Get characters from csv
            FileHelper.FromCsvToList(characters, pathCSV);
            
            // Show characters list
            ShowCharacters(characters);

            // Go back to menu
            Console.WriteLine("PRESIONA UNA TECLA PARA VOLVER AL MENU");
            Console.ReadKey();
        }

        // Menu Items - (Add Character)
        public static void MenuItem_AddCharacter ()
        {
            Console.Clear();
            Console.WriteLine("CONSTRUYE TU PERSONAJE: \n");
            int id = characters.Last().Id + 1; // Get the last id to increment 1
            Console.WriteLine("Nombre: ");
            string fullName = Console.ReadLine();
            Console.WriteLine("Elige una clase (1.Mago, 2.Luchador, 3.Tanque): ");
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
            Console.WriteLine("Ataque (0 - 200): ");
            double attack = double.Parse(Console.ReadLine());
            Console.WriteLine("Vida (0 - 1500): ");
            double life = double.Parse(Console.ReadLine());
            Console.WriteLine("Probabilidad de Golpe Critico (1.0 - 2.0): ");
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

    }


}


