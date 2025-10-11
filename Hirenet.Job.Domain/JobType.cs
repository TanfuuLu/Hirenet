using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Job.Domain;
public class JobType {
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int JobTypeId { get; set; }
	public string JobTypeName { get; set; }

}
