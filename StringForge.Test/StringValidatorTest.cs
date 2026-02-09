using System;
using System.Collections.Generic;
using System.Text;

namespace StringForge.Test {
    [TestClass]
    public sealed class StringValidatorTest {
        [TestMethod(DisplayName = "IsValidEmail with valid email returns true")]
        public void IsValidEmail_ValidEmail_ReturnsTrue() {
            string email = "john.doe@mail.eu";
            bool result = StringForge.StringValidator.IsValidEmail(email);
            Assert.IsTrue(result);
        }

        [TestMethod(DisplayName = "IsValidEmail with invalid email returns false")]
        public void IsValidEmail_InvalidEmail_ReturnsFalse() {
            string email = "john.doe.mail.eu";
            bool result = StringForge.StringValidator.IsValidEmail(email);
            Assert.IsFalse(result);
        }

        [TestMethod(DisplayName = "IsValidPhoneNumber with valid phone number returns true")]
        public void IsValidPhoneNumber_ValidPhoneNumber_ReturnsTrue() {
            string phoneNumber = "+33 6 12 34 56 78";
            bool result = StringForge.StringValidator.IsValidPhoneNumber(phoneNumber);
            Assert.IsTrue(result);
        }

        [TestMethod(DisplayName = "IsValidPhoneNumber with valid phone number without spaces returns true")]
        public void IsValidPhoneNumber_ValidPhoneNumberWithoutSpaces_ReturnsTrue() {
            string phoneNumber = "+33612345678";
            bool result = StringForge.StringValidator.IsValidPhoneNumber(phoneNumber);
            Assert.IsTrue(result);
        }

        [TestMethod(DisplayName = "IsValidPhoneNumber with valid US phone number returns true")]
        public void IsValidPhoneNumber_ValidUSPhoneNumber_ReturnsTrue() {
            string phoneNumber = "+1 555 123 4567";
            bool result = StringForge.StringValidator.IsValidPhoneNumber(phoneNumber);
            Assert.IsTrue(result);
        }

        [TestMethod(DisplayName = "IsValidPhoneNumber without plus sign returns false")]
        public void IsValidPhoneNumber_WithoutPlusSign_ReturnsFalse() {
            string phoneNumber = "33612345678";
            bool result = StringForge.StringValidator.IsValidPhoneNumber(phoneNumber);
            Assert.IsFalse(result);
        }

        [TestMethod(DisplayName = "IsValidPhoneNumber with too few digits returns false")]
        public void IsValidPhoneNumber_TooFewDigits_ReturnsFalse() {
            string phoneNumber = "+331234";
            bool result = StringForge.StringValidator.IsValidPhoneNumber(phoneNumber);
            Assert.IsFalse(result);
        }

        [TestMethod(DisplayName = "IsValidPhoneNumber with null returns false")]
        public void IsValidPhoneNumber_Null_ReturnsFalse() {
            bool result = StringForge.StringValidator.IsValidPhoneNumber(null!);
            Assert.IsFalse(result);
        }

        [TestMethod(DisplayName = "IsValidPhoneNumber with empty string returns false")]
        public void IsValidPhoneNumber_EmptyString_ReturnsFalse() {
            string phoneNumber = "";
            bool result = StringForge.StringValidator.IsValidPhoneNumber(phoneNumber);
            Assert.IsFalse(result);
        }

        [TestMethod(DisplayName = "IsValidPhoneNumber with letters returns false")]
        public void IsValidPhoneNumber_WithLetters_ReturnsFalse() {
            string phoneNumber = "+33 6 AB CD EF GH";
            bool result = StringForge.StringValidator.IsValidPhoneNumber(phoneNumber);
            Assert.IsFalse(result);
        }
    }
}
