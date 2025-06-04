
namespace MyModelsLib;

public class Order
{
    public string NameOfCustumer { get; set; }
    public int Id { get; set; }

    public Creditcard Credit{ get; set; }
   

    public Order(string nameOfWorker, int id,Creditcard creditcard){
        NameOfCustumer = nameOfWorker;
        Id = id;
        Credit = creditcard;
    }
    public Order(string nameOfWorker, int id){
        NameOfCustumer = nameOfWorker;
        Id = id;
    }
    public Order(){
        NameOfCustumer = "defoult";
        Id = 0;
    }
}