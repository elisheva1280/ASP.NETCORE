namespace lesson2.Login.Interface;
public interface ILogin
{
      // public void SWDel(int id);
      // public void SWputHours(int id, int hours);
      // public bool SWputName(int id, string name);
      // public bool SWPost(string nameOfWorker,int id,int hours );
      // public string SWGetById(int id);

     public bool ifExist(string name, string password);

}