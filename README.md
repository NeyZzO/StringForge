<h1 align="center">StringForge</h1>

![Tests](https://github.com/NeyZzO/StringForge/actions/workflows/tests.yml/badge.svg)

A simple .NET 10 string utility library. This project primarily serves as a playground for learning **GitHub Actions** and **CI/CD workflows** — the library itself is just a convenient excuse to have real code and tests to run in a pipeline. Don't blame me if it's not perfect because some of the code is generated with AI (not all of it but some part of it), the goal here isn't to give something that'll really be used but rather learn DevOps and have fun with CI/CD pipelines.

## Classes

### `CaseConverter`

Converts strings between common case formats and identifies the case type of a given string.

| Method | Description |
|---|---|
| `ToTitleCase` | Capitalizes the first letter of each word |
| `ToSnakeCase` | Converts to `snake_case` |
| `ToCamelCase` | Converts to `camelCase` |
| `ToPascalCase` | Converts to `PascalCase` |
| `ToKebabCase` | Converts to `kebab-case` |
| `ToAlternatingCase` | Converts to `aLtErNaTiNg CaSe` |
| `ToScreamingSnakeCase` | Converts to `SCREAMING_SNAKE_CASE` |
| `IdentifyCase` | Returns the `CaseType` enum value matching the input's format |

### `SlugGenerator`

Generates URL-friendly slugs from arbitrary strings.

| Method | Description |
|---|---|
| `GenerateSlug` | Lowercases, replaces spaces with hyphens, strips invalid characters |
| `RemoveDiacritics` | Strips diacritical marks (e.g. `é` → `e`) |

### `StringManipulator`

Common string operations: reversing, truncating, repeating, and masking.

| Method | Description |
|---|---|
| `Reverse` | Reverses the characters in a string |
| `Truncate` | Truncates to a max length with a configurable suffix (default `...`) |
| `RepeatString` | Repeats a string *n* times with a separator |
| `MaskEmail` | Masks an email address (e.g. `j***n@example.com`) |
| `MaskPhoneNumber` | Masks a phone number keeping country code, first digit, and last two |

### `StringValidator`

Validates strings against common formats.

| Method | Description |
|---|---|
| `IsValidEmail` | Checks if a string is a valid email address |
| `IsValidPhoneNumber` | Checks if a string is a valid international phone number |

### `TextAnalyzer`

Analyzes text content for statistics and patterns.

| Method | Description |
|---|---|
| `CountWords` | Counts the number of words |
| `CountSentences` | Counts the number of sentences |
| `MostFrequentChar` | Finds the most frequently occurring non-whitespace character |
| `IsPalindrome` | Checks if a string is a palindrome (ignoring case and non-alphanumeric chars) |
| `AverageWordLength` | Calculates the average word length |
| `LevenshteinDistance` | Computes the edit distance between two strings |

## CI/CD

This project uses a GitHub Actions workflow that runs the full unit test suite on every push to `main` and on every pull request targeting `main`. This is a first step into learning CI/CD pipelines.

## Tech Stack

- **.NET 10** (preview)
- **MSTest** with **Microsoft.Testing.Platform**