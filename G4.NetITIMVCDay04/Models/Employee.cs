using System.ComponentModel.DataAnnotations.Schema;

namespace G4.NetITIMVCDay04.Models
{
    public class Employee
    {
        /*---------------------------------------------------------*/
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        [Column(TypeName = "decimal(8,2)")] // Total 8, After 2 => 123456,78 
        public decimal Salary { get; set; }
        /*---------------------------------------------------------*/
        // One To Many
        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
        /*---------------------------------------------------------*/
    }
}
