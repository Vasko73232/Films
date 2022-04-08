namespace Films.Core.Domain.SharedKernel.Model;

public interface IKey<TEntity>
{
    TEntity New();
}