namespace API.Requests
{
    public record CreateDiaryRecordRequest(string Description, string ShortDescription, DateTime? date = null);
}
