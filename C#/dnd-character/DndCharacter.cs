using System;

public class DndCharacter
{
    public int Strength { get; private set; }
    public int Dexterity { get; private set; }
    public int Constitution { get; private set; }
    public int Intelligence { get; private set; }
    public int Wisdom { get; private set; }
    public int Charisma { get; private set; }
    public int Hitpoints { get; private set; }

    public static int Modifier(int score)
    {
        return (int)Math.Floor((score - 10.0) / 2);
    }

    public static int Ability() 
    {
        Random rand = new Random();
        int die1 = rand.Next(1, 7);
        int die2 = rand.Next(1, 7);
        int die3 = rand.Next(1, 7);
        int die4 = rand.Next(1, 7);
        int min1 = Math.Min(die1, die2);
        int min2 = Math.Min(die3, die4);
        int minimum = Math.Min(min1, min2);

        return die1 + die2 + die3 + die4 - minimum;
    }

    public static DndCharacter Generate()
    {
        DndCharacter dnd = new DndCharacter();
        dnd.Strength = Ability();
        dnd.Dexterity = Ability();
        dnd.Constitution = Ability();
        dnd.Intelligence = Ability();
        dnd.Wisdom = Ability();
        dnd.Charisma = Ability();
        dnd.Hitpoints = 10 + Modifier(dnd.Constitution);

        return dnd;
    }
}
