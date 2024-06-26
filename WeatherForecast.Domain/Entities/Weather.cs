﻿using WeatherForecast.Domain.Entities;

public class Weather : EntityBase
{

    public Guid Id { get; private set; }
    public DateTime Date { get; private set; }
    public double AverageTemperature { get; private set; }
    public string Summary { get; private set; }

    public List<HourlyWeather> HourlyWeathers { get; private set; } = new List<HourlyWeather>();
    public Weather(Guid id, DateTime date, double averageTemperature, string summary, List<HourlyWeather> hourlyWeathers)
    {
        Id = id;
        Date = date;
        AverageTemperature = averageTemperature;
        Summary = summary;
        HourlyWeathers = hourlyWeathers;
    }

    public void Update(Weather weather)
    {

        Date =weather.Date;
        AverageTemperature = weather.AverageTemperature;
        Summary = weather.Summary;
        HourlyWeathers = weather.HourlyWeathers;
    }
}