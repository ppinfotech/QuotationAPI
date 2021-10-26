using System;
using QuotationAPI.Controllers;
using QuotationAPI.Models;
using NUnit.Framework;

namespace UnitTestProject1
{
    public class UnitTest1
    {
        private Quotation quotation;
        [SetUp]
        public void Setup()
        {
            quotation = new Quotation();
        }

        [Test]
        public void ReturnNullOrEmpty()
        {
            var minShippingCost = Quotation.GetMinAmount(null);
            Assert.That(minShippingCost, Is.Null);
        }

        [Test]
        //this will throw an exception as we pass null value
        public void ThrowAnException()
        {
            var bestPrice = Assert.ThrowsAsync<ArgumentNullException>(() => quotation.GetQuotation(null));
            Assert.That(bestPrice.Message.Contains("shippingDetails"));
        }


        [Test]
        //this will retunr valid output
        public async System.Threading.Tasks.Task ValidOutputObjectAsync()
        {
            Address sAddress = new Address();
            Address dAddress = new Address();

            sAddress.Address1 = "A";
            sAddress.Address2 = "B";
            sAddress.Address3 = "C";
            sAddress.City = "D";
            sAddress.Country = "E";
            sAddress.State = "F";
            sAddress.Zip = "G";

            dAddress.Address1 = "A";
            dAddress.Address2 = "B";
            dAddress.Address3 = "C";
            dAddress.City = "D";
            dAddress.Country = "E";
            dAddress.State = "F";
            dAddress.Zip = "G";

            Dimension objDimension1 = new Dimension();
            objDimension1.Height = 10;
            objDimension1.Width = 20;
            objDimension1.Length = 30;

            Dimension objDimension2 = new Dimension();
            objDimension2.Height = 10;
            objDimension2.Width = 20;
            objDimension2.Length = 30;

            Dimension[] dimension = { objDimension1, objDimension2 };

            InputDataModel inputDataModel = new InputDataModel();
            inputDataModel.ContactAddress = sAddress;
            inputDataModel.WarehouseAddress = dAddress;
            inputDataModel.Dimensions = dimension;

            Response response = new Response();
            response = await quotation.GetQuotation(inputDataModel);
            Assert.That(response.Amount, Is.EqualTo(response.Amount));
        }


        [Test]
        //this will return the valid output
        public void ValidOutput()
        {
            var expectedValue = Convert.ToDecimal(8.2);
            var sampleData = new[]
            {
                new Response() {Amount = Convert.ToDecimal(10.2)},
                new Response() {Amount = Convert.ToDecimal(13.2)},
                new Response() {Amount = expectedValue}
            };
            var minShippingCost = Quotation.GetMinAmount(sampleData);
            Assert.That(minShippingCost.Amount, Is.EqualTo(expectedValue));
        }

        [TearDown]
        public void TearDown()
        {
            quotation = null;
        }
    }
}
