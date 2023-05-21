using System.Net.Http.Headers;
using System.Text;
using medisoft.application.models;
using medisoft.model;
using medisoft.service.IServices;
using Newtonsoft.Json;

namespace medisoft.service;

public class BardService : IBardService
{
    private readonly string _apiKey;
    public BardService(string apiKey)
    {
        this._apiKey = apiKey;

    }

    public BardReportModel GenerateReport(ReportRequestContract requestInput)
    {
        string conversation = string.Join(" ", requestInput.Transcripts);
        string command_input = "The patient info: " +
        "Age: " + requestInput.Patient.Age + ". ";
        if (requestInput.Patient.ChronicDiseases.Length > 0)
        {
            command_input += "Chronic disease: " + string.Join(", ", requestInput.Patient.ChronicDiseases) + ". ";
        }
        command_input += "Gender: " + requestInput.Patient.Gender + ". ";
        if (requestInput.Patient.Allergies.Length > 0)
        {
            command_input += "Allergies: " + string.Join(", ", requestInput.Patient.Allergies) + ". ";
        }


        command_input += "extract symptoms and diagnosis from this conversation '" +
        conversation + "' as json format ";
        /* add the belo to command_input
        'consest of the following structure:"{
          "symptoms": [
            {name:"string", "icd10-am":"string"}
          ],
          "diagnosis": {name:"string","icd10-am":"string"},
        "diagnosisExplaaination":"string"
        "drugOfChoice":{
        "name":"string",
        "description":"string",
        "GenericName":"string"
        }
        }"
        without patient info'
        */
        command_input += "consest of the following structure:{" +
        "\"symptoms\": [" +
        "{name:\"string\", \"icd10am\":\"string\"}" +
        "]," +
        "\"diagnosis\": {name:\"string\",\"icd10am\":\"string\"}," +
        "\"diagnosisExplaination\":\"string\"," +
        "\"drugOfChoice\":{" +
        "\"name\":\"string\"," +
        "\"description\":\"string\"," +
        "\"GenericName\":\"string\"" +
        "}" +
        "} without patient info";
        //encode command_input to url format
        command_input = System.Web.HttpUtility.UrlEncode(command_input);

        string request = @"{""input"":"" " + command_input + @" ""}";
        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this._apiKey);
        var response = client.PostAsync("https://api.bardapi.dev/chat", new StringContent(request, Encoding.UTF8, "text/plain")).Result;
        var responseString = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(responseString);
        //extract json in middle of sentence from responseString
        BardOutputResultModel outputResult = JsonConvert.DeserializeObject<BardOutputResultModel>(responseString);
        string json = outputResult.output.Substring(outputResult.output.IndexOf('{'), outputResult.output.LastIndexOf('}') - outputResult.output.IndexOf('{') + 1);
        try
        {
            BardReportModel report = JsonConvert.DeserializeObject<BardReportModel>(json);
            return report;
        }
        catch (Exception ex)
        {
            return null;
        }

    }
}