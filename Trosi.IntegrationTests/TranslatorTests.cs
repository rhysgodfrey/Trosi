using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trosi.Exceptions;

namespace Trosi.IntegrationTests
{
    [TestFixture]
    public class TranslatorTests
    {
        [Test]
        [TestCase("Translate", "Traduire", "en", "fr")]
        [TestCase("Traduire", "Translate", "fr", "en")]
        [TestCase("Translate", "Перевести", "en", "ru")]
        [TestCase("Перевести", "Översätta", "ru", "sv")]
        [TestCase("Översätta", "ترجمة", "sv", "ar")]
        public void EnsureCorrectTranslation(string inputText, string expectedResult, string from, string to)
        {
            // Arrange
            var translator = new Translator();

            // Act
            var result = translator.Translate(inputText, from, to);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void EnsureExceptionThrownnForInvalidCountry()
        {
            // Arrange
            var translator = new Translator();

            // Act and Assert
            Assert.Throws<TrosiTranslationException>(() => translator.Translate("Translate", "UK", "US"));
        }

        [Test]
        public void EnsureMultipleCallsFromSameObjectComplete()
        {
            // Arrange
            var translator = new Translator();

            // Act
            var firstResult = translator.Translate("Translate", "en", "de");
            var secondResult = translator.Translate("Translate", "en", "it");

            // Assert
            Assert.That(firstResult, Is.EqualTo("Übersetzen"));
            Assert.That(secondResult, Is.EqualTo("Traduci"));
        }
    }
}
