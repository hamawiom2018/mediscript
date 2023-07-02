using Newtonsoft.Json;

namespace medisoft.model;

/*
{
  "symptoms": [
    {name:"string", "icd10am":"string"}
  ],
  "diagnosis": {name:"string","icd10am":"string"},
"diagnosisExplaination":"string"
"drugOfChoice":{
"name":"string",
"description":"string",
"GenericName":"string"
}
}
*/




public class Diagnosis
{
    public string Name { get; set; }
    [JsonProperty("icd10-am")]
    public string Icd10Am { get; set; }
    public string DiagnosisExplaination { get; set; }
    public List<Test> TestsNeeds { get; set; }

    public class Test
    {
        public string Name { get; set; }
        public string Justification { get; set; }
    }
}

public class BardReportModel
{
    public List<Symptom> Symptoms { get; set; }
    public List<Diagnosis> DifferentialDiagnosis { get; set; }

    public class Symptom
    {
        public string Name { get; set; }
        [JsonProperty("icd10-am")]
        public string Icd10Am { get; set; }
    }
    public bool success { get; set; }
}
