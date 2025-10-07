using APIBootcamp.API.Entities.Enum;

namespace APIBootcamp.API.DTOs.EmployeeTaskDTO
{
    public class ResultEmployeeTaskDTO
    {
        public int Id { get; set; }
        public string EmployeeTaskName { get; set; }
        public byte TaskCompletedRate { get; set; }
        public DateTime AssignDate { get; set; }
        public DateTime DueDate { get; set; }
        public EmployeeTaskPriority EmployeeTaskPriority { get; set; }
        public EmployeeTaskStatus EmployeeTaskStatus { get; set; }

        public int ChefId { get; set; }
    }
}
