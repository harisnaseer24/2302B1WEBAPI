namespace _2302B1CodeFirstAPI.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Skill  { get; set; }
        public int age { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

       
    }
}
