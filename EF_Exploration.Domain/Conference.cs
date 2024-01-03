using System.ComponentModel.DataAnnotations;

namespace EF_Exploration.Domain
{
    public class Conference
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<Division> Divisions {get;set;} = new List<Division>();
    }

    //List<T>
    //HashSet<T>
    //..so many other collections...
}