using Hirenet.Contract.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Contract.Application.DTOs.MilestoneDTOs;
public class UpdateMilestoneDTO {
	public int MilestoneId { get; set; }
	public DateTime MilestoneEndTime { get; set; }
}
public class  UpdateStatusMilestoneDTO {
	public int MilestoneId { get; set; }
	public MilestoneStatus MilestoneStatus { get; set; }
	
}
