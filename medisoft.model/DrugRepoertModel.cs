public class DrugItem
{
    public string genericName { get; set; }
    public string description { get; set; }
}
public class DrugOfChoiceModel
{
    public List<DrugItem> drugOfChoice { get; set; }
    public bool success { get; set; }
}