using Hirenet.Contract.Application.DTOs;
using Hirenet.Contract.Application.Interfaces;
using Hirenet.Contract.Domain.Models;
using Hirenet.Contract.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hirenet.Contract.Infrastructure.Repositories;
public class MilestoneFileRepository : IMilestoneFileRepository {
	private readonly ContractDbContext dbContext;

    public MilestoneFileRepository(ContractDbContext dbContext) {
	  this.dbContext = dbContext;
    }


	public async Task<IEnumerable<MilestoneFile>> GetFilesByMilestoneAsync(int milestoneId) {
		return await dbContext.MilestoneFiles
		    .Where(f => f.MilestoneId == milestoneId)
		    .ToListAsync();
	}

    public async Task<ICollection<MilestoneFile>> GetAllMilestoneFileAsync(int milestoneId) {
	  var milestoneFilesList = await dbContext.MilestoneFiles.Where(mf => mf.MilestoneId == milestoneId).ToListAsync();
		return milestoneFilesList;
	}

    public async Task<MilestoneFile> UploadFileAsync(MilestoneFileUploadDTO dto, string rootPath) {
		var uploadDir = Path.Combine(rootPath, "milestones");
		if (!Directory.Exists(uploadDir))
			Directory.CreateDirectory(uploadDir);

		var uniqueName = $"{Guid.NewGuid()}_{dto.File.FileName}";
		var filePath = Path.Combine(uploadDir, uniqueName);

		using (var stream = new FileStream(filePath, FileMode.Create)) {
			await dto.File.CopyToAsync(stream);
		}
		if(dto.MilestoneId == null)
			throw new ArgumentException("MilestoneId cannot be null");
		var fileEntity = new MilestoneFile {
			FileName = dto.File.FileName,
			FileUrl = $"/milestones/{uniqueName}",
			MilestoneId = (int)dto.MilestoneId
		};

		dbContext.MilestoneFiles.Add(fileEntity);
		var checkMilestone = await dbContext.Milestones.FirstOrDefaultAsync(m => m.MilestoneId == dto.MilestoneId);
		if (checkMilestone != null) {
			checkMilestone.MilestoneFiles.Add(fileEntity);
		}

		await dbContext.SaveChangesAsync();

		return fileEntity;
	}
}
