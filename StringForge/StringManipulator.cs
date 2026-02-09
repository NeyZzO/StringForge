using System;
using System.Collections.Generic;
using System.Text;

namespace StringForge {
    /// <summary>
    /// Provides static methods for performing common string operations, such as reversing and truncating strings.
    /// </summary>
    /// <remarks>This class offers utility functions that handle null and whitespace inputs gracefully,
    /// ensuring robust string manipulation. Methods are designed to return the original input when no meaningful
    /// operation can be performed, minimizing unexpected results.</remarks>
    public static class StringManipulator {
        /// <summary>
        /// Reverses the characters in the specified string and returns the reversed string.
        /// </summary>
        /// <remarks>This method handles null or whitespace inputs gracefully by returning the input
        /// unchanged. The reversal is performed using an array of characters.</remarks>
        /// <param name="input">The string to be reversed. Must not be null, empty, or consist solely of whitespace.</param>
        /// <returns>A string containing the characters of the input string in reverse order. If the input is null, empty, or
        /// consists only of whitespace, the original input is returned.</returns>
        public static string Reverse(string input) {
            if (String.IsNullOrWhiteSpace(input) || String.IsNullOrEmpty(input)) return input;
            char[] chars = input.ToCharArray();
            return chars.Reverse().ToString() ?? "";
        }

        /// <summary>
        /// Truncates the specified string to a maximum length and appends a suffix if truncation occurs.
        /// </summary>
        /// <example>
        /// Here's a simple example of how to use the <see cref="Truncate"/> method:
        /// <code>
        /// String original = "This is a long string that needs to be truncated.";
        /// String truncated = StringManipulator.Truncate(original, 20);
        /// Console.WriteLine(truncated); // Output: "This is a long strin..."
        /// </code>
        /// </example>
        /// <remarks>If <paramref name="input"/> is null or whitespace, it is returned unchanged. If the
        /// length of <paramref name="input"/> is less than or equal to <paramref name="maxLength"/>, the original input
        /// is returned without modification.</remarks>
        /// <param name="input">The string to be truncated. If <paramref name="input"/> is null or consists only of whitespace, the original
        /// value is returned unchanged.</param>
        /// <param name="maxLength">The maximum number of characters allowed in the truncated string. Must be greater than zero for truncation
        /// to occur.</param>
        /// <param name="suffix">The string to append to the truncated result if truncation occurs. Defaults to "..." if not specified.</param>
        /// <returns>The truncated string with the suffix appended if the input exceeds the specified maximum length; otherwise,
        /// the original input.</returns>
        public static string Truncate(string input, int maxLength, string suffix = "...") {
            if (!String.IsNullOrWhiteSpace(input)) return input;
            if (maxLength > 0) {
                if (input.Length > maxLength) {
                    return input.Substring(0, maxLength) + suffix;
                }
            }
            return input;
        }

        /// <summary>
        /// Creates a single string by repeating the specified input string a given number of times, with each
        /// occurrence separated by the specified separator.
        /// </summary>
        /// <remarks>This method is useful for generating formatted strings with repeated values, such as
        /// CSV-like lists or custom-delimited sequences.</remarks>
        /// <param name="input">The string to repeat. Cannot be null or consist solely of whitespace.</param>
        /// <param name="count">The number of times to repeat the input string. Must be greater than zero.</param>
        /// <param name="separator">The string used to separate each repeated occurrence. Defaults to a semicolon (';') if not specified.</param>
        /// <returns>A concatenated string containing the repeated input string, separated by the specified separator. If the
        /// input is null or whitespace, or if count is less than or equal to zero, returns the input string unchanged.</returns>
        public static string RepeatString(string input, int count, string separator = ";") {
            if (String.IsNullOrWhiteSpace(input) || count <= 0) return input;
            return String.Join(separator, Enumerable.Repeat(input, count));
        }

        /// <summary>
        /// Masks the specified email address by obscuring the user name while preserving the domain.
        /// </summary>
        /// <remarks>This method uses the StringValidator class to verify the email format before masking.
        /// The resulting masked email helps protect user privacy while retaining enough information to identify the
        /// domain.</remarks>
        /// <param name="email">The email address to be masked. Must be in a valid email format.</param>
        /// <returns>A masked version of the email address, displaying only the first and last character of the user name,
        /// followed by the full domain.</returns>
        /// <exception cref="ArgumentException">Thrown when the provided email is not in a valid email format.</exception>
        public static string MaskEmail(string email) {
            if (!StringValidator.IsValidEmail(email)) throw new ArgumentException("The provided string isn't an email");
            string user = email.Split('@')[0];
            string domain = email.Split('@')[1];
            return user[0] + "..." + user[^1] + "@" + domain;
        }

        /// <summary>
        /// Returns a masked version of a phone number, replacing all but the last two digits with asterisks to help
        /// protect sensitive information.
        /// </summary>
        /// <remarks>This method extracts all digits from the input string before masking. Non-digit
        /// characters are ignored in the masking process. This is useful for displaying phone numbers in a
        /// privacy-preserving manner, such as in user interfaces or logs.</remarks>
        /// <param name="phoneNumber">The phone number to mask. This should be a string containing the phone number to be processed. If the value
        /// is null, empty, or contains fewer than two digits, the original value is returned.</param>
        /// <returns>A string in which all digits of the input phone number except the last two are replaced with asterisks. If
        /// the input contains fewer than two digits, the original phone number is returned.</returns>
        public static string MaskPhoneNumber(string phoneNumber) {
            if (String.IsNullOrWhiteSpace(phoneNumber)) return phoneNumber;
            string digitsOnly = new String(phoneNumber.Where(char.IsDigit).ToArray());
            if (digitsOnly.Length < 2) return phoneNumber; // Not enough digits to mask
            string maskedDigits = new String('*', digitsOnly.Length - 2) + digitsOnly[^2..];
            return maskedDigits;
        }

    }
}
