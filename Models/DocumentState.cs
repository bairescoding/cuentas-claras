using System;
using System.Collections.Generic;

namespace CuentasClaras.Models;

public record DocumentState
{
    public DateTime LastModifiedAt { get; init; } = DateTime.UtcNow;
    public List<Transaction> Transactions { get; init; } = new();
    public List<Category> Categories { get; init; } = new();
    public List<Account> Accounts { get; init; } = new();
}

public record Category(string Id, string Name, string Icon);
public record Account(string Id, string Name, decimal InitialBalance = 0);
