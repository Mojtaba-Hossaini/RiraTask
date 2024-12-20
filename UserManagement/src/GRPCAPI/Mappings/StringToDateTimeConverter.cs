using AutoMapper;

namespace API.Mappings;

public class StringToDateTimeConverter : ITypeConverter<string, DateTime>
{
    public DateTime Convert(string source, DateTime destination, ResolutionContext context)
    {
        if(DateTime.TryParse(source, out DateTime dateTime)) return dateTime;
        return default;
    }
}