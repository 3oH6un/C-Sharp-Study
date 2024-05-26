namespace ThisIsC_Sharp._7_Class.NestedClass;

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
    private List<ItemValue> listConfig = new List<ItemValue>();

    public void SetConfig(string item, string value)
    {
        ItemValue iv = new ItemValue();
        iv.SetValue(this, item, value);
    }

    public string GetConfig(string item)
    {
        foreach (ItemValue iv in listConfig)
        {
            if (iv.GetItem() == item)
            {
                return iv.GetValue();
            }
        }

        return "";
    }

    private class ItemValue
    {
        private string item;
        private string value;

        public void SetValue(Configuration config, string item, string value)
        {
            this.item = item;
            this.value = value;

            bool found = false;
            for (int i = 0; i < config.listConfig.Count; i++)
            {
                if (config.listConfig[i].item == item)
                {
                    config.listConfig[i] = this;
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                config.listConfig.Add(this);
            }

        }

        public string GetItem()
        {
            return item;
        }

        public string GetValue()
        {
            return value;
        }
    }
}