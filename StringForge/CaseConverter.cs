using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StringForge {
    /// <summary>
    /// Provides static methods for converting strings between various case formats, such as title case, snake_case,
    /// camelCase, PascalCase, kebab-case, alternating case, and SCREAMING_SNAKE_CASE, as well as identifying the case
    /// type of a given string.
    /// </summary>
    /// <remarks>This class offers a comprehensive set of string case conversion utilities suitable for
    /// different programming conventions and scenarios. All methods handle null or empty inputs gracefully by returning
    /// the original value. The class is thread-safe and can be used without instantiation.</remarks>
    public static class CaseConverter {

        /// <summary>
        /// Converts the specified string to title case, capitalizing the first letter of each word and converting the
        /// remaining letters to lowercase.
        /// </summary>
        /// <remarks>This method trims leading and trailing whitespace, converts the input to lowercase,
        /// and capitalizes the first letter of each word. Multiple consecutive whitespace characters are treated as
        /// single word separators.</remarks>
        /// <param name="input">The string to convert to title case. Cannot be null or empty; if null or empty, the original value is
        /// returned.</param>
        /// <returns>A string in title case format, with each word's first letter capitalized. Returns the original input if it
        /// is null or empty.</returns>
        public static string ToTitleCase(string input) {
            if (String.IsNullOrWhiteSpace(input) || String.IsNullOrEmpty(input)) return input;
            StringBuilder sb = new StringBuilder(input.Length);
            input = input.Trim().ToLower();
            string[] words = input.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words) {
                sb.Append(char.ToUpper(word[0]) + word.Substring(1) + " ");
            }
            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// Converts the specified string to snake_case format.
        /// </summary>
        /// <remarks>This method handles camelCase, PascalCase, kebab-case, spaces, and mixed inputs.
        /// Consecutive uppercase letters are treated as acronyms.</remarks>
        /// <param name="input">The string to convert to snake_case. If null or empty, the original value is returned.</param>
        /// <returns>A string in snake_case format with all lowercase letters separated by underscores.</returns>
        public static string ToSnakeCase(string input) {
            if (String.IsNullOrWhiteSpace(input)) return input;

            var words = SplitIntoWords(input);
            return string.Join("_", words).ToLower();
        }

        /// <summary>
        /// Converts the specified string to camelCase format.
        /// </summary>
        /// <remarks>This method handles various input formats including snake_case, kebab-case, PascalCase, and spaces.
        /// The first letter is always lowercase, and each subsequent word starts with an uppercase letter.</remarks>
        /// <param name="input">The string to convert to camelCase. If null or empty, the original value is returned.</param>
        /// <returns>A string in camelCase format.</returns>
        public static string ToCamelCase(string input) {
            if (String.IsNullOrWhiteSpace(input)) return input;

            var words = SplitIntoWords(input);
            if (words.Count == 0) return input;

            var sb = new StringBuilder();
            for (int i = 0; i < words.Count; i++) {
                var word = words[i].ToLower();
                if (i == 0) {
                    sb.Append(word);
                } else {
                    sb.Append(char.ToUpper(word[0]));
                    sb.Append(word.Substring(1));
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Converts the specified string to PascalCase format.
        /// </summary>
        /// <remarks>This method handles various input formats including snake_case, kebab-case, camelCase, and spaces.
        /// Each word starts with an uppercase letter followed by lowercase letters.</remarks>
        /// <param name="input">The string to convert to PascalCase. If null or empty, the original value is returned.</param>
        /// <returns>A string in PascalCase format.</returns>
        public static string ToPascalCase(string input) {
            if (String.IsNullOrWhiteSpace(input)) return input;

            var words = SplitIntoWords(input);
            var sb = new StringBuilder();
            foreach (var word in words) {
                var lowerWord = word.ToLower();
                sb.Append(char.ToUpper(lowerWord[0]));
                sb.Append(lowerWord.Substring(1));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Converts the specified string to kebab-case format.
        /// </summary>
        /// <remarks>This method handles camelCase, PascalCase, snake_case, spaces, and mixed inputs.
        /// All letters are converted to lowercase and words are separated by hyphens.</remarks>
        /// <param name="input">The string to convert to kebab-case. If null or empty, the original value is returned.</param>
        /// <returns>A string in kebab-case format with all lowercase letters separated by hyphens.</returns>
        public static string ToKebabCase(string input) {
            if (String.IsNullOrWhiteSpace(input)) return input;

            var words = SplitIntoWords(input);
            return string.Join("-", words).ToLower();
        }

        /// <summary>
        /// Converts the specified string to aLtErNaTiNg CaSe format.
        /// </summary>
        /// <remarks>This method alternates between lowercase and uppercase for each letter,
        /// starting with lowercase. Non-letter characters do not affect the alternation pattern.</remarks>
        /// <param name="input">The string to convert to alternating case. If null or empty, the original value is returned.</param>
        /// <returns>A string in alternating case format.</returns>
        public static string ToAlternatingCase(string input) {
            if (String.IsNullOrWhiteSpace(input)) return input;

            var sb = new StringBuilder(input.Length);
            bool useLower = true;
            foreach (char c in input) {
                if (char.IsLetter(c)) {
                    sb.Append(useLower ? char.ToLower(c) : char.ToUpper(c));
                    useLower = !useLower;
                } else {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Converts the specified string to SCREAMING_SNAKE_CASE format.
        /// </summary>
        /// <remarks>This method handles various input formats and converts to all uppercase letters
        /// separated by underscores. Commonly used for constants.</remarks>
        /// <param name="input">The string to convert to SCREAMING_SNAKE_CASE. If null or empty, the original value is returned.</param>
        /// <returns>A string in SCREAMING_SNAKE_CASE format with all uppercase letters separated by underscores.</returns>
        public static string ToScreamingSnakeCase(string input) {
            if (String.IsNullOrWhiteSpace(input)) return input;

            var words = SplitIntoWords(input);
            return string.Join("_", words).ToUpper();
        }

        /// <summary>
        /// Identifies the case type of the specified string.
        /// </summary>
        /// <remarks>This method analyzes the input string pattern to determine its case type.
        /// If the input matches multiple patterns or no specific pattern, it defaults to TitleCase.</remarks>
        /// <param name="input">The string to analyze. If null or empty, returns TitleCase.</param>
        /// <returns>A <see cref="CaseType"/> value representing the detected case type.</returns>
        public static CaseType IdentifyCase(string input) {
            if (String.IsNullOrWhiteSpace(input)) return CaseType.TitleCase;

            input = input.Trim();

            // Check for SCREAMING_SNAKE_CASE (all uppercase with underscores)
            if (Regex.IsMatch(input, @"^[A-Z][A-Z0-9]*(_[A-Z0-9]+)+$")) {
                return CaseType.ScreamingSnakeCase;
            }

            // Check for UPPERCASE (all uppercase, no separators)
            if (Regex.IsMatch(input, @"^[A-Z0-9]+$")) {
                return CaseType.UpperCase;
            }

            // Check for snake_case (lowercase with underscores)
            if (Regex.IsMatch(input, @"^[a-z][a-z0-9]*(_[a-z0-9]+)+$")) {
                return CaseType.SnakeCase;
            }

            // Check for kebab-case (lowercase with hyphens)
            if (Regex.IsMatch(input, @"^[a-z][a-z0-9]*(-[a-z0-9]+)+$")) {
                return CaseType.KebabCase;
            }

            // Check for PascalCase (starts with uppercase, no separators, has lowercase)
            if (Regex.IsMatch(input, @"^[A-Z][a-zA-Z0-9]*$") && Regex.IsMatch(input, @"[a-z]")) {
                // Distinguish from camelCase by checking first letter
                if (char.IsUpper(input[0]) && input.Length > 1 && Regex.IsMatch(input.Substring(1), @"[A-Z]")) {
                    return CaseType.PascalCase;
                }
                if (char.IsUpper(input[0])) {
                    return CaseType.PascalCase;
                }
            }

            // Check for camelCase (starts with lowercase, has uppercase somewhere)
            if (Regex.IsMatch(input, @"^[a-z][a-zA-Z0-9]*$") && Regex.IsMatch(input, @"[A-Z]")) {
                return CaseType.CamelCase;
            }

            // Check for aLtErNaTiNg CaSe
            if (IsAlternatingCase(input)) {
                return CaseType.AlternatingCase;
            }

            // Check for Title Case (words separated by spaces, each starting with uppercase)
            if (Regex.IsMatch(input, @"^[A-Z][a-z]*(\s+[A-Z][a-z]*)*$")) {
                return CaseType.TitleCase;
            }

            // Default
            return CaseType.TitleCase;
        }

        /// <summary>
        /// Splits a string into individual words, handling various case formats.
        /// </summary>
        /// <param name="input">The string to split into words.</param>
        /// <returns>A list of words extracted from the input.</returns>
        private static List<string> SplitIntoWords(string input) {
            var words = new List<string>();

            // Replace common separators with spaces
            var normalized = Regex.Replace(input, @"[-_\s]+", " ");

            // Insert space before uppercase letters (for camelCase/PascalCase)
            var withSpaces = Regex.Replace(normalized, @"([a-z])([A-Z])", "$1 $2");

            // Handle consecutive uppercase (acronyms) followed by lowercase
            withSpaces = Regex.Replace(withSpaces, @"([A-Z]+)([A-Z][a-z])", "$1 $2");

            var parts = withSpaces.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var part in parts) {
                if (!string.IsNullOrWhiteSpace(part)) {
                    words.Add(part);
                }
            }

            return words;
        }

        /// <summary>
        /// Determines if a string is in alternating case format.
        /// </summary>
        /// <param name="input">The string to check.</param>
        /// <returns>True if the string follows an alternating case pattern; otherwise, false.</returns>
        private static bool IsAlternatingCase(string input) {
            bool? expectLower = null;
            int letterCount = 0;

            foreach (char c in input) {
                if (char.IsLetter(c)) {
                    letterCount++;
                    if (expectLower == null) {
                        expectLower = char.IsLower(c);
                    } else {
                        bool isLower = char.IsLower(c);
                        if (isLower != expectLower) {
                            return false;
                        }
                        expectLower = !expectLower;
                    }
                }
            }

            // Need at least 3 letters to confirm alternating pattern
            return letterCount >= 3;
        }
    }
}
