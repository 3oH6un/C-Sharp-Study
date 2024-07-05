namespace Practice._2024_05.Practice._6;

public class MainApp
{
    public static void _Main(string[] args)
    {
        Configuration config = new Configuration();
        config.SetConfig("Version", "V 5.0");
        config.SetConfig("Size", "655,324 KB");

        Console.WriteLine(config.GetConfig("Version"));
        Console.WriteLine(config.GetConfig("Size"));

        config.SetConfig("Version", "V 5.0.1");
        Console.WriteLine(config.GetConfig("Version"));
    }
}

class Configuration
{
    private List<ItemValue> _listConfig;

    public Configuration()
    {
        this._listConfig = new List<ItemValue>();
    }

    public string GetConfig(string item)
    {
        foreach (ItemValue iv in _listConfig)
        {
            if (iv.GetItem() == item)
            {
                return iv.GetValue();
            }
        }

        return "";
    }

    public void SetConfig(string item, string value)
    {
        bool found = false;

        foreach (ItemValue config in this._listConfig)
        {
            if (config.GetItem() == item)
            {
                config.SetValue(value);
            }
        }

        if (!found)
        {
            this._listConfig.Add(new ItemValue(item, value));
        }
    }
}

class ItemValue
{
    private string _item;
    private string _value;

    public ItemValue(string item, string value)
    {
        this._item = item;
        this._value = value;
    }

    public string GetItem()
    {
        return this._item;
    }

    public string GetValue()
    {
        return this._value;
    }

    public void SetItem(string item)
    {
        this._item = item;
    }

    public void SetValue(string value)
    {
        this._value = value;
    }
}