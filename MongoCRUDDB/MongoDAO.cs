using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoCRUDDB
{
    internal class MongoDAO:IProductDAO
    {
        private IUI io;
        int IndexInput=0;
        IMongoCollection<ProductODM> collection;
        List<string> strings = new List<string> { "Type", "ProductName", "Description", "Price", "In Stock" };
        List<string> productInput = new List<string>();
        public MongoDAO(string MongoURI, string db,IUI io)
        {
            var client = new MongoClient(MongoURI);
            var database = client.GetDatabase(db);
            this.collection = database.GetCollection<ProductODM>("Stock");
            this.io = io;

        }
        public ProductODM CreateProduct()
        {
            for (int i = 0; i < 5; i++)
            {
                io.Print(strings[i]);
                productInput.Add(io.GetInput());
            }
            return new ProductODM
            {
                Type = productInput[0],
                ProductName = productInput[1],
                Description = productInput[2],
                Price = int.Parse(productInput[3]),
                InStock = int.Parse(productInput[4])
            };
        }
        public void Create(ProductODM product)
        {
            this.collection.InsertOne(product);
            productInput.Clear();
        }

        public void Delete(ObjectId id)
        {
            var filter = Builders<ProductODM>.Filter.Eq("_id", id);
            collection.DeleteOne(filter);
        }

        public void ReadAll()
        {
            Read().ForEach(product =>
            {
                io.Print("ObjectId: " + product.Id.ToString() + "\nType: " + product.Type +
            "\nProductName: " + product.ProductName + "\nDescription: " + product.Description +
            "\nPrice: " + product.Price + "\nIn Stock: " + product.InStock + "\n");
            });
        }
        public List<ProductODM> Read()
        {
            return this.collection.Find(new BsonDocument()).ToList();
        }

        public ObjectId Id()
        {
            return ObjectId.Parse(io.GetInput());
        }

        public int Index()
        {
            int count = 1;
            strings.ToList().ForEach(x => Console.WriteLine(count++ + " " + x));
            io.Print("\nSelect the number for the category to change!");
            IndexInput = int.Parse(io.GetInput());
            return IndexInput;
        }

        public string UIInput()
        {
            int indexInput = IndexInput-1;
            io.Print(strings[indexInput]);
            return io.GetInput();
        }

        public void Update(ObjectId id,int index,string UIinput)
        {
            index = IndexInput-1;
            var filter = Builders<ProductODM>.Filter.Eq("_id", id);
            if (index < 3)
            {
                var update = Builders<ProductODM>.Update.Set(strings[index--], UIinput);
                collection.UpdateOne(filter, update);
            }
            else
            {
                var update = Builders<ProductODM>.Update.Set(strings[index--], int.Parse(UIinput));
                collection.UpdateOne(filter, update);
            }
        }

    }
}
