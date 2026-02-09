using System;
using System.Collections.Generic;
using System.Text;

namespace StringForge.Test {
    [TestClass]
    public sealed class TextAnalyzerTest {
        [TestMethod(DisplayName = "CountWords with valid string returns correct word count")]
        public void CountWords_ValidString_ReturnsCorrectWordCount() {
            string input = "Hello World, this is a test.";
            int expected = 6;
            int actual = TextAnalyzer.CountWords(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "CountWords on empty string returns 0")]
        public void CountWords_EmptyString_ReturnsZero() {
            string input = "";
            int expected = 0;
            int actual = TextAnalyzer.CountWords(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "CountSentences with valid string returns correct sentence count")]
        public void CountSentences_ValidString_ReturnsCorrectSentenceCount() {
            string input = "Hello World! This is a test. Are you ready?";
            int expected = 3;
            int actual = TextAnalyzer.CountSentences(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "CountSentences on empty string returns 0")]
        public void CountSentences_EmptyString_ReturnsZero() {
            string input = "";
            int expected = 0;
            int actual = TextAnalyzer.CountSentences(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "MostFrequentChar with valid string returns correct character")]
        public void MostFrequentChar_ValidString_ReturnsCorrectCharacter() {
            string input = "Hello World!";
            char? expected = 'l';
            char? actual = TextAnalyzer.MostFrequentChar(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "MostFrequentChar on empty string returns null")]
        public void MostFrequentChar_EmptyString_ReturnsNull() {
            string input = "";
            char? expected = null;
            char? actual = TextAnalyzer.MostFrequentChar(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "MostFrequentChar with multiple characters having the same frequency returns the first one")]
        public void MostFrequentChar_MultipleCharactersSameFrequency_ReturnsFirstCharacter() {
            string input = "aabbcc";
            char? expected = 'a';
            char? actual = TextAnalyzer.MostFrequentChar(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "MostFrequentChar with whitespace characters returns the most frequent non-whitespace character")]
        public void MostFrequentChar_WhitespaceCharacters_ReturnsMostFrequentNonWhitespaceCharacter() {
            string input = "a a a b b c";
            char? expected = 'a';
            char? actual = TextAnalyzer.MostFrequentChar(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "MostFrequentChar with all whitespace characters returns null")]
        public void MostFrequentChar_AllWhitespace_ReturnsNull() {
            string input = "     ";
            char? expected = null;
            char? actual = TextAnalyzer.MostFrequentChar(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "MostFrequentChar with case-sensitive characters returns the most frequent character considering case")]
        public void MostFrequentChar_CaseSensitiveCharacters_ReturnsMostFrequentCharacterConsideringCase() {
            string input = "aAaBbB";
            char? expected = 'a';
            char? actual = TextAnalyzer.MostFrequentChar(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "IsPalindrome with valid palindrome string returns true")]
        public void IsPalindrome_ValidPalindrome_ReturnsTrue() {
            string input = "kayak";
            Assert.IsTrue(TextAnalyzer.IsPalindrome(input));
        }

        [TestMethod(DisplayName = "IsPalindrome with not palindrome string returns false")]
        public void IsPalindrome_NotPalindrome_ReturnsFalse() {
            string input = "hello";
            Assert.IsFalse(TextAnalyzer.IsPalindrome(input));
        }

        [TestMethod(DisplayName = "IsPalindrome with empty string returns true")]
        public void IsPalindrome_EmptyString_ReturnsTrue() {
            string input = "";
            Assert.IsTrue(TextAnalyzer.IsPalindrome(input));
        }

        [TestMethod(DisplayName = "AverageWordLength with valid string returns correct average word length")]
        public void AverageWordLength_ValidString_ReturnsCorrectAverage() {
            string input = "Hello World";
            double expected = 5.0;
            double actual = TextAnalyzer.AverageWordLength(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "AverageWordLength with empty string returns 0")]
        public void AverageWordLength_EmptyString_ReturnsZero() {
            string input = "";
            double expected = 0.0;
            double actual = TextAnalyzer.AverageWordLength(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "AverageWordLength with one word and whitespace returns correct average word length")]
        public void AverageWordLength_OneWordWithWhitespace_ReturnsCorrectAverage() {
            string input = "   Hello   ";
            double expected = 5.0;
            double actual = TextAnalyzer.AverageWordLength(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "LevenshteinDistance with valid strings returns correct distance")]
        public void LevenshteinDistance_ValidStrings_ReturnsCorrectDistance() {
            string s1 = "kitten";
            string s2 = "sitting";
            int expected = 3;
            int actual = TextAnalyzer.LevenshteinDistance(s1, s2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "LevenshteinDistance with identical strings returns 0")]
        public void LevenshteinDistance_IdenticalStrings_ReturnsZero() {
            string s1 = "hello";
            string s2 = "hello";
            int expected = 0;
            int actual = TextAnalyzer.LevenshteinDistance(s1, s2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "LevenshteinDistance with one empty string returns the length of the other string")]
        public void LevenshteinDistance_OneEmptyString_ReturnsLengthOfOtherString() {
            string s1 = "";
            string s2 = "hello";
            int expected = 5;
            int actual = TextAnalyzer.LevenshteinDistance(s1, s2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "LevenshteinDistance with both empty strings returns 0")]
        public void LevenshteinDistance_BothEmptyStrings_ReturnsZero() {
            string s1 = "";
            string s2 = "";
            int expected = 0;
            int actual = TextAnalyzer.LevenshteinDistance(s1, s2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "LevenshteinDistance with null strings returns 0")]
        public void LevenshteinDistance_NullStrings_ReturnsZero() {
            string s1 = null!;
            string s2 = null!;
            int expected = 0;
            int actual = TextAnalyzer.LevenshteinDistance(s1, s2);
            Assert.AreEqual(expected, actual);
        }
    }
}
