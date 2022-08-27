using DataDrivenTestTyping.Lib;
using FluentAssertions;
using static DataDrivenTestTyping.Lib.TemperatureUnit;

namespace DataDrivenTestTyping.MsTest;

[TestClass]
public class TemperatureConverterTests
{
    [DataTestMethod]
    [DataRow(Celsius, Celsius, 27, 27)]
    [DataRow(Celsius, Fahrenheit, 27, 80.6)]
    [DataRow(Celsius, Kelvin, 27, 300.15)]
    [DataRow(Fahrenheit, Celsius, 80, 26.67)]
    [DataRow(Fahrenheit, Fahrenheit, 80, 80)]
    [DataRow(Fahrenheit, Kelvin, 80, 299.82)]
    [DataRow(Kelvin, Celsius, 300, 26.85)]
    [DataRow(Kelvin, Fahrenheit, 300, 80.33)]
    [DataRow(Kelvin, Kelvin, 300, 300)]
    public void ConvertsCorrectly(TemperatureUnit from, TemperatureUnit to, object value, object expected)
    {
        ConvertsCorrectly(from, to, Convert.ToDouble(value), Convert.ToDouble(expected));
    }

    public void ConvertsCorrectly(TemperatureUnit from, TemperatureUnit to, double value, double expected)
    {
        var result = TemperatureConverter.Convert(value, from, to);

        result.Should().BeApproximately(expected, 0.005);
    }
}