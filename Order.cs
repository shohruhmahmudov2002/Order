using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

public class Order
{
    [JsonPropertyName("ID")]
    [JsonPropertyOrder(2)]
    public int OrderID { get; set; }
    [JsonPropertyName("Name")]
    [JsonPropertyOrder(1)]
    public string CustomerName { get; set; }
    [JsonPropertyName("Amount")]
    [JsonPropertyOrder(5)]
    public decimal TotalAmount { get; set; }
    [JsonPropertyName("Order Information")]
    [JsonPropertyOrder(4)]
    public List<OrderItem> OrderItems { get; set; }
    [JsonPropertyName("Status")]
    [JsonPropertyOrder(3)]
    public OrderState OrderState { get; set; }
    [JsonPropertyName("Time of Order")]
    public string DateTime { get; set; }
    public override string ToString()
    {
        return $"\nTime: {DateTime}\nID: {OrderID} | Name: {CustomerName} |" +
            $" Amount: {TotalAmount} | Status: {OrderState}";
    }
}
[JsonConverter(typeof(JsonStringEnumConverter<OrderState>))]
public enum OrderState
{
    Pending,
    Processing,
    Shipped,
    Delivered,
    Canceled,
    Returned,
    Refunded
}

