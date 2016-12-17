using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeService
    {
        [WebInvoke(Method = "GET", UriTemplate = "Get/{Id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        Employee GetEmployee(string Id);

        [WebInvoke(Method = "GET", UriTemplate = "Delete/{Id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        void DeleteEmployee(string Id);

        [WebInvoke(Method = "GET", UriTemplate = "List", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        List<Employee> GetEmployees();

        [WebInvoke(Method = "GET", UriTemplate = "Add", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        void AddEmployee();

        [WebInvoke(Method = "POST", UriTemplate = "Create", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        [OperationContract]
        void CreateEmployee(Employee employee);

        [WebInvoke(Method = "POST", UriTemplate = "Update", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        [OperationContract]
        void UpdateEmployee(Employee employee);
    }
}
