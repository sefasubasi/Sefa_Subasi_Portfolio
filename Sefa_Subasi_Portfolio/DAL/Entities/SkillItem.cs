namespace Sefa_Subasi_Portfolio.DAL.Entities
{
    public class SkillItem
    {
        public int SkillItemId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
