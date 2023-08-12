using CorewithReactJS.Models;
using CorewithReactJS.WorkerService.Interface;
using Dapper;
using System.Data;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace CorewithReactJS.WorkerService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DapperContext _context;
        public EmployeeService(DapperContext dapperContext)
        {
            _context = dapperContext;
        }
        public bool DeleteEmployee()
        {
            throw new NotImplementedException();
        }

        public List<EmployeeModel> GetEmployees(int employeeid)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("EmployeeID", employeeid, DbType.Single, ParameterDirection.Input);

                using (var connection = _context.CreateConnection())
                {

                    var list = connection.Query<EmployeeModel>(StordProcedure.usp_GetEmployee, null, commandType: CommandType.StoredProcedure).ToList();
                    return list;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool InsertUpdateEmployees(EmployeeModel employeeModel)
        {
            var parameters = new DynamicParameters();
            parameters.Add("EmployeeID", employeeModel.Email, DbType.Single, ParameterDirection.Input);
            parameters.Add("EmployeeID", employeeModel.IsActive, DbType.Single, ParameterDirection.Input);
            parameters.Add("EmployeeID", employeeModel.Salary, DbType.Single, ParameterDirection.Input);
            parameters.Add("EmployeeID", employeeModel.EmployeeName, DbType.Single, ParameterDirection.Input);
            parameters.Add("EmployeeID", employeeModel.PhoneNo, DbType.Single, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {

                var result = connection.Execute(StordProcedure.usp_InsertUpdateEmployee, null, commandType: CommandType.StoredProcedure);
                return result > 0 ? true : false;
            }
        }
    }
}
