using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringProcessor.Repository;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StringProcessorTests
{
    [TestClass]
    public class StringPorcessorTests
    {
        [TestMethod]
        public void TrucateStrings_StringLengthLessOrEqualTo15_ReturnsTrue()
        {
            List<string> originalStrings = new List<string>() 
            {
                "AAAc91%cWwWkLq$1ci3_848v3d__K",
                "Abbbc51%cCcCWkLq$1sd_4568923__h"
            };

            var stringRepository = new StringRepository();

            var formattedStrings = stringRepository.TrucateStrings(originalStrings);

            foreach (var str in formattedStrings)
            {
                Assert.IsTrue(str.Length <= 15);
            }
        }

        [TestMethod]
        public void RemoveNo4_4HasbeenRemoved_ReturnsTrue()
        {
            List<string> originalStrings = new List<string>()
            {
                "AAAc91%cWwWkLq$1ci3_848v3d__K",
                "Abbbc51%cCcCWkLq$1sd_4568923__h"
            };

            var stringRepository = new StringRepository();

            var formattedStrings = stringRepository.RemoveNo4(originalStrings);

            foreach (var str in formattedStrings)
            {
                Assert.IsTrue(!str.Contains("4"));
            }
        }

        [TestMethod]
        public void RemoveUnderscore_UnderscoreHasbeenRemoved_ReturnsTrue()
        {
            List<string> originalStrings = new List<string>()
            {
                "AAAc91%cWwWkLq$1ci3_848v3d__K",
                "Abbbc51%cCcCWkLq$1sd_4568923__h"
            };

            var stringRepository = new StringRepository();

            var formattedStrings = stringRepository.RemoveUnderscore(originalStrings);

            foreach (var str in formattedStrings)
            {
                Assert.IsTrue(!str.Contains("_"));
            }
        }

        [TestMethod]
        public void ReplaceDollarSymbols_DollarHasbeenReplacedWithPound_ReturnsTrue()
        {
            List<string> originalStrings = new List<string>()
            {
                "AAAc91%cWwWkLq$1ci3_848v3d__K",
                "Abbbc51%cCcCWkLq$1sd_4568923__h"
            };

            var stringRepository = new StringRepository();

            var formattedStrings = stringRepository.ReplaceDollarSymbols(originalStrings);

            foreach (var str in formattedStrings)
            {
                Assert.IsTrue(!str.Contains("$") && str.Contains("£"));
            }
        }

        [TestMethod]
        public void RemoveDuplcateChars_DuplicatesRemoved_ReturnsTrue()
        {
            List<string> originalStrings = new List<string>()
            {
                "AAAc91%cWwWkLq$1ci3_848v3d__K",
                "Abbbc51%cCcCWkLq$1sd_4568923__h"
            };

            var stringRepository = new StringRepository();

            var formattedStrings = stringRepository.RemoveDuplcateChars(originalStrings);

            Regex regEx = new Regex("/([A - Za - z]).*\\1");

            foreach (var str in formattedStrings)
            {
                var s = regEx.Match(str).Value;
                Assert.IsTrue(string.IsNullOrEmpty(s));
            }
        }

        [TestMethod]
        public void RemoveNullEmptyStringMembers_ReturnsTrue()
        {
            List<string> originalStrings = new List<string>()
            {
                "",
                "Abbbc51%cCcCWkLq$1sd_4568923__h"
            };

            var stringRepository = new StringRepository();

            var formattedStrings = stringRepository.RemoveNullEmptyStringMembers(originalStrings);

            foreach (var str in formattedStrings)
            {
                Assert.IsTrue(!string.IsNullOrEmpty(str));
            }
        }
    }
}
