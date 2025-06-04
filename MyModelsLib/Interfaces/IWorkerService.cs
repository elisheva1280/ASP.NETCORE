namespace MyModelsLib.Interface;
public interface IWorkerService{
  public string SWGetById(int id);
  public Worker SWGetByName(string name);
  public bool SWPost(string nameOfWorker,int id,int hour,string pass,string role );
  public bool SWputName(int id, string name);
  public void SWputHours(int id, int hours);
  public void SWDel(int id);
 public  bool SifExist(string nameOfWorker, string pass);

  // public bool SifExist(string name,string password) ;
}