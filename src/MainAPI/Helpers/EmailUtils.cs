using System.Text.RegularExpressions;

namespace MainAPI.Helpers;

public class EmailUtils
{
    /// <summary>
    ///     Valida se o e-mail é válido.
    /// </summary>
    /// <param name="email">O e-mail a ser validado.</param>
    /// <returns>True se o e-mail for válido, caso contrário False.</returns>
    public static bool IsValid(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        // Expressão regular para validar e-mails
        var emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase);
    }
}