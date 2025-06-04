namespace MyModelsLib;
public class Creditcard
{
    
    public string CardNumber{ get; set; }

    public int Cvv{ get; set; }

    public int Expiration{ get; set; } 

    public Creditcard(string cd,int cv,int ex){
        CardNumber = cd;
        Cvv=cv;
        Expiration=ex;
    }  
}