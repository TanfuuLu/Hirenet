using Hirenet.Contract.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Contract.Domain.Models;
public class Milestone {
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int MilestoneId { get; set; }
	public string? MilestoneTitle { get; set; }
	public string? MilestoneDescription { get; set; }
	public MilestoneStatus MilestoneStatus { get; set; } = MilestoneStatus.Pending;
	public DateTime MilestoneEndTime { get; set; }
	public DateTime DateCreated { get; set; } = DateTime.Now;
	public DateTime? DateCompleted { get; set; }

	public ICollection<MilestoneFile>  MilestoneFiles { get; set; } = new List<MilestoneFile>();
	public int ContractId { get; set; }
	public JobContract? Contract { get; set; }
}
