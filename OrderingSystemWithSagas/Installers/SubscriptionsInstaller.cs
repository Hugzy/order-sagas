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
                typeof(OrderPlaced),
                typeof(OrderCreated),
                typeof(OrderPayment),
                typeof(OrderReadyForExport),
            };

            var bus = container.Resolve<IBus>();

            Task.WaitAll(eventTypes.Select(type => bus.Subscribe(type)).ToArray());
        }
    }
}