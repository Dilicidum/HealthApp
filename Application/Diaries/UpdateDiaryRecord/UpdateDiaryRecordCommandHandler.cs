using Domain.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;

namespace Application.Diaries.UpdateDiaryRecord
{
    public class UpdateDiaryRecordCommandHandler(IApplicationContext context) : IRequestHandler<UpdateDiaryRecordCommand>
    {
        public async Task Handle(UpdateDiaryRecordCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.shortDescription))
            {
                throw new InputValidationException($"Short description cannot be empty");
            }

            var diaryRecord = await context.Diaries.Where(x=>x.Id == request.Id).FirstOrDefaultAsync();

            if(diaryRecord == null)
            {
                throw new InputValidationException($"Object with {request.Id} is invalid");
            }

            diaryRecord.ChangeShortDescription(request.shortDescription);
            diaryRecord.ChangeDescription(request.description);
            diaryRecord.ChangeDayRating(request.dayRating);

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
