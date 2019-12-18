using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Interfaces;

namespace Test
{
    public class MyMessage : IMyPopup
    {
        public string Message { get; set; }
        public void ShowPopup(string message)
        {
            Message = message;
        }
    }

    [TestClass]
    public class ViewModelsTests
    {
        MainViewModel mainViewModel = new MainViewModel();
    
        [TestMethod]
        public void MainViewModelCreatorTestMethod()
        {
            MainViewModel vm = new MainViewModel();
            Assert.IsNotNull(vm.DeleteProductCommand);
            Assert.IsNotNull(vm.ModifyProductCommand);
            Assert.IsNotNull(vm.AddProductCommand);
            Assert.IsNotNull(vm.ProductRepostiory);
        }

        [TestMethod]
        public void AddProductViewModelTest()
        {
            MainViewModel vm = new MainViewModel();
            AddProductViewModel addProductViewModel = new AddProductViewModel(vm.ProductRepostiory, new MyMessage());
            Assert.IsNotNull(addProductViewModel.ValidatorPopup);
            Assert.IsNotNull(addProductViewModel.AddProductCommand);
            Assert.IsNotNull(addProductViewModel.BackToMainWindowCommand);          
        }

        [TestMethod]
        public void ModifyProductViewModelTest()
        {
            MyMessage myMessage = new MyMessage();
            MainViewModel vm = new MainViewModel();
            vm.Product = vm.Products.Last();
            ModifyProductViewModel modifyProductViewModel = new ModifyProductViewModel(vm.Product, myMessage);
            Assert.IsNotNull(modifyProductViewModel.ValidatorPopup);
            Assert.IsNotNull(modifyProductViewModel.BackToMainWindowCommand);
            Assert.IsNotNull(modifyProductViewModel.ModifyProductCommand);
        }

        [TestMethod]
        public void AddProductFailTest()
        {
            MyMessage myMessage = new MyMessage();
            MainViewModel vm = new MainViewModel();
            AddProductViewModel addProductViewModel = new AddProductViewModel(vm.ProductRepostiory, myMessage);
            addProductViewModel.AddProductCommand.Execute(null);
            Assert.IsNotNull(myMessage.Message);
        }

        [TestMethod]
        public void AddProductSuccessTest()
        {
            MyMessage myMessage = new MyMessage();
            MainViewModel vm = new MainViewModel();
            AddProductViewModel addProductViewModel = new AddProductViewModel(vm.ProductRepostiory, myMessage);
            addProductViewModel.CloseWindow = () => { };
            addProductViewModel.Name = "Testowy";
            addProductViewModel.ProductNumber = "TX-1111";
            addProductViewModel.MakeFlag = true;
            addProductViewModel.FinishedGoodsFlag = true;
            addProductViewModel.Color = null;
            addProductViewModel.SafetyStockLevel = 100;
            addProductViewModel.ReorderPoint = 100;
            addProductViewModel.StandardCost = 100;
            addProductViewModel.ListPrice = 100;
            addProductViewModel.Size = "S";
            addProductViewModel.SizeUnitMeasureCode = "CM";
            addProductViewModel.WeightUnitMeasureCode = "LB";
            addProductViewModel.Weight = 100;
            addProductViewModel.DaysToManufacture = 100;
            addProductViewModel.ProductLine = "M";
            addProductViewModel.Class = "H";
            addProductViewModel.Style = "M";
            addProductViewModel.ProductSubcategoryCheck = false;
            addProductViewModel.ProductModelCheck = false;
            addProductViewModel.SellStartDate = DateTime.Today;
            addProductViewModel.SellEndDate = DateTime.Today.AddDays(1);
            addProductViewModel.ModifiedDate = DateTime.Today;
            addProductViewModel.AddProductCommand.Execute("Product added succefully!");
            Assert.AreEqual("Product added succefully!", myMessage.Message);
        }

        [TestMethod]
        public void ModifyProductFailTest()
        {
            MyMessage myMessage = new MyMessage();
            ModifyProductViewModel modifyProductViewModel = new ModifyProductViewModel(new Model.Product(), myMessage);
            modifyProductViewModel.ModifyProductCommand.Execute(null);
            Assert.IsNotNull(myMessage.Message);
        }

        [TestMethod]
        public void ModifyProductSuccessTest()
        {
            MyMessage myMessage = new MyMessage();
            MainViewModel vm = new MainViewModel();
            vm.Product = vm.Products.Last();
            ModifyProductViewModel modifyProductViewModel = new ModifyProductViewModel(vm.Product, myMessage);
            modifyProductViewModel.Product.Weight = 101;
            modifyProductViewModel.ClassCheck = false;
            modifyProductViewModel.ColorCheck = false;
          
            modifyProductViewModel.BackToMainWindowCommand.Execute(null);

        }
        [TestMethod]
        public void DeleteProductTest()
        {
            MainViewModel vm = new MainViewModel();
            int size = vm.Products.Count();
            vm.Product = vm.Products.Last();
            vm.DeleteProductCommand.Execute(null);
            Assert.AreEqual(size - 1, vm.Products.Count());
        }
    }
}
