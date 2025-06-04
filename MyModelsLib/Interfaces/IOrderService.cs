// using Creditcard;
namespace MyModelsLib.Interface;
public interface IOrderService{
  public string SOGetById(int id);

  public bool SOPost(int id,string nameOfCustumer, string creditcardn,int cv,int ex);
  // public async void dothepizza();
  // public static bool pay(string creditcardn,int cv,int ex);
  // public static void Invoice(int id, string nameOfCustumer);
}