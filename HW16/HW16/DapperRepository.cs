using Dapper;
using HW16.Models;
using Npgsql;

namespace HW16
{
    internal class DapperRepository
    {
        // Формируем строку подключения к БД
        public static string SQLConnectionString = "User ID=postgres;Password=l-185139;HOST=localhost;Port=5432;Database=Shop;";

        // Реализуем метод, возвращающий список покупателей, у которых возраст меньше указанного
        public List<Customer>? GetCustomersByAge(int minAge)
        {
            using (var connection = new NpgsqlConnection(SQLConnectionString))
            {
                try
                {
                    var sql = @"SELECT firstname, lastname
                                FROM customers
                                WHERE age < " + minAge;
                    var result = connection.Query<Customer>(sql);
                    return result.ToList();
                }
                catch
                {
                    return null;
                }
            }
        }

        // Реализуем метод, возвращающий список покупателей по фразе
        public List<Customer>? GetCustomersByName(string name)
        {
            using (var connection = new NpgsqlConnection(SQLConnectionString))
            {
                try
                {
                    var sql = @"SELECT id, lastname
                                FROM customers
                                WHERE firstname LIKE '%" + name + "%'";
                    var result = connection.Query<Customer>(sql);
                    return result.ToList();
                }
                catch
                {
                    return null;
                }
            }
        }

        // Реализуем метод, возвращающий список товаров по количеству и цене
        public List<Product>? GetProductsByQuantityAndPrice(int quntity, int price)
        {
            using (var connection = new NpgsqlConnection(SQLConnectionString))
            {
                try
                {
                    var sql = @"SELECT name, description
                                FROM products
                                WHERE stockquantity < " + quntity + " AND price >  " + price;
                    var result = connection.Query<Product>(sql);
                    return result.ToList();
                }
                catch
                {
                    return null;
                }
            }
        }

        // Реализуем метод, возвращающий список всех товаров по наименованию
        public List<Product>? GetProductsOrderByName()
        {
            using (var connection = new NpgsqlConnection(SQLConnectionString))
            {
                try
                {
                    var sql = @"SELECT *
                                FROM products
                                ORDER BY name";
                    var result = connection.Query<Product>(sql);
                    return result.ToList();
                }
                catch
                {
                    return null;
                }
            }
        }

        // Реализуем метод, возвращающий список всех товаров по наименованию
        public List<Order>? GetOrdersByQuantity(int quantity)
        {
            using (var connection = new NpgsqlConnection(SQLConnectionString))
            {
                try
                {
                    var sql = @"SELECT id
                                FROM orders
                                WHERE quantity  > " + quantity;
                    var result = connection.Query<Order>(sql);
                    return result.ToList();
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
