﻿using Expelibrum.Services;
using Xunit;

namespace Expelibrum.Tests.Expelibrum.Services
{
    public class PDFUtilsShould
    {

        [Fact]
        public void RecognizeIsbnSeparatedByColonOnly()
        {
            var sut = new PDFUtils();
            var isbn = "isbn:1234567890";

            Assert.Equal("1234567890", sut.FindIsbn(isbn));
        }

        [Fact]
        public void RecognizeIsbnSeparatedByWhitespace()
        {
            var sut = new PDFUtils();
            var isbn = "isbn 1234567890";

            Assert.Equal("1234567890", sut.FindIsbn(isbn));
        }

        [Fact]
        public void RecognizeIsbnSeparatedByColonAndWhitespace()
        {
            var sut = new PDFUtils();
            var isbn = "isbn: 1234567890";

            Assert.Equal("1234567890", sut.FindIsbn(isbn));
        }

        [Fact]
        public void RecognizeIsbnSeparatedByWhitespaceDashWhitespace()
        {
            var sut = new PDFUtils();
            var isbn = "isbn - 1234567890";

            Assert.Equal("1234567890", sut.FindIsbn(isbn));
        }

        [Fact]
        public void RecognizeIsbnSeparatedByGarbage()
        {
            var sut = new PDFUtils();
            var isbn = "isbn-13 (abcd): 1234567890123";

            Assert.Equal("1234567890123", sut.FindIsbn(isbn));
        }

        [Fact]
        public void RecognizeIsbnUppercase()
        {
            var sut = new PDFUtils();
            var isbn = "ISBN 1234567890123";

            Assert.Equal("1234567890123", sut.FindIsbn(isbn));
        }

        [Fact]
        public void RecognizeIsbn13()
        {
            var sut = new PDFUtils();
            var isbn = "isbn 123-4567890123";

            Assert.Equal("1234567890123", sut.FindIsbn(isbn));
        }

        [Fact]
        public void RecognizeExplicitIsbn()
        {
            var sut = new PDFUtils();
            var isbn = "isbn-10 1234567890";

            Assert.Equal("1234567890", sut.FindIsbn(isbn));
        }

        [Fact]
        public void RecognizeIsbnWithDashes()
        {
            var sut = new PDFUtils();
            var isbn = "isbn 123-4-5678-9012-3";

            Assert.Equal("1234567890123", sut.FindIsbn(isbn));
        }

        [Fact]
        public void RecognizeIsbnWithUnderscores()
        {
            var sut = new PDFUtils();
            var isbn = "isbn 123_4_5678_9012_3";

            Assert.Equal("1234567890123", sut.FindIsbn(isbn));
        }

        [Fact]
        public void FindIsbn()
        {
            var sut = new PDFUtils();
            var input = "abcd ---- _#$1ff 1234 isbn 1234567890 ffff ?!434 @@@@@ xxxx";

            Assert.Equal("1234567890", sut.FindIsbn(input));
        }
    }
}
