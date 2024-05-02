namespace MailSender.Extensions;

/// <summary>
/// ExceptionExtensions
/// </summary>
public static class ExceptionExtensions
{
    /// <summary>
    /// GetOriginalException
    /// </summary>
    /// <param name="ex"></param>
    /// <returns></returns>
    public static Exception GetOriginalException(this Exception ex)
    {
        while (true)
        {
            if (ex.InnerException == null) return ex;
            ex = ex.InnerException;
        }
    }
}