using System.Net.Http.Headers;
using System.Text;
using medisoft.application.models;
using medisoft.model;
using medisoft.service.IServices;
using Newtonsoft.Json;

namespace medisoft.service;

public class PalmService : IBardService
{
    private readonly string _apiKey;
    public PalmService(string apiKey)
    {
        this._apiKey = apiKey;

    }

    public BardReportModel GenerateReport(ReportRequestContract requestInput)
    {
        string conversation = string.Join(" ", requestInput.Transcripts);
        string command_input = "extract differential diagnosis and symptoms from {";
        command_input += "The patient info: " +
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
        if (requestInput.Patient.patientInformation.Length > 0)
        {
            foreach (var item in requestInput.Patient.patientInformation)
            {
                command_input += item.title + ": " + item.description + ". ";
            }
        }
        command_input += " Conversation between patient and doctor: " + conversation + " }";



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
        command_input += " in JSON format consist of the following structure:{" +
  "\"symptoms\": [" +
    "{" +
      "\"name\": \"string\"," +
      "\"icd10-am\": \"string\"" +
    "}" +
  "]," +
  "\"differentialDiagnosis\": [" +
    "{" +
      "\"name\": \"string\"," +
      "\"icd10-am\": \"string\"," +
      "\"diagnosisExplaination\": \"string\"" +
    /*"\"TestsNeeds\": [" +
      "{" +
        "\"name\": \"string\"," +
        "\"justification\": \"string\"" +
      "}" +
    "]" +*/
    "}" +
  "]" +
"}";
        //encode command_input to url format
        // command_input = System.Web.HttpUtility.UrlEncode(command_input);
        //command_input="What is todays date?";
        /*string request = @"{""input"":"" " + command_input + @" ""}";
        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this._apiKey);
        
        

        var response = client.PostAsync("https://api.bardapi.dev/chat", new StringContent(request, Encoding.UTF8, "text/plain")).Result;
        var responseString = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(responseString);
        //extract json in middle of sentence from responseString
        BardOutputResultModel outputResult = JsonConvert.DeserializeObject<BardOutputResultModel>(responseString);
        */
        var client = new HttpClient();
        //post to https://mediscriptbardpy.azurewebsites.net/ask
        PalmRequestModel request = new PalmRequestModel();
        request.prompt = new PalmPrompt();
        request.prompt.text = command_input;
        var response = client.PostAsync("https://generativelanguage.googleapis.com/v1beta2/models/text-bison-001:generateText?key=" + _apiKey, new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")).Result;
        var responseString = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(responseString);
        PalmResponseModel outputResult = JsonConvert.DeserializeObject<PalmResponseModel>(responseString);

        BardReportModel report = new BardReportModel();
        report.success = false;
        try
        {
            string content = outputResult.candidates[0].output;
            string json = content.Substring(content.IndexOf('{'), content.LastIndexOf('}') - content.IndexOf('{') + 1);
            //not case sensitive
            report = JsonConvert.DeserializeObject<BardReportModel>(json, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            });
            report.success = true;
        }
        catch (Exception ex)
        {
            throw new Exception("Error parsing response from palm api :" + responseString + " " + ex.StackTrace);
        }

        return report;

    }

    public DrugOfChoiceModel GenerateDrugReport(DrugRequestContract requestInput)
    {
        string conversation = string.Join(" ", requestInput.Transcripts);
        string command_input = "extract drug of choices from {";
        command_input += "The patient info: " +
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
        if (requestInput.Patient.patientInformation.Length > 0)
        {
            foreach (var item in requestInput.Patient.patientInformation)
            {
                command_input += item.title + ": " + item.description + ". ";
            }
        }
        command_input += " Conversation between patient and doctor: " + conversation + ". ";
        command_input += "The diagnosis is: " + requestInput.diagnosis + ". ";
        command_input += "The symptoms are: " + string.Join(", ", requestInput.symptoms) + ". ";
        command_input += " }";



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
        command_input += " in JSON format consist of the following structure:{" +
  "\"drugOfChoices\": [" +
    "{" +
      "\"genericName\": \"string\"," +
      "\"description\": \"string\"" +
    "}" +
  "]} , I want the answer directly without mentioning the patient info";
        //encode command_input to url format
        var client = new HttpClient();
        //post to https://mediscriptbardpy.azurewebsites.net/ask
        PalmRequestModel request = new PalmRequestModel();
        request.prompt = new PalmPrompt();
        request.prompt.text = command_input;
        var response = client.PostAsync("https://generativelanguage.googleapis.com/v1beta2/models/text-bison-001:generateText?key=" + _apiKey, new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")).Result;
        var responseString = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(responseString);
        PalmResponseModel outputResult = JsonConvert.DeserializeObject<PalmResponseModel>(responseString);

        DrugOfChoiceModel report = new DrugOfChoiceModel();
        report.success = false;
        try
        {
            string content = outputResult.candidates[0].output;
            string json = content.Substring(content.IndexOf('{'), content.LastIndexOf('}') - content.IndexOf('{') + 1);
            //not case sensitive
            report = JsonConvert.DeserializeObject<DrugOfChoiceModel>(json, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            });
            report.success = true;
        }
        catch (Exception ex)
        {
            throw new Exception("Error parsing response from palm api :" + responseString + " " + ex.StackTrace);
        }

        return report;
    }

    public NeededTestModel GenerateNeededTestReport(DrugRequestContract requestInput)
    {
        string conversation = string.Join(" ", requestInput.Transcripts);
        string command_input = "extract from {";
        command_input += "The patient info: " +
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
        if (requestInput.Patient.patientInformation.Length > 0)
        {
            foreach (var item in requestInput.Patient.patientInformation)
            {
                command_input += item.title + ": " + item.description + ". ";
            }
        }
        command_input += " Conversation between patient and doctor: " + conversation + ". ";
        command_input += "The diagnosis is: " + requestInput.diagnosis + ". ";
        command_input += "The symptoms are: " + string.Join(", ", requestInput.symptoms) + ". ";
        command_input += " }";



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
        command_input += " in JSON format consist of the following structure:{" +
  "\"TestsNeeds\": [" +
    "{" +
      "\"name\": \"string\"," +
      "\"justification\": \"string\"" +
    "}" +
  "]}";

  var client = new HttpClient();
        //post to https://mediscriptbardpy.azurewebsites.net/ask
        PalmRequestModel request = new PalmRequestModel();
        request.prompt = new PalmPrompt();
        request.prompt.text = command_input;
        var response = client.PostAsync("https://generativelanguage.googleapis.com/v1beta2/models/text-bison-001:generateText?key=" + _apiKey, new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")).Result;
        var responseString = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(responseString);
        PalmResponseModel outputResult = JsonConvert.DeserializeObject<PalmResponseModel>(responseString);

        NeededTestModel report = new NeededTestModel();
        report.success = false;
        try
        {
            string content = outputResult.candidates[0].output;
            string json = content.Substring(content.IndexOf('{'), content.LastIndexOf('}') - content.IndexOf('{') + 1);
            //not case sensitive
            report = JsonConvert.DeserializeObject<NeededTestModel>(json, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            });
            report.success = true;
        }
        catch (Exception ex)
        {
            throw new Exception("Error parsing response from palm api :" + responseString + " " + ex.StackTrace);
        }

        return report;

    }
}