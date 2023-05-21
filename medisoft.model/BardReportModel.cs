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

public class BardReportModel
{
    public Diagnosis diagnosis { get; set; }
    public string diagnosisExplaination { get; set; }
    public DrugOfChoice drugOfChoice { get; set; }
    public Symptoms[] symptoms { get; set; }
    public bool success { get; set; }
}
public class Symptoms{
    public string name { get; set; }
    public string icd10am { get; set; }
}
public class Diagnosis{
    public string name { get; set; }
    public string icd10am { get; set; }
}
public class DrugOfChoice{
    public string name { get; set; }
    public string description { get; set; }
    public string GenericName { get; set; }
}