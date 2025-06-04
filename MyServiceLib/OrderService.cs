// using System;
// using System.Net.Http;
// using System.Text;
// using System.Text.Json;
// using System.Threading.Tasks;
// using lesson2.Modells;
using MyModelsLib;
using MyModelsLib.Interface;
using MyFileServiceLib.Interface;

namespace MyServiceLib;


public class OrderService : IOrderService
{

    // public IOrderService O;

    IFileService<Order> fileService1;

    public OrderService(IFileService<Order> fileService)
    {
        this.fileService1 = fileService;
    }
    string path = @"H:\finalApi\WebApi\Order.json";
    string path2 = @"H:\finalApi\WebApi\mail.json";

    // public List<Order> OrderList=new List<Order>(){
    //     new Order("yoram",105),
    //     new Order("abir",103),
    //     new Order("jeq",107),
    //     new Order("yosef",109)
    // };


    public string SOGetById(int id)
    {
        var OrderList = fileService1.Read(path);
        foreach (Order p in OrderList)
            if (p.Id == id) return "the name of worker is: " + p.NameOfCustumer;
        return null;
    }

    public bool SOPost(int id, string nameOfCustumer, string creditcardn, int cv, int ex)
    {
        Creditcard cd = new Creditcard(creditcardn, cv, ex);
        Order newo = new Order(nameOfCustumer, id, cd);
        fileService1.Write(path, newo);
        // OrderList.Add(newo);
        var OrderList = fileService1.Read(path);
        if (this.SOGetById(id) != null)
        {
            Task c=dothepizza();
            bool b= pay(creditcardn,cv, ex);
            Invoice(id,nameOfCustumer);


            // Task.Run(async () => await dothepizza());
            return true;
        }
        return false;
    }

    public async Task dothepizza()
    {

        Console.WriteLine("Roll out the dough");
        await Task.Delay(2000); // Use await instead of Wait()

        Console.WriteLine("Add toppings");
        await Task.Delay(2000);

        Console.WriteLine("Put in the oven");
        await Task.Delay(2000);

        Console.WriteLine("Remove");
        await Task.Delay(2000);

        Console.WriteLine("enjoy!!!🍕🍕🍕🍕🍕🍕🍕🍕🍕🍕🍕");
    }

    public bool pay(string creditcardn, int cv, int ex)
    {
        if (creditcardn == null || cv == null || ex == null) { return false; }
        Creditcard cd = new Creditcard(creditcardn, cv, ex);
        Console.WriteLine("the creditcard in checking...");
        Task.Delay(2000).Wait();
        Console.WriteLine("the creditcard is OK!!!👍");
        return true;
    }

    public void Invoice(int id, string nameOfCustumer)
    {
        Order newo = new Order(nameOfCustumer, id);
        fileService1.Write(path2, newo);
        Task.Delay(2000).Wait();
        Console.WriteLine("the invoke sended");
    }




}