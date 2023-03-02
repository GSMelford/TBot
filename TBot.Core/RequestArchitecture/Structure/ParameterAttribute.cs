namespace TBot.Core.RequestArchitecture.Structure;

[AttributeUsage(AttributeTargets.Property)]
public class ParameterAttribute : Attribute
{
    public string Name { get; }
    public bool Required { get; set; } 
    public UrlEncode IsEncode { get; set; }
    public bool IsJson { get; set; }
        
    public ParameterAttribute(string name)
    {
        Name = name;
    }
}