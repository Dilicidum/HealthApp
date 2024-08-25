using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Diaries.RecordDay
{
    public record RecordDayCommand(string Description, string ShortDescription, DateTime? date = null) : IRequest;
}
