namespace medisoft.model;
/*
{
    "candidates": [
        {
            "output": "{\"drugOfChoice\": [{\"genericName\": \"Prednisone\", \"description\": \"Anti-inflammatory steroid used to treat inflammation and swelling.\"}]}",
            "safetyRatings": [
                {
                    "category": "HARM_CATEGORY_DEROGATORY",
                    "probability": "NEGLIGIBLE"
                },
                {
                    "category": "HARM_CATEGORY_TOXICITY",
                    "probability": "NEGLIGIBLE"
                },
                {
                    "category": "HARM_CATEGORY_VIOLENCE",
                    "probability": "LOW"
                },
                {
                    "category": "HARM_CATEGORY_SEXUAL",
                    "probability": "NEGLIGIBLE"
                },
                {
                    "category": "HARM_CATEGORY_MEDICAL",
                    "probability": "LOW"
                },
                {
                    "category": "HARM_CATEGORY_DANGEROUS",
                    "probability": "NEGLIGIBLE"
                }
            ]
        }
    ]
}
*/
public class PalmResponseModel
{
    public List<PalmCandidate> candidates { get; set; }
}
public class PalmCandidate
{
    public string output { get; set; }
    public List<PalmSafetyRating> safetyRatings { get; set; }
}
public class PalmSafetyRating
{
    public string category { get; set; }
    public string probability { get; set; }
}


