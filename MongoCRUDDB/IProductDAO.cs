using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoCRUDDB
{
    internal interface IProductDAO
    {
        ProductODM CreateProduct();
        void Create(ProductODM product);
        List<ProductODM> Read();
        void ReadAll();

        ObjectId Id();
        int Index();
        string UIInput();
        void Update(ObjectId Id,int Index,string UIInput);
        void Delete(ObjectId Id);

    }
}
