using System.IO;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Text.Json;

public static class ValidateCpfFunction
{
    [Function("ValidateCpf")]
    public static async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("ValidateCpfFunction");
        logger.LogInformation("C# HTTP trigger function processed a request.");

        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var data = JsonSerializer.Deserialize<CpfRequest>(requestBody);

        bool isValid = ValidateCpf(data.Cpf);

        var response = req.CreateResponse(isValid ? System.Net.HttpStatusCode.OK : System.Net.HttpStatusCode.BadRequest);
        await response.WriteStringAsync(isValid ? "CPF is valid." : "CPF is invalid.");

        return response;
    }

    private static bool ValidateCpf(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11 || !long.TryParse(cpf, out _))
            return false;

        int[] cpfArray = cpf.Select(c => c - '0').ToArray();
        int[] multiplier1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplier2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        int sum = 0;
        for (int i = 0; i < 9; i++)
            sum += cpfArray[i] * multiplier1[i];

        int remainder = sum % 11;
        int firstCheckDigit = remainder < 2 ? 0 : 11 - remainder;

        if (cpfArray[9] != firstCheckDigit)
            return false;

        sum = 0;
        for (int i = 0; i < 10; i++)
            sum += cpfArray[i] * multiplier2[i];

        remainder = sum % 11;
        int secondCheckDigit = remainder < 2 ? 0 : 11 - remainder;

        return cpfArray[10] == secondCheckDigit;
    }

    private class CpfRequest
    {
        public string Cpf { get; set; }
    }
}