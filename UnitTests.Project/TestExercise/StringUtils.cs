namespace UnitTests.InitialProject.TestExercise;
public class StringUtils
{
    public string ReverseString(string str)
    {
        if (string.IsNullOrEmpty(str))
            return str;

        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public string ToUpperCase(string str)
    {
        if (string.IsNullOrEmpty(str))
            return str;

        return str.ToUpper();
    }

    public string ToLowerCase(string str)
    {
        if (string.IsNullOrEmpty(str))
            return str;

        return str.ToLower();
    }

    public string ConcatenateStrings(params string[] strings)
    {
        return string.Concat(strings);
    }

    public bool IsPalindrome(string word)
    {
        word = word.ToLower();

        int startIndex = 0;
        int endIndex = word.Length - 1;

        while (startIndex < endIndex)
        {
            if (word[startIndex] != word[endIndex])
            {
                return false;
            }

            startIndex++;
            endIndex--;
        }

        return true;
    }

    public bool AreEqualOrdinalIgnoreCase(string str1, string str2)
    {
        return string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);
    }

    public bool AreEqualOrdinalCase(string str1, string str2)
    {
        return string.Equals(str1, str2, StringComparison.Ordinal);
    }

    public bool checkStartEnd(string str,string x, string y)
    {
        return str.StartsWith(x, StringComparison.OrdinalIgnoreCase) &&
               str.EndsWith(y, StringComparison.OrdinalIgnoreCase);
    }

    public int CountVowels(string text)
    {
        int count = 0;
        foreach (char c in text)
        {
            if ("aeiou".IndexOf(c, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                count++;
            }
        }
        return count;
    }

    public int CountWords(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return 0;

        int wordCount = 0;
        bool previousIsWhiteSpace = true;

        foreach (char c in input)
        {
            if (char.IsWhiteSpace(c))
            {
                previousIsWhiteSpace = true;
            }
            else if (previousIsWhiteSpace)
            {
                wordCount++;
                previousIsWhiteSpace = false;
            }
        }

        return wordCount;
    }

    public int CountCharacterOccurrences(string input, char character)
    {
        if (string.IsNullOrEmpty(input))
            return 0;

        int count = 0;
        int index = 0;
        string target = character.ToString();  

        while ((index = input.IndexOf(target, index, StringComparison.OrdinalIgnoreCase)) != -1)
        {
            count++;
            index++; 
        }

        return count;
    }

    public string ReverseWords(string str)
    {
        if (string.IsNullOrWhiteSpace(str))
            return str;

        return string.Join(" ", str.Split(' ').Reverse());
    }

    public string AlternateCase(string str)
    {
        if (string.IsNullOrEmpty(str))
            return str;

        return new string(str.Select(c => char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c)).ToArray());
    }
}
