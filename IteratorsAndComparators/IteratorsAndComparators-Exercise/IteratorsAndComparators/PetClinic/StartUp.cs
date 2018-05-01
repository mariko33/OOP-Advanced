using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class StartUp
{
    private static List<Pet> pets = new List<Pet>();
    private static List<Clinic> clinics = new List<Clinic>();
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        for (int i = 0; i < number; i++)
        {
            var input = Console.ReadLine().Split();

            try
            {
                Run(input);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }


    }

    private static void Run(string[] input)
    {
        string command = input[0];
        switch (command)
        {
            case "Create":
                {
                    string typeOfCreation = input[1];
                    if (typeOfCreation == "Pet")
                    {
                        Pet pet = new Pet(input[2], int.Parse(input[3]), input[4]);
                        pets.Add(pet);
                    }
                    else
                    {
                        Clinic clinic = new Clinic(input[2], int.Parse(input[3]));
                        
                        clinics.Add(clinic);
                    }
                    break;
                }
            case "Add":
                {
                    string petName = input[1];
                    string clinicName = input[2];

                    Clinic clinic = clinics.FirstOrDefault(c => c.Name == clinicName);
                    Pet pet = pets.FirstOrDefault(p => p.Name == petName);
                    Console.WriteLine(clinic.AddPet(pet));
                    break;
                }
            case "Release":
                {
                    string clinicName = input[1];

                    Clinic clinic = clinics.FirstOrDefault(c => c.Name == clinicName);
                    Console.WriteLine(clinic.ReleasingPet());
                    break;

                }
            case "HasEmptyRooms":
                {
                    string clinicName = input[1];

                    Clinic clinic = clinics.FirstOrDefault(c => c.Name == clinicName);
                    Console.WriteLine(clinic.HasEmptyRoom());
                    break;
                }
            case "Print":
            {
                string clinicName = input[1];
                Clinic clinic = clinics.FirstOrDefault(c => c.Name == clinicName);
                if (input.Length == 2)
                {

                    Console.WriteLine(clinic.ToString());
                }
                else
                {
                    int roomNumber = int.Parse(input[2]);
                    Console.WriteLine(clinic.PrintRoom(roomNumber));
                }
                break;
            }
        }

    }
}




