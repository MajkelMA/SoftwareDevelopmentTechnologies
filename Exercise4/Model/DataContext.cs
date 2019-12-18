using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DataContext : IDataContext<Product>
    {
        private readonly TablesDataContext tables;

        //public DataContext(TablesDataContext tables)
        //{
        //    this.tables = tables;
        //}

        public DataContext()
        {
            this.tables = new TablesDataContext();
        }

        public bool Add(Product item)
        {
            try
            {
                tables.GetTable<Product>().InsertOnSubmit(item);
                tables.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Product item)
        {
            try
            {
                tables.GetTable<Product>().DeleteOnSubmit(item);
                tables.SubmitChanges(ConflictMode.ContinueOnConflict);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Product Get(int id)
        {
            return (from product in tables.GetTable<Product>()
                    where product.ProductID == id
                    select product).First();
        }

        public IQueryable<Product> GetItems()
        {
            throw new NotImplementedException();
        }

        public IQueryable<P> GetItems<P>() where P : class
        {
            return tables.GetTable<P>();
        }

        //public IQueryable GetItems<T>()
        //{
        //    throw new NotImplementedException();
        //}

        //public IQueryable GetItems<P>() where P : class
        //{
        //    return tables.GetTable<P>();
        //}

        public bool Update(Product item)
        {
            try
            {
                Product productToUpdate = tables.GetTable<Product>().Where(p => p.ProductID == item.ProductID).First();
                productToUpdate.Name = item.Name;
                productToUpdate.ProductNumber = item.ProductNumber;
                productToUpdate.Color = item.Color;
                productToUpdate.SafetyStockLevel = item.SafetyStockLevel;
                productToUpdate.ReorderPoint = item.ReorderPoint;
                productToUpdate.StandardCost = item.StandardCost;
                productToUpdate.ListPrice = item.ListPrice;
                productToUpdate.Size = item.Size;
                productToUpdate.SizeUnitMeasureCode = item.SizeUnitMeasureCode;
                productToUpdate.WeightUnitMeasureCode = item.WeightUnitMeasureCode;
                productToUpdate.Weight = item.Weight;
                productToUpdate.DaysToManufacture = item.DaysToManufacture;
                productToUpdate.ProductLine = item.ProductLine;
                productToUpdate.Class = item.Class;
                productToUpdate.Style = item.Style;
                productToUpdate.ProductSubcategoryID = item.ProductSubcategoryID;
                productToUpdate.SellStartDate = item.SellStartDate;
                productToUpdate.ProductModelID = item.ProductModelID;
                productToUpdate.SellStartDate = item.SellStartDate;
                productToUpdate.SellEndDate = item.SellEndDate;
                productToUpdate.DiscontinuedDate = item.DiscontinuedDate;
                productToUpdate.ModifiedDate = item.ModifiedDate;
                tables.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
