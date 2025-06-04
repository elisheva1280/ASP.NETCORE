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

   public class PizzaService : IPizzaService
    {

    
    IFileService<MyPizza> fileService1;

    public PizzaService(IFileService<MyPizza> fileService){
        this.fileService1 = fileService;
    }   
    string path=@"H:\finalApi\WebApi\pizzas.json";
    
// public List<MyPizza> Pizzalist=new List<MyPizza>(){
//     new MyPizza("bazzal",105,true),
//     new MyPizza("pitriot",103,false),
//     new MyPizza("agvania",107,true),
//     new MyPizza("zeitim",109,true)
// };
    
// public bool SAdd(int id,bool isGlotan,string nameOfPizza){
//     MyPizza p=new MyPizza(nameOfPizza,id,isGlotan);
//     return true;
// }
public string SGetById(int id){
    var Pizzalist = fileService1.Read(path);  
    MyPizza pp=null;
    foreach(MyPizza p in Pizzalist)
    {
        if(p.Id==id){
            pp=p;
        }             
    }
    if(pp!=null)
         return "the pizza is: "+pp.NameOfPizza + ",glotan?"+pp.IsGlotan;
    return null;
}



public bool SPost(string nameOfPizza,int id,bool glotan){
    MyPizza p= new MyPizza(nameOfPizza, id, glotan);
    fileService1.Write(path, p);
var Pizzalist = fileService1.Read(path);  
if(this.SGetById(id)!=null)
   return true;
return false;
}


public bool SputName(int id, string name){
    var Pizzalist = fileService1.Read(path);  
    foreach(MyPizza p in Pizzalist)
        if(p.Id==id) {
             p.NameOfPizza = name;
             fileService1.Update(Pizzalist,path);
             return true;
        }
    return false;    
  
}


public void SputGlotan(int id, bool glotan){
    var Pizzalist = fileService1.Read(path); 
    var change=new List<MyPizza>();

    foreach(MyPizza p in Pizzalist)
    {
            if(p.Id==id) 
                change.Add(p); // Add to the list of items to remove       
    }
    foreach(MyPizza p in change){       
           p.IsGlotan = glotan;            
         
    }
fileService1.Update(Pizzalist,path); 
}

public void SDel(int id1){
    var Pizzalist1 = fileService1.Read(path); 
    List<MyPizza> Pizzalist = Pizzalist1;
    foreach(MyPizza i in Pizzalist){
        if(i.Id==id1) {
            Pizzalist.Remove(i);
            fileService1.Update(Pizzalist,path);
        } 
    }  
}

    }


    
 
