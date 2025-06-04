namespace MyFileServiceLib.Interface;
public interface IFileService<T>{

    List<T> Read(string path);
    void Write(string path, T obj);

    void Update(List<T> list, string path);

}