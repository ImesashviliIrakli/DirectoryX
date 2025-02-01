namespace Api.Middleware;

public class LanguageMiddleware
{
    private readonly RequestDelegate _next;

    public LanguageMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var defaultLanguage = "en-US";

        var language = context.Request.Headers["Accept-Language"].ToString();

        if (string.IsNullOrWhiteSpace(language))
        {
            language = defaultLanguage;
        }
        else
        {
            language = IsValidLanguageCode(language) ? language : defaultLanguage;
        }

        context.Items["Language"] = language;

        context.Request.Headers["Accept-Language"] = language;

        await _next(context);
    }

    private bool IsValidLanguageCode(string languageCode)
    {
        return !string.IsNullOrWhiteSpace(languageCode) && languageCode.Length >= 2;
    }
}
