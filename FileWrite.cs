using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

public class File
{
    public static void Write(string updatedJson)
    {
        using var fileStream = new FileStream("D:\\C# darslar\\Practise\\Order\\Order.json", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        var updatedMem = new MemoryStream(Encoding.UTF8.GetBytes(updatedJson));
        updatedMem.CopyTo(fileStream);
        Console.WriteLine("Json filega malumotlar ko'chirildi");
    }
}

