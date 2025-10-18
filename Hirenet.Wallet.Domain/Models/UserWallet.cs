using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Wallet.Domain.Models;
public class UserWallet {
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int WalletId { get ; set; }	
	public string UserId { get; set; }
	public decimal AvailableBalance { get; set; } = 0;
	public decimal EscrowBalance { get; set; } = 0;
	public DateTime CreateAt { get; set; } = DateTime.Now;
	public DateTime UpdateAt { get; set; }

}
