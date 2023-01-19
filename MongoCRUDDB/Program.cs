using MongoCRUDDB;

IUI io;
IProductDAO productDAO;

io = new IO();
productDAO = new MongoDAO("", "WebShop",io);

WebShopController productController = new WebShopController(io, productDAO);
productController.Start();