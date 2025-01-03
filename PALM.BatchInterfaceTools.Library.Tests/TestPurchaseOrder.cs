using PALM.BatchInterfaceTools.Library.Constants;
using PALM.BatchInterfaceTools.Library.Entities.PurchaseOrders.InboundEncumbranceLoad;
using PALM.BatchInterfaceTools.Library.Extensions;
using System.Text;

namespace Test.PALM.BatchInterfaceTools.Library
{
    public class TestPurchaseOrder
    {
        [Fact]
        public void TestInboundEncumbranceLoad()
        {
            IEnumerable<POHeaderDetails> purchaseOrders = CreateMockInboundEncumbranceLoad();
            StringBuilder sb = purchaseOrders.WriteRecordsToStringBuilder();

            Assert.True(sb.Length > 0);
        }

        #region Mock Data
        private IEnumerable<POHeaderDetails> CreateMockInboundEncumbranceLoad()
        {
            List<POHeaderDetails> inboundEncumbranceLoad = new();
            inboundEncumbranceLoad.Add(CreateMockPOHeaderDetails());
            inboundEncumbranceLoad.Add(CreateMockPOHeaderDetails());

            return inboundEncumbranceLoad;
        }

        private POHeaderDetails CreateMockPOHeaderDetails()
        {
            POHeaderDetails poHeaderDetails = new();
            poHeaderDetails.POHeaderAction = PurchaseOrdersConstants.POHeaderActionValues.ADD;
            poHeaderDetails.BusinessUnit = "55000";
            poHeaderDetails.POID = "NEXT";
            poHeaderDetails.PODate = new DateOnly(2024, 12, 25);

            poHeaderDetails.POLines.Add(CreateMockPOLineDetails());
            poHeaderDetails.POLines.Add(CreateMockPOLineDetails());

            return poHeaderDetails;
        }
        private POLineDetails CreateMockPOLineDetails()
        {
            POLineDetails poLineDetails = new();
            poLineDetails.POLineAction = PurchaseOrdersConstants.POLineActionValues.ADD;
            poLineDetails.LineNumber = new Random().Next(1, 999);

            poLineDetails.POLineShipDetails = CreateMockPOLineShipDetails();
            poLineDetails.PODistributionDetails.Add(CreateMockPODistributionDetails());
            poLineDetails.PODistributionDetails.Add(CreateMockPODistributionDetails());

            return poLineDetails;
        }
        private POLineShipDetails CreateMockPOLineShipDetails()
        {
            POLineShipDetails poLineShipDetails = new();
            poLineShipDetails.POQuantity = 1.01m;
            poLineShipDetails.POTotalLineAmount = 100.01m;

            return poLineShipDetails;
        }
        private PODistributionDetails CreateMockPODistributionDetails()
        {
            PODistributionDetails poDistributionDetails = new();
            poDistributionDetails.PODistributionAction = PurchaseOrdersConstants.PODistributionActionValues.ADD; 
            poDistributionDetails.DistributionLineNumber = new Random().Next(1, 999);
            poDistributionDetails.Organization = "5512345678";
            poDistributionDetails.Account = "123456";
            poDistributionDetails.Fund = "12345";
            poDistributionDetails.BudgetEntity = "12345678";
            poDistributionDetails.Category = "123456";
            poDistributionDetails.StateProgram = "";

            return poDistributionDetails;
        }
        #endregion
    }
}