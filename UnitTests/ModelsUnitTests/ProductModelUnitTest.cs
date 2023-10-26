using Backend.Models;
using static System.Net.WebRequestMethods;

namespace UnitTests.ModelsUnitTests
{
    public class ProductModelUnitTest
    {
        // Test creation of Product model instance
        [Fact]
        public void ProductConstructor_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            string name = "NameOfProduct";
            decimal price = 100.34m;
            string imageUri = "https://i.postimg.cc/85yJJXHm/pexels-math-90946.jpg";

            // Act
            Product product = new()
            {
                Name = name,
                Price = price,
                ImageUri = imageUri
            };

            // Assert
            Assert.Equal(name, product.Name);
            Assert.Equal(price, product.Price);
            Assert.Equal(imageUri, product.ImageUri);
        }

        // Test Name property validation rule: no leading or trailing white-space chars
        [Fact]
        public void ValidateNameProperty_ShouldTrimWhiteSpaceChars()
        {
            // Arrange
            string name = "   NameOfProduct    ";
            string validatedName = "NameOfProduct";
            decimal price = 100.34m;
            string imageUri = "https://i.postimg.cc/85yJJXHm/pexels-math-90946.jpg";

            // Act
            Product product = new()
            {
                Name = name,
                Price = price,
                ImageUri = imageUri
            };

            // Assert
            Assert.Equal(validatedName, product.Name);
        }

        // Test Name property validation rule: no null value
        [Fact]
        public void ValidateNameProperty_ShouldThrowNullError()
        {
            // Arrange
            string? name = null;
            decimal price = 100.34m;
            string imageUri = "https://i.postimg.cc/85yJJXHm/pexels-math-90946.jpg";

            // Act and Assert
            Assert.Throws<NullReferenceException>(() =>
            {
                Product product = new()
                {
                    Name = name,
                    Price = price,
                    ImageUri = imageUri
                };
            });
        }

        // Test Name property validation rule: no empty string
        [Fact]
        public void ValidateNameProperty_ShouldThrowEmptyError()
        {
            // Arrange
            string name = String.Empty;
            decimal price = 100.34m;
            string imageUri = "https://i.postimg.cc/85yJJXHm/pexels-math-90946.jpg";

            // Act and Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Product product = new()
                {
                    Name = name,
                    Price = price,
                    ImageUri = imageUri
                };
            });
        }

        // Test Name property validation rule: string max length 255
        [Fact]
        public void ValidateNameProperty_ShouldEnforeMaxLength255()
        {
            // Arrange
            string name = String.Empty;
            decimal price = 100.34m;
            string imageUri = "https://i.postimg.cc/85yJJXHm/pexels-math-90946.jpg";
            while (name.Length <= 256) name += "a";

            // Act and Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Product product = new()
                {
                    Name = name,
                    Price = price,
                    ImageUri = imageUri
                };
            });
        }
        
        // Test Price property validation rule: no null value
        [Fact]
        public void ValidatePriceProperty_ShouldThrowNullError()
        {
            // Arrange
            string name = "NameOfProperty";
            decimal? price = null;
            string imageUri = "https://i.postimg.cc/85yJJXHm/pexels-math-90946.jpg";

            // Act and Assert
            Assert.ThrowsAny<InvalidOperationException>(() =>
            {
                Product product = new()
                {
                    Name = name,
                    Price = (decimal)price,
                    ImageUri = imageUri
                };
            });
        }

        // Test Price property validation rule: no negative value
        [Fact]
        public void ValidatePriceProperty_ShouldNotAllowNegativeValue()
        {
            // Arrange
            string name = "NameOfProperty";
            decimal price = -1.00m;
            string imageUri = "https://i.postimg.cc/85yJJXHm/pexels-math-90946.jpg";

            // Act and Arrange
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                Product product = new()
                {
                    Name = name,
                    Price = price,
                    ImageUri = imageUri
                };
            });
        }

        // Test Price property validation rule: zero not allowed
        [Fact]
        public void ValidatePriceProperty_ShouldNotAllowZeroValue()
        {
            // Arrange
            string name = "NameOfProperty";
            decimal price = 0.00m;
            string imageUri = "https://i.postimg.cc/85yJJXHm/pexels-math-90946.jpg";

            // Act and Arrange
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                Product product = new()
                {
                    Name = name,
                    Price = price,
                    ImageUri = imageUri
                };
            });
        }

        // Test Price property validation rule: value more than 1,000,000.00 not allowed
        [Fact]
        public void ValidatePriceProperty_ShouldNotAllowValueMoreThanOneMillion()
        {
            // Arrange
            string name = "NameOfProperty";
            decimal price = 1000000.01m;
            string imageUri = "https://i.postimg.cc/85yJJXHm/pexels-math-90946.jpg";

            // Act and Arrange
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                Product product = new()
                {
                    Name = name,
                    Price = price,
                    ImageUri = imageUri
                };
            });
        }

        // Test Price property validation rule: no more than 2 significant decimal places allowed
        [Fact]
        public void ValidatePriceProperty_ShouldNotAllowMoreThanTwoDecimalPlaces()
        {
            // Arrange
            string name = "NameOfProperty";
            decimal price = 1.001m;
            string imageUri = "https://i.postimg.cc/85yJJXHm/pexels-math-90946.jpg";

            // Act and Arrange
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                Product product = new()
                {
                    Name = name,
                    Price = price,
                    ImageUri = imageUri
                };
            });
        }

        // Test ImageUri property validation rule: no leading or trailing white-space chars
        [Fact]
        public void ValidateImageUriProperty_ShouldTrimWhiteSpaceChars()
        {
            // Arrange
            string name = "NameOfProduct";
            decimal price = 100.34m;
            string imageUri = "    https://i.postimg.cc/85yJJXHm/pexels-math-90946.jpg    ";
            string validatedImageUri = "https://i.postimg.cc/85yJJXHm/pexels-math-90946.jpg";

            // Act
            Product product = new()
            {
                Name = name,
                Price = price,
                ImageUri = imageUri
            };

            // Assert
            Assert.Equal(validatedImageUri, product.ImageUri);
        }

        // Test ImageUri property validation rule: no null value
        [Fact]
        public void ValidateImageUriProperty_ShouldThrowNullError()
        {
            // Arrange
            string name = "NameOfProduct";
            decimal price = 100.34m;
            string? imageUri = null;

            // Act and Assert
            Assert.Throws<NullReferenceException>(() =>
            {
                Product product = new()
                {
                    Name = name,
                    Price = price,
                    ImageUri = imageUri
                };
            });
        }

        // Test ImageUri property validation rule: no invalid uri
        [Fact]
        public void ValidateImageUriProperty_ShouldThrowInvalidUriError()
        {
            // Arrange
            string name = "NameOfProduct";
            decimal price = 100.34m;
            string imageUri = "/85yJJXHm/pexels-math-90946.jpg";

            // Act and Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Product product = new()
                {
                    Name = name,
                    Price = price,
                    ImageUri = imageUri
                };
            });
        }

        // Test ImageUri property validation rule: referencing to file other than
        // .jpg, .jpeg or .png not allowed
        [Fact]
        public void ValidateImageUriProperty_ShouldThrowInvalidFileExtensionError()
        {
            // Arrange
            string name = "NameOfProduct";
            decimal price = 100.34m;
            string imageUri = "https://i.postimg.cc/85yJJXHm/pexels-math-90946.pdf";

            // Act and Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Product product = new()
                {
                    Name = name,
                    Price = price,
                    ImageUri = imageUri
                };
            });
        }
    }
}