# Shopping cart

A small shopping cart in C#, designed with classic object-oriented principles.

## Features

- Add items to a cart; the same product (name and price) is merged into one line
- Discounts: percentage off, vouchers
- Receipt printing
- Skonto for invoices (e.g. 2 % off if paid within 10 days)

## Design

| Concept | Where |
|---|---|
| Encapsulation: private state, read-only views, private setters | `Item`, `Cart` |
| Strategy pattern / open-closed principle: new discounts are new classes | `IDiscount`, `PercentOff`, `Voucher` |
| Single responsibility: printing is separate from the cart | `ReceiptPrinter` |

## Build, run, test

Requires the .NET 10 SDK.

```
dotnet run --project src/ShoppingCart
dotnet test
```

## Issues

Reports from production are tracked as [issues](../../issues).
