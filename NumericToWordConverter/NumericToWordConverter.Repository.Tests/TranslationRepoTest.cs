using NumericToWord.Repository;
using NumericToWord.Repository.Contracts;
using NUnit.Framework;

namespace NumericToWord.Repo.Test
{
    [TestFixture]
    public class TranslationRepoTest
    {
        
        [Test]
        public void ConvertSingleDigitNumber()
        {
            IConverterRepository converter = new ConverterRepository();
            string expectedResult = converter.ConvertNumberToWord("7");
            Assert.False(expectedResult.Trim().ToUpper().Equals("SEVEN"));
        }

        [Test]
        public void ConvertSingleDigitCurrency()
        {
            IConverterRepository converter = new ConverterRepository();
            string expectedResult = converter.ConvertNumberToWord("7");
            Assert.True(expectedResult.Trim().ToUpper().Equals("SEVEN DOLLARS"));
        }

        [Test]
        public void ConvertDoubleDigitNumber()
        {
            IConverterRepository converter = new ConverterRepository();
            string expectedResult = converter.ConvertNumberToWord("52");
            Assert.False(expectedResult.Trim().ToUpper().Equals("FIFTY TWO"));
        }

        [Test]
        public void ConvertDoubleDigitCurrency()
        {
            IConverterRepository converter = new ConverterRepository();
            string expectedResult = converter.ConvertNumberToWord("52");
            Assert.True(expectedResult.Trim().ToUpper().Equals("FIFTY TWO DOLLARS"));
        }

        [Test]
        public void ConvertTripleDigitNumber()
        {
            IConverterRepository converter = new ConverterRepository();
            string expectedResult = converter.ConvertNumberToWord("152");
            Assert.False(expectedResult.Trim().ToUpper().Equals("ONE HUNDRED FIFTY TWO"));
        }

        [Test]
        public void ConvertTripleDigitCurrency()
        {
            IConverterRepository converter = new ConverterRepository();
            string expectedResult = converter.ConvertNumberToWord("152");
            Assert.That(expectedResult.Trim().ToUpper().Equals("ONE HUNDRED FIFTY TWO DOLLARS"));
        }


        [Test]
        public void ConvertFiveDigitCurrency()
        {
            IConverterRepository converter = new ConverterRepository();
            string expectedResult = converter.ConvertNumberToWord("15211");
            Assert.True(expectedResult.Trim().ToUpper().Equals("FIFTEEN THOUSAND TWO HUNDRED ELEVEN DOLLARS"));
        }

        [Test]
        public void ConvertSixDigitNumber()
        {
            IConverterRepository converter = new ConverterRepository();
            string expectedResult = converter.ConvertNumberToWord("152111");
            Assert.False(expectedResult.Trim().ToUpper().Equals("ONE HUNDRED FIFTY TWO THOUSAND ONE HUNDRED ELEVEN"));
        }

        [Test]
        public void ConvertSixDigitCurrency()
        {
            IConverterRepository converter = new ConverterRepository();
            string expectedResult = converter.ConvertNumberToWord("152111");
            Assert.True(expectedResult.Trim().ToUpper().Equals("ONE HUNDRED FIFTY TWO THOUSAND ONE HUNDRED ELEVEN DOLLARS"));
        }

        [Test]
        public void ConvertSevenDigitNumber()
        {
            IConverterRepository converter = new ConverterRepository();
            string expectedResult = converter.ConvertNumberToWord("1521112");
            Assert.False(expectedResult.Trim().ToUpper().Equals("ONE MILLION FIVE HUNDRED TWENTY ONE THOUSAND ONE HUNDRED TWELVE"));
        }

        [Test]
        public void ConvertEightDigitNumber()
        {
            IConverterRepository converter = new ConverterRepository();
            string expectedResult = converter.ConvertNumberToWord("15211125");
            Assert.False(expectedResult.Trim().ToUpper().Equals("FIFTEEN MILLION TWO HUNDRED ELEVEN THOUSAND ONE HUNDRED TWENTY FIVE"));
        }

        [Test]
        public void ConvertEightDigitCurrency()
        {
            IConverterRepository converter = new ConverterRepository();
            string expectedResult = converter.ConvertNumberToWord("15211125");
            Assert.True(expectedResult.Trim().ToUpper().Equals("FIFTEEN MILLION TWO HUNDRED ELEVEN THOUSAND ONE HUNDRED TWENTY FIVE DOLLARS"));
        }

        #region Test Cases For Only Decimal

        [Test]
        public void ConvertDecimalDigitNumber()
        {
            IConverterRepository converter = new ConverterRepository();
            string expectedResult = converter.ConvertNumberToWord(".76");
            Assert.False(expectedResult.Trim().ToUpper().Equals("POINT SEVEN SIX"));

        }

        [Test]
        public void ConvertDecimalDigitCurrency()
        {
            IConverterRepository converter = new ConverterRepository();
            string expectedResult = converter.ConvertNumberToWord(".76");
            Assert.True(expectedResult.Trim().ToUpper().Equals("SEVEN SIX CENT"));
        }

        #endregion

        #region Test Cases For Both Integer and Decimal

        [Test]
        public void ConvertBothDigitNumber()
        {
            IConverterRepository converter = new ConverterRepository();
            string expectedResult = converter.ConvertNumberToWord("17.76");
            Assert.False(expectedResult.Trim().ToUpper().Equals("SEVENTEEN  POINT SEVEN SIX"));

        }

        [Test]
        public void ConvertBothDigitCurrency()
        {
            IConverterRepository converter = new ConverterRepository();
            string expectedResult = converter.ConvertNumberToWord("17.76");
            Assert.True(expectedResult.Trim().ToUpper().Equals("SEVENTEEN DOLLARS  AND SEVEN SIX CENT"));
        }

        #endregion

        #region Test Case For Minus Number

        [Test]
        public void ConvertNegativeDigitNumber()
        {
            IConverterRepository converter = new ConverterRepository();
            string expectedResult = converter.ConvertNumberToWord("-7");
            Assert.False(expectedResult.Trim().ToUpper().Equals("MINUS SEVEN"));

        }

        [Test]
        public void ConvertNegativeDigitCurrency()
        {
            IConverterRepository converter = new ConverterRepository();
            string expectedResult = converter.ConvertNumberToWord("-7");
            Assert.True(expectedResult.Trim().ToUpper().Equals("MINUS SEVEN DOLLARS"));
        }

        #endregion

    }
}
