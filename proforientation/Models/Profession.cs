namespace proforientation.Models
{
    public class Profession
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ScoreMin { get; set; }
        public int ScoreMax { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
    }
}
