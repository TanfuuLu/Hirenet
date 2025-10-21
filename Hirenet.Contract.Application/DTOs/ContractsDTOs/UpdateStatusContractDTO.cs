using Hirenet.Contract.Domain.Enums;
using Hirenet.Contract.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Contract.Application.DTOs.ContractsDTOs;
public class UpdateStatusContractDTO {
	public ContractStatus ContractStatus { get; set; } 
	public int ContractId { get; set; }

}
