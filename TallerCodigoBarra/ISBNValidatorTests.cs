using Entity;

namespace TallerCodigoBarra
{
    [TestFixture]
    public class ValidateISBNTests
    {
        private ValidateISBN _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new ValidateISBN();
        }

        [Test]
        public void IsValidISBN_ValidISBN10_ReturnsTrue()
        {
            bool result = _validator.IsValidISBN("0471958697");
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidISBN_InvalidISBN10_ReturnsFalse()
        {
            bool result = _validator.IsValidISBN("047195869X");
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidISBN_ValidISBN13_ReturnsTrue()
        {
            bool result = _validator.IsValidISBN("9780470059029");
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidISBN_InvalidISBN13_ReturnsFalse()
        {
            bool result = _validator.IsValidISBN("9780470059023");
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidISBN_ISBNWithInvalidCharacters_ReturnsFalse()
        {
            bool result = _validator.IsValidISBN("9780X70059029");
            Assert.IsFalse(result);
        }
    }
}