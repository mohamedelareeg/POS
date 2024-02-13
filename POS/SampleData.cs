using POS.Domain.Models;
using System.Collections.ObjectModel;

namespace POS
{
    public static class SampleData
    {
        public static ObservableCollection<Category> GenerateCategories()
        {
            ObservableCollection<Category> categories = new ObservableCollection<Category>();

            for (int i = 1; i <= 5; i++)
            {
                Category category = new Category
                {
                    Id = i,
                    Name = $"Category {i}",
                    Type = $"Type {i}"
                };

                //category.Products = GenerateProducts(10, category);

                categories.Add(category);
            }

            return categories;
        }

        public static ObservableCollection<Product> GenerateProducts(int count, Category category)
        {
            ObservableCollection<Product> products = new ObservableCollection<Product>();

            for (int i = 1; i <= count; i++)
            {
                Product product = new Product
                {
                    Id = i,
                    Name = $"Product {category.Id}-{i}",  // Include category information in the product name
                    Category = category,
                    Quantity = i * 1.5,
                    Cost = i * 2.0,
                    Price = i * 2.5,
                    Type = $"Type {i}",
                    Barcode = $"Barcode {i}",
                    Earned = i * 0.5,
                    Datex = $"DateX {i}",
                    Datee = $"DateE {i}"
                };

                products.Add(product);
            }

            return products;
        }
    }
}
