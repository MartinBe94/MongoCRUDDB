using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoCRUDDB
{
    internal class WebShopController
    {
        private IUI io;
        private IProductDAO productDAO;
        public WebShopController(IUI io, IProductDAO productDAO)
        {
            this.io = io;
            this.productDAO = productDAO;
        }
        public void Start()
        {
            while (true)
            {
                io.Print("Welcome to the program!\nSelect what to do!\n1. ReadAll\n2. Create\n3. Update\n4. Delete\n5. Exit\n");
                try
                {
                    switch (int.Parse(io.GetInput()))
                    {
                        case 1:
                            productDAO.ReadAll();
                            break;

                        case 2:
                            productDAO.Create(productDAO.CreateProduct());
                            io.Print("Document created!\n");
                            break;

                        case 3:
                            productDAO.ReadAll();
                            io.Print("Write the id of the product you want to change!");
                            productDAO.Update(productDAO.Id(),productDAO.Index(),productDAO.UIInput()); //Update
                            io.Print("Document updated!\n");
                            break;

                        case 4:
                            productDAO.ReadAll();
                            io.Print("Select the id of the product you want to delete!");
                            productDAO.Delete(ObjectId.Parse(io.GetInput()));
                            io.Print("Document deleted!\n");
                            break;

                        case 5:
                            io.Exit();
                            break;
                    }
                }
                catch { io.Print("Wrong input try again!\n"); }
            }
        }
    }
}
