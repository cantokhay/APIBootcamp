using APIBootcamp.API.Entities.Enum;

namespace APIBootcamp.API.DTOs.EmployeeTaskDTO
{
    public class CreateEmployeeTaskDTO
    {
        public string EmployeeTaskName { get; set; }
        public byte TaskCompletedRate { get; set; }
        public DateTime AssignDate { get; set; }
        public DateTime DueDate { get; set; }
        public EmployeeTaskPriority EmployeeTaskPriority { get; set; }

        public int ChefId { get; set; }
    }
}
