using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualBasic;

namespace NETPROJECT
{
    public class Category
    {
        public int Id { get; set; }
        public int SubCategoryId { get; set; }
        public Category SubCategory { get; set; }
        
        public int ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }

        public string Name { get; set; }

        public Category(int id, int subCategoryId, string name, List<Order> categoryOrders)
        {
            Id = id;
            SubCategoryId = subCategoryId;
            Name = name;
            CategoryOrders = categoryOrders;
        }
        
        public Category(Category category)
        {
            Id = category.Id;
            SubCategoryId = category.SubCategoryId;
            Name = category.Name;
            CategoryOrders = category.CategoryOrders;
        }

        public static Category operator ++(Category category)
        { 
	        Console.WriteLine("Викликаний унарний оператор інкременту для категорії");
	        
	        var newCategory = new Category
	        {
		        Id = category.Id,
		        Name = category.Name,
		        ParentCategoryId = category.ParentCategory.ParentCategoryId,
		        ParentCategory = category.ParentCategory.ParentCategory,
		        SubCategory = category.ParentCategory,
		        SubCategoryId = category.ParentCategoryId
	        };

	        return newCategory;
        }
        
        public Category()
        {
            Id = 0;
            SubCategoryId = 0;
            Name = "";
            CategoryOrders = new List<Order>();
        }

        public List<Order> CategoryOrders { get; }


    }
}