using System.Threading.Tasks;

namespace TinTucCTSV.Data.Interfaces
{
    public interface IEmail
    {
      Task SendEmailAsync(string email, string subject, string message);
    }
}