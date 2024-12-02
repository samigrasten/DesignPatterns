using ECommerceSystem.DomainObjects;
using ECommerceSystem.Features.Application.Exit;
using ECommerceSystem.Features.Application.MainMenu;
using ECommerceSystem.Features.Basket.Checkout;
using ECommerceSystem.Features.Basket.Checkout.CheckoutSteps;
using ECommerceSystem.Features.Basket.Checkout.Factories;
using ECommerceSystem.Features.Basket.Checkout.PaymentMethods;
using ECommerceSystem.Features.Basket.Checkout.PostProcessors;
using ECommerceSystem.Features.Basket.Checkout.PostProcessors.CreateOrderConfirmation;
using ECommerceSystem.Features.Basket.Checkout.ShippingMethods;
using ECommerceSystem.Features.Basket.ViewBasket;
using ECommerceSystem.Features.Products.AddProductToBasket;
using ECommerceSystem.Features.Products.DisplayProducts;
using ECommerceSystem.Features.Shared;
using ECommerceSystem.Features.Shared.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var serviceProvider = new ServiceCollection()
    .AddLogging()
    .AddSingleton<MainMenu>()
    .AddSingleton<CommandReader>()
    .AddSingleton<ActionFactory>()
    .AddSingleton<OrderBasket>()
    .AddSingleton<ProductRepository>()
    .AddSingleton<OrderRepository>()
    .AddSingleton<IAction, DisplayProductsAction>()
    .AddSingleton<IAction, AddProductToBasketAction>()
    .AddSingleton<IAction, ViewBasketAction>()
    .AddSingleton<IAction, CheckoutAction>()
    .AddSingleton<IAction, ExitAction>()
    .AddSingleton<PaymentMethodFactory>()
    .AddSingleton<ShippingMethodFactory>()
    .AddSingleton<ProcessOrder>()
    .AddSingleton<CheckoutStepList>()
    .AddSingleton<IShippingMethod, FreeShipping>()
    .AddSingleton<IShippingMethod, ExressShipping>()
    .AddSingleton<IShippingMethod, InternationalShipping>()
    .AddSingleton<IPaymentMethod, CreditCardPayment>()
    .AddSingleton<IPaymentMethod, PaypalPayment>()
    .AddSingleton<IPaymentMethod, CryptoPayment>()
    .AddSingleton<IObserver<Order>, CreateOrderConfirmation>()
    .AddSingleton<IObserver<Order>, SendUserNotification>()
    .BuildServiceProvider();

Console.OutputEncoding = System.Text.Encoding.UTF8;
var mainMenu = serviceProvider.GetService<MainMenu>();
mainMenu?.Run();
