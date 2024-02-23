namespace POS
{
    public static class SaleCalculator
    {
        //public static List<(double Quantity, double Cost)> CalculateSaleQuantities(int productId, double quantityToSell, AppDbContext dbContext)
        //{
        //    List<(double Quantity, double Cost)> saleQuantities = new List<(double Quantity, double Cost)>();

        //    double quantityLeftToSell = quantityToSell;

        //    var soldCount = dbContext.SaleProducts.Where(s => s.ProductId == productId).Count();
        //    // Retrieve purchase history for the given product
        //    var purchaseHistory = dbContext.PurchaseProducts.Where(p => p.ProductId == productId).ToList();

        //    // Remove already sold items from purchase history
        //    foreach (var purchase in dbContext.SaleProducts.Where(s => s.ProductId == productId))
        //    {
        //        var correspondingPurchase = purchaseHistory.FirstOrDefault(p => p.Id == purchase.PurchaseProductId);
        //        if (correspondingPurchase != null)
        //        {
        //            if (purchase.Quantity >= correspondingPurchase.Quantity)
        //            {
        //                purchaseHistory.Remove(correspondingPurchase);
        //            }
        //            else
        //            {
        //                correspondingPurchase.Quantity -= purchase.Quantity;
        //            }
        //        }
        //    }

        //    foreach (var purchase in purchaseHistory.OrderBy(p => p.Date))
        //    {
        //        double quantityFromThisPurchase = Math.Min(quantityLeftToSell, purchase.Quantity);
        //        quantityLeftToSell -= quantityFromThisPurchase;

        //        if (quantityFromThisPurchase > 0)
        //        {
        //            saleQuantities.Add((quantityFromThisPurchase, purchase.PurchasePrice));
        //        }

        //        if (quantityLeftToSell <= 0)
        //        {
        //            break;
        //        }
        //    }

        //    return saleQuantities;
        //}

    }
}
