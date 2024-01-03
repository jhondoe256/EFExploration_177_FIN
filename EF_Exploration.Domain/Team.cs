using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EF_Exploration.Domain.CoachModels;

namespace EF_Exploration.Domain
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int HeadCoachId { get; set; }
        public HeadCoach HeadCoach { get; set; }

        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }
        public string HomeRecord { get; set; } = string.Empty;
        public string RoadRecord { get; set; } = string.Empty;
        public double PercentWins { get; set; }

        public int DivisionId { get; set; }

        [ForeignKey(nameof(DivisionId))]
        public Division Division { get; set; }

        public List<Player> Players { get; set; } = new List<Player>();
        public List<AssistantCoach> AssistantCoaches { get; set; } = new List<AssistantCoach>();
    }
}