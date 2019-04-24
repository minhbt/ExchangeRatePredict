using System;
using System.Net;
using System.Threading.Tasks;

namespace OnSolve.EP.Repositories.Interfaces.RestAPI
{
    public interface IRepository
    {
        Task AddAsync<T>(T entity, string requestUri);
        Task<HttpStatusCode> DeleteAsync(string requestUri);
        Task EditAsync<T>(T t, string requestUri);
        Task<T> GetAsync<T>(string path);
    }

}
