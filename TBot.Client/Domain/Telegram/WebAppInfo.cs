namespace TBot.Client.Domain.Telegram;

public class WebAppInfo
{
	public string Url { get; set; }

	public WebAppInfo(string url)
	{
		Url = url;
	}
}