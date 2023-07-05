using static medisoft.model.Diagnosis;

namespace medisoft.model
{
    public class NeededTestModel
    {
        public List<NeededTest> TestsNeeds { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
    }
}