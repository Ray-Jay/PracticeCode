//  Date: 10-23-19
//  Chapter 38 pgs 236 - 244
//  Purpose: Learn to use Language Integrated Query (LINQ)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace QueryExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            List<GameObject> gameObjects = new List<GameObject>();
            gameObjects.Add(new Ship { ID = 3, X = 9, Y = 3, CurrentHP = 0,   MaxHP = 100, PlayerID = 2 });
            gameObjects.Add(new Ship { ID = 2, X = 4, Y = 2, CurrentHP = 75, MaxHP = 100, PlayerID = 1 });
            gameObjects.Add(new Ship { ID = 4, X = 2, Y = 4, CurrentHP = 100, MaxHP = 100, PlayerID = 3 });
            gameObjects.Add(new Ship { ID = 1, X = 0, Y = 0, CurrentHP = 50,  MaxHP = 100, PlayerID = 1 });

            List<Player> players = new List<Player>();
            players.Add(new Player { ID = 1, UserName = "Player 1", TeamColor = "Red" });
            players.Add(new Player { ID = 2, UserName = "Player 2", TeamColor = "Blue" });
            players.Add(new Player { ID = 3, UserName = "Player 3", TeamColor = "Indigo" });

            // selects each currentHP and maxHP and saves in a new list
            Console.WriteLine("1) from -> select");
            IEnumerable<string> results = from o in gameObjects
                                          select o.CurrentHP + "/" + o.MaxHP;
            foreach (string s in results)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();

            // selects currentHP, if moving, and saves in a new list of game objects
            Console.WriteLine("2) where");
            IEnumerable<GameObject> moving = from o in gameObjects
                                             where o.CurrentHP > 0
                                             select o;
            // foreach as Lambda expression
            moving.ToList().ForEach(i => Console.WriteLine(i));
            Console.WriteLine();

            // uses let to create variable percentUse for later use. then saves info about each object to new IEnumerable
            Console.WriteLine("3) let");
            IEnumerable<string> statuses = from o in gameObjects
                                           let percentUse = Math.Round(o.CurrentHP / o.MaxHP * 100)
                                           select $"{o.ID} is at {percentUse}%.";
            statuses.ToList().ForEach(i => Console.WriteLine(i));
            Console.WriteLine();

            // use join on gameObjects and players and create a var of id's and color
            Console.WriteLine("4) join");
            var objectColors = from o in gameObjects
                               join p in players on o.PlayerID equals p.ID
                               select new { o.ID, p.TeamColor };        // this is called an anonymous type. it creates an object (that isn't named)
            objectColors.ToList().ForEach(i => Console.WriteLine(i));
            Console.WriteLine();

            // use orderby to sort player names and add to IEnumerable
            Console.WriteLine("5) orderby");
            IEnumerable<Player> sortedPlayers = from p in players
                                                orderby p.UserName     // default is ascending. could add descending after UserName
                                                select p;
            sortedPlayers.ToList().ForEach(i => Console.WriteLine(i.UserName));
            Console.WriteLine();

            // use multi-level sort using orderby and add to IEnumerable
            Console.WriteLine("6) multi-level orderby");
            IEnumerable<GameObject> sortedGameObjects = from o in gameObjects
                                                        orderby o.PlayerID ascending, o.MaxHP descending
                                                        select o;
            sortedGameObjects.ToList().ForEach(i => Console.WriteLine(i));
            Console.WriteLine();

            // use group clause to bundle items and add to IEnumerable grouping
            Console.WriteLine("7) group by");
            // IEnumerable<IGrouping<int, GameObject>>  belowcould be replaced by "var" 
            IEnumerable<IGrouping<int, GameObject>> groups = from o in gameObjects
                                                             group o by o.PlayerID;
            groups.ToList().ForEach(i => Console.WriteLine(i.Key));
            Console.WriteLine();

            // use into keyword to continue work after group and take results and put into playerGroup variable
            Console.WriteLine("8) into");
            var objectCountPerPlayer = from o in gameObjects
                                       group o by o.PlayerID
                                       into playerGroup
                                       select new { ID = playerGroup.Key, Count = playerGroup.Count() };
            objectCountPerPlayer.ToList().ForEach(i => Console.WriteLine(i.ID + " " + i.Count));
            Console.WriteLine();

            // use join and into keywords to create group join
            Console.WriteLine("9) group join");
            var playerObjects = from p in players
                                join o in gameObjects on p.ID equals o.PlayerID into objectsOwnedByPlayer
                                select new { Player = p, Objects = objectsOwnedByPlayer };
            foreach (var objects in playerObjects)
            {
                Console.WriteLine(objects.Player.UserName + " has the following objects: ");
                foreach (GameObject o in objects.Objects)
                {
                    Console.WriteLine($"     {o.ID} {o.CurrentHP} /{o.MaxHP}");
                }
            }
            Console.WriteLine();


            // method syntax for shortcuts. Like #2 above, but using ints
            Console.WriteLine("10) method syntax");
            IEnumerable<int> aliveIDs2 = gameObjects.Where(o => o.CurrentHP > 0).Select(o => o.ID);

            // replaces this:
            //IEnumerable<int> aliveIDs1 = from o in gameObjects
            //                             where o.CurrentHP > 0
            //                             select o.ID;
            aliveIDs2.ToList().ForEach(i => Console.WriteLine(i));
            Console.WriteLine();

            // page 244 Try It Out #1
            Console.WriteLine("11) full health");
            IEnumerable<GameObject> fullHealth = gameObjects.Where(o => o.MaxHP == o.CurrentHP).Select(o => o);
            fullHealth.ToList().ForEach(i => Console.WriteLine(i));
            Console.WriteLine();
            IEnumerable<int> fullHealthIDs = gameObjects.Where(o => o.MaxHP == o.CurrentHP).Select(o => o.PlayerID);
            fullHealthIDs.ToList().ForEach(i => Console.WriteLine(i));

            // page 244 Try It Out #2   
            Console.WriteLine("12) percent health");
            var percentHealth = gameObjects
                .GroupBy(o => new { o.PlayerID, o.CurrentHP, o.MaxHP })
                .OrderBy(o => o.Key.CurrentHP / o.Key.MaxHP)
                .Select(o => o);

            // same as: 
            //var percentHealth = from o in gameObjects
            //                    group o by new { o.PlayerID, o.CurrentHP, o.MaxHP } into pgroup
            //                    orderby pgroup.Key.CurrentHP / pgroup.Key.MaxHP
            //                    select pgroup;

            percentHealth.ToList().ForEach(i => Console.WriteLine($"Player ID: {i.Key.PlayerID} Health Points: {i.Key.CurrentHP}"));
            Console.WriteLine();

            // page 244 Try It Out #3
            Console.WriteLine("13) query without LINQ");

            List<GameObject> aliveObjects2 = new List<GameObject>();
            foreach (GameObject game in gameObjects)
            {
                if (game.CurrentHP > 0)
                {
                    aliveObjects2.Add(game);
                }
            }
            aliveObjects2.ForEach(a => Console.WriteLine(a));

            // with LINQ:
            //IEnumerable<GameObject> aliveObjects = from o in gameObjects
            //                                       where o.CurrentHP > 0
            //                                       select o;

            //aliveObjects.ToList().ForEach(i => Console.WriteLine(i));
        }
    }
}
