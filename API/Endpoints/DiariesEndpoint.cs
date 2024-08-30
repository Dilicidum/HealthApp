using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using API.Requests;
using System.Reflection;
using Application.Diaries.RecordDay;
using Application.Diaries.GetAllDiaryRecords;
using Application.Diaries.UpdateDiaryRecord;
using Application.Diaries.GetDiaryRecordId;
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
                if(string.IsNullOrWhiteSpace(request.ShortDescription) || request.date == null)
                {
                    return Results.BadRequest("Invalid request body");
                }

                await sender.Send(new RecordDayCommand(request.Description, request.ShortDescription,request.dayRating, request.date));
                
                return Results.Created();
            })
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);

            app.MapGet("/", async (ISender sender) => Results.Ok((object?)await sender.Send(new GetAllDiaryRecordsQuery())))
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status500InternalServerError);

            app.MapGet("/{id}", async (int Id,ISender sender) =>
            {
                var diary = await sender.Send(new GetDiaryRecordQuery(Id));

                if(diary == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(diary);
            })
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);


            app.MapPut("/{id}", async(int Id, [FromBody] UpdateDiaryRecordRequest request,ISender sender) =>
            {
                if(request == null)
                {
                    return Results.BadRequest();
                }

                await sender.Send(new UpdateDiaryRecordCommand(Id, request.ShortDescription, request.dayRating ,request.Description));

                return Results.NoContent();
            })
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);

        }

        

    }
}
