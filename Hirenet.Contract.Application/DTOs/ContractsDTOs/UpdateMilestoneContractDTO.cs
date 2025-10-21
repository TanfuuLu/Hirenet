using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Contract.Application.DTOs.ContractsDTOs;
public class UpdateMilestoneContractDTO {
	public ICollection<int> MilestonesId { get; set; } = new List<int>();
	public int ContractId { get; set; }

}
