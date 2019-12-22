using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Interfaces;

namespace Test
{
    public class MyMessage : IWindow
    {
        public string Message { get; set; }
        public bool CloseFlag { get; set; }
        public bool ShowFlag { get; set; }

        public MyMessage()
        {
            Message = "";
            CloseFlag = false;
            ShowFlag = false;
        }

        public void Close()
        {
            CloseFlag = true;
        }

        public void Show()
        {
            ShowFlag = true;
        }

        public void ShowPopup(string message)
        {
            Message = message;
        }
    }

    [TestClass]
    public class ViewModelsTests
    {
        MainViewModel mainViewModel = new MainViewModel();

        private void SetMainViewModelFlags(MainViewModel vm)
        {
            vm.ColorCheck = false;
            vm.SizeCheck = false;
            vm.ProductLineCheck = false;
            vm.ClassCheck = false;
            vm.StyleCheck = false;
            vm.ProductSubcategoryCheck = false;
            vm.ProductModelCheck = false;
        }


        [TestMethod]
        public void MainViewModelCreatorTestMethod()
        {
            MainViewModel vm = new MainViewModel();
            Assert.IsNotNull(vm.DeleteProductCommand);
            Assert.IsNotNull(vm.ModifyProductCommand);
            Assert.IsNotNull(vm.AddProductCommand);
            Assert.IsNotNull(vm.ProductRepository);
        }

        [TestMethod]
        public void AddProductFailTest()
        {
            MyMessage myMessage = new MyMessage();
            MainViewModel vm = new MainViewModel();
            vm.MainWindow = myMessage;
            vm.AddProductCommand.Execute(null);
            Assert.IsNotNull(myMessage.Message);
        }

        [TestMethod]
        public void AddProductSuccessTest()
        {
            int changeCounter = 0;
            MyMessage myMessage = new MyMessage();
            MainViewModel vm = new MainViewModel();
            vm.ProductRepository.ChangeInCollection += () => changeCounter++;
            vm.MainWindow = myMessage;
            SetMainViewModelFlags(vm);
            vm.Name = "product test";
            vm.ProductNumber = "XYZ-123123";
            vm.MakeFlag = false;
            vm.FinishedGoodsFlag = false;
            vm.SafetyStockLevel = 1;
            vm.ReorderPoint = 2;
            vm.StandardCost = 12;
            vm.ListPrice = 12;
            vm.DaysToManufacture = 2;
            vm.SellEndDate = DateTime.Now;
            vm.SellEndDateCheck = false;
            vm.DiscontinuedDateCheck = false;
            vm.AddProductCommand.Execute(null);
            Product addedProduct = vm.Products.Last();
            Assert.AreEqual("Add success", myMessage.Message);
            Assert.AreEqual(12, addedProduct.ListPrice);
            Assert.AreEqual(1, changeCounter);
        }

        [TestMethod]
        public void ModifyProductFailTest()
        {
            MyMessage myMessage = new MyMessage();
            MainViewModel vm = new MainViewModel();
            vm.MainWindow = myMessage;
            vm.Product = new Product();
            vm.ModifyProductCommand.Execute(null);
            Assert.AreNotEqual("", myMessage.Message);
        }

        [TestMethod]
        public void ModifyProductSuccessTest()
        {
            MyMessage myMessage = new MyMessage();
            MainViewModel vm = new MainViewModel();
            vm.MainWindow = myMessage;
            vm.Product = vm.Products.Last();
            vm.ProductNumber = "test";
            vm.ModifyProductCommand.Execute(null);
            Assert.AreEqual("test", vm.Products.Last().ProductNumber);
            Assert.AreEqual("Product modified succefully!", myMessage.Message);

        }


        [TestMethod]
        public void DeleteProducNotSelectedFailTest()
        {
            MyMessage myMessage = new MyMessage();
            MainViewModel vm = new MainViewModel();
            vm.MainWindow = myMessage;
            vm.Product = new Product();
            vm.DeleteProductCommand.Execute(null);
            Assert.AreEqual("please, Select a product", myMessage.Message);
        }

        [TestMethod]
        public void DeleteProductFailTest()
        {
            MyMessage myMessage = new MyMessage();
            MainViewModel vm = new MainViewModel();
            vm.MainWindow = myMessage;
            vm.Product = new Product();
            vm.Product.ProductID = 9999999;
            vm.DeleteProductCommand.Execute(null);
            Assert.AreEqual("Delete failed", myMessage.Message);
        }

        [TestMethod]
        public void DeleteProductSuccessTest()
        {
            MyMessage myMessage = new MyMessage();
            MainViewModel vm = new MainViewModel();
            vm.MainWindow = myMessage;
            vm.Product = vm.Products.Last();
            vm.DeleteProductCommand.Execute(null);
            Assert.AreEqual("Delete success", myMessage.Message);
        }
    }
}
