using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirenet.Contract.Domain.Models;
public class MilestoneFile {
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]	
	public int FileId { get; set; }
	public string? FileName { get; set; }
	public string? FileUrl { get; set; }
	public DateTime DateUploaded { get; set; } = DateTime.Now;
	public int MilestoneId { get; set; }
	public Milestone? Milestone { get; set; }
}
