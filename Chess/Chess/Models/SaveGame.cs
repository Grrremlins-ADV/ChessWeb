using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Chess.DataContexts;

namespace Chess.Models
{
	public class SaveGame
	{
		[Key]
		public int Id { get; set; }

		[StringLength(64)]
		[Required]
		[Index("FullIndex", 2)]
		public string User1 { get; set; }

		[StringLength(64)]
		[Required]
		[Index("FullIndex", 3)]
		public string User2 { get; set; }

		public bool End { get; set; }

		[StringLength(64)]
		public string WinnerName { get; set; }

		public int[] Field { get; set; }
	}
}