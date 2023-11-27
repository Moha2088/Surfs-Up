using SurfsWebShopLibrary.Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurfsWebShopLibrary.ShoppingCart.Models;

namespace SurfsWebShopLibrary.Storage
{
    /// <summary>
    /// Stores the data used for the application.
    /// </summary>
    public class StorageService : IStorageService
    {
        /// <summary>
        /// Stores a list of products.
        /// </summary>
        public IList<ProductModel> Products { get; private set; }

        /// <summary>
        /// Stores the shopping cart.        
        /// </summary>
        public ShoppingCartModel ShoppingCart { get; private set; }

        /// <summary>
        ///  Constructs a storage service.
        /// </summary>
        public StorageService()
        {
            Products = new List<ProductModel>();
            ShoppingCart = new ShoppingCartModel();

            // Store a list of all the products for the online shop.
            AddProduct(new ProductModel("Shortboard", "The Minilog", 24, "shortboard-theminilog.jpg"));
            AddProduct(new ProductModel("Funboard", "The Wide Glider", 24, "Funboard-TheWideGlider.jpg"));
            AddProduct(new ProductModel("Shortboard", "The Golden Ratio", 29, "Shortboard-TheGoldenRatio.jpg"));
            AddProduct(new ProductModel("Fish", "Mahi Mahi", 29, "fish-MahiMahi.jpg"));
            AddProduct(new ProductModel("Longboard", "The Emerald Glider", 29, "longboard-TheEmeraldGlider.jpg"));
            AddProduct(new ProductModel("Shortboard", "The Bomb", 16, "shortboard-TheBomb.jpg"));
            AddProduct(new ProductModel("Longboard", "Walden Magic", 26, "longboard-WaldenMagic.jpg"));
            AddProduct(new ProductModel("SUP", "Naish One", 27, "SUP-NaishOne.jpg"));
            AddProduct(new ProductModel("SUP", "Six Tourer", 28, "SUP-SixTourer.jpg"));
            AddProduct(new ProductModel("SUP", "Naish Maliko", 29, "SUP-NaishMaliko.jpg"));
        }

        /// <summary>
        /// Adds a product to the storage.
        /// </summary>
        /// <param name="productModel">The <see cref="ProductModel"/> type to be added.</param>
        private void AddProduct(ProductModel productModel)
        {
            if (!Products.Any(p => p.Sku == productModel.Sku))
            {
                Products.Add(productModel);
            }
        }
    }
}



