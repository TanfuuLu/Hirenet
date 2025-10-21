using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Contract.Application.DTOs;
public class MilestoneFileUploadDTO {
	public IFormFile File { get; set; }
	[DataType(DataType.Text)]
	public int? MilestoneId { get; set; }
	[DataType(DataType.Text)]
	public string? rootPath { get; set; }

}
