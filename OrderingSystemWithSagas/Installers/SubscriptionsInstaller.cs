using System.Linq;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Rebus.Bus;
using Shared.Events;

namespace OrderingSystemWithSagas.Installers
{
    public class SubscriptionsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var eventTypes = new[]
            {
                typeof(PlaceOrderEvent),
                typeof(OrderCreatedEvent),
                typeof(PayOrderEvent),
                typeof(OrderReadyForPaymentEvent),
                typeof(OrderFailedEvent),
                typeof(OrderReadyForExportEvent),
                typeof(OrderExportedEvent),
                typeof(OrderCanceledEvent),
                typeof(PaymentFailedEvent),
                typeof(PaymentSucceededEvent),
                typeof(ExportOrderEvent)
            };

            var bus = container.Resolve<IBus>();

            Task.WaitAll(eventTypes.Select(type => bus.Subscribe(type)).ToArray());
        }
    }
}