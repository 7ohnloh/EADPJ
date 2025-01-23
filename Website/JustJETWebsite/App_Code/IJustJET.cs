using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IJustJET" in both code and config file together.
namespace Company
{
    [ServiceContract]
    public interface IJustJET
    {
        [OperationContract]
        DataSet GetPayment();

        [OperationContract]
        DataSet GetPaymentDetails(int Payment);
    }
}
