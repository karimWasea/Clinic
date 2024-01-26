namespace Clinicss.Models
{
    public class BaseVM
    {
        public int? PagNumber { get; set; }

        public Guid Id { get; set; }= default;
        public string ActionName { get; set; } = string.Empty; 
    }

}
