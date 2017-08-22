using System;
using System.Threading.Tasks;

namespace dtu.blognet.Core.Query
{
    public interface IQueryHandler<in TQuery, TResponse> where TQuery : IQuery<TResponse>
    {
        TResponse Get();
        Task<TResponse> GetAsync();
    }
}
