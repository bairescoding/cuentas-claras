using System;
using System.Linq;
using System.Threading.Tasks;
using CuentasClaras.Models;

namespace CuentasClaras.Services;

public class DocumentManager
{
    private readonly IStorageProvider _storageProvider;
    public DocumentState State { get; private set; } = new();

    public event Action? OnStateChanged;

    public DocumentManager(IStorageProvider storageProvider)
    {
        _storageProvider = storageProvider;
    }

    public async Task InitializeAsync()
    {
        State = await _storageProvider.LoadStateAsync();
        NotifyStateChanged();
    }

    public async Task AddTransactionAsync(Transaction transaction)
    {
        State.Transactions.Add(transaction);
        State = State with { LastModifiedAt = DateTime.UtcNow };
        await _storageProvider.SaveStateAsync(State);
        NotifyStateChanged();
    }

    public async Task DeleteTransactionAsync(Guid id)
    {
        var item = State.Transactions.FirstOrDefault(t => t.Id == id);
        if (item != null)
        {
            State.Transactions.Remove(item);
            State = State with { LastModifiedAt = DateTime.UtcNow };
            await _storageProvider.SaveStateAsync(State);
            NotifyStateChanged();
        }
    }

    public decimal GetTotalBalance() => 
        State.Transactions.Where(t => t.Type == TransactionType.Income).Sum(t => t.Amount) - 
        State.Transactions.Where(t => t.Type == TransactionType.Expense).Sum(t => t.Amount);

    public decimal GetIncome() => State.Transactions.Where(t => t.Type == TransactionType.Income).Sum(t => t.Amount);
    public decimal GetExpense() => State.Transactions.Where(t => t.Type == TransactionType.Expense).Sum(t => t.Amount);

    private void NotifyStateChanged() => OnStateChanged?.Invoke();
}
