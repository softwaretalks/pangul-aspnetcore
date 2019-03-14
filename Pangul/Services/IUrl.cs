using System.Threading.Tasks;

namespace Pangul.Services
{
    public interface IUrl
    {
        Task<OperationResult> GetResponse();
    }
}