using Hirenet.Contract.Domain.Enums;
using Hirenet.Contract.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Contract.Application.DTOs.MilestoneDTOs;
public class CreateMilestoneDTO {
	public string? MilestoneTitle { get; set; }
	public string? MilestoneDescription { get; set; }
	public MilestoneStatus MilestoneStatus { get; set; } = MilestoneStatus.Pending;
	public DateTime MilestoneEndTime { get; set; }
	public DateTime DateCreated { get; set; } = DateTime.Now;
	public DateTime? DateCompleted { get; set; }
	public int ContractId { get; set; }
}
