using Entities;
using System.Threading.Tasks;

namespace BL
{
    public interface IRatingBL
    {
       public Task AddToContext(Rating rating);        
    }
}