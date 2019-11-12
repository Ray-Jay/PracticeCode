using System;
using System.Collections.Generic;
using System.Linq;


public class GradeSchool
{
    // create Dictionary to hold grade and List of students in each grade
    Dictionary<int, List<string>> schoolRoster = new Dictionary<int, List<string>>();

    // Adds grade if not already in dictionary, then adds student
    public void Add(string student, int grade)
    {
        if (!schoolRoster.ContainsKey(grade))
        {
            schoolRoster.Add(grade, new List<string>());
        }
        schoolRoster[grade].Add(student);
    }

    // creates new list to hold students, loops through all lists, ordered by grade, then ordered by students. returns list as array
    public IEnumerable<string> Roster()
    {
        List<string> students = new List<string>();
        foreach (int grade in schoolRoster.Keys.OrderBy(x => x))
        {
            students.AddRange(schoolRoster[grade].OrderBy(x => x));
        }
        return students.ToArray();
    }

    // if the grade is already in the schoolRoster, send all students in that list, ordered by name, otherwise send a blank list
    public IEnumerable<string> Grade(int grade)
    {
        if (schoolRoster.ContainsKey(grade))
        {
            return schoolRoster[grade].OrderBy(x => x);
        }
        return new List<string>();
    }
}