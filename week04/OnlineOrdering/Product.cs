public class Product
{
    private string _productName;
    private int _productId;
    private double _price;
    private int _quantity;

    public Product(string productName, int productId, int price, int quantity)
    {
        _productName = productName;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }
    
    public string GetProductName()
    {
        return _productName;
    }
    public int GetProductId()
    {
        return _productId;
    }
    public double GetPrice()
    {
        return _price;
    }
    public int GetQuantity()
    {
        return _quantity;
    }
}