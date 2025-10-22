using Hirenet.Contract.Application.DTOs;
using Hirenet.Contract.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Contract.Application.Interfaces;
public interface  IMilestoneFileRepository {
	Task<MilestoneFile> UploadFileAsync(MilestoneFileUploadDTO dto, string rootPath);
	Task<IEnumerable<MilestoneFile>> GetFilesByMilestoneAsync(int milestoneId);
	Task<ICollection<MilestoneFile>> GetAllMilestoneFileAsync(int milestoneId);
}
