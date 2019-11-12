using System;
using System.Collections.Generic;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden
{
    string[] plantsGroupedByStudent;
    private string[] students = { "Alice", "Bob", "Charlie", "David", 
                                  "Eve", "Fred", "Ginny", "Harriet", 
                                  "Ileana", "Joseph", "Kincaid", "Larry" };
    // constructor
    // split input string on newline character. then put into groups of 4 to match the students array placement
    public KindergartenGarden(string diagram)
    {
        string[] temp = diagram.Split('\n');
        char[] tempRow1 = temp[0].ToCharArray();
        char[] tempRow2 = temp[1].ToCharArray();

        plantsGroupedByStudent = new string[tempRow1.Length/2];

        for (int i = 0; i < plantsGroupedByStudent.Length; i++)    
        {
            plantsGroupedByStudent[i] = tempRow1[i * 2].ToString() + tempRow1[i * 2 + 1] + tempRow2[i * 2] + tempRow2[i * 2 + 1];
        }
    }

    // find the student index and match it to the plantsGroupedByStudent array
    public IEnumerable<Plant> Plants(string student)
    {
        int index = Array.IndexOf(students, student);
        string studentPlants = plantsGroupedByStudent[index];

        List<Plant> plants = new List<Plant>();
        foreach (char c in studentPlants)
        {
            switch (c)
            {
                case 'V':
                    plants.Add(Plant.Violets);
                    break;
                case 'R':
                    plants.Add(Plant.Radishes);
                    break;
                case 'C':
                    plants.Add(Plant.Clover);
                    break;
                case 'G':
                    plants.Add(Plant.Grass);
                    break;
            }
        }

        return plants;
    }
}