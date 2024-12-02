namespace EcommerceSystem;

public class EcommerceApp
{
    private readonly List<Product> _products = new List<Product>();
    private readonly List<Order> _orders = new List<Order>();
    private readonly List<OrderItem> _orderBasket = new List<OrderItem>();

    public void Run()
    {
        SeedProducts();

        Console.WriteLine("Welcome to the E-commerce System!");

        while (true)
        {
            Console.WriteLine("\n1. View Products");
            Console.WriteLine("2. Add Product to Basket");
            Console.WriteLine("3. View Basket");
            Console.WriteLine("4. Finalize Order");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
                
            var option = int.Parse(Console.ReadLine());
                
            switch (option)
            {
                case 1:
                    DisplayProducts();
                    break;
                case 2:
                    AddProductToBasket();
                    break;
                case 3:
                    ViewBasket();
                    break;
                case 4:
                    FinalizeOrder();
                    break;
                case 5:
                    Console.WriteLine("Thank you for using E-commerce System!");
                    return;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

    private void SeedProducts()
    {
        _products.Add(new Product("Laptop", "Electronics", 1000.00));
        _products.Add(new Product("Headphones", "Electronics", 150.00));
        _products.Add(new Product("Shirt", "Clothing", 30.00));
        _products.Add(new Product("Shoes", "Clothing", 70.00));
        _products.Add(new Product("Novel", "Books", 20.00));
        _products.Add(new Product("Cookbook", "Books", 25.00));
    }

    private void DisplayProducts()
    {
        Console.WriteLine("\nAvailable Products:");
        for (var i = 0; i < _products.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_products[i].Name} ({_products[i].Category}) - {_products[i].Price} €");
        }
    }

    private void AddProductToBasket()
    {
        DisplayProducts();
        Console.Write("Select a product by number: ");
        var productIndex = int.Parse(Console.ReadLine()) - 1;

        if (productIndex < 0 || productIndex >= _products.Count)
        {
            Console.WriteLine("Invalid product selection.");
            return;
        }

        Console.Write("Enter quantity: ");
        var quantity = int.Parse(Console.ReadLine());
        if (quantity < 1)
        {
            Console.WriteLine("Quantity must be at least 1.");
            return;
        }

        var selectedProduct = _products[productIndex];
        _orderBasket.Add(new OrderItem(selectedProduct, quantity));
        Console.WriteLine($"{quantity} x {selectedProduct.Name} added to basket.");
    }

    private void ViewBasket()
    {
        if (_orderBasket.Count == 0)
        {
            Console.WriteLine("\nYour basket is empty.");
            return;
        }

        Console.WriteLine("\nYour Basket:");
        double total = 0;
        foreach (var item in _orderBasket)
        {
            var itemTotal = item.Product.Price * item.Quantity;
            total += itemTotal;
            Console.WriteLine($"{item.Quantity} x {item.Product.Name} - {item.Product.Price} € each (Total: {itemTotal} €)");
        }
        Console.WriteLine($"Total: {total} €");
    }

    private void FinalizeOrder()
    {
        if (_orderBasket.Count == 0)
        {
            Console.WriteLine("\nYour basket is empty. Add items before finalizing the order.");
            return;
        }

        ViewBasket();

        // Payment Processing
        Console.WriteLine("\nChoose a payment method:");
        Console.WriteLine("1. Credit Card");
        Console.WriteLine("2. PayPal");
        Console.WriteLine("3. Crypto");
        Console.Write("Select payment method: ");
        var paymentMethod = int.Parse(Console.ReadLine());
        var totalAmount = CalculateTotalAmount();

        // Shipping Selection
        Console.WriteLine("\nChoose a shipping method:");
        Console.WriteLine("1. Standard (Free)");
        Console.WriteLine("2. Express (15.00  €)");
        Console.WriteLine("3. International (25.00 €)");
        Console.Write("Select shipping method: ");
        var shippingMethod = int.Parse(Console.ReadLine());

        var shippingCost = GetShippingCost(shippingMethod);
        Console.WriteLine($"Shipping cost: {shippingCost}€");
        
        var paymentSuccess = ProcessPayment(paymentMethod, totalAmount + shippingCost);
        if (!paymentSuccess)
        {
            Console.WriteLine("Payment failed. Order not placed.");
            return;
        }
        
        var order = new Order
        {
            Items = new List<OrderItem>(_orderBasket),
            PaymentMethod = paymentMethod,
            ShippingMethod = shippingMethod,
            ShippingCost = shippingCost,
            TotalCost = totalAmount + shippingCost
        };

        _orders.Add(order);
        _orderBasket.Clear();

        SendOrderConfirmation(order);
        Console.WriteLine("Order placed successfully!");
    }

    private double CalculateTotalAmount()
    {
        double total = 0;
        foreach (var item in _orderBasket)
        {
            total += item.Product.Price * item.Quantity;
        }
        return total;
    }

    private bool ProcessPayment(int paymentMethod, double amount)
    {
        switch (paymentMethod)
        {
            case 1:
                Console.WriteLine("Processing payment with Credit Card...");
                break;
            case 2:
                Console.WriteLine("Processing payment with PayPal...");
                break;
            case 3:
                Console.WriteLine("Processing payment with Crypto...");
                break;
            default:
                Console.WriteLine("Invalid payment method.");
                return false;
        }

        Console.WriteLine($"Payment of {amount}€ was successful!");
        return true;
    }

    private double GetShippingCost(int shippingMethod)
    {
        return shippingMethod switch
        {
            1 => 0.00,
            2 => 15.00,
            3 => 25.00,
            _ => 0.00
        };
    }

    private void SendOrderConfirmation(Order order)
    {
        Console.WriteLine($"\nOrder Confirmation:");
        foreach (var item in order.Items)
        {
            Console.WriteLine($"{item.Quantity} x {item.Product.Name} - {item.Product.Price}€ each");
        }
        Console.WriteLine($"Shipping: {GetShippingMethodName(order.ShippingMethod)} ({order.ShippingCost} €)");
        Console.WriteLine($"Total Cost: {order.TotalCost}€");
    }

    private string GetShippingMethodName(int shippingMethod)
    {
        return shippingMethod switch
        {
            1 => "Standard",
            2 => "Express",
            3 => "International",
            _ => "Unknown"
        };
    }
}