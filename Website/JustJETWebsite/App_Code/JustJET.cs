using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Data;
using Company.BusinessLogicLayer;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "JustJET" in code, svc and config file together.
namespace Company
{
    public class JustJET : IJustJET
    {
        public DataSet GetPayment()
        {
            BLLPaymentCatalog bizLayerPayment = new BLLPaymentCatalog();
            return bizLayerPayment.GetPayment();
        }

        public DataSet GetPaymentDetails(int Payment_Id)
        {
            BLLPaymentCatalog bizLayerPayment = new BLLPaymentCatalog();
            return bizLayerPayment.GetPaymentDetails(Payment_Id);
        }
    }
}
