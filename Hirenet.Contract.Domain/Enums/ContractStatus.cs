using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Contract.Domain.Enums;
public enum ContractStatus {
	Pending, //1
	Working,//2
	Completed,//3
	Cancelled,//4
	WaitingForPayment,//5

}