using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PigLatin
{
    public class TestPigLatin
    {
        [Fact]
        public void NoVowelsTesting()
        {
            //arrange
            PigLatinGenerator myGen = new PigLatinGenerator("gym");
            string actual = myGen.PigLatinOutput;

            //act
            string expected = "gym";

            //assert
            Assert.Equal(actual, expected);

        } 


        [Fact]
        public void SpecialCharactersTesting()
        {
            //arrange
            PigLatinGenerator myGen = new PigLatinGenerator("gym@gmail.com");
            string actual = myGen.PigLatinOutput;

            //act
            string expected = "gym@gmail.com";

            //assert
            Assert.Equal(actual, expected);

        }

        [Fact]
        public void FirstLetterIsVowelTesting()
        {
            //arrange
            PigLatinGenerator myGen = new PigLatinGenerator("aardvark");
            string actual = myGen.PigLatinOutput;

            //act
            string expected = "aardvarkway";

            //assert
            Assert.Equal(actual, expected);

        }

        [Fact]
        public void WordWithVowelsTesting()
        {
            //arrange
            PigLatinGenerator myGen = new PigLatinGenerator("hello");
            string actual = myGen.PigLatinOutput;

            //act
            string expected = "ellohay";

            //assert
            Assert.Equal(actual, expected);

        }

        [Fact]
        public void WholeSentenceTesting()
        {
            //arrange
            PigLatinGenerator myGen = new PigLatinGenerator("hello erin erin@gmail.com");
            string actual = myGen.PigLatinOutput;

            //act
            string expected = "ellohay erinway erin@gmail.com";

            //assert
            Assert.Equal(actual, expected);

        }

        [Theory]

        [InlineData("apple", "appleway")]
        [InlineData("heck","eckhay")]
        [InlineData("strong", "ongstray")]
        [InlineData("tommy@email.com", "tommy@email.com")]
        [InlineData("Tommy", "ommytay")]
        [InlineData("gym", "gym")]
        [InlineData("apple joy gym tommy@email.com strong", "appleway oyjay gym tommy@email.com ongstray")]

        public void TestingTheory(string input, string expected)
        {
            //arrange
            PigLatinGenerator myGen = new PigLatinGenerator(input);
            string actual = myGen.PigLatinOutput;

            //assert
            Assert.Equal(actual, expected);
        }

    }
}
