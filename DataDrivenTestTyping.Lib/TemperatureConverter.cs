using static DataDrivenTestTyping.Lib.TemperatureUnit;

namespace DataDrivenTestTyping.Lib;

public class TemperatureConverter
{
    public static double Convert(double value, TemperatureUnit from, TemperatureUnit to) =>
    (from, to) switch
    {
        (Celsius, Fahrenheit) => CelsiusToFahrenheit(value),
        (Celsius, Kelvin) => CelsiusToKelvin(value),
        (Fahrenheit, Celsius) => FahrenheitToCelsius(value),
        (Fahrenheit, Kelvin) => CelsiusToKelvin(FahrenheitToCelsius(value)),
        (Kelvin, Celsius) => KelvinToCelsius(value),
        (Kelvin, Fahrenheit) => CelsiusToFahrenheit(KelvinToCelsius(value)),
        _ => value,
    };

    private static double KelvinToCelsius(double kelvin) => kelvin - 273.15;

    private static double CelsiusToKelvin(double celsius) => celsius + 273.15;

    private static double FahrenheitToCelsius(double fahrenheit) => (fahrenheit - 32) * 5 / 9;

    private static double CelsiusToFahrenheit(double celsius) => (celsius * 9 / 5) + 32;
}