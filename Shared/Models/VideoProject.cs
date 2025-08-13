namespace MiVideoEditor.Shared.Models
{
    public class VideoProject
    {
        public string ProjectId { get; set; }
        public List<string> FileUrls { get; set; } = new List<string>();
        // Otros datos como efectos, transiciones, etc.
        // public List<Effect> Effects { get; set; }
    }
}
