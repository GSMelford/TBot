using Newtonsoft.Json;

namespace TBot.Core.Utilities;

public class SerializationExtensions
{
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}