namespace medisoft.application.models;

public class ReportRequestContract{
    public PatientModel Patient { get; set; }
    public string[] Transcripts { get; set; }
}

public class PatientModel{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender{get;set;}
    public string[] ChronicDiseases{get;set;}
    public string[] Allergies{get;set;}
}