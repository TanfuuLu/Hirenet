using Hirenet.Contract.Domain.Enums;
using Hirenet.Contract.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Contract.Application.DTOs.ContractsDTOs;
public class CreateContractDTO {
	public string OwnerId { get; set; }
	public string ClientId { get; set; }
	public string ContractName { get; set; }
	public string ContractType { get; set; }
	public string ContractDescription { get; set; }
	public ContractStatus ContractStatus { get; set; } = ContractStatus.Pending; //Working, Completed, Paid, Waiting for Payment
	public string PaymentType { get; set; } // Contract Price, Base on Milestones

	public DateTime StartDate { get; set; }
}
