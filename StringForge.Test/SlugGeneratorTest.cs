namespace StringForge.Test {
    [TestClass]
    public sealed class SlugGeneratorTest {
        [TestMethod(DisplayName = "GenerateSlug with valid string returns a valid slug")]
        public void GenerateSlug_ValidString_ReturnsExpectedSlug() {
            string input = "This is a Test string!";
            string expected = "this-is-a-test-string";
            string actual = SlugGenerator.GenerateSlug(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "GenerateSlug with empty string returns an empty slug")]
        public void GenerateSlug_EmptyString_ReturnsEmptySlug() {
            string input = "     ";
            string expected = "";
            string actual = SlugGenerator.GenerateSlug(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "RemoveDiacritics with valid string returns a valid string without Diacritics")]
        public void RemoveDiacritics_ValidString_ReturnsValidSlug() {
            string input = "Un message très long";
            string expected = "Un message tres long";
            string actual = SlugGenerator.RemoveDiacritics(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "RemoveDiacritics with valid string returns a valid string without Diacritics")]
        public void RemoveDiacritics_ValidString_ReturnsValidStringWithoutDiacritics() {
            string input = "Hello World!";
            string actual = SlugGenerator.RemoveDiacritics(input);
            Assert.AreEqual(input, actual);
        }
    }
}
