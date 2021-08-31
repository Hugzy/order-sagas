using System.Threading.Tasks;

namespace RebusTest.Rebus
{
    public interface IRunnable
    {
        public Task Start();
    }
}