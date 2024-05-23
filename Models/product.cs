using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebInvManagement.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Price")]
        public double Price { get; set; }

        [BsonElement("Quantity")]
        public int Quantity { get; set; }

        [BsonElement("Barcode")]
        public long Barcode { get; set; }

        [BsonElement("Weight")]
        public double Weight { get; set; }

        public Product()
        {
            // Required for serialization
        }

        public Product(string name, string description, double price, int quantity, long barcode, double weight)
        {
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            Barcode = barcode;
            Weight = weight;
        }
    }
}
