using Newtonsoft.Json;

namespace TBot.Core.Utilities;

public class JsonSerializableObject
{
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}