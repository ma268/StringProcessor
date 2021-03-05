using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringProcessor.Repository
{
    public class StringRepository
    {
        public List<String> TrucateStrings(List<String> originalStrings)
        {
            List<String> newStrings = new List<String>();

            foreach (var str in originalStrings)
            {
                if (str.Length > 15)
                {
                    newStrings.Add(str.Substring(0, 15));
                }
                else
                {
                    newStrings.Add(str);
                }
            }

            return newStrings;
        }

        public List<String> RemoveNullEmptyStringMembers(List<String> originalStrings)
        {
            List<String> newStrings = new List<String>();
            foreach (var str in originalStrings)
            {
                if (!string.IsNullOrEmpty(str))
                {
                    newStrings.Add(str);
                }
            }

            return newStrings;
        }

        public List<String> RemoveDuplcateChars(List<String> originalStrings)
        {
            List<String> newStrings = new List<String>();

            foreach (var str in originalStrings)
            {
                if (str.Length < 2)
                    break;

                Regex regex = new Regex("(.)(?<=\\1\\1)", RegexOptions.CultureInvariant | RegexOptions.Compiled);

                newStrings.Add(regex.Replace(str, string.Empty));

            }

            return newStrings;
        }

        public List<String> ReplaceDollarSymbols(List<String> originalStrings)
        {
            List<String> newStrings = new List<String>();

            foreach (var str in originalStrings)
            {
                Regex regex = new Regex("\\$");

                newStrings.Add(regex.Replace(str, "£"));

            }

            return newStrings;
        }

        public List<String> RemoveUnderscore(List<String> originalStrings)
        {
            List<String> newStrings = new List<String>();

            foreach (var str in originalStrings)
            {
                Regex regex = new Regex("_");

                newStrings.Add(regex.Replace(str, string.Empty));

            }

            return newStrings;
        }

        public List<String> RemoveNo4(List<String> originalStrings)
        {
            List<String> newStrings = new List<String>();

            foreach (var str in originalStrings)
            {
                Regex regex = new Regex("4");

                newStrings.Add(regex.Replace(str, string.Empty));

            }

            return newStrings;
        }
    }
}
