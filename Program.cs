using System.Text;
using System.Text.Json;

namespace OrderHW;
internal class Program
{
    static void Main(string[] args)
    {
        var order = new Order()
        {
            OrderID = 1,
            CustomerName = "Shohruh",
            TotalAmount = 100,
            OrderItems = new List<OrderItem>
            {
                new()
                {
                    ItemName = "Disk",
                    Quantity = 120,
                    Price = 20_000
                },
                new()
                {
                    ItemName = "VideoGame",
                    Quantity = 50,
                    Price = 120_000
                }
            },
        };
        var jsonOptions = new JsonSerializerOptions()
        {
            AllowTrailingCommas = true,
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        using var memoryStream = new MemoryStream();
        JsonSerializer.Serialize(memoryStream, order, jsonOptions);
        memoryStream.Position = 0;

        Console.WriteLine($"-----Then-----");
        string json1 = Encoding.UTF8.GetString(memoryStream.ToArray());
        Console.WriteLine(json1);

        Console.WriteLine($"\n-----Now-----");
        memoryStream.Position = 0;
        string json2 = Encoding.UTF8.GetString(memoryStream.ToArray());
        json2 = json2.Replace("\"quantity\": 120", "\"quantity\": 100");
        Console.WriteLine(json2);

        var orderUpdated = JsonSerializer.Deserialize<Order>(json2,jsonOptions);
        Console.WriteLine($"\nOrder ID: {orderUpdated.OrderID} | Customer Name: {orderUpdated.CustomerName} |" +
            $" Total amount: {orderUpdated.TotalAmount}");
        Console.WriteLine("Order Items: ");
        foreach(var items in orderUpdated.OrderItems)
        {
            Console.WriteLine($"\tItem name: {items.ItemName}\n\tQuantity: {items.Quantity}" +
                $"\n\tPrice: {items.Price}\n");
        }
    }
}

