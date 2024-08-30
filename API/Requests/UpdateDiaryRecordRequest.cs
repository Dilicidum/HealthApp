namespace API.Requests
{
    public record UpdateDiaryRecordRequest(string Description, string ShortDescription, int dayRating);
}
