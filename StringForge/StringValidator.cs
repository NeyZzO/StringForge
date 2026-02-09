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

        public static bool IsValidEmail(string email) {
            if (String.IsNullOrEmpty(email)) return false;
            string mailPattern = @"^((?!\.)[\w\-_.]*[^.])(@\w+)(\.\w+(\.\w+)?[^.\W])$";
            return Regex.IsMatch(email, mailPattern);
        }
    }
}
