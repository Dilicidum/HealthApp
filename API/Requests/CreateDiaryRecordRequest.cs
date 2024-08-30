namespace API.Requests
{
    public record CreateDiaryRecordRequest(string Description, string ShortDescription,int dayRating, DateTime? date = null);
}
