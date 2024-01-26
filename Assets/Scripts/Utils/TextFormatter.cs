using System;

public class TextFormatter 
{
    public static string DivideIntWithChar(int value, char dividingChar)
    {
        string stringToReturn = value.ToString();
      
        if(value > 999)
        {
            int charsAmount = 0;
            for(int i = stringToReturn.Length - 1; i >= 0; i--)
            {
                if(stringToReturn[i] != dividingChar && (i - 1 != 0 || i != 0)) charsAmount++;
                if(charsAmount == 3 && i != 0)
                {
                    stringToReturn = stringToReturn.Substring(0,i) + dividingChar + stringToReturn.Substring(i);
                    charsAmount = 0;
                }
            }
        }
        return $"{stringToReturn}";
    }

    public static string FormatPercentageValue(float percentage)
    {
        string charToPut = String.Empty;
        if (percentage > 0) charToPut = "+";
        
        percentage *= 100;
        return $"{charToPut}{percentage:0.#}%";
    }
}
