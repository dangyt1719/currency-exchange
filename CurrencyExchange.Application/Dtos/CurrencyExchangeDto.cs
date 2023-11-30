using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Application.Dtos;
public record CurrencyExchangeDto
{
    public Guid UserId { get; set; }
    public Guid AccountId { get; set; }
    public decimal Amount { get; set; }
    public decimal Rate { get; set; }
    [DefaultValue(0.05)]
    public decimal Сommission { get; set; }

    public CurrencyExchangeDto(Guid userId, Guid accountId, decimal amount, decimal rate)
    {
        UserId = userId;
        AccountId = accountId;
        Amount = amount;
        Rate = rate;
    }
}
