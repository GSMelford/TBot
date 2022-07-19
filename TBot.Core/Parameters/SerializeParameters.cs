using System.Reflection;
using TBot.Core.Attributes;

namespace TBot.Core.Parameters;

public class SerializeParameters
{
    public IEnumerable<Parameter>? BuildParameters()
    {
        Type parametersObject = GetType();
        
        foreach (PropertyInfo property in parametersObject.GetProperties())
        {
            object[] attrs = property.GetCustomAttributes(false);
            object? value = property.GetValue(this);

            if (attrs[0] is not ParameterNameAttribute attribute)
                continue;
            
            if (!CheckDefaultParameterValue(value))
            {
                yield return new Parameter(attribute.ParameterName, value, attribute.UrlEncode);
            }
            else if(attribute.IsRequired)
            {
                throw new ArgumentException(
                    $"{nameof(SerializeParameters)} error. Property {property.Name} has to set");
            }
        }
    }

    private static bool CheckDefaultParameterValue(object? value)
    {
        return value switch
        {
            null => true,
            ValueType => Activator.CreateInstance(value.GetType())?.Equals(value) ?? false,
            _ => false
        };
    }
}