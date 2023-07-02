/*{
    "content": "",
    "conversation_id": "c_f7e0ac3591f8176f",
    "response_id": "r_f7e0ac3591f81a16",
    "factualityQueries": null,
    "textQuery": [
        "meaning of life",
        1
    ],
    "choices": [
        {
            "id": "rc_f7e0ac3591f81759",
            "content": [
                "The meaning of life is a question that has been asked by philosophers and theologians for centuries. There is no one answer that will satisfy everyone, but some possible answers include:\n\n* To find happiness and fulfillment.\n* To make a difference in the world.\n* To learn and grow as a person.\n* To connect with others and build relationships.\n* To experience the beauty of the world.\n* To leave a legacy behind.\n\nUltimately, the meaning of life is up to each individual to decide. There is no right or wrong answer, and what matters most is that you find something that gives your life meaning.\n\nHere are some additional thoughts on the meaning of life:\n\n* The meaning of life is not something that is given to us, but something that we create.\n* The meaning of life is not static, but can change over time.\n* The meaning of life is not always easy to find, but it is worth the search.\n\nIf you are struggling to find meaning in your life, there are a few things you can do:\n\n* Reflect on your values and what is important to you.\n* Think about what you are passionate about and what you enjoy doing.\n* Consider how you can make a difference in the world.\n* Connect with others who share your values and interests.\n* Seek out new experiences and challenges.\n\nThe meaning of life is a journey, not a destination. It is something that we discover along the way. So don't be afraid to explore and experiment. The more you live, the more you will learn about what gives your life meaning."
            ]
        },
        {
            "id": "rc_f7e0ac3591f81a00",
            "content": [
                "The meaning of life is a question that has been asked by philosophers and theologians for centuries. There is no one answer that will satisfy everyone, but some possible answers include:\n\n* To find happiness and fulfillment.\n* To make a difference in the world.\n* To learn and grow as a person.\n* To connect with others and build relationships.\n* To experience the beauty of the world.\n* To leave a legacy behind.\n\nUltimately, the meaning of life is up to each individual to decide. There is no right or wrong answer, and what matters most is that you find something that gives your life meaning.\n\nHere are some additional thoughts on the meaning of life:\n\n* The meaning of life is not something that is given to us, but something that we create for ourselves.\n* The meaning of life can change over time, as we grow and learn new things.\n* The meaning of life is not always easy to find, but it is worth the search.\n\nIf you are struggling to find meaning in your life, there are a few things you can do:\n\n* Think about what is important to you and what gives you joy.\n* Spend time with people who make you feel good about yourself.\n* Do things that challenge you and help you grow as a person.\n* Help others in need.\n* Be open to new experiences.\n\nThe meaning of life is a journey, not a destination. It is something that we discover along the way. So don't be afraid to explore, to try new things, and to make mistakes. The most important thing is to keep searching for what gives your life meaning."
            ]
        },
        {
            "id": "rc_f7e0ac3591f81ca7",
            "content": [
                "The meaning of life is a question that has been pondered by philosophers and theologians for centuries. There is no one answer that will satisfy everyone, but some possible answers include:\n\n* To find happiness and fulfillment.\n* To make a difference in the world.\n* To learn and grow as a person.\n* To connect with others and build relationships.\n* To experience the beauty of the world.\n* To leave a legacy behind.\n\nUltimately, the meaning of life is up to each individual to decide. What matters most is that you find something that gives your life meaning and purpose.\n\nHere are some additional thoughts on the meaning of life:\n\n* The meaning of life is not something that is given to us, but something that we create.\n* The meaning of life is not static, but can change over time as we grow and learn.\n* The meaning of life is not always easy to find, but it is worth the search.\n\nIf you are struggling to find meaning in your life, there are a few things you can do:\n\n* Reflect on your values and what is important to you.\n* Think about what you are passionate about and what you want to achieve in life.\n* Connect with others who share your values and interests.\n* Get involved in activities that make you feel good and make a difference in the world.\n\nThe meaning of life is a journey, not a destination. It is something that we discover along the way. So don't be afraid to explore, experiment, and find what gives your life meaning."
            ]
        }
    ]
} as class*/

using Newtonsoft.Json;

public class BardResponseModel
{
    [JsonProperty("content")]
    public string Content { get; set; }

    [JsonProperty("conversation_id")]
    public string ConversationId { get; set; }

    [JsonProperty("response_id")]
    public string ResponseId { get; set; }

    [JsonProperty("factualityQueries")]
    public object FactualityQueries { get; set; }

    [JsonProperty("textQuery")]
    public List<object> TextQuery { get; set; }

    [JsonProperty("choices")]
    public List<Choice> Choices { get; set; }
}

public class Choice
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("content")]
    public List<string> Content { get; set; }
}