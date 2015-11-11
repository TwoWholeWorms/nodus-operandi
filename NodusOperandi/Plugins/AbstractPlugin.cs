namespace NodusOperandi.Plugins
{
    
    using System;
    
    abstract public class AbstractPlugin
    {
        
        abstract public string Name { get; }
        abstract public void RegisterPlugin();

    }

}

