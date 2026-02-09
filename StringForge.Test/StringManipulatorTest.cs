using System;
using System.Collections.Generic;
using System.Text;

namespace StringForge.Test {
    [TestClass]
    public sealed class StringManipulatorTest {

        [TestMethod(DisplayName = "Reverse with valid string returns a reversed string")]
        public void Reverse_ValidString_ReturnsReversedString() {
            string input = "Hello World!";
            string expected = "!dlroW olleH";
            string actual = StringManipulator.Reverse(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "Reverse with empty string returns an empty string")]
        public void Reverse_EmptyString_ReturnsEmptyString() {
            string input = "";
            string expected = "";
            string actual = StringManipulator.Reverse(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "Reverse with one char string returns a one char string")]
        public void Reverse_OneChar_ReturnsOneChar() {
            string input = "a";
            string expected = "a";
            string actual = StringManipulator.Reverse(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "Truncate with valid string returns a truncated string")]
        public void Truncate_ValidString_ReturnsTruncatedString() {
            string input = "This is a long string that needs to be truncated.";
            string expected = "This is a long strin...";
            string actual = StringManipulator.Truncate(input, 20);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "Truncate with string shorter than max length returns the original string")]
        public void Truncate_ShortString_ReturnsOriginalString() {
            string input = "Short string";
            string expected = "Short string";
            string actual = StringManipulator.Truncate(input, 20);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "Truncate an empty string returns an empty string")]
        public void Truncate_EmptyString_ReturnsEmptyString() {
            string input = "";
            string expected = "";
            string actual = StringManipulator.Truncate(input, 20);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "RepeatString with valid input returns repeated string")]
        public void RepeatString_ValidInput_ReturnsRepeatedString() {
            string input = "abc";
            string expected = "abc;abc;abc";
            string actual = StringManipulator.RepeatString(input, 3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "RepeatString with valid input and 0 repeats input string")]
        public void RepeatString_ZeroRepeat_ReturnsOriginalString() {
            string input = "abc";
            string expected = "abc";
            string actual = StringManipulator.RepeatString(input, 0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "RepeatString with empty string returns empty string")]
        public void RepeatString_EmptyString_ReturnsEmptyString() {
            string input = "";
            string expected = "";
            string actual = StringManipulator.RepeatString(input, 3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "MaskEmail with valid email returns masked email")]
        public void MaskEmail_ValidEmail_ReturnsMaskedEmail() {
            string input = "john.doe@mail.eu";
            string expected = "j******e@mail.eu";
            string actual = StringManipulator.MaskEmail(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "MaskEmail with invalid email throws an error")]
        public void MaskEmail_InvalidEmail_ThrowsError() {
            string input = "john.doemail.eu";
            Assert.Throws<ArgumentException>(() => StringManipulator.MaskEmail(input));
        }

        [TestMethod(DisplayName = "MaskPhoneNumber with valid phone number returns masked phone number")]
        public void MaskPhoneNumber_ValidPhoneNumber_ReturnsMaskedPhoneNumber() {
            string input = "+33612345678";
            string expected = "+336******78";
            string actual = StringManipulator.MaskPhoneNumber(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "MaskPhoneNumber with spaces returns masked phone number")]
        public void MaskPhoneNumber_WithSpaces_ReturnsMaskedPhoneNumber() {
            string input = "+33 6 12 34 56 78";
            string expected = "+336******78";
            string actual = StringManipulator.MaskPhoneNumber(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "MaskPhoneNumber with US number returns masked phone number")]
        public void MaskPhoneNumber_USNumber_ReturnsMaskedPhoneNumber() {
            string input = "+1 555 123 4567";
            string expected = "+15*******67";
            string actual = StringManipulator.MaskPhoneNumber(input, countryCodeLength: 1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "MaskPhoneNumber with 3-digit country code returns masked phone number")]
        public void MaskPhoneNumber_ThreeDigitCountryCode_ReturnsMaskedPhoneNumber() {
            string input = "+212612345678";
            string expected = "+2126******78";
            string actual = StringManipulator.MaskPhoneNumber(input, countryCodeLength: 3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "MaskPhoneNumber with invalid phone number throws an error")]
        public void MaskPhoneNumber_InvalidPhoneNumber_ThrowsError() {
            string input = "0612345678";
            Assert.Throws<ArgumentException>(() => StringManipulator.MaskPhoneNumber(input));
        }

        [TestMethod(DisplayName = "MaskPhoneNumber with invalid country code length throws an error")]
        public void MaskPhoneNumber_InvalidCountryCodeLength_ThrowsError() {
            string input = "+33612345678";
            Assert.Throws<ArgumentException>(() => StringManipulator.MaskPhoneNumber(input, countryCodeLength: 5));
        }

    }
}
