using System;
using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    private List<int> scores;
    public HighScores(List<int> list)
    {
        scores = list;
    }

    public List<int> Scores()
    {
        return scores;
    }

    public int Latest()
    {
        return scores.Last();
    }

    public int PersonalBest()
    {
        
        return scores.Max(); 
    }

    public List<int> PersonalTopThree()
    {
        //scores.Sort();          // could remove the sort and reverse if used OrderByDescending(??) in return. Learning how
        //scores.Reverse();
        return scores.OrderByDescending(num => num).Take(3).ToList();     

        //another way
        //List<int> temp = new List<int>();
        //int counter = 0;
        //foreach (int score in scores )
        //{
        //    counter++;
        //    if (counter > 3)
        //    {
        //        break;
        //    }
        //    temp.Add(score);
        //}
        //return temp;



        // another way #2
        //if (list.Count >= 3)
        //{
        //    return new List<int> { list.ElementAt(0), list.ElementAt(1), list.ElementAt(2)};
        //}
        //else if (list.Count == 2)
        //{
        //    return new List<int> { list.ElementAt(0), list.ElementAt(1)};
        //}
        //else
        //{
        //    return new List<int> { list.ElementAt(0)};
        //}

    }
}