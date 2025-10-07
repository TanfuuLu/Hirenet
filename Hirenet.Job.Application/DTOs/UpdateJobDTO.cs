using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Job.Application.DTOs;
public class UpdateJobDTO {
	public string JobName { get; set; }
	public string JobDetail { get; set; }
	public string JobRequirement { get; set; }
	public string JobType { get; set; }
	public string SalaryRange { get; set; }
	public DateTime ExpiredDate { get; set; }
}
