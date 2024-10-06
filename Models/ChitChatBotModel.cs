namespace AIApiWrapper.Models
{

    public class ChitChatBotPayload
    {
        public string? Text { get; set; }
        public int? State { get; set; }
    }
    public class ChitChatBotResponseData
    {
        public string? Status { get; set; }
        public ChitChatBotInnerData? Data { get; set; }
        public string? Error { get; set; }
    }
    public class ChitChatBotInnerData
    {
        public string? output_text { get; set; }
    }
    public class ChitChatBotMetaData
    {
        public string? RequestId { get; set; }
        public string? ShamsiDate { get; set; }
        public string? Code { get; set; }
        public string? SourceType { get; set; }
        public string? SourceName { get; set; }
        public string? Version { get; set; }
        public string? Status { get; set; }
    }

    public class ChitChatBotResponseObject
    {
        public ChitChatBotResponseData Data { get; set; }
        public ChitChatBotMetaData Meta { get; set; }
    }

}
