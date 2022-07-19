using TBot.Core.Attributes;
using TBot.Core.Parameters;

namespace TBot.Api.Telegram.GetFile;

public class GetFileParameters : SerializeParameters
{
    [ParameterName("file_id", true)]
    public string FileId { get; set; }
}