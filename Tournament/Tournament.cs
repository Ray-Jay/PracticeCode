// help provided by: ntsaini on exercism
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Tournament
{
    public static void Tally(Stream inStream, Stream outStream)
    {
        // create variables to read input, write output, and hold team data
        var sr = new StreamReader(inStream);
        var sw = new StreamWriter(outStream);
        var statsDict = new Dictionary<string, TeamInfo>();

        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            string[] splitArr = line.Split(';');
            //if (splitArr.Length == 3)
            //{
                string teamA = splitArr[0];
                string teamB = splitArr[1];
                string gameResult = splitArr[2];

                // if team is not in the dictionary, add it
                if (!statsDict.TryGetValue(teamA, out TeamInfo teamAInfo))
                {
                    teamAInfo = new TeamInfo(teamA);
                    statsDict.Add(teamA, teamAInfo);
                }
                if (!statsDict.TryGetValue(teamB, out TeamInfo teamBInfo))
                {
                    teamBInfo = new TeamInfo(teamB);
                    statsDict.Add(teamB, teamBInfo);
                }

                // update statistics for each team
                teamAInfo.Played++;
                teamBInfo.Played++;
                switch (gameResult)
                {
                    case "win":
                        teamAInfo.Won++;
                        teamBInfo.Loss++;
                        teamAInfo.Points += 3;
                        break;
                    case "loss":
                        teamAInfo.Loss++;
                        teamBInfo.Won++;
                        teamBInfo.Points += 3;
                        break;
                    case "draw":
                        teamAInfo.Draw++;
                        teamBInfo.Draw++;
                        teamAInfo.Points++;
                        teamBInfo.Points++;
                        break;
                    default:
                        break;
                }
           // }
        } //end while

        // sort the results, descending by points and if tied, ascending by name
        var statsList = statsDict.Values.ToList().OrderByDescending(x => x.Points).ThenBy(x => x.Name);

        // the commented code below does the same thing as the line listed above
        //var statsList = statsDict.Values.ToList();
        //statsList.Sort((x, y) =>
        //{
        //    // sort by points, descending
        //    int result = y.Points.CompareTo(x.Points);
        //    if (result == 0)  // if same # of points, sort by team name, ascending
        //    {
        //        result = x.Name.CompareTo(y.Name);
        //    }
        //    return result;
        //});

        // prepare output
        sw.Write("Team                           | MP |  W |  D |  L |  P");
        foreach (var stat in statsList)
        {
            sw.Write("\n");
            sw.Write("{0,-30} |{1,3} |{2,3} |{3,3} |{4,3} |{5,3}",
                stat.Name, stat.Played, stat.Won, stat.Draw, stat.Loss, stat.Points
                );
        }
        sw.Close();
    }
}

// class to hold all statistics for a team
class TeamInfo
{
    // properties
    public string Name { get; set; }
    public int Played { get; set; }
    public int Won { get; set; }
    public int Loss { get; set; }
    public int Draw { get; set; }
    public int Points { get; set; }

    // constructor
    public TeamInfo(string team)
    {
        Name = team;
    }
}
