import React, { Component } from 'react';

export class Employee extends Component {
    static displayName = Employee.name;
    constructor(props) {
        super(props);
        this.state = { employees: [], loading: true };
      }

      componentDidMount() {
        this.populateEmployeeData();
      }
    
      static renderEmployeeTable(employees) {
        return (
          <table className='table table-striped' aria-labelledby="tabelLabel">
            <thead>
              <tr>
                <th>Employee Name</th>
                <th>Phone No</th>
                <th>Salary</th>
                <th>Email ID</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {employees.map(employee =>
                <tr key={employee.employeeID}>
                  <td>{employee.employeeName}</td>
                  <td>{employee.phoneNo}</td>
                  <td>{employee.salary}</td>
                  <td>{employee.email}</td>
                 
                  <td><button emp-id ={employee.employeeID}>Edit</button></td>
                  
                  </tr>
              )}
            </tbody>
          </table>
        );
      }
      static editEmployeeData(data) {
        return (
            <div>
                <span>Employee Name</span>
                <input type='text' value={data.employeeName}></input>
                <span>Phone No</span>
                <input type='text' value={data.phoneNo}></input>
                <span>Salary</span>
                <input type='text' value={data.salary}></input>
                <span>Email</span>
                <input type='text' value={data.email}></input>
                <span>Acive</span>
                <input type='text' value={data.isActive}></input>
                <input type='hidden' value={data.employeeID}></input>
                <button type='save'>Save</button><button >Cancel</button>


            </div>
          
        );
      }
    
      render() {
        let contents = this.state.loading
          ? <p><em>Loading...</em></p>
          : Employee.renderEmployeeTable(this.state.employees);
    
        return (
          <div>
            <h1 id="tabelLabel" >Employee Table</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
          </div>
        );
      }
    async populateEmployeeData() {
        const response = await fetch('employee');
        const data = await response.json();
        this.setState({ employees: data, loading: false });
    }
    async editEmployeeData() {
        const response = await fetch('employee');
        const data = await response.json();
        this.setState({ employees: data, loading: false });
    }
}
