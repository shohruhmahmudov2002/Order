using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

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
            OrderState = OrderState.Pending,
            DateTime = DateTime.Now.ToString("dd-MM-yyyy, hh:mm:ss"),
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
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)}
        };

        using var memoryStream = new MemoryStream();
        JsonSerializer.Serialize(memoryStream, order, jsonOptions);
        memoryStream.Position = 0;

        Console.WriteLine(new string('-',20)+"Then"+new string('-',20));
        string json1 = Encoding.UTF8.GetString(memoryStream.ToArray());
        Console.WriteLine(json1);

        Console.WriteLine(new string('-', 20) + "Now" + new string('-', 20));
        memoryStream.Position = 0;
        string json2 = Encoding.UTF8.GetString(memoryStream.ToArray());
        json2 = json2.Replace("\"quantity\": 50", "\"quantity\": 100");
        Console.WriteLine(json2);
        File.Write(json2);
        var orderUpdated = JsonSerializer.Deserialize<Order>(json2,jsonOptions);
        Console.WriteLine(orderUpdated.ToString());
        Console.WriteLine("Order Items: ");
        foreach(var items in orderUpdated.OrderItems)
        {
            Console.WriteLine(items.ToString());
        }
    }
}

