using Domain.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Diaries.GetAllDiaryRecords
{
    public class GetAllDiaryRecordsQueryHandler(IApplicationContext context) : IRequestHandler<GetAllDiaryRecordsQuery, IEnumerable<Domain.Entities.Diary>>
    {
        public async Task<IEnumerable<Domain.Entities.Diary>> Handle(GetAllDiaryRecordsQuery request, CancellationToken cancellationToken)
        {
            var diaries = await context.Diaries.ToListAsync(cancellationToken);
            return diaries;
        }
    }
}
