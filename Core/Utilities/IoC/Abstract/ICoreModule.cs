using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IoC.Abstract
{
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
