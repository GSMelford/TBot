using System.Reflection;
using TBot.Core.Exceptions;
using TBot.Core.RequestArchitecture.Structure;
using TBot.Core.Utilities;

namespace TBot.Core.RequestArchitecture;

public class BaseParameters
{
    public IEnumerable<Parameter>? ToParameters()
    {
        Type baseParameters = GetType();
        
        foreach (PropertyInfo property in baseParameters.GetProperties())
        {
            object[] attributes = property.GetCustomAttributes(false);
            object? value = property.GetValue(this);

            ParameterAttribute? parameterAttribute = null;
            foreach (object attributeObject in attributes)
            {
                if (attributeObject is not ParameterAttribute attribute) {
                    continue;
                }
                
                parameterAttribute = attribute;
                break;
            }

            if (parameterAttribute is null)
            {
                continue;
            }

            if (!IsDefaultValue(value))
            {
                yield return new Parameter(parameterAttribute.Name, parameterAttribute.IsJson ? value.ToJson() : value, parameterAttribute.IsEncode);
            }
            else if(parameterAttribute.Required)
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