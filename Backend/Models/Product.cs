using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Product
    {
        public Product()
        {
            _name = String.Empty;
            _imageUri = String.Empty;
        }

        // Model properties

        // Unique identifier of the product
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        // Name of the product
        [Required, MaxLength(255)]
        public required string Name
        {
            get => _name;
            set
            {
                // Validate the string value before assigning it to _name

                // Remove any leading or trailing white-space chars
                value = value.Trim();

                // Throw an error if the string value is null or empty
                ArgumentException.ThrowIfNullOrEmpty(value);

                // Throw an error if the length of the string value is more than 255
                if (value.Length > 255)
                    throw new ArgumentException("Name cannot have more than 255 characters.");

                // Assign the string value to _name after validating
                _name = value;
            }
        }
        private string _name;

        // Price of the product
        [Required, Column(TypeName = "decimal(18,2)")]
        public required decimal Price
        {
            get => _price;
            set
            {
                // Validate the decimal value before assigning it to _price

                // Throw an error if the decimal value is null
                ArgumentNullException.ThrowIfNull(value);

                // Throw an error if the decimal value is negative 
                if (Decimal.IsNegative(value))
                    throw new ArgumentException("Price cannot be negative.");

                // Throw an error if the decimal value is equal to zero
                if (value.Equals(0))
                    throw new ArgumentException("Price cannot be zero.");

                // Throw an error if the decimal value is more than 1,000,000.00
                if (value > 1000000.00m)
                    throw new ArgumentException("Price cannot be more than 1,000,000.00");

                // Throw an error if the decimal value has more than 2 significant decimal places
                if (!value.Equals(Decimal.Round(value, 2)))
                    throw new ArgumentException("Price cannot have more than 2 numbers after decimal.");
                
                // Assign the decimal value to _price after validating
                _price = value;
            }
        }
        private decimal _price;

        // Uri referecing an image of the product
        [Required]
        public required string ImageUri
        {
            get => _imageUri;
            set
            {
                // Validate the string value before assigning it to _imageUri

                // Remove any leading or trailing white-space chars
                value = value.Trim();

                // Throw an error if the string value is null or empty
                ArgumentException.ThrowIfNullOrEmpty(value);

                // Throw an error if the string value is an invalid Uri
                if (!Uri.TryCreate(value, UriKind.Absolute, out Uri? uriResult))
                    throw new ArgumentException("ImageUri cannot be an invalid Uri.");

                // Throw an error if the string value references to a file
                // with an extension other than validExtensions
                string[] validExtensions = { ".jpg", ".jpeg", ".png" };
                if (!validExtensions.Contains(Path.GetExtension(uriResult.LocalPath).ToLower()))
                    throw new ArgumentException("ImageUri cannot reference a file with an extension other than .jpg, .jpeg or .png");

                // Assign the string value to _imageUri after validating
                _imageUri = value;
            }
        }
        private string _imageUri;
    }
}
