using Domain.Entities;
using Domain.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;

namespace Application.Diaries.GetDiaryRecordId
{
    public class GetDiaryRecordQueryHandler(IApplicationContext context) : IRequestHandler<GetDiaryRecordQuery, Diary>
    {
        public async Task<Diary> Handle(GetDiaryRecordQuery request, CancellationToken cancellationToken)
        {
            var diary = await context.Diaries.Where(x=>x.Id == request.Id).FirstOrDefaultAsync();

            if (diary == null)
            {
                throw new InputValidationException($"No object with {request.Id} exists");
            }

            return diary;
        }
    }
}
