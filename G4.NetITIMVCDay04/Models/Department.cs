namespace G4.NetITIMVCDay04.Models
{
    public class Department
    {
        /*---------------------------------------------------------*/
        public int Id { get; set; }
        public string? DeptName { get; set; }
        /*---------------------------------------------------------*/
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
        /*---------------------------------------------------------*/
    }
}
