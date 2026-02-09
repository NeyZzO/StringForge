using System;
using System.Collections.Generic;
using System.Text;

namespace StringForge {
    public static class TextAnalyzer {
        /// <summary>
        /// Counts the number of words in the specified input string.
        /// </summary>
        /// <remarks>Words are defined as sequences of characters separated by whitespace characters such
        /// as spaces, tabs, or newlines.</remarks>
        /// <param name="input">The string to analyze for word count. Must not be null, empty, or consist solely of whitespace.</param>
        /// <returns>The total number of words found in the input string. Returns 0 if the input is null, empty, or contains only
        /// whitespace.</returns>
        public static int CountWords(string input) {
            if (String.IsNullOrEmpty(input) || String.IsNullOrWhiteSpace(input)) return 0;
            string[] words = input.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        /// <summary>
        /// Counts the number of sentences in the specified input string.
        /// </summary>
        /// <remarks>A sentence is defined as a sequence of characters ending with a period ('.'),
        /// exclamation mark ('!'), or question mark ('?'). Consecutive sentence-ending punctuation marks are treated as
        /// a single delimiter.</remarks>
        /// <param name="input">The input string to analyze. Cannot be null, empty, or consist only of white-space characters.</param>
        /// <returns>The total number of sentences found in the input string. Returns 0 if the input is null, empty, or consists
        /// only of white-space characters.</returns>
        public static int CountSentences(string input) { 
            if (String.IsNullOrEmpty(input) || String.IsNullOrWhiteSpace(input)) return 0;
            string[] sentences = input.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            return sentences.Length;
        }

        /// <summary>
        /// Determines the most frequently occurring character in the specified string, excluding whitespace characters.
        /// </summary>
        /// <remarks>If multiple characters share the highest frequency, the method returns the first such
        /// character encountered in the input. Character comparison is case-sensitive.</remarks>
        /// <param name="input">The string to analyze for character frequency. This parameter must not be null, empty, or consist solely of
        /// whitespace.</param>
        /// <returns>The character that appears most frequently in the input string, or null if the input is null, empty, or
        /// contains only whitespace.</returns>
        public static char? MostFrequentChar(string input) {
            if (String.IsNullOrEmpty(input) || String.IsNullOrWhiteSpace(input)) return null;
            char? result = null;
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (char c in input) {
                if (char.IsWhiteSpace(c)) continue;
                if (charCount.ContainsKey(c)) {
                    charCount[c]++;
                } else {
                    charCount[c] = 1;
                }
            }
            foreach (char c in charCount.Keys) {
                if (result == null || charCount[c] > charCount[result.Value]) {
                    result = c;
                }
            }
            return result;
        }
        /// <summary>
        /// Determines whether the specified string is a palindrome, ignoring case and non-alphanumeric characters.
        /// </summary>
        /// <remarks>The method removes all characters from the input string that are not letters or
        /// digits and performs a case-insensitive comparison. White-space and punctuation are ignored when determining
        /// if the string is a palindrome.</remarks>
        /// <param name="input">The string to evaluate. This parameter must not be null, empty, or consist only of white-space characters.</param>
        /// <returns>true if the input string is a palindrome; otherwise, false.</returns>
        public static bool IsPalindrome(string input) {
            if (String.IsNullOrEmpty(input) || String.IsNullOrWhiteSpace(input)) return true;
            string cleaned = new string(input.Where(char.IsLetterOrDigit).ToArray()).ToLower();
            return cleaned.SequenceEqual(cleaned.Reverse());
        }

        /// <summary>
        /// Calculates the average length of words in the specified input string.
        /// </summary>
        /// <remarks>Words are defined as sequences of characters separated by whitespace. The method
        /// splits the input based on spaces, tabs, and line breaks. If there are no valid words, the method returns
        /// 0.</remarks>
        /// <param name="input">The input string containing words to analyze. Cannot be null, empty, or consist solely of whitespace.</param>
        /// <returns>The average length of the words in the input string. Returns 0 if the input is null, empty, or contains no
        /// valid words.</returns>
        public static double AverageWordLength(string input) {
            if (String.IsNullOrEmpty(input) || String.IsNullOrWhiteSpace(input)) return 0;
            string[] words = input.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            double totalLength = words.Sum(w => w.Length);
            return totalLength / words.Length;
        }

        /// <summary>
        /// Calculates the Levenshtein distance between two strings, which is the minimum number of single-character
        /// edits required to transform one string into the other.
        /// </summary>
        /// <remarks>If either string is null or empty, the distance is equal to the length of the other
        /// string. The Levenshtein distance is commonly used to measure the similarity between two strings in
        /// applications such as spell checking and approximate string matching.</remarks>
        /// <param name="s">The first string to compare. Cannot be null.</param>
        /// <param name="t">The second string to compare. Cannot be null.</param>
        /// <returns>An integer representing the minimum number of single-character insertions, deletions, or substitutions
        /// required to change string 's' into string 't'. Returns 0 if both strings are null or empty.</returns>
        public static int LevenshteinDistance(string s, string t) {
            if (String.IsNullOrEmpty(s)) return String.IsNullOrEmpty(t) ? 0 : t.Length;
            if (String.IsNullOrEmpty(t)) return s.Length;
            int[,] d = new int[s.Length + 1, t.Length + 1];
            for (int i = 0; i <= s.Length; i++) d[i, 0] = i;
            for (int j = 0; j <= t.Length; j++) d[0, j] = j;
            for (int i = 1; i <= s.Length; i++) {
                for (int j = 1; j <= t.Length; j++) {
                    int cost = (s[i - 1] == t[j - 1]) ? 0 : 1;
                    d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + cost);
                }
            }
            return d[s.Length, t.Length];
        }
    }
}
