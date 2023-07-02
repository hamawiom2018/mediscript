namespace medisoft.application.models;

public class ReportRequestContract
{
    public PatientModel Patient { get; set; }
    public string[] Transcripts { get; set; }
}

public class DrugRequestContract
{
    public PatientModel Patient { get; set; }
    public string[] Transcripts { get; set; }
    public string diagnosis { get; set; }
    public string[] symptoms { get; set; }
}

public class PatientModel
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string[] ChronicDiseases { get; set; }
    public string[] Allergies { get; set; }
    public PatientInformation[] patientInformation { get; set; }
}

public class PatientInformation
{
    public string title { get; set; }
    public string description { get; set; }
}



