
using lesson2.Login.Interface;
using MyFileServiceLib.Interface;
using MyModelsLib;

namespace lesson2.Login.service;
public class LoginClass: ILogin
{
    IFileService<Worker> fileService1;

    public LoginClass(IFileService<Worker> i){
        fileService1=i;
    }

    // string path = @"lesson2\Workers.json";
    // string path = @"H:\finalApi\WebApi\lesson2\Workers.json";
    // 
    // Workers.json
    public List<Worker> WorkerList = new List<Worker>(){
    new Worker("s",105,5,"s","Admin"),      
    new Worker("a",105,5,"a","Admin"),    
    new Worker("yoram",105,5,"123456","Admin"),
    new Worker("abir",103,7,"12","Admin"),
    new Worker("jeq",107,12,"0000","worker"),
    new Worker("0",107,12,"0","worker"),
    new Worker("yosef",109,10,"1234","superworker")
    };
    
    public bool ifExist(string name, string password){
        var wl=WorkerList;
        Worker ww=null;
        // var workerlist = fileService1.Read(path);
        Console.WriteLine("i am hear!!!!!!!!!!!!!!!!!!!!!😊😂  my name: "+name);
        foreach(Worker w in wl){
            Console.WriteLine("name:"+ w.NameOfWorker+" "+w.NameOfWorker.Equals(name));
            Console.WriteLine("password:"+ w.Password);
            if(w.NameOfWorker.Equals(name)&&w.Password.Equals(password))
            ww=w;
        }
        if(ww!=null){
            return true;
        }
        return false;
    }
}


    
    
    
