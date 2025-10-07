using APIBootcamp.API.Entities.Abstract;
using APIBootcamp.API.Entities.Enum;
using APIBootcamp.API.Entities.Relation;
using System.ComponentModel.DataAnnotations;

namespace APIBootcamp.API.Entities.Concrete
{
    public class EmployeeTask : IGenericEntity<EmployeeTask>
    {
        [Key]
        public int Id { get; set; }
        public string EmployeeTaskName { get; set; }
        public byte TaskCompletedRate { get; set; }
        public DateTime AssignDate { get; set; }
        public DateTime DueDate { get; set; }
        public EmployeeTaskPriority EmployeeTaskPriority { get; set; }
        public EmployeeTaskStatus EmployeeTaskStatus { get; set; }
        public DataStatus DataStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        // Navigation Property
        public List<EmployeeTaskChef> EmployeeTaskChefs { get; set; }
    }
}
