using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Job.Domain;
public class Job {
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int JobID { get; set; }
	public string JobName { get; set; }
	public string JobDetail { get; set; }
	public string JobRequirement { get; set; }
	public string CompanyName { get; set; }
	public string WorkType { get; set; }
	public string SalaryRange { get; set; }	
	public DateTime CreatedDate { get; set; }
	public DateTime ExpiredDate { get; set; }
}
