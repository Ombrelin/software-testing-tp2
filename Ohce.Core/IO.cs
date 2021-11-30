using System.Threading.Tasks;

namespace Ohce
{
    public interface IO
    {
        Task OutPutStringAsync(string outPut);
        Task<string> GetInputStringAsync();
        Task HandleExitAsync();
    }
}