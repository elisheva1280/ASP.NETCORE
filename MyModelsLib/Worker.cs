
namespace MyModelsLib;

public class Worker
{
    public string NameOfWorker { get; set; }
    public int Id { get; set; }
    public int Hours { get; set; }
    public string Password{get; set;}

    public string Role{get; set;}

    public Worker(string nameOfWorker, int id, int hours,string pass,string role){
        NameOfWorker = nameOfWorker;
        Id = id;
        Hours = hours;
        Password=pass;
        Role=role;     
    }
}