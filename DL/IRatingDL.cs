using Entities;
using System.Threading.Tasks;

namespace DL
{
    public interface IRatingDL
    {
        public Task AddToContext(Rating rating);
    }
}