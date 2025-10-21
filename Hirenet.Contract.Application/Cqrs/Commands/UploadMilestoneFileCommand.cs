using Hirenet.Contract.Application.DTOs;
using Hirenet.Contract.Domain.Models;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Contract.Application.Cqrs.Commands;
public record  UploadMilestoneFileCommand(MilestoneFileUploadDTO modelDto) : IRequest<MilestoneFile>  {
}
