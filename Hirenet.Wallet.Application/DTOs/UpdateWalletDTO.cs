using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Wallet.Application.DTOs;
public class UpdateWalletDTO {
	public string UserId { get; set; }
	public decimal AvailableBalance {  get; set; }
	public decimal EscrowBalance { get; set; }
}
