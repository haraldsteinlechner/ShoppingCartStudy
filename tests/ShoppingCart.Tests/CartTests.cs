public class CartTests {
  [Fact]
  public void Total_is_the_sum_of_all_lines() {
    var cart = new Cart();
    cart.Add(new Item("Apple", 1.00m, 3));
    cart.Add(new Item("Pear", 2.50m, 2));
    Assert.Equal(8.00m, cart.Total);
  }

  [Fact]
  public void Same_product_is_merged_into_one_line() {
    var cart = new Cart();
    cart.Add(new Item("Apple", 1.00m, 2));
    cart.Add(new Item("Apple", 1.00m, 1));
    Assert.Single(cart.Items);
    Assert.Equal(3, cart.Items[0].Qty);
  }
}

public class DiscountTests {
  [Fact]
  public void Percent_off_reduces_the_total() {
    var cart = new Cart();
    cart.Add(new Item("TV", 100m, 1));
    cart.Apply(new PercentOff(0.10m));
    Assert.Equal(90m, cart.Total);
  }

  [Fact]
  public void Voucher_reduces_the_total() {
    var cart = new Cart();
    cart.Add(new Item("TV", 100m, 1));
    cart.Apply(new Voucher(5m));
    Assert.Equal(95m, cart.Total);
  }
}

public class SkontoTests {
  [Fact]
  public void Skonto_applies_right_after_invoicing() {
    var cart = new Cart();
    cart.Add(new Item("Laptop", 1000m, 1));
    cart.Invoice();
    Assert.Equal(980m, new Skonto(0.02m, 10).AmountDue(cart));
  }
}
