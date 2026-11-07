namespace Sefa_Subasi_Portfolio.DAL.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectCategory {  get; set; }
        public string Head { get; set; }
        public string Detail {  get; set; }
        public string WebSite { get; set; }
        public List<ProjectTechnology> ProjectTechnologies{  get; set; } 
    }
}
