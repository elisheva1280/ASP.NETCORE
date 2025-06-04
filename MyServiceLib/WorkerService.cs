// using System;
// using System.Net.Http;
// using System.Text;
// using System.Text.Json;
// using System.Threading.Tasks;
// using lesson2.Modells;


using MyModelsLib;
using MyModelsLib.Interface;
using MyFileServiceLib.Interface;
// using Login;




namespace MyServiceLib;



public class WorkerService : IWorkerService
{
    // public IWorkerService W;


    IFileService<Worker> fileService1;
    public WorkerService(IFileService<Worker> fileService)
    {
        this.fileService1 = fileService;
    }

    // IWorkerService<Worker> workerService;
    // public WorkerService(IWorkerService<Worker> workerService){
    //     this.workerService = workerService;
    // }



    string path = @"H:\finalApi\WebApi\Workers.json";


    public List<Worker> WorkerList = new List<Worker>(){
    new Worker("s",105,5,"s","Admin"),
    new Worker("a",105,5,"a","Admin"),
    new Worker("yoram",105,5,"123456","Admin"),
    new Worker("abir",103,7,"12","Admin"),
    new Worker("jeq",107,12,"0000","worker"),
    new Worker("0",107,12,"0","worker"),
    new Worker("yosef",109,10,"1234","superworker")
};


    public string SWGetById(int id)
    {
        foreach (Worker p in WorkerList)
            if (p.Id == id) return "the name of worker is: " + p.NameOfWorker + " count of work's hours: " + p.Hours;
        return null;
    }
    public Worker SWGetByName(string name)
    {
        foreach (Worker p in WorkerList)
            if (p.NameOfWorker == name)
                return p;
        // return (Worker)p;
        return null;
    }



    public bool SWPost(string nameOfWorker, int id, int hours, string pass, string role)
    {
        WorkerList.Add(new Worker(nameOfWorker, id, hours, pass, role));
        if (this.SWGetById(id) != null)
            return true;
        return false;
    }


    public bool SWputName(int id, string name)
    {
        foreach (Worker p in WorkerList)
            if (p.Id == id)
            {
                p.NameOfWorker = name;
                return true;
            }
        return false;
    }


    public void SWputHours(int id, int hours)
    {
        foreach (Worker p in WorkerList)
            if (p.Id == id)
            {
                p.Hours = hours;
                Console.WriteLine("succed👍👌👍");
            }
    }



    public void SWDel(int id)
    {
        foreach (var i in WorkerList)
        {
            if (i.Id == id) WorkerList.Remove(i);
        }
    }

    public bool SifExist(string nameOfWorker, string pass)
    {
        foreach (var i in WorkerList)
        {
            if (i.NameOfWorker == nameOfWorker)
                if (i.Password == pass)
                    return true;
        }
        return false;
    }

}
