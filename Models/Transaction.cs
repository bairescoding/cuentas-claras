using System;

namespace CuentasClaras.Models;

public record Transaction
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Description { get; init; } = string.Empty;
    public decimal Amount { get; init; }
    public TransactionType Type { get; init; }
    public DateTime Date { get; init; } = DateTime.UtcNow;
    public string CategoryId { get; init; } = string.Empty;
    public string AccountId { get; init; } = string.Empty;
}

public enum TransactionType
{
    Income,
    Expense
}
