using System;
using System.Runtime.Serialization;

namespace EmployeeService
{
    [DataContract(Name = "Employee", Namespace ="")]
    public class Employee
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }
        [DataMember(Name = "Name")]
        public string Name { get; set; }
        [DataMember(Name = "Gender")]
        public string Gender { get; set; }
        [DataMember(Name = "DateOfBirth")]
        public DateTime DateOfBirth { get; set; }
    }
}