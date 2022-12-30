using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HelperLibrary
{
  public static class Tools
  {
    public static string ElapseTimeToHourMinuteSecond(TimeSpan elapsedTime)
    {
      // Format and display the TimeSpan value.
      string heures = $"{elapsedTime.Hours} heure{Plural(elapsedTime.Hours)}";
      string minutes = $"{elapsedTime.Minutes} minute{Plural(elapsedTime.Minutes)}";
      string secondes = $"{elapsedTime.Seconds} seconde{Plural(elapsedTime.Seconds)}";
      string millisecondes = $"{elapsedTime.Milliseconds} milliseconde{Plural(elapsedTime.Milliseconds)}";
      string result = $"{heures} {minutes} {secondes} et {millisecondes}";
      return result;
    }

    public static string Plural(int number)
    {
      return number > 1 ? "s" : string.Empty;
    }

    public static bool IsFileBinary(string filename, string commaSeparatedBinaryExtensions)
    {
      bool result = false;
      foreach (string extension in commaSeparatedBinaryExtensions.Split(','))
      {
        if (Path.GetExtension(filename) == extension)
        {
          return true;
        }
      }

      return result;
    }

    public static List<string> GetMatchedItems(List<string> fileLines, string sqlSearchedWords)
    {
      var result = new List<string>();
      foreach (string item in sqlSearchedWords.Split(','))
      {
        result.AddRange(fileLines.Where(x => x.Contains(item.ToLower())).ToList());
        result.AddRange(fileLines.Where(x => x.Contains(item.ToUpper())).ToList());
      }

      return result;
    }

    public static bool ListOfLinesHasMatch(List<string> fileLines, string sqlRequestStartWord)
    {
      foreach (string item in sqlRequestStartWord.Split(','))
      {
        if (fileLines.Any(w => w.Contains(item.ToLower())) || fileLines.Any(w => w.Contains(item.ToUpper())))
        {
          return true;
        }
      }

      return false;
    }
  }
}
