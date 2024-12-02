class Order
{
    public List<OrderItem> Items { get; set; }
    public int PaymentMethod { get; set; }
    public int ShippingMethod { get; set; }
    public double ShippingCost { get; set; }
    public double TotalCost { get; set; }
}