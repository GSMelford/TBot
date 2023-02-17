using TBot.Core.Attributes;
using TBot.Core.RequestArchitecture;

namespace TBot.Client.Api.Telegram.GetFile;

public class GetFileParameter : BaseParameters
{
    [Parameter("file_id", true)]
    public string FileId { get; set; }
}