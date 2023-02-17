﻿using TBot.Core.RequestArchitecture.Structure;

namespace TBot.Core.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class ParameterAttribute : Attribute
{
    public string Name { get; }
    public bool IsRequired { get; }
    public UrlEncode IsEncode { get; }
        
    public ParameterAttribute(
        string name, 
        bool isRequired = false, 
        UrlEncode isEncode = UrlEncode.NoEncode)
    {
        Name = name;
        IsRequired = isRequired;
        IsEncode = isEncode;
    }
}