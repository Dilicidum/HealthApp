using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Diaries.UpdateDiaryRecord
{
    public record UpdateDiaryRecordCommand(int Id,string shortDescription, string description): IRequest;
}
