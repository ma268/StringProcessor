using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringProcessor.Repository
{
    public interface IStringRepository
    {

        List<String> TrucateStrings(List<String> originalStrings);

        List<String> RemoveNullEmptyStringMembers(List<String> originalStrings);

        List<String> RemoveDuplcateChars(List<String> originalStrings);

        List<String> ReplaceDollarSymbols(List<String> originalStrings);

        List<String> RemoveUnderscore(List<String> originalStrings);

        List<String> RemoveNo4(List<String> originalStrings);
    }
}
