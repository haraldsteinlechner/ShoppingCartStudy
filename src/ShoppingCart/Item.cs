/// <summary>A product line in a shopping cart: name, unit price and quantity.</summary>
public class Item(string name, decimal price, int qty) {
  public string Name { get; } = name;
  public decimal Price { get; private set; } = price;
  public int Qty { get; set; } = qty;

  /// <summary>Reduces the unit price by the given fraction (0.10 = 10 %).</summary>
  public void Discount(decimal fraction) => Price *= 1 - fraction;
}
