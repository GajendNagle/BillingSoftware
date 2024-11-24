using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for MoneyConverter_C
/// </summary>
public class MoneyConverter_C
{
    public  string CurrencyToWord(string number)
    {
        string temp;
        string rupees, paisa;
        rupees = paisa = string.Empty;
        int decimalPlace, count;
        string hundreds, words;
        hundreds = words = string.Empty;
        string[] places = new string[9];
        places[0] = "Thousand";
        places[2] = "Lakh";
        places[4] = "Crore";
        places[6] = "Arab";
        places[8] = "Kharab";
        string[] no = number.Split('.');
        decimalPlace = number.IndexOf('.');
        if (decimalPlace > 0)
        {
            temp = no[1].PadLeft(2, '0');
            if (double.Parse(temp) > 0)
            {
                paisa = " and " + ConvertTens(temp).Trim() + " Paisa";
            }
        }
        no[0] = no[0].PadLeft(3, '0');
        hundreds = ConvertHundreds(no[0].Substring(no[0].Length - 3));
        no[0] = no[0].Substring(0, no[0].Length - 3);
        count = 0;
        while (no[0] != string.Empty)
        {
            if (no[0].Length == 1)
            {
                words = ConvertDigit(no[0]) + " " + places[count] + " " + words;
                no[0] = no[0].Substring(0, no[0].Length - 1);
            }
            else
            {
                temp = no[0].Substring(no[0].Length - 2);
                words = ConvertTens(temp) + " " + places[count] + " " + words;
                no[0] = no[0].Substring(0, no[0].Length - 2);
            }
            count += 2;
        }
        return "Rupees " + words.Trim() + " " + hundreds.Trim() + paisa + " " + "Only";
    }
    public  string ConvertHundreds(string value)
    {
        string result = string.Empty;
        if (decimal.Parse(value) == 0)
            return string.Empty;
        value = value.PadRight(3, '0');
        if (int.Parse(value.Substring(0, 1)) != 0)
            result = ConvertDigit(value.Substring(0, 1)) + " Hundred";
        if (int.Parse(value.Substring(1, 1)) != 0)
            result += " " + ConvertTens(value.Substring(1, 2));
        else
            result += " " + ConvertDigit(value.Substring(2, 1));
        return result.Trim();
    }

    public  string ConvertTens(string value)
    {
        string result = string.Empty;
        if (decimal.Parse(value.Substring(0, 1)) == 1)
        {
            switch (int.Parse(value))
            {
                case 10: result = "Ten"; break;
                case 11: result = "Eleven"; break;
                case 12: result = "Twelve"; break;
                case 13: result = "Thirteen"; break;
                case 14: result = "Fourteen"; break;
                case 15: result = "Fifteen"; break;
                case 16: result = "Sixteen"; break;
                case 17: result = "Seventeen"; break;
                case 18: result = "Eighteen"; break;
                case 19: result = "Nineteen"; break;
            }
        }
        else
        {
            switch (int.Parse(value.Substring(0, 1)))
            {
                case 2: result = "Twenty"; break;
                case 3: result = "Thirty"; break;
                case 4: result = "Fourty"; break;
                case 5: result = "Fifty"; break;
                case 6: result = "Sixty"; break;
                case 7: result = "Seventy"; break;
                case 8: result = "Eighty"; break;
                case 9: result = "Ninety"; break;
            }
            result += " " + ConvertDigit(value.Substring(1, 1));
        }
        return result.Trim();
    }

    private string ConvertDigit(string p)
    {
        switch (int.Parse(p))
        {
            case 1: return "One";
            case 2: return "Two";
            case 3: return "Three";
            case 4: return "Four";
            case 5: return "Five";
            case 6: return "Six";
            case 7: return "Seven";
            case 8: return "Eight";
            case 9: return "Nine";
            default: return string.Empty;
        }
    }
}
