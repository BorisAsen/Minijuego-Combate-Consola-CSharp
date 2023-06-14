// ************* LIBRARIES ************* //
using System;
using static System.Math;
using System.Globalization;

namespace CSharp_Combat_Minigame
{
    
    public static class FileHelper
    {
        public static void Versus(List<Character> characters)
        {
            Console.CursorVisible = false;

            for (int i = 0; i < 6; i++)
            {
                Console.Clear();

                if (i % 2 == 0)
                {
                    Console.WriteLine("       (P1)                                            (P1)                     ");
                    Console.WriteLine("      _____         __          __   _______           _____                 ");
                    Console.WriteLine("     /     \\       \\ \\      / /  /   ____\\        /     \\                  ");
                    Console.WriteLine("  \\_|    > <|_/     \\ \\    / /   |  |____      \\_|> <    |_/                ");
                    Console.WriteLine("    |    )O(|         \\ \\  / /    \\____   \\      |)O(    |                       ");
                    Console.WriteLine("     \\_____/          \\ \\/ /      ____|  |         \\_____/           ");
                    Console.WriteLine("      _| |_             \\___/      /______/          _| |_            ");
                }
                else if (i % 2 == 1)
                {
                    Console.WriteLine("       (P1)        \\   \\    \\     /    /    /           (P1)                     ");
                    Console.WriteLine("      _____         __          __   _______           _____                 ");
                    Console.WriteLine("     /     \\    \\  \\ \\      / /  /   ____\\  /     /     \\                  ");
                    Console.WriteLine("  \\_|    > <|_/     \\ \\    / /   |  |____      \\_|> <    |_/                ");
                    Console.WriteLine("    |    )O(|         \\ \\  / /    \\____   \\      |)O(    |                       ");
                    Console.WriteLine("     \\_____/       /  \\ \\/ /      ____|  |  \\      \\_____/           ");
                    Console.WriteLine("      _| |_          /  \\___/      /______/  \\       _| |_            ");
                } else
                {
                    Console.WriteLine("       (P1)                                            (P1)                     ");
                    Console.WriteLine("      _____         __          __   _______           _____                 ");
                    Console.WriteLine("     /     \\       \\ \\      / /  /   ____\\        /     \\                  ");
                    Console.WriteLine("  \\_|    > <|_/     \\ \\    / /   |  |____      \\_|> <    |_/                ");
                    Console.WriteLine("    |    )O(|         \\ \\  / /    \\____   \\      |)O(    |                       ");
                    Console.WriteLine("     \\_____/          \\ \\/ /      ____|  |         \\_____/           ");
                    Console.WriteLine("      _| |_             \\___/      /______/          _| |_            ");
                }

                Thread.Sleep(250); // Pause for 250 milliseconds to create animation effect
            }

            Console.CursorVisible = true;
        }
        // Get characters from csv file
        public static void FromCsvToList(List<Character> characters, string fileName)
        {
            // Open the file in read mode
            FileStream file = new FileStream(fileName, FileMode.Open);
            
            // Create a streamreader to read the file
            StreamReader streamReader = new StreamReader(file);

            // Define the variable that will contain each line of the file
            string line;
            // Define the variable that will contain each field of the line
            string[] fields;
            // Skip the first line that contains fields name
            streamReader.ReadLine();

            // Create an instance of NumberFormatInfo to specify the correct decimal format for floating point values
            NumberFormatInfo numberFormat = new NumberFormatInfo();
            numberFormat.NumberDecimalSeparator = ".";

            // Read the file as long as there are lines to read
            while ((line = streamReader.ReadLine()) != null)
            {
                // Get the fields from the line
                fields = line.Split(',');
                // Build a new character with the fields
                Character newCharacter = new Character(
                    int.Parse(fields[0]), // id
                    fields[1], // fullName
                    (Character.CharacterClass)Enum.Parse(typeof(Character.CharacterClass), fields[2]), // chClass
                    double.Parse(fields[3], numberFormat), // attack
                    double.Parse(fields[4], numberFormat), // life
                    double.Parse(fields[5], numberFormat) // criticalHitProbability
                );
                // Add newCharacter to the List of characters
                characters.Add(newCharacter);
            }

            // Close StreamReader to release the resources associated with the file
            streamReader.Close();
        }

        // // Funcion para guardar los datos de una lista en un archivo CSV sobrescribiedolo si ya existe
        // public static void EscribirArchivo_Overwrite(List<Personaje> personajes, string fileName)
        // {
        //     // Defino un FileStream para crear el archivo, si ya existe se sobreescribe
        //     FileStream archivo = new FileStream(fileName, FileMode.Create);

        //     // Abro el archivo en modo escritura
        //     StreamWriter fileWriter = new StreamWriter(archivo);

        //     // Escribo la primera linea con los nombres de los campos
        //     string campos = "id,nombreCompleto,clase,ataque,vida,probabilidadGolpeCritico";
        //     fileWriter.WriteLine(campos);

        //     // Recorro la lista de empleados
        //     foreach (Personaje personaje in personajes)
        //     {
        //         // Construyo una línea de texto con los atributos del personaje
        //         string line = personaje.Id + "," + personaje.NombreCompleto + "," + personaje.Clase + "," + personaje.Ataque + "," + personaje.Vida + "," + personaje.ProbabilidadGolpeCritico;

        //         // Escribo la línea en el archivo
        //         fileWriter.WriteLine(line);
        //     }

        //     // Cierro el StreamWriter para liberar los recursos asociados al archivo
        //     fileWriter.Close();
        // }

        // Save the character list in csv file (Append)
        public static void SaveCharacterList_Append(List<Character> characters, string fileName)
        {
            // Ask if the file already existed and save it in a vble
            bool fileAlreadyExist = File.Exists(fileName);

            // Open the file in read mode (Append)
            FileStream file = new FileStream(fileName, FileMode.Append);

            // Create a streamreader to write the file
            StreamWriter fileWriter = new StreamWriter(file);

            // If the file did not exist write the first header line
            if (!fileAlreadyExist)
            {
                string header = "id,nombreCompleto,clase,ataque,vida,probabilidadGolpeCritico";
                fileWriter.WriteLine(header);
            }

            // Iterate over the characters list
            foreach (Character character in characters)
            {
                // Build a text line with the characters attributes
                string line = character.Id + "," + character.FullName + "," + character.ChClass + "," + character.Attack + "," + character.Life + "," + character.CriticalHitProbability;

                // Write the line
                fileWriter.WriteLine(line);
            }

            // Close StreamWriter to release the resources associated with the file
            fileWriter.Close();
        }

        // Save a character in csv file (Append)
        public static void SaveCharacter_Append(Character character, string fileName)
        {
            // Ask if the file already existed and save it in a vble
            bool fileAlreadyExist = File.Exists(fileName);

            // Open the file in read mode (Append)
            FileStream file = new FileStream(fileName, FileMode.Append);

            // Create a streamreader to write the file
            StreamWriter fileWriter = new StreamWriter(file);

            // If the file did not exist write the first header line
            if (!fileAlreadyExist)
            {
                string header = "id,nombreCompleto,clase,ataque,vida,probabilidadGolpeCritico";
                fileWriter.WriteLine(header);
            }

            // Build a text line with the characters attributes
            string line = character.Id + "," + character.FullName + "," + character.ChClass + "," + character.Attack + "," + character.Life + "," + character.CriticalHitProbability;

            // Write the line to save the character
            fileWriter.WriteLine(line);

            // Close StreamWriter to release the resources associated with the file
            fileWriter.Close();
        }

        // // Funcion para guardar los resultados en un archivo txt sobrescribiendolo
        // public static void EscribirResultadosTXT_Overwrite(Personaje pMasAtaque, Personaje pMenosVida, int[] cantidadCadaClase, string fileName)
        // {
        //     // Defino un FileStream para crear el archivo, si ya existe se sobreescribe
        //     FileStream archivo = new FileStream(fileName, FileMode.Create);

        //     // Abro el archivo en modo escritura
        //     StreamWriter fileWriter = new StreamWriter(archivo);

        //     // Escribo la primera linea informativa
        //     string linea = "RESULTADOS - Relevamiento de datos";
        //     fileWriter.WriteLine(linea);

        //     // Escribo el personaje con mas ataque
        //     linea = "Personaje con mas ataque (" + pMasAtaque.Ataque + "): " + pMasAtaque.Id + " - " + pMasAtaque.NombreCompleto;
        //     fileWriter.WriteLine(linea);

        //     // Escribo el personaje con menos vida
        //     linea = "Personaje con menos vida (" + pMenosVida.Vida + "): " + pMenosVida.Id + " - " + pMenosVida.NombreCompleto;
        //     fileWriter.WriteLine(linea);

        //     // Cantidad de personajes de cada clase
        //     for (int i = 0; i < cantidadCadaClase.Length; i++)
        //     {
        //         linea = "Cantidad de personajes de la clase (" + ((Personaje.ClasePersonaje)i).ToString() + "): " + cantidadCadaClase[i];
        //         fileWriter.WriteLine(linea);
        //     }

        //     // Cierro el StreamWriter para liberar los recursos asociados al archivo
        //     fileWriter.Close();
        // }

    }



}


