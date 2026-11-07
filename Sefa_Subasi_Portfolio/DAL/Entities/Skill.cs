namespace Sefa_Subasi_Portfolio.DAL.Entities
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public List<SkillItem> SkillItems { get; set; }
    }
}
