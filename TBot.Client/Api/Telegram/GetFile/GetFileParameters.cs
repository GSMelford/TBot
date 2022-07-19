using TBot.Core.Attributes;
using TBot.Core.Parameters;

namespace TBot.Client.Api.Telegram.GetFile;

public class GetFileParameters : SerializeParameters
{
    [ParameterName("file_id", true)]
    public string FileId { get; set; }
}