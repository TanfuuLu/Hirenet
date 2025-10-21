using Hirenet.Contract.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Contract.Domain.Models;
public class JobContract {
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int ContractId { get; set; }
	public string OwnerId { get; set; }
	public string ClientId { get; set; }


	public string ContractName { get; set; }
	public string ContractType { get; set; }
	public string ContractDescription { get; set; }
	public ContractStatus ContractStatus { get; set; } = ContractStatus.Pending; //Working, Completed, Paid, Waiting for Payment
	public string PaymentType { get; set; } // Contract Price, Base on Milestones

	public DateTime StartDate { get; set; }
	public ICollection<Milestone> Milestones { get; set; } = new List<Milestone>();


}
