using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoCRUDDB
{
    internal class ProductODM
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Type")]
        public string? Type { get; set; }
        [BsonElement("ProductName")]
        public string? ProductName { get; set; }

        [BsonElement("Description")]
        public string? Description { get; set; }

        [BsonElement("In Stock")]
        public int? InStock { get; set; }

        [BsonElement("Price")]
        public int? Price { get; set; }
    }
}
