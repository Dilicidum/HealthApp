using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Factories;
using Domain.Persistance;
using MediatR;
namespace Application.Diaries.RecordDay
{
    public class RecordDayCommandHandler(IDiaryFactory diaryFactory, IApplicationContext context) : IRequestHandler<RecordDayCommand>
    {
        public async Task Handle(RecordDayCommand request, CancellationToken cancellationToken)
        {
            var diary = await diaryFactory.Create(request.Description, request.ShortDescription, request.date);
            await context.Diaries.AddAsync(diary);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
