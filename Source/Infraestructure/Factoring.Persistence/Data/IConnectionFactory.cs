using System.Data;

namespace Factoring.Persistence.Data
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
