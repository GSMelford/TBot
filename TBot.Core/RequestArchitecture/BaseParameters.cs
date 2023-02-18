using System.Reflection;
using TBot.Core.Exceptions;
using TBot.Core.RequestArchitecture.Structure;

namespace TBot.Core.RequestArchitecture;

public class BaseParameters
{
    public IEnumerable<Parameter>? ToList()
    {
        Type baseParameters = GetType();
        
        foreach (PropertyInfo property in baseParameters.GetProperties())
        {
            object[] attributes = property.GetCustomAttributes(false);
            object? value = property.GetValue(this);

            if (attributes.FirstOrDefault() is not ParameterAttribute attribute)
            {
                continue;
            }
            
            if (!IsDefaultValue(value))
            {
                yield return new Parameter(attribute.Name, value, attribute.IsEncode);
            }
            else if(attribute.IsRequired)
            {
                throw new DiscrepancyException($"Required property not set on property: {property.Name}");
            }
        }
    }

    private static bool IsDefaultValue(object? value)
    {
        return value switch
        {
            null => true,
            ValueType => Activator.CreateInstance(value.GetType())?.Equals(value) ?? false,
            _ => false
        };
    }
}