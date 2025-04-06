namespace MainAPI.Helpers;

public static class StringUtils
{
    /// <summary>
    /// Remove todos os caracteres não numéricos de uma string.
    /// </summary>
    /// <param name="value">A string a ser processada.</param>
    /// <returns>Uma string contendo apenas números.</returns>
    public static string RemoveFormatting(string value)
    {
        return string.IsNullOrWhiteSpace(value)
            ? string.Empty
            : new string(value.Where(char.IsDigit).ToArray());
    }
}