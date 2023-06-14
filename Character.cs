// ************* LIBRARIES ************* //
using System;
using static System.Math;
using System.Globalization;

namespace CSharp_Combat_Minigame
{
    public class Character
    {
        // ************* DATA STRUCTURES ************* //
        public enum CharacterClass { Mago, Luchador, Tanque };
        public static string[] FirstName={"Elfo", "Ogro", "Caballero", "Hechicero", "Enano", "Druida", "Cazador", "Monje", "Paladin", "Brujo", "Nigromante", "Arquero", "Guardian", "Alquimista", "Sacerdote" };
        public static string[] LastName={" del Bosque", " de los Valles", " del Amanecer", " de la Oscuridad", " del Abismo", " de la Tormenta", " de la Niebla", " del Horizonte", " del Desierto", " de las Ruinas", " de Hielo", " de Fuego", " del Cielo", " del Submundo", " de la Aurora" };


        // ************* ATTRIBUTES ************* //
        private int id; // Id
        private string fullName; // Full name
        private CharacterClass chClass; // Character class
        private double attack; // Attack points
        private double life; // Life points
        private double criticalHitProbability ; //Critical hit probability 



        // ************* GETTERS AND SETTERS ************* //
        public int Id { get => id; set => id = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public CharacterClass ChClass { get => chClass; set => chClass = value; }
        public double Attack { get => attack; set => attack = value; }
        public double Life { get => life; set => life = value; }
        public double CriticalHitProbability { get => criticalHitProbability; set => criticalHitProbability = value; }


        // ************* CONSTUCTOR ************* //
        // Constructor
        public Character(int id, string fullName, CharacterClass chClass, double attack, double life, double criticalHitProbability)
        {
            this.id = id;
            this.fullName = fullName;
            this.chClass = chClass;
            this.attack = attack;
            this.life = life;
            this.criticalHitProbability = criticalHitProbability;
        }

        // Empty Constructor
        public Character()
        {
            this.id = 0;
            this.fullName = "";
            //this.chClass = null;
            this.attack = 0;
            this.life = 0;
            this.criticalHitProbability = 0;
        }



        // ************* METHODS  ************* //
        // Show a character
        public void ShowCharacter()
        {
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Nombre: " + fullName);
            Console.WriteLine("Clase: " + chClass);
            Console.WriteLine("Ataque: " + attack);
            Console.WriteLine("Vida: " + life);
            Console.WriteLine("Probabilidad de golpe critico: " + criticalHitProbability);
            Console.WriteLine();
        }


    }


}


