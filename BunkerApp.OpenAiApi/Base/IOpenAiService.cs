namespace BunkerApp.OpenAiApi.Base;

public interface IOpenAiService<TResult>
{
    Task<TResult> Generate();
}