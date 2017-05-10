using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix.Framework.Interfaces
{
    public interface IEventService
    {
        Task<List<string>> Members(string roomId);
    }
}
