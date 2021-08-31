using System;
using System.Threading.Tasks;
using Rebus.Activation;
using Rebus.Config;
using Rebus.Handlers;
using Rebus.Routing.TypeBased;
using Rebus.Sagas;

namespace RebusTest.Rebus
{
    public class LegalInfoAcquiredInFirstSystem
    {
        public string CorrId { get; set; }

    }

    public class LegalInfoAcquiredInSecondSystem
    {
        public string CorrId { get; set; }

    }
    
    public class CollectLegalInfoSagaData : ISagaData
    {
        public Guid Id { get; set; }
        public int Revision { get; set; }
        
        public string CrmCustomerId { get; set; }
        public bool GotLegalInfoFromFirstSystem { get; set; }
        public bool GotLegalInfoFromSecondSystem { get; set; }
    }

    public class CollectLegalInfoSaga : Saga<CollectLegalInfoSagaData>,
        IAmInitiatedBy<CustomerCreated>,
        IHandleMessages<LegalInfoAcquiredInFirstSystem>,
        IHandleMessages<LegalInfoAcquiredInSecondSystem>
    {
        protected override void CorrelateMessages(ICorrelationConfig<CollectLegalInfoSagaData> config)
        {
            // ensure idempotency by setting up correlation for this one in addition to
            // allowing CustomerCreated to initiate a new saga instance
            config.Correlate<CustomerCreated>(m => m.CustomerId, d => d.CrmCustomerId);
            // ensure proper correlation for the other messages
            config.Correlate<LegalInfoAcquiredInFirstSystem>(m => m.CorrId, d => d.CrmCustomerId);
            config.Correlate<LegalInfoAcquiredInSecondSystem>(m => m.CorrId, d => d.CrmCustomerId);
        }

        public async Task Handle(CustomerCreated message)
        {
            if (!IsNew) return;
        }

        public Task Handle(LegalInfoAcquiredInFirstSystem message)
        {
            throw new NotImplementedException();
        }

        public Task Handle(LegalInfoAcquiredInSecondSystem message)
        {
            throw new NotImplementedException();
        }
    }

    public class CustomerCreated
    {
        public string CustomerId { get; set; }
    }
    
    public class SagaBaseFuckery : IRunnable
    {

        
        private void DoConfigure()
        {
            
        }
        
        public async Task Start()
        {
            using var activator = new BuiltinHandlerActivator();
            var bus = activator.Bus;
           
            Configure.With(activator)
                .Routing(r => r.TypeBased()
                    .MapAssemblyOf<CustomerCreated>("crm.input"));
            
            await bus.Subscribe<CustomerCreated>();
            
            
        }
    }


}