﻿using CSharpFunctionalExtensions;
using System.Text.Json.Serialization;

namespace Conekta.Dotnet6.Values;


[JsonConverter(typeof(ConektaAmountJsonConverter))]
public class ConektaAmount : ValueObject<ConektaAmount>
{
    public readonly static ConektaAmount Empty = new ConektaAmount(0);
    public int Value { get; protected set; } = 0;


    protected ConektaAmount()
    {

    }
    protected ConektaAmount(int value)
    {
        Value = value;
    }

    public static ConektaAmount Create(decimal amount)
    {
        int value = Convert.ToInt32(amount * 100);
        return new ConektaAmount(value);

    }
    public static ConektaAmount Create(double amount)
    {
        int value = Convert.ToInt32(amount * 100);
        return new ConektaAmount(value);

    }
    public static ConektaAmount Create(int conektaInt)
    {
        return new ConektaAmount(conektaInt);

    }

    public decimal ToDecimal()
    {

        var decimalValue = Convert.ToDecimal(Value / 100);

        return decimalValue;

    }

    protected override bool EqualsCore(ConektaAmount other)
    {
        return Value == other.Value;
    }

    protected override int GetHashCodeCore()
    {
        return Value.GetHashCode(); 
    }
}