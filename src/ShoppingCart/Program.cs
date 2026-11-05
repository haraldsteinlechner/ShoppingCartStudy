var cart = new Cart();
cart.Add(new Item("Apple", 1.00m, 3));
cart.Add(new Item("Pear", 2.50m, 2));
cart.Apply(new PercentOff(0.10m));
cart.Apply(new Voucher(2.00m));

ReceiptPrinter.Print(cart);

cart.Invoice();
var skonto = new Skonto(0.02m, 10);
Console.WriteLine();
Console.WriteLine($"Amount due with 2 % Skonto (within 10 days): {skonto.AmountDue(cart):F2}");
