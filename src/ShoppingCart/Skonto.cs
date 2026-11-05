/// <summary>Skonto: a percentage off if an invoice is paid within a number of days.</summary>
public class Skonto(decimal percent, int days) {
  public decimal AmountDue(Cart cart) {
    var daysSinceInvoice = (DateTime.Today - cart.InvoicedOn!.Value).Days;
    return daysSinceInvoice <= days ? cart.Total * (1 - percent) : cart.Total;
  }
}
