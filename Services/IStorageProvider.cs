using CuentasClaras.Models;
using System.Threading.Tasks;

namespace CuentasClaras.Services;

public interface IStorageProvider
{
    Task<DocumentState> LoadStateAsync();
    Task SaveStateAsync(DocumentState state);
}
