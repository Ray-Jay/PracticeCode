//  Date: 10-25-19
//  Exercism IO RNA Transciption
//  Purpose: receive a DNA input string and transcribe it to the corresponding RNA code

using System.Text;

public static class RnaTranscription
{
    public static string ToRna(string nucleotide)
    {
        string DNA = "ACGT";
        string RNA = "UGCA";
        StringBuilder sb = new StringBuilder(nucleotide.Length);

        foreach (char s in nucleotide)
        {
            int index = DNA.IndexOf(s);
            sb.Append(RNA[index]);
        }
        
        return sb.ToString();
    }
}