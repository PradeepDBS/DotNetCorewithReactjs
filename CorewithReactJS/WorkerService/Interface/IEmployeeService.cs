using CorewithReactJS.Models;

namespace CorewithReactJS.WorkerService.Interface
{
    public interface IEmployeeService
    {
        List<EmployeeModel> GetEmployees(int employeeid);
        bool InsertUpdateEmployees(EmployeeModel employeeModel);
        bool DeleteEmployee();
    }
}
