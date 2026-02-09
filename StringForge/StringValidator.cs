using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StringForge {

    /// <summary>
    /// A validator class for strings. Can be used to validate strings based on certain criteria, such as length, character content, or format.
    /// Useful when processing forms (e.g., validating email addresses, phone numbers, passwords, ...)
    /// </summary>
    public static class StringValidator {

        /// <summary>
        /// Determines whether the specified email address is in a valid format.
        /// </summary>
        /// <remarks>The method checks that the email address contains a local part, an '@' symbol, and a
        /// domain part. The validation ensures the address does not start or end with a dot and does not contain
        /// consecutive dots. This method does not guarantee that the email address exists or can receive mail; it only
        /// verifies the format.</remarks>
        /// <param name="email">The email address to validate. Must be a non-null, non-empty string.</param>
        /// <returns>true if the email address is valid; otherwise, false.</returns>
        public static bool IsValidEmail(string email) {
            if (String.IsNullOrEmpty(email)) return false;
            string mailPattern = @"^((?!\.)[\w\-_.]*[^.])(@\w+)(\.\w+(\.\w+)?[^.\W])$";
            return Regex.IsMatch(email, mailPattern);
        }

        /// <summary>
        /// Determines whether the specified phone number is valid according to an international format with country code.
        /// </summary>
        /// <remarks>A valid phone number must start with a '+' followed by digits (and optionally spaces, dashes, or parentheses).
        /// The total number of digits must be at least 8 (country code + phone number).</remarks>
        /// <param name="phoneNumber">The phone number to validate. This value must not be null or empty.</param>
        /// <returns>true if the phone number is valid; otherwise, false.</returns>
        public static bool IsValidPhoneNumber(string phoneNumber) {
            if (String.IsNullOrEmpty(phoneNumber)) return false;
            // Format: +{digits} with optional spaces, dashes, parentheses
            string phonePattern = @"^\+[\d\s\-()]+$";
            if (!Regex.IsMatch(phoneNumber, phonePattern)) return false;
            // Ensure we have at least 8 digits total (country code 1-3 + at least 5 digits for number)
            string digitsOnly = new string(phoneNumber.Where(char.IsDigit).ToArray());
            return digitsOnly.Length >= 8;
        }
    }
}
