namespace NodusOperandi.Plugins
{

    abstract public class AbstractPlugin
    {
        
        abstract public string Name { get; }
        abstract public void RegisterPlugin();

    }

}
