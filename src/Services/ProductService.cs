

public class ProductService{

public static List<Product> products=new List<Product>
{
    new Product{
        Id=Guid.Parse("eddfdc07-cc8a-401d-886d-1cb1b0b12978"),
        Name="iphone14 pro max",
        Slug="phone14-pro-max",
        ImageUrl="iphone14.png",
        Description="128GB BLACK COLOR 6.1 INCHES",
        Price=3000.99,
        Quantity=30,
        Sold=5,
        shipping=1,
        category_id =Guid.Parse("eddfdc07-cc8a-401d-886d-1cb1b0b12978"),
        CreatedAt=DateTime.Now,

    },
    new Product{
        Id=Guid.Parse("62a00def-94b6-46fe-86be-5fe3ed0ea2a4"),
        Name="iphone watch",
        Slug="iphone watch",
        ImageUrl="iphone watch.png",
        Description="New Apple Watch SE (2nd Gen, 2023) [GPS + Cellular 40mm] Smartwatch with Starlight Aluminum Case with Starlight Sport Band S/M. Fitness & Sleep Tracker",
        Price=1049.00,
        Quantity=50,
        Sold=10,
        shipping=1,
        category_id =Guid.Parse(" eddfdc07-cc8a-401d-886d-1cb1b0b12978"),
        CreatedAt=DateTime.Now,

    },
    new Product{
        Id=Guid.Parse("a7540863-ac69-4da4-a286-4325e970d2dd"),
        Name="usb-c to Lightning Adapter",
        Slug="usb-c to Lightning Adapter",
        ImageUrl="usb-c to Lightning Adapter.png",
        Description="The Apple 20W USB‑C Power Adapter offers fast, efficient charging at home, in the office, or on the go. Pair it with iPhone 8 or later for fast charging — 50 percent battery in around 30 minutes.¹ Or pair it with the iPad Pro and iPad Air for optimal charging performance. Compatible with any USB-C enabled device",
        Price=29,
        Quantity=100,
        Sold=10,
        shipping=2.0,
        category_id =Guid.Parse("a7540863-ac69-4da4-a286-4325e970d2dd"),
        CreatedAt=DateTime.Now,
    }};
public List<Product> GetAllProduct()
{
return products;
}
public Product? GetProductById(Guid productId){
return products.Find(product => product.Id == productId);
}
public Product? CreateNewProduct(Product newProduct){
newProduct.Id = new Guid();
newProduct.CreatedAt=DateTime.Now;
products.Add(newProduct);
return newProduct;
}
public Product UpdateProduct(Guid id ,Product productUpdate){
   
   var productUpdated=products.Find(product => product.Id == id);{
    if(productUpdated!=null){
        productUpdated.Name=productUpdate.Name?? productUpdated.Name;
        productUpdated.Slug=productUpdate.Slug??productUpdated.Slug;
        productUpdated.ImageUrl=productUpdate.ImageUrl??productUpdated.ImageUrl;
        productUpdated.Description=productUpdate.Description??productUpdated.Description;
        productUpdated.Quantity=productUpdate.Quantity;
        productUpdated.Sold=productUpdate.Sold ;
        productUpdated.shipping=productUpdate.shipping ;
        productUpdated.category_id = productUpdate.category_id ;
    }
    return productUpdated;
   }
    
}
public bool deleteProductById(Guid id){
    var productDeleted=products.Find(product => product.Id == id);
    if(productDeleted!=null){
    products.Remove(productDeleted);
    return true;
    }
    return false;
}}




// 






