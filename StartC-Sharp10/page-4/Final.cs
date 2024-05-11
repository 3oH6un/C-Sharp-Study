namespace StartC_Sharp10.page_4;

public class UserService : IAsdf
{
    public IAsdf asdf = new UserService();
    public Object aaaa = new UserService();

    public string Write(int id)
    {
        return "";
    }

    public string Read(int id)
    {
        return "";
    }

    public string Update(int id)
    {
        return "";
    }

    public string Delete(int id)
    {
        return "";
    }
}

public interface IAsdf
{
    public string Write(int id);
    public string Read(int id);
    public string Update(int id);
    public string Delete(int id);
}