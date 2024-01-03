using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Exploration.Domain
{
    public class Division
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int ConferenceId { get; set; }
        
        [ForeignKey(nameof(ConferenceId))]
        public Conference Conference { get; set; }

        public List<Team> Teams { get; set; } = new List<Team>();
    }
}