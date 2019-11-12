using System;
using System.Collections.Generic;

public enum Shakes
{
    Wink = 1,
    Double_Blink = 2,
    Close_Eyes = 4,
    Jump = 8,
    Reverse = 16,
}

public static class SecretHandshake
{
    public static string[] Commands(int commandValue)
    {
        List<Shakes> handshakes = new List<Shakes>();
        List<string> results = new List<string>();
        bool isReverse = false;
        
        for (int i = 1; i <= 5; i++)
        {
            if ((1 << (i - 1) & commandValue) != 0)            // shifting left by one space at a time to read bits from right to left
            {
                handshakes.Add((Shakes)(1 << (i - 1)));
            }
        }

        foreach (Shakes shake in handshakes)
        {
            switch (shake)
            {
                case Shakes.Wink:
                    results.Add(Shakes.Wink.ToString().ToLower());
                    break;
                case Shakes.Double_Blink:
                    results.Add("double blink");
                    break;
                case Shakes.Close_Eyes:
                    results.Add("close your eyes");
                    break;
                case Shakes.Jump:
                    results.Add(Shakes.Jump.ToString().ToLower());
                    break;
                case Shakes.Reverse:
                    isReverse = true;
                    break;
                default:
                    break;
            }
        }

        if (isReverse)
        {
            results.Reverse();
        } 

        return results.ToArray();
    }
}
