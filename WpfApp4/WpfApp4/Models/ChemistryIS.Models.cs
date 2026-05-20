using ChemistryIS.Models.ChemistryIS.Models;

namespace ChemistryIS.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<TopicContent> Contents { get; set; } = new List<TopicContent>();
    }

    namespace ChemistryIS.Models
    {
        public class TopicContent
        {
            public int Id { get; set; }
            public string SectionTitle { get; set; }
            public string BodyText { get; set; }
        }
    }
}

namespace ChemistryIS.Models
{
    public class ChemicalElement
    {
        public int Id { get; set; }
        public int AtomicNumber { get; set; }
        public string Symbol { get; set; }
        public string NameRu { get; set; }
        public decimal AtomicMass { get; set; }
        public string Category { get; set; }
        public string ElectronConfig { get; set; }

        public bool IsNotFound { get; set; } = false;
    }
}