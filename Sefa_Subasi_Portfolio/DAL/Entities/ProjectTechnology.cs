namespace Sefa_Subasi_Portfolio.DAL.Entities
{
    public class ProjectTechnology
    {
        public int ProjectTechnologyId { get; set; }
        public string ProjectTechnologyName { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }

    }
}
