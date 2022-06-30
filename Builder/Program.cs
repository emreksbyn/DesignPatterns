using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDirector director1 = new ProductDirector();
            var builder1 = new OldCustomerProductBuilder();
            director1.GenerateProduct(builder1);
            var model1 = builder1.GetModel();
            Console.WriteLine(model1.Id);
            Console.WriteLine(model1.ProductName);
            Console.WriteLine(model1.CategoryName);
            Console.WriteLine(model1.UnitPrice);
            Console.WriteLine(model1.DiscountApplied);
            Console.WriteLine(model1.DiscountedPrice);

            //Console.WriteLine("----------------------------");

            //ProductDirector director2 = new ProductDirector();
            //var builder2 = new OldCustomerProductBuilder();
            //director2.GenerateProduct(builder2);
            //var model2 = builder1.GetModel();
            //Console.WriteLine(model2.Id);
            //Console.WriteLine(model2.ProductName);
            //Console.WriteLine(model2.CategoryName);
            //Console.WriteLine(model2.UnitPrice);
            //Console.WriteLine(model2.DiscountApplied);
            //Console.WriteLine(model2.DiscountedPrice);
            Console.ReadLine();
        }
    }

    class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }

    abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetModel();
    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }

        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice * (decimal)0.90;
            model.DiscountApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }
    }

    class OldCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }
        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice;
            model.DiscountApplied = false;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }
    }

    class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}