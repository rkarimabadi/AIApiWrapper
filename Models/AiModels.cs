using System.Text.Json.Serialization;

namespace AIApiWrapper.Models
{
    public class AiQuestionPayload
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("question")]
        public string Question { get; set; }
    }
    public class AiApiResponse
    {
        public AiResponseData Data { get; set; }
        public string Status { get; set; }
        public string RequestId { get; set; }
    }

    public class AiResponseData
    {
        public List<AiAnswerData> Data { get; set; }
        public bool HasAnswer { get; set; }
        public List<object> SimilarKbs { get; set; } // Assuming similarKbs is an array of objects; you might need a specific class if it's more detailed.
    }

    public class AiAnswerData
    {
        public string Side { get; set; }
        public string Type { get; set; }
        public string Answer { get; set; }
        public string SessionId { get; set; }
        public string ReplyId { get; set; }
        public string Provider { get; set; }
        public AiConfig Config { get; set; }
        public bool HasAnswer { get; set; }
        public string Question { get; set; }
        public string Score { get; set; } // Changed to string to match the nullable JSON value.
        public string Audio { get; set; }
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; } // Nullable DateTime
    }

    public class AiConfig
    {
        public string Type { get; set; }
        public string Score { get; set; } // Changed to string to match the nullable JSON value.
    }
}
