using System;
using Rebus.Sagas;

namespace OrderingSystemWithSagas.Orders
{
    public class OrderSagaData : ISagaData
    {
        public Guid Id { get; set; }
        public int Revision { get; set; }
        
        public int OrderId { get; set; }
        public bool ReceivedPayment { get; set; }
        public bool IsFailed { get; set; }
        public string Cause { get; set; }
        public bool IsReadyForExport { get; set; }
        public bool IsExported { get; set; }
        
    }
}