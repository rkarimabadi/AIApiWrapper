using System.Text.Json.Serialization;

namespace AIApiWrapper.Models
{
    public class AudioRequest
    {
        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("data")]
        public string Data { get; set; }
    }


    public class AudioResponse
    {
        public AudioResponseData Data { get; set; }
        public AudioMetaContent Meta { get; set; }
    }

    public class AudioResponseData
    {
        public string Status { get; set; }
        public AudioInnerData Data { get; set; }
        public string RequestId { get; set; }
    }

    public class AudioInnerData
    {
        public string Result { get; set; }
        public List<object> TimeStamp { get; set; }  // Use `List<object>` or a more specific type based on your actual data
        public double Rtf { get; set; }
    }

    public class AudioMetaContent
    {
        public string ShamsiDate { get; set; }
        public string RequestId { get; set; }
    }
    public class SpeachRequestPayload
    {
        public string Data { get; set; }
        public bool FilePath { get; set; }
        public string Base64 { get; set; }
        public string Checksum { get; set; }
        public string Timestamp { get; set; }
        public string Speaker { get; set; }
        public string Speed { get; set; }
    }
    public class SpeachResponse
    {
        public SpeachResponseData Data { get; set; }
        public SpeachMetaContent Meta { get; set; }
    }

    public class SpeachResponseData
    {
        public string Status { get; set; }
        public SpeachInnerData Data { get; set; }
        public object Error { get; set; }
    }

    public class SpeachInnerData
    {
        public List<SpeachTimestamp> Timestamps { get; set; }
        public string FilePath { get; set; }
        public string Base64 { get; set; }
        public string Checksum { get; set; }
    }

    public class SpeachTimestamp
    {
        public string Text { get; set; }
        public double BeginTime { get; set; }
        public double EndTime { get; set; }
    }

    public class SpeachMetaContent
    {
        public string ShamsiDate { get; set; }
        public string RequestId { get; set; }
    }

    public class TextToSpeechResponse
    {
        public TextToSpeechData Data { get; set; }
        public TextToSpeechMeta Meta { get; set; }
    }

    public class TextToSpeechData
    {
        public ProcessData? Data { get; set; }
        public string? Error { get; set; } // Assuming error can be null
        public string Status { get; set; }
    }

    public class ProcessData
    {
        public string EstimatedProcessTime { get; set; }
        public string Token { get; set; }
    }

    public class TextToSpeechMeta
    {
        public string RequestId { get; set; }
        public string ShamsiDate { get; set; }
    }

    public class TextToSpeechTrackingResponse
    {
        public string Status { get; set; }
        public TextToSpeechTrackingData? Data { get; set; }
        public string? Error { get; set; }
    }
    public class TextToSpeechTrackingData
    {
        public string FilePath { get; set; }
    }
}
