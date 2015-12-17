using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringExtension;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestStringExtensions
    {
        [TestMethod]
        public void TestToMorseCode()
        {
            const string test = "sos";
            const string expected = "... --- ...";
            var result = test.ToMorseCode();
            Assert.IsTrue(result.Equals(expected));
        }

        [TestMethod]
        public void TestToMorseCodeT()
        {
            const string test = "T";
            var result = test.ToMorseCode();
            Assert.IsTrue(String.Compare(result, "-", StringComparison.Ordinal) == 0);
        }

        [TestMethod]
        public void TestToMorseCodeE()
        {
            const string test = "E";
            var result = test.ToMorseCode();
            Assert.IsTrue(String.Compare(result, ".", StringComparison.Ordinal) == 0);
        }

        [TestMethod]
        public void TestLeft()
        {
            const string test = "test";
            var result = test.Left(2);
            Assert.IsTrue(result.Equals("te"));
        }

        [TestMethod]
        public void TestLeftExceedsCount()
        {
            const string test = "test";
            var result = test.Left(5);
            Assert.IsTrue(result.Equals("test"));
        }

        [TestMethod]
        public void TestLeftNull()
        {
            string test = null;
            var result = test.Left(5);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestRight()
        {
            const string test = "test";
            var result = test.Right(2);
            Assert.IsTrue(result.Equals("st"));
        }

        [TestMethod]
        public void TestRightExceedsCount()
        {
            const string test = "test";
            var result = test.Right(5);
            Assert.IsTrue(result.Equals("test"));
        }

        [TestMethod]
        public void TestRightNull()
        {
            string test = null;
            var result = test.Right(5);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestMiddle()
        {
            const string test = "test";
            var result = test.Middle(1, 2);
            Assert.IsTrue(result.Equals("es"));
        }


        [TestMethod]
        public void TestMiddleNull()
        {
            string test = null;
            var result = test.Middle(1, 2);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestToBytes()
        {
            const string test = "test";
            var result = test.ToBytes();
            Assert.IsTrue(test.Count() == 4);
        }

        [TestMethod]
        public void TestTryParse()
        {
            const string test = "125";
            int val;
            var result = test.TryParse(out val);
            Assert.IsTrue(result);
            Assert.IsTrue(val == 125);
        }

        [TestMethod]
        public void TestTryNullableParse()
        {
            const string test = "125";
            int? val;
            var result = test.TryNullableParse(out val);
            Assert.IsTrue(result);
            Assert.IsTrue(val == 125);
        }

        [TestMethod]
        public void TestGetLastCharacterAsString()
        {
            const string test = "test";
            var result = test.GetLastCharacterAsString();
            Assert.IsTrue(result == "t");
        }

        [TestMethod]
        public void TestGetFirstCharacterAsString()
        {
            const string test = "test";
            var result = test.GetFirstCharacterAsString();
            Assert.IsTrue(result == "t");
        }

        [TestMethod]
        public void TestRightOf()
        {
            const string test = "test";
            var result = test.RightOf(1);
            Assert.IsTrue(result == "st");
        }

        [TestMethod]
        public void TestRightOfRightBoundary()
        {
            const string test = "test";
            var result = test.RightOf(3);
            Assert.IsTrue(result == "");
        }

        [TestMethod]
        public void TestRightOfLeftBoundary()
        {
            const string test = "test";
            var result = test.RightOf(0);
            Assert.IsTrue(result == "test");
        }

        [TestMethod]
        public void TestRightOfNull()
        {
            const string test = null;
            var result = test.RightOf(3);
            Assert.IsTrue(result == null);
        }

        [TestMethod]
        public void TestRightOfFirst()
        {
            const string test = "test";
            var result = test.RightOfFirst("s");
            Assert.IsTrue(result == "t");
        }

        [TestMethod]
        public void TestLeftOfFirst()
        {
            const string test = "test";
            var result = test.LeftOfFirst("s");
            Assert.IsTrue(result == "te");
        }

        [TestMethod]
        public void TestLeftOf()
        {
            const string test = "test";
            var result = test.LeftOf(2);
            Assert.IsTrue(result == "te");
        }

        [TestMethod]
        public void TestLeftOfRightBoundary()
        {
            const string test = "test";
            var result = test.LeftOf(3);
            Assert.IsTrue(result == "");
        }

        [TestMethod]
        public void TestLeftOfLeftBoundary()
        {
            const string test = "test";
            var result = test.LeftOf(0);
            Assert.IsTrue(result == "");
        }

        [TestMethod]
        public void TestLeftOfNull()
        {
            const string test = null;
            var result = test.LeftOf(3);
            Assert.IsTrue(result == null);
        }

        [TestMethod]
        public void TestGetPermutations()
        {
            const string test = "can";
            var result = test.GetPermutations();
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void TestGetDefinitions()
        {
            const string test = "can";
            var result = test.GetDefinitions();
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void TestIsWordTrue()
        {
            const string test = "can";
            var result = test.IsDictionaryWord();
            Assert.IsTrue(result.Value);
        }

        [TestMethod]
        public void TestIsWordFalse()
        {
            const string test = "xvx";
            var result = test.IsDictionaryWord();
            Assert.IsFalse(result.Value);
        }

        [TestMethod]
        public void TestGetAnagramsPositive()
        {
            const string test = "act";
            var result = test.GetAnagrams();
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void TestGetAnagramsNegative()
        {
            const string test = "zzz";
            var result = test.GetAnagrams();
            Assert.IsFalse(result.Count > 0);
        }

        [TestMethod]
        public void TestGetSoundExMatchesPostive()
        {
            const string test = "log";
            var result = test.GetSoundExMatches();
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void TestRemoveNonDigits()
        {
            const string test = "test123";

            var result = test.RemoveNonDigits();
            Assert.IsTrue(result == "123");
        }

        [TestMethod]
        public void TestRemoveNonAlpha()
        {
            const string test = "test123";

            var result = test.RemoveNonAlpha();
            Assert.IsTrue(result == "test");
        }

        [TestMethod]
        public void TestRemoveNonAlphaOrNonDigit()
        {
            const string test = "$100,000 US";
            var result = test.RemoveAllNonAlphaOrNonDigit();
            Assert.IsTrue(result == "100000US");
        }

        [TestMethod]
        public void TestRemovePunctuation()
        {
            const string test = "St. Paul";
            var result = test.RemovePunctuation();
            Assert.IsTrue(result == "St Paul");
        }

        [TestMethod]
        public void TestRemoveWhiteSpace()
        {
            const string test = "Test This";
            var result = test.RemoveWhiteSpace();
            Assert.IsTrue(result == "TestThis");
        }

        [TestMethod]
        public void TestShuffle()
        {
            const string test = "Test This";
            var result = test.Shuffle();
            Assert.IsTrue(result != "Test This");
            Assert.IsTrue(result.Length == test.Length);
        }

        [TestMethod]
        public void TestReverse()
        {
            const string test = "Test";
            var result = test.Reverse();
            Assert.IsTrue(result == "tseT");
        }

        [TestMethod]
        public void TestKeepLeft1()
        {
            const string test = "Test";
            var result = test.KeepLeft(3);
            Assert.IsTrue(result == "Tes");
        }

        [TestMethod]
        public void TestKeepLeft2()
        {
            const string test = "Test";
            var result = test.KeepLeft(2);
            Assert.IsTrue(result == "Te");
        }

        [TestMethod]
        public void TestKeepLeft3()
        {
            const string test = "Test";
            var result = test.KeepLeft(0);
            Assert.IsTrue(result == "");
        }

        [TestMethod]
        public void TestKeepLeft4()
        {
            const string test = "Test";
            var result = test.KeepLeft(10);
            Assert.IsTrue(result == "Test");
        }

        [TestMethod]
        public void TestKeepRight1()
        {
            const string test = "Test";
            var result = test.KeepRight(3);
            Assert.IsTrue(result == "est");
        }

        [TestMethod]
        public void TestKeepRight2()
        {
            const string test = "Test";
            var result = test.KeepRight(2);
            Assert.IsTrue(result == "st");
        }

        [TestMethod]
        public void TestKeepRight3()
        {
            const string test = "Test";
            var result = test.KeepRight(0);
            Assert.IsTrue(result == "");
        }

        [TestMethod]
        public void TestKeepRight4()
        {
            const string test = "Test";
            var result = test.KeepRight(10);
            Assert.IsTrue(result == "Test");
        }

        [TestMethod]
        public void TestRotateRight1()
        {
            const string test = "Test";
            var result = test.RotateRight();
            Assert.IsTrue(result == "tTes");
        }

        [TestMethod]
        public void TestRotateLeft1()
        {
            const string test = "Test";
            var result = test.RotateLeft();
            Assert.IsTrue(result == "estT");
        }

        [TestMethod]
        public void TestRotate()
        {
            const string test = "Test";
            var result = test.Rotate(2);
            Assert.IsTrue(result == "stTe");
        }

        [TestMethod]
        public void TestDamerauLevenshteinDistanceEqualTrue()
        {
            const string test1 = "Test";
            const string test2 = "Test";
            var result = test1.DamerauLevenshteinDistance(test2);
            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void TestDamerauLevenshteinDistanceEqualFalse()
        {
            const string test1 = "Test";
            const string test2 = "Test2";
            var result = test1.DamerauLevenshteinDistance(test2);
            Assert.IsTrue(result != 0);
        }

        [TestMethod]
        public void TestLevenshteinDistanceEqualTrue()
        {
            const string test1 = "Test";
            const string test2 = "Test";
            var result = test1.LevenshteinDistance(test2);
            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void TestLevenshteinDistanceEqualFalse()
        {
            const string test1 = "Test";
            const string test2 = "Test2";
            var result = test1.LevenshteinDistance(test2);
            Assert.IsTrue(result != 0);
        }

        [TestMethod]
        public void TestLevenshteinDistanceEqual2()
        {
            const string test1 = "book";
            const string test2 = "back";
            var result = test1.LevenshteinDistance(test2);
            Assert.IsTrue(result == 2);
        }


        [TestMethod]
        public void TestJaroWinklerEqual()
        {
            const string test1 = "Test";
            const string test2 = "Test";
            var result = test1.JaroWinkler(test2);
            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void TestJaroWinklerNotEqual()
        {
            const string test1 = "Teaa";
            const string test2 = "Test";
            var result = test1.JaroWinkler(test2);
            Assert.IsTrue(result < 1);
        }

        [TestMethod]
        public void TestSoundExScore()
        {
            const string test1 = "test";
            var result = test1.SoundEx();
            Assert.IsTrue(result == "T230");
        }

        [TestMethod]
        public void TestSoundExDifference4()
        {
            const string test1 = "book";
            const string test2 = "buck";
            var result = test1.SoundExDifference(test2);
            Assert.IsTrue(result == 4);
        }

        [TestMethod]
        public void TestSoundExDifference3()
        {
            const string test1 = "book";
            const string test2 = "break";
            var result = test1.SoundExDifference(test2);
            Assert.IsTrue(result == 3);
        }

        [TestMethod]
        public void TestSoundExDifference2()
        {
            const string test1 = "book";
            const string test2 = "breaker";
            var result = test1.SoundExDifference(test2);
            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void TestSoundExDifference1()
        {
            const string test1 = "book";
            const string test2 = "lookers";
            var result = test1.SoundExDifference(test2);
            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void TestSoundExDifference0()
        {
            const string test1 = "Animal";
            const string test2 = "lookers";
            var result = test1.SoundExDifference(test2);
            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void TestSubstringFrequency()
        {
            const string test1 = "I am what I am.";
            const string test2 = "am";
            var result = test1.Occurences(test2);
            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void TestSubstringFrequencyChar()
        {
            const string test1 = "I am what I am.";
            const char test2 = 'a';
            var result = test1.Occurrences(test2);
            Assert.IsTrue(result == 3);
        }


        [TestMethod]
        public void TestCountWords()
        {
            const string test1 = "I am what I am.";
            var result = test1.CountWords();
            Assert.IsTrue(result == 5);
        }

        [TestMethod]
        public void TestDoubleMetaphonePrimary()
        {
            var primaryKey = "Smith".GetDoubleMetaphone().Primary;
            Assert.IsTrue(primaryKey == "SM0");
        }

        [TestMethod]
        public void TestDoubleMetaphoneSecondary()
        {
            var secondaryKey = "Smith".GetDoubleMetaphone().Secondary;
            Assert.IsTrue(secondaryKey == "XMT");
        }

        [TestMethod]
        public void TestDoubleMetaphonePrimary2()
        {
            const string test = "Smith";
            var primaryKey = test.DoubleMetaphonePrimaryKey();
            Assert.IsTrue(primaryKey == "SM0");
        }

        [TestMethod]
        public void TestDoubleMetaphoneSecondary2()
        {
            const string test = "Smith";
            var secondaryKey = test.DoubleMetaphoneSecondaryKey();
            Assert.IsTrue(secondaryKey == "XMT");
        }


        [TestMethod]
        public void TestIsHomoPhone()
        {
            const string test1 = "Carrots";
            const string test2 = "Karats";
            var result = test1.IsHomophone(test2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestIsGivenNameTrue()
        {
            const string test1 = "Robert";
            var result = test1.IsGivenName();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestIsGivenNameFalse()
        {
            const string test1 = "ZZZ";
            var result = test1.IsGivenName();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestIsSurnameTrue()
        {
            const string test1 = "Peterson";
            var result = test1.IsSurname();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestIsSurnameFalse()
        {
            const string test1 = "ZZZ";
            var result = test1.IsSurname();
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void TestGetCapialized()
        {
            const string test1 = "adam";
            var result = test1.GetCapitalized();
            Assert.IsTrue(result == "Adam");
        }

        [TestMethod]
        public void TestGetNameAnagrams()
        {
            const string test1 = "Adam";
            var result = test1.GetNameAnagrams();
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void TestHasPrefixPositive()
        {
            const string test1 = "super";
            var result = test1.HasPrefix("sup");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestHasPrefixNegative()
        {
            const string test1 = "super";
            var result = test1.HasPrefix("pu");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestHasSuffixPositive()
        {
            const string test1 = "super";
            var result = test1.HasSuffix("per");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestHasSuffixNegative()
        {
            const string test1 = "super";
            var result = test1.HasSuffix("rup");
            Assert.IsFalse(result);
        }

    }
}
