using HW16;

var dapperRepo = new DapperRepository();

var customerList = dapperRepo.GetCustomersByAge(30);
Console.WriteLine("Case: WHERE age < 30 ");
if (customerList != null)
{
    foreach (var customer in customerList)
    {
        Console.WriteLine(customer.firstname + " " + customer.lastname);
    }
}
customerList = dapperRepo.GetCustomersByName("ан");
Console.WriteLine("Case: WHERE name LIKE '%ан%'");
if (customerList != null)
{
    foreach (var customer in customerList)
    {
        Console.WriteLine(customer.id + " " + customer.lastname);
    }
}
var productList = dapperRepo.GetProductsByQuantityAndPrice(20, 100);
Console.WriteLine("Case: WHERE stockquantity < 20 AND price > 100");
if (productList != null)
{
    foreach (var product in productList)
    {
        Console.WriteLine(product.Name + " " + product.Description);
    }
}
productList = dapperRepo.GetProductsOrderByName();
Console.WriteLine("Case: ORDER BY name");
if (productList != null)
{
    foreach (var product in productList)
    {
        Console.WriteLine(product.Name + " " + product.StockQuantity + " " + product.Price);
    }
}
var orderList = dapperRepo.GetOrdersByQuantity(5);
Console.WriteLine("Case: WHERE quantity  > 5");
if (orderList != null)
{
    foreach (var order in orderList)
    {
        Console.WriteLine(order.Id);
    }
}
