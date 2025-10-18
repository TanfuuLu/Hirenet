using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Wallet.Application.DTOs;
public class CreateWalletDTO {
	public string UserId { get; set; }
	public decimal AvailableBalance { get; set; } = 0;
	public decimal EscrowBalance { get; set; } = 0;
	public DateTime CreateAt { get; set; } = DateTime.Now;
	public DateTime UpdateAt { get; set; } = DateTime.Now;
}
