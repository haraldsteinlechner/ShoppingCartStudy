/// <summary>Prints a receipt for a cart. Kept separate from the cart (single responsibility).</summary>
public static class ReceiptPrinter {
  public static void Print(Cart cart) {
    decimal sum = 0;
    foreach (var i in cart.Items) {
      var line = Math.Round(i.Price * i.Qty, 2);   // round for display
      Console.WriteLine($"{i.Name,-8} {i.Qty,2} × {i.Price,6:F2} = {line,8:F2}");
      sum += line;
    }
    if (cart.Credit > 0) {
      Console.WriteLine($"{"Voucher",-23}{-cart.Credit,8:F2}");
      sum -= cart.Credit;
    }
    Console.WriteLine(new string(' ', 23) + "--------");
    Console.WriteLine($"{"Total",-23}{sum,8:F2}");
  }
}
