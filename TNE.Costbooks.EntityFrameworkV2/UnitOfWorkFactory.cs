using Microsoft.Extensions.DependencyInjection;
using TNE.Domain;
using TNE.Domain.EntityFrameworkV2;

namespace TNE.Costbooks.EntityFrameworkV2;

public class UnitOfWorkFactory : IUnitOfWorkFactory
{
    private readonly IServiceProvider _serviceProvider;

    public UnitOfWorkFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IUnitOfWork Create()
    {
        var uow = _serviceProvider.GetRequiredService<UnitOfWork>();

        return uow;
    }
}