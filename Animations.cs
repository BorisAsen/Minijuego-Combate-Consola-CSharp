// ************* LIBRARIES ************* //
using System;
using static System.Math;
using System.Globalization;
using System.Collections.Generic;
using System.Threading;

namespace CSharp_Combat_Minigame
{
    public static class Animations 
    {
        private static readonly Dictionary<Character.CharacterClass, char> classLetters = new Dictionary<Character.CharacterClass, char>()
        {
            { Character.CharacterClass.Mago, 'M' },
            { Character.CharacterClass.Luchador, 'L' },
            { Character.CharacterClass.Tanque, 'T' }
        };

        private static char GetClassLetter(Character.CharacterClass characterClass)
        {
            if (classLetters.TryGetValue(characterClass, out char letter))
            {
                return letter;
            }
            return ' '; // Default value if character class is not found in the dictionary
        }

        public static void Versus(Character character1, Character character2)
        {
            // Class to letter
            char a = GetClassLetter(character1.ChClass);
            char b = GetClassLetter(character2.ChClass);

            Console.CursorVisible = false;

            for (int i = 0; i < 12; i++)
            {
                Console.Clear();

                if (i % 2 == 0)
                {
                    Console.WriteLine("(" + character1.FullName +") VS (" + character2.FullName + ")");
                    Console.WriteLine("      _____      __        __   _______       _____           ");
                    Console.WriteLine("     / (" + a + ") \\     \\ \\      / /  /   ____\\     / (" + b + ") \\      ");
                    Console.WriteLine("    |    > <|     \\ \\    / /   |  |____     |> <    |        ");
                    Console.WriteLine("  \\/|    )O(|\\/    \\ \\  / /    \\____   \\  \\/|)O(    |\\/ ");
                    Console.WriteLine("     \\_____/        \\ \\/ /       ___|  |     \\_____/      ");
                    Console.WriteLine("      _| |_          \\__/      /______/      _| |_          ");
                }
                else if (i % 2 == 1)
                {
                    Console.WriteLine("(" + character1.FullName +") VS (" + character2.FullName + ")");
                    Console.WriteLine("      _____      __        __   _______       _____           ");
                    Console.WriteLine("     / (" + a + ") \\     \\ \\      / /  /   ____\\     / (" + b + ") \\      ");
                    Console.WriteLine("  \\_|    > <|_/   \\ \\    / /   |  |____   \\_|> <    |_/      ");
                    Console.WriteLine("    |    )O(|      \\ \\  / /    \\____   \\    |)O(    |   ");
                    Console.WriteLine("     \\_____/        \\ \\/ /       ___|  |     \\_____/      ");
                    Console.WriteLine("      _| |_          \\__/      /______/      _| |_          ");
                } else
                {
                    Console.WriteLine("(" + character1.FullName +") VS (" + character2.FullName + ")");
                    Console.WriteLine("      _____      __        __   _______       _____           ");
                    Console.WriteLine("     / (" + a + ") \\     \\ \\      / /  /   ____\\     / (" + b + ") \\      ");
                    Console.WriteLine("    |    > <|     \\ \\    / /   |  |____     |> <    |        ");
                    Console.WriteLine("  \\/|    )O(|\\/    \\ \\  / /    \\____   \\  \\/|)O(    |\\/ ");
                    Console.WriteLine("     \\_____/        \\ \\/ /       ___|  |     \\_____/      ");
                    Console.WriteLine("      _| |_          \\__/      /______/      _| |_          ");
                }
                Thread.Sleep(200); // Pause for 250 milliseconds to create animation effect
            }
            Console.WriteLine();
            Console.CursorVisible = true;
        }

        public static void AnimateAttack(Character character1, Character character2)
        {
            char a = GetClassLetter(character1.ChClass);
            char b = GetClassLetter(character2.ChClass);
            
            switch (character1.ChClass)
            {
                case Character.CharacterClass.Mago:
                    AnimateMagoAttack(a, b);
                    break;
                case Character.CharacterClass.Luchador:
                    AnimateLuchadorAttack(a, b);
                    break;
                case Character.CharacterClass.Tanque:
                    AnimateTanqueAttack(a, b);
                    break;
            }
            Console.WriteLine();
        }

        public static void AnimateMagoAttack(char a, char b)
        {
            Console.CursorVisible = false;

            for (int i = 0; i < 8; i++)
            {
                Console.Clear();
                Console.WriteLine();

                if (i % 4 == 0)
                {
                    Console.WriteLine("        (P1)                             (P2)       ");
                    Console.WriteLine("       _____                             ____       ");
                    Console.WriteLine("      / (" + a + ") \\                     █    / (" + b + ") \\     ");
                    Console.WriteLine("     |    > <|___/_\\|/_           █\\__| > <   |    ");
                    Console.WriteLine("   _/|    )-(|     /|\\            █   | ───   |\\_  ");
                    Console.WriteLine("      \\_____/                     █    \\_____/     ");
                    Console.WriteLine("       _| |_                            _| |_       ");
                }
                else if (i % 4 == 1)
                {
                    Console.WriteLine("        (P1)                             (P2)       ");
                    Console.WriteLine("       _____                             ____       ");
                    Console.WriteLine("      / (" + a + ") \\                     █    / (" + b + ") \\     ");
                    Console.WriteLine("     |    > <|___/ . . _\\|/_      █\\__| > <   |    ");
                    Console.WriteLine("   _/|    )─(|          /|\\       █   | ───   |\\_  ");
                    Console.WriteLine("      \\_____/                     █    \\_____/     ");
                    Console.WriteLine("       _| |_                            _| |_       ");
                }
                else if (i % 4 == 2)
                {
                    Console.WriteLine("        (P1)                             (P2)       ");
                    Console.WriteLine("       _____                             ____       ");
                    Console.WriteLine("      / (" + a + ") \\                     █    / (" + b + ") \\     ");
                    Console.WriteLine("     |    > <|___/    . . _\\|/_   █\\__| > <   |    ");
                    Console.WriteLine("   _/|    )O(|             /|\\    █   | ───   |\\_  ");
                    Console.WriteLine("      \\_____/                     █    \\_____/     ");
                    Console.WriteLine("       _| |_                            _| |_       ");
                }
                else 
                {
                    Console.WriteLine("        (P1)                             (P2)       ");
                    Console.WriteLine("       _____                             ____       ");
                    Console.WriteLine("      / (" + a + ") \\                     █    / (" + b + ") \\     ");
                    Console.WriteLine("     |    > <|___/       . . _\\|/ █\\__| > <   |    ");
                    Console.WriteLine("   _/|    )O(|                /|\\ █   | ───   |\\_  ");
                    Console.WriteLine("      \\_____/                     █    \\_____/     ");
                    Console.WriteLine("       _| |_                            _| |_       ");
                }

                Thread.Sleep(300); // Pause for 250 milliseconds to create animation effect
            }

            Console.CursorVisible = true;
        }
        
        public static void AnimateLuchadorAttack(char a, char b)
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine("        (P1)                             (P2)       ");
            Console.WriteLine("       _____        /|                   ____       ");
            Console.WriteLine("      / (" + a + ") \\      //             █    / (" + b + ") \\     ");
            Console.WriteLine("     |    - -|   _//_             █\\__| > <   |    ");
            Console.WriteLine("   _/|     O |\\__//               █   | ───   |\\_  ");
            Console.WriteLine("      \\_____/                     █    \\_____/     ");
            Console.WriteLine("       _| |_                            _| |_       ");
            Thread.Sleep(300); // Pause for 250 milliseconds to create animation effect

            Console.Clear();
            Console.WriteLine("             (P1)                        (P2)       ");
            Console.WriteLine("            _____        /|              ____       ");
            Console.WriteLine("    . . _  / (" + a + ") \\      //        █    / (" + b + ") \\     ");
            Console.WriteLine("   . . _  |    - -|   _//_        █\\__| > <   |    ");
            Console.WriteLine("  . . _ _/|     O |\\__//          █   | ───   |\\_  ");
            Console.WriteLine("    . . _  \\_____/                █    \\_____/     ");
            Console.WriteLine("             _| |_                      _| |_       ");
            Thread.Sleep(300); // Pause for 250 milliseconds to create animation effect

            Console.Clear();
            Console.WriteLine("                  (P1)                   (P2)       ");
            Console.WriteLine("                 _____        /|         ____       ");
            Console.WriteLine("         . . _  / (" + a + ") \\      //   █    / (" + b + ") \\     ");
            Console.WriteLine("        . . _  |    - -|   _//_   █\\__| > <   |    ");
            Console.WriteLine("       . . _ _/|     O |\\__//     █   | ───   |\\_  ");
            Console.WriteLine("         . . _  \\_____/           █    \\_____/     ");
            Console.WriteLine("                  _| |_                 _| |_       ");
            Thread.Sleep(300); // Pause for 250 milliseconds to create animation effect

            for (int i = 0; i < 9; i++)
            {
                Console.Clear();

                if (i % 3 == 0)
                {
                    Console.WriteLine("                     (P1)                (P2)       ");
                    Console.WriteLine("                    _____        /|      ____       ");
                    Console.WriteLine("            . . _  / (" + a + ") \\      //█    / (" + b + ") \\     ");
                    Console.WriteLine("           . . _  |    - -|   _//_█\\__| > <   |    ");
                    Console.WriteLine("          . . _ _/|     )-|\\__//  █   | ───   |\\_  ");
                    Console.WriteLine("            . . _  \\_____/        █    \\_____/     ");
                    Console.WriteLine("                     _| |_              _| |_       ");
                }
                else if (i % 3 == 1)
                {
                    Console.WriteLine("                     (P1)                (P2)       ");
                    Console.WriteLine("                    _____     /\\         ____       ");
                    Console.WriteLine("            . . _  / (" + a + ") \\    ||  █    / (" + b + ") \\     ");
                    Console.WriteLine("           . . _  |    - -|  _||_ █\\__| > <   |    ");
                    Console.WriteLine("          . . _ _/|     )-|\\__||  █   | ───   |\\_  ");
                    Console.WriteLine("            . . _  \\_____/        █    \\_____/     ");
                    Console.WriteLine("                     _| |_              _| |_       ");
                } else
                {
                    Console.WriteLine("                     (P1)                (P2)       ");
                    Console.WriteLine("                    _____        /|      ____       ");
                    Console.WriteLine("            . . _  / (" + a + ") \\      //█    / (" + b + ") \\     ");
                    Console.WriteLine("           . . _  |    - -|   _//_█\\__| > <   |    ");
                    Console.WriteLine("          . . _ _/|     )-|\\__//  █   | ───   |\\_  ");
                    Console.WriteLine("            . . _  \\_____/        █    \\_____/     ");
                    Console.WriteLine("                     _| |_              _| |_       "); 
                }

                Thread.Sleep(300); // Pause for 250 milliseconds to create animation effect
            }

            Console.CursorVisible = true;
        }
        public static void AnimateTanqueAttack(char a, char b)
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine("        (P1)                             (P2)       ");
            Console.WriteLine("       _____                             ____       ");
            Console.WriteLine("      / (" + a + ") \\                     █    / (" + b + ") \\     ");
            Console.WriteLine("   __|    - -|__                  █\\__| > <   |    ");
            Console.WriteLine("  /  |    ┌──|  \\                 █   | ───   |\\_  ");
            Console.WriteLine("      \\_____/                     █    \\_____/     ");
            Console.WriteLine("       _| |_                            _| |_       ");
            Thread.Sleep(450); // Pause for 250 milliseconds to create animation effect

            Console.Clear();
            Console.WriteLine("                 (P1)                    (P2)       ");
            Console.WriteLine("                ______                   ____       ");
            Console.WriteLine("           . _ / (" + a + ")  \\           █    / (" + b + ") \\     ");
            Console.WriteLine("       . _ ___/    - -/__         █\\__| > <   |    ");
            Console.WriteLine("      . _ /  /    ┌──/   \\        █   | ───   |\\_  ");
            Console.WriteLine("         . _ \\_____/              █    \\_____/     ");
            Console.WriteLine("          . _ _/ /_                     _| |_       ");
            Thread.Sleep(300); // Pause for 250 milliseconds to create animation effect

            Console.Clear();
            Console.WriteLine("                      (P1)               (P2)       ");
            Console.WriteLine("                     ______              ____       ");
            Console.WriteLine("                . _ / (" + a + ")  \\      █    / (" + b + ") \\     ");
            Console.WriteLine("            . _ ___/    - -/__    █\\__| > <   |    ");
            Console.WriteLine("           . _ /  /    ┌──/   \\   █   | ───   |\\_  ");
            Console.WriteLine("              . _ \\_____/         █    \\_____/     ");
            Console.WriteLine("               . _ _/ /_                _| |_       ");
            Thread.Sleep(300); // Pause for 250 milliseconds to create animation effect

            for (int i = 0; i < 9; i++)
            {
                Console.Clear();

                if (i % 3 == 0)
                {
                    Console.WriteLine("                            (P1)         (P2)       ");
                    Console.WriteLine("                           ______        ____       ");
                    Console.WriteLine("                          / (" + a + ")  \\█    / (" + b + ") \\     ");
                    Console.WriteLine("                      ___/    - -/█\\__| > <   |    ");
                    Console.WriteLine("                     /  /    ┌──/ █   | ───   |\\_  ");
                    Console.WriteLine("                        \\_____/   █    \\_____/     ");
                    Console.WriteLine("                         _/ /_          _| |_       ");
                }
                else if (i % 3 == 1)
                {
                    Console.WriteLine("                           (P1)          (P2)       ");
                    Console.WriteLine("                          _____          ____       ");
                    Console.WriteLine("                        / (" + a + ")  \\  █    / (" + b + ") \\     ");
                    Console.WriteLine("                      __|    - -| █\\__| > <   |    ");
                    Console.WriteLine("                     /  |    ┌──| █   | ───   |\\_  ");
                    Console.WriteLine("                         \\______/ █    \\_____/     ");
                    Console.WriteLine("                         _/ |_          _| |_       ");
                } else
                {
                    Console.WriteLine("                            (P1)         (P2)       ");
                    Console.WriteLine("                           ______        ____       ");
                    Console.WriteLine("                          / (" + a + ")  \\█    / (" + b + ") \\     ");
                    Console.WriteLine("                      ___/    - -/█\\__| > <   |    ");
                    Console.WriteLine("                     /  /    ┌──/ █   | ───   |\\_  ");
                    Console.WriteLine("                        \\_____/   █    \\_____/     ");
                    Console.WriteLine("                         _/ /_          _| |_       ");
                }
                Thread.Sleep(300); // Pause for 250 milliseconds to create animation effect
            }

            Console.CursorVisible = true;
        }











    }



}


