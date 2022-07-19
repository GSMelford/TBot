namespace TBot.Core.Interfaces;

public interface IExecutable
{
    public Task<HttpResponseMessage> Execute(HttpClient httpClient);
}