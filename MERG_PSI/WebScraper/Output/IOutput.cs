using System.Threading.Tasks;

namespace WebScraper
{
    public interface IOutput
    {
        Task DoOutput(string jsonToOutput);
    }
}
