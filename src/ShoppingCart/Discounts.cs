/// <summary>
/// A discount strategy (strategy pattern): new kinds of discount are added as new classes,
/// the cart itself does not need to know them (open/closed principle).
/// </summary>
public interface IDiscount {
  void ApplyTo(Cart cart);
}

/// <summary>A percentage off every item, e.g. 0.10 = 10 %.</summary>
public class PercentOff(decimal percent) : IDiscount {
  public void ApplyTo(Cart cart) {
    foreach (var item in cart.Items) item.Discount(percent);
  }
}

/// <summary>A fixed amount off the cart, e.g. a 5.00 voucher.</summary>
public class Voucher(decimal amount) : IDiscount {
  public void ApplyTo(Cart cart) => cart.AddCredit(amount);
}
