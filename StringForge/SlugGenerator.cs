using System;
using System.Collections.Generic;
using System.Text;

namespace StringForge {
    public static class SlugGenerator {
        /// <summary>
        /// Generates a URL-friendly slug from the specified string by converting it to lowercase, replacing spaces with
        /// hyphens, and removing invalid characters.
        /// </summary>
        /// <remarks>The resulting slug contains only lowercase alphanumeric characters and hyphens.
        /// Consecutive hyphens are collapsed into a single hyphen, and leading or trailing hyphens are
        /// removed.</remarks>
        /// <param name="input">The string to convert into a slug. If the value is null or consists only of white-space characters, the
        /// original value is returned.</param>
        /// <returns>A string containing the generated slug suitable for use in URLs. If the input is null or white space, the
        /// original input is returned.</returns>
        public static string GenerateSlug(string input) {
            if (String.IsNullOrWhiteSpace(input)) return input;
            string slug = input.ToLowerInvariant();
            slug = slug.Replace(" ", "-");
            slug = System.Text.RegularExpressions.Regex.Replace(slug, @"[^a-z0-9\-]", "");
            slug = System.Text.RegularExpressions.Regex.Replace(slug, @"-+", "-");
            slug = slug.Trim('-');
            return slug;
        }

        /// <summary>
        /// Removes all diacritical marks from the specified string, returning a version with only base characters.
        /// </summary>
        /// <remarks>This method normalizes the input string to decompose characters with diacritics into
        /// their base characters and combining marks, then removes the non-spacing marks before re-normalizing the
        /// result. This is useful for generating plain-text representations of strings for comparison, searching, or
        /// slug generation.</remarks>
        /// <param name="input">The string from which to remove diacritical marks. If null or empty, the input is returned unchanged.</param>
        /// <returns>A string containing the input text without diacritical marks. If the input is null or empty, the same value
        /// is returned.</returns>
        public static string RemoveDiacritics(string input) {
            if (String.IsNullOrWhiteSpace(input)) return input;
            string normalized = input.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            foreach (char c in normalized) {
                if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark) {
                    sb.Append(c);
                }
            }
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
