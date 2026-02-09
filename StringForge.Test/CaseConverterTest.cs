using System;
using System.Collections.Generic;
using System.Text;

namespace StringForge.Test {
    [TestClass]
    public sealed class CaseConverterTest {

        #region ToTitleCase Tests

        [TestMethod(DisplayName = "ToTitleCase with lowercase string returns title case")]
        public void ToTitleCase_LowercaseString_ReturnsTitleCase() {
            string input = "hello world";
            string expected = "Hello World";
            string actual = CaseConverter.ToTitleCase(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "ToTitleCase with uppercase string returns title case")]
        public void ToTitleCase_UppercaseString_ReturnsTitleCase() {
            string input = "HELLO WORLD";
            string expected = "Hello World";
            string actual = CaseConverter.ToTitleCase(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "ToTitleCase with empty string returns empty string")]
        public void ToTitleCase_EmptyString_ReturnsEmptyString() {
            string input = "";
            string actual = CaseConverter.ToTitleCase(input);
            Assert.AreEqual(input, actual);
        }

        [TestMethod(DisplayName = "ToTitleCase with null returns null")]
        public void ToTitleCase_Null_ReturnsNull() {
            string? actual = CaseConverter.ToTitleCase(null!);
            Assert.IsNull(actual);
        }

        #endregion

        #region ToSnakeCase Tests

        [TestMethod(DisplayName = "ToSnakeCase with camelCase returns snake_case")]
        public void ToSnakeCase_CamelCase_ReturnsSnakeCase() {
            string input = "helloWorld";
            string expected = "hello_world";
            string actual = CaseConverter.ToSnakeCase(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "ToSnakeCase with PascalCase returns snake_case")]
        public void ToSnakeCase_PascalCase_ReturnsSnakeCase() {
            string input = "HelloWorld";
            string expected = "hello_world";
            string actual = CaseConverter.ToSnakeCase(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "ToSnakeCase with spaces returns snake_case")]
        public void ToSnakeCase_WithSpaces_ReturnsSnakeCase() {
            string input = "hello world test";
            string expected = "hello_world_test";
            string actual = CaseConverter.ToSnakeCase(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "ToSnakeCase with empty string returns empty string")]
        public void ToSnakeCase_EmptyString_ReturnsEmptyString() {
            string input = "";
            string actual = CaseConverter.ToSnakeCase(input);
            Assert.AreEqual(input, actual);
        }

        #endregion

        #region ToCamelCase Tests

        [TestMethod(DisplayName = "ToCamelCase with snake_case returns camelCase")]
        public void ToCamelCase_SnakeCase_ReturnsCamelCase() {
            string input = "hello_world";
            string expected = "helloWorld";
            string actual = CaseConverter.ToCamelCase(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "ToCamelCase with PascalCase returns camelCase")]
        public void ToCamelCase_PascalCase_ReturnsCamelCase() {
            string input = "HelloWorld";
            string expected = "helloWorld";
            string actual = CaseConverter.ToCamelCase(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "ToCamelCase with spaces returns camelCase")]
        public void ToCamelCase_WithSpaces_ReturnsCamelCase() {
            string input = "hello world test";
            string expected = "helloWorldTest";
            string actual = CaseConverter.ToCamelCase(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "ToCamelCase with empty string returns empty string")]
        public void ToCamelCase_EmptyString_ReturnsEmptyString() {
            string input = "";
            string actual = CaseConverter.ToCamelCase(input);
            Assert.AreEqual(input, actual);
        }

        #endregion

        #region ToPascalCase Tests

        [TestMethod(DisplayName = "ToPascalCase with snake_case returns PascalCase")]
        public void ToPascalCase_SnakeCase_ReturnsPascalCase() {
            string input = "hello_world";
            string expected = "HelloWorld";
            string actual = CaseConverter.ToPascalCase(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "ToPascalCase with camelCase returns PascalCase")]
        public void ToPascalCase_CamelCase_ReturnsPascalCase() {
            string input = "helloWorld";
            string expected = "HelloWorld";
            string actual = CaseConverter.ToPascalCase(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "ToPascalCase with spaces returns PascalCase")]
        public void ToPascalCase_WithSpaces_ReturnsPascalCase() {
            string input = "hello world test";
            string expected = "HelloWorldTest";
            string actual = CaseConverter.ToPascalCase(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "ToPascalCase with empty string returns empty string")]
        public void ToPascalCase_EmptyString_ReturnsEmptyString() {
            string input = "";
            string actual = CaseConverter.ToPascalCase(input);
            Assert.AreEqual(input, actual);
        }

        #endregion

        #region ToKebabCase Tests

        [TestMethod(DisplayName = "ToKebabCase with camelCase returns kebab-case")]
        public void ToKebabCase_CamelCase_ReturnsKebabCase() {
            string input = "helloWorld";
            string expected = "hello-world";
            string actual = CaseConverter.ToKebabCase(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "ToKebabCase with PascalCase returns kebab-case")]
        public void ToKebabCase_PascalCase_ReturnsKebabCase() {
            string input = "HelloWorld";
            string expected = "hello-world";
            string actual = CaseConverter.ToKebabCase(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "ToKebabCase with snake_case returns kebab-case")]
        public void ToKebabCase_SnakeCase_ReturnsKebabCase() {
            string input = "hello_world";
            string expected = "hello-world";
            string actual = CaseConverter.ToKebabCase(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "ToKebabCase with empty string returns empty string")]
        public void ToKebabCase_EmptyString_ReturnsEmptyString() {
            string input = "";
            string actual = CaseConverter.ToKebabCase(input);
            Assert.AreEqual(input, actual);
        }

        #endregion

        #region ToAlternatingCase Tests

        [TestMethod(DisplayName = "ToAlternatingCase with lowercase returns alternating case")]
        public void ToAlternatingCase_Lowercase_ReturnsAlternatingCase() {
            string input = "hello";
            string expected = "hElLo";
            string actual = CaseConverter.ToAlternatingCase(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "ToAlternatingCase with uppercase returns alternating case")]
        public void ToAlternatingCase_Uppercase_ReturnsAlternatingCase() {
            string input = "HELLO";
            string expected = "hElLo";
            string actual = CaseConverter.ToAlternatingCase(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "ToAlternatingCase with spaces preserves spaces")]
        public void ToAlternatingCase_WithSpaces_PreservesSpaces() {
            string input = "hello world";
            string expected = "hElLo WoRlD";
            string actual = CaseConverter.ToAlternatingCase(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "ToAlternatingCase with empty string returns empty string")]
        public void ToAlternatingCase_EmptyString_ReturnsEmptyString() {
            string input = "";
            string actual = CaseConverter.ToAlternatingCase(input);
            Assert.AreEqual(input, actual);
        }

        #endregion

        #region ToScreamingSnakeCase Tests

        [TestMethod(DisplayName = "ToScreamingSnakeCase with camelCase returns SCREAMING_SNAKE_CASE")]
        public void ToScreamingSnakeCase_CamelCase_ReturnsScreamingSnakeCase() {
            string input = "helloWorld";
            string expected = "HELLO_WORLD";
            string actual = CaseConverter.ToScreamingSnakeCase(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "ToScreamingSnakeCase with spaces returns SCREAMING_SNAKE_CASE")]
        public void ToScreamingSnakeCase_WithSpaces_ReturnsScreamingSnakeCase() {
            string input = "hello world";
            string expected = "HELLO_WORLD";
            string actual = CaseConverter.ToScreamingSnakeCase(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "ToScreamingSnakeCase with empty string returns empty string")]
        public void ToScreamingSnakeCase_EmptyString_ReturnsEmptyString() {
            string input = "";
            string actual = CaseConverter.ToScreamingSnakeCase(input);
            Assert.AreEqual(input, actual);
        }

        #endregion

        #region IdentifyCase Tests

        [TestMethod(DisplayName = "IdentifyCase with snake_case returns SnakeCase")]
        public void IdentifyCase_SnakeCase_ReturnsSnakeCase() {
            string input = "hello_world";
            CaseType expected = CaseType.SnakeCase;
            CaseType actual = CaseConverter.IdentifyCase(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "IdentifyCase with camelCase returns CamelCase")]
        public void IdentifyCase_CamelCase_ReturnsCamelCase() {
            string input = "helloWorld";
            CaseType expected = CaseType.CamelCase;
            CaseType actual = CaseConverter.IdentifyCase(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "IdentifyCase with PascalCase returns PascalCase")]
        public void IdentifyCase_PascalCase_ReturnsPascalCase() {
            string input = "HelloWorld";
            CaseType expected = CaseType.PascalCase;
            CaseType actual = CaseConverter.IdentifyCase(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "IdentifyCase with kebab-case returns KebabCase")]
        public void IdentifyCase_KebabCase_ReturnsKebabCase() {
            string input = "hello-world";
            CaseType expected = CaseType.KebabCase;
            CaseType actual = CaseConverter.IdentifyCase(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "IdentifyCase with SCREAMING_SNAKE_CASE returns ScreamingSnakeCase")]
        public void IdentifyCase_ScreamingSnakeCase_ReturnsScreamingSnakeCase() {
            string input = "HELLO_WORLD";
            CaseType expected = CaseType.ScreamingSnakeCase;
            CaseType actual = CaseConverter.IdentifyCase(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "IdentifyCase with UPPERCASE returns UpperCase")]
        public void IdentifyCase_UpperCase_ReturnsUpperCase() {
            string input = "HELLO";
            CaseType expected = CaseType.UpperCase;
            CaseType actual = CaseConverter.IdentifyCase(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "IdentifyCase with Title Case returns TitleCase")]
        public void IdentifyCase_TitleCase_ReturnsTitleCase() {
            string input = "Hello World";
            CaseType expected = CaseType.TitleCase;
            CaseType actual = CaseConverter.IdentifyCase(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod(DisplayName = "IdentifyCase with aLtErNaTiNg returns AlternatingCase")]
        public void IdentifyCase_AlternatingCase_ReturnsAlternatingCase() {
            // Note: L'implémentation actuelle de IsAlternatingCase peut ne pas détecter tous les patterns
            string input = CaseConverter.ToAlternatingCase("test");
            CaseType actual = CaseConverter.IdentifyCase(input);
            // Vérifie que le résultat de ToAlternatingCase est reconnu (ou Unknown si pas implémenté)
            Assert.AreEqual(CaseType.AlternatingCase, actual);
        }

        [TestMethod(DisplayName = "IdentifyCase with empty string returns TitleCase")]
        public void IdentifyCase_EmptyString_ReturnsTitleCase() {
            string input = "";
            CaseType expected = CaseType.TitleCase;
            CaseType actual = CaseConverter.IdentifyCase(input);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
