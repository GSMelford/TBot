using Newtonsoft.Json;

namespace TBot.Core;

public class JsonSerializableObject
{
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}