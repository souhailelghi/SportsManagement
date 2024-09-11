namespace SportsManagementApp.Models
{
    public class Field
    {
        public Guid FieldId { get; set; }
        public string FieldType { get; set; }
        public int Capacity { get; set; }
        public string AvailableHours { get; set; }
    }
}
