/// <summary>A shopping cart. Items are encapsulated; callers get a read-only view.</summary>
public class Cart {
  readonly List<Item> items = new();

  public IReadOnlyList<Item> Items => items;

  /// <summary>Voucher credit that is deducted from the total.</summary>
  public decimal Credit { get; private set; }

  /// <summary>Date of the invoice, once the cart has been invoiced.</summary>
  public DateTime? InvoicedOn { get; private set; }

  /// <summary>Adds an item. The same product (name and price) is merged into one line.</summary>
  public void Add(Item item) {
    var existing = items.Find(x => x.Name == item.Name && x.Price == item.Price);
    if (existing != null) existing.Qty += item.Qty;
    else items.Add(item);
  }

  /// <summary>Applies a discount strategy to this cart.</summary>
  public void Apply(IDiscount discount) => discount.ApplyTo(this);

  public void AddCredit(decimal amount) => Credit += amount;

  public void Invoice() => InvoicedOn = DateTime.Today;

  public decimal Total => items.Sum(i => i.Price * i.Qty) - Credit;
}
