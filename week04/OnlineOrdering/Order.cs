public class Order
{
    
    private List<Product> _products;
    private Customer _customer;
    private double _shippingCost;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
        _shippingCost = (double)(_customer.GetAddress().IsInUSA() ? 5m : 35m);
    }
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
    public double CalculateTotalCost()
    {
        double totalProductCost = 0;
        foreach (Product product in _products)
        {
            totalProductCost += product.GetPrice() * product.GetQuantity();
        }
        return totalProductCost + _shippingCost;
    }
    public string PackingLabel()
    {
        string label = $"Packing Label: \n";
        foreach (Product product in _products)
        {
            label += $"Product Name: {product.GetProductName()}, \nProduct ID: {product.GetProductId()}, \nQuantity: {product.GetQuantity()}\n";
        }
        return label.Trim();
    }

    public string ShippingLabel()
    {
        
        return $"Shipping Label:\nName: {_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }

}