namespace MainAPI.Helpers;

public class CnpjUtils
{
    /// <summary>
    ///     Valida se o CNPJ é válido.
    /// </summary>
    /// <param name="cnpj">O CNPJ a ser validado.</param>
    /// <returns>True se o CNPJ for válido, caso contrário False.</returns>
    public static bool IsValid(string cnpj)
    {
        if (string.IsNullOrWhiteSpace(cnpj))
            return false;

        // Remover formatação
        cnpj = RemoveFormatting(cnpj);

        // Verificar se o tamanho é 14
        if (cnpj.Length != 14)
            return false;

        // Verificar se todos os dígitos são iguais (ex.: 11111111111111)
        if (cnpj.All(c => c == cnpj[0]))
            return false;

        // Calcular os dígitos verificadores
        var firstVerifier = CalculateVerifierDigit(cnpj.Substring(0, 12));
        var secondVerifier = CalculateVerifierDigit(cnpj.Substring(0, 12) + firstVerifier);

        // Verificar se os dígitos verificadores estão corretos
        return cnpj.EndsWith($"{firstVerifier}{secondVerifier}");
    }

    private static string RemoveFormatting(string value)
    {
        return string.IsNullOrWhiteSpace(value)
            ? string.Empty
            : new string(value.Where(char.IsDigit).ToArray());
    }

    private static int CalculateVerifierDigit(string cnpjBase)
    {
        var weights = cnpjBase.Length == 12
            ? new[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 }
            : new[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        var sum = 0;
        for (var i = 0; i < cnpjBase.Length; i++) sum += (cnpjBase[i] - '0') * weights[i];

        var remainder = sum % 11;
        return remainder < 2 ? 0 : 11 - remainder;
    }
}