using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Exploration.Domain.CoachModels
{
    public abstract class Coach
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int? TeamId { get; set; }

        [ForeignKey(nameof(TeamId))]
        public Team? Team { get; set; }
    }
}