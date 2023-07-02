//{"session_id":"XQh41s0Zp_q2-TDiv6ZpX9jpgh7vcG6rup9T6S5FLIgpEbvlfxXIAJUjCXNj2N9Pmo3sGg.","message":"What is the meaning of life?"} as class

using Newtonsoft.Json;

public class BardRequestModel
{
    [JsonProperty("session_id")]
    public string SessionId { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }
}