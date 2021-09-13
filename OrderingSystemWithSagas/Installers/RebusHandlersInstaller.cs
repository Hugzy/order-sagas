using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using OrderingSystemWithSagas.Orders;
using Rebus.CastleWindsor;

namespace OrderingSystemWithSagas.Installers
{
    public class RebusHandlersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.RegisterHandler<OrderSaga>();
            container.RegisterHandler<PaymentReadyHandler>();
            container.RegisterHandler<PayOrderEventHandler>();
            container.RegisterHandler<ExportOrderHandler>();
        }
    }
}