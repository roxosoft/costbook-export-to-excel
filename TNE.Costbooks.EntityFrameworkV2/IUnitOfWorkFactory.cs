namespace TNE.Domain;

public interface IUnitOfWorkFactory
{
    IUnitOfWork Create();
}