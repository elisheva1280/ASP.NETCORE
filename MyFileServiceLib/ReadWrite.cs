
using System.Net;
using System.Security.AccessControl;
using System.IO;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using MyFileServiceLib;
// using MyFileServiceLib.interface;
using MyFileServiceLib.Interface;
using MyModelsLib;
namespace MyFileServiceLib;

public class ReadWrite<T> : IFileService<T>
{
    // string _path;
    // string path=@"H:\finalApi\WebApi\pizzas.json";
    public ReadWrite()
    {
        // _path = path;
    }
    public List<T> Read(string path)
    {
        var list = new List<T>();
        var text = File.ReadAllText(path);
        if (!string.IsNullOrEmpty(text))
        {
            list = JsonConvert.DeserializeObject<List<T>>(text);
        }
        return list;
    }
    public void Write(string path,T obj)
    {
        var list = Read(path);
        list.Add(obj);
        File.WriteAllText(path, JsonConvert.SerializeObject(list));
    }

    public void Update(List<T> list, string path)
    {
       File.WriteAllText(path, JsonConvert.SerializeObject(list));
    }

    public void Add(T obj,string path){
        var list = Read(path);
        list.Add(obj);
        File.WriteAllText(path, JsonConvert.SerializeObject(list));

    }
}

