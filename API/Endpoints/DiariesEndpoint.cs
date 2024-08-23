using Application.Diary.RecordDay;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using API.Requests;
namespace API.Endpoints
{
    public class DiariesEndpoint : CarterModule
    {
        public DiariesEndpoint() : base("api/diaries") {
            IncludeInOpenApi();
        }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/", async ([FromBody] CreateDiaryRecordRequest request,ISender sender) =>
            {
                if(request.ShortDescription is null || request.date == null)
                {
                    return Results.BadRequest("Invalid request body");
                }

                await sender.Send(new RecordDayCommand(request.Description, request.ShortDescription, request.date));
                
                return Results.Created();
            })
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);
        }

    }
}
