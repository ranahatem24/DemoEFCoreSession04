using C48_EFCore_Session_04.DbContexts;

namespace DemoEFCoreSession04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext dbContext = new AppDbContext();
            #region Session 04
            #region Loading Related Data
            #region Problem
            //var employee =  await  dbContext.Employees.FirstOrDefaultAsync(X => X.Id == 1);
            //if(employee!=null)
            //{
            //    Console.WriteLine($"Employee Id: {employee.Id}");
            //    Console.WriteLine($"Employee Name: {employee.Name}");
            //    Console.WriteLine($"Employee Salary: {employee.Salary}");
            //    Console.WriteLine($"Employee Department Id: {employee.DepartmentId}");
            //    Console.WriteLine($"Employee Department Id: {employee.Department.Id}");
            //    Console.WriteLine($"Employee Department  Name: {employee.Department.Name}");
            //}
            #endregion
            #region Solutions
            #region Projection
            //var employee = await dbContext.Employees.Select(E => new
            //{
            //    EmployeeId = E.Id,
            //    EmployeeName = E.Name,
            //    DepartmentId = E.DepartmentId,
            //    DepartmentName = E.Department.Name
            //}).FirstOrDefaultAsync(X=>X.DepartmentId==1);
            //if (employee != null)
            //{
            //    Console.WriteLine($"Employee Id: {employee.EmployeeId}");
            //    Console.WriteLine($"Employee Name: {employee.EmployeeName}");

            //    Console.WriteLine($"Employee Department Id: {employee.DepartmentId}");

            //    Console.WriteLine($"Employee Department  Name: {employee.DepartmentName}");
            //}

            #endregion
            #region Egar Loading
            #region Example 01
            //var employee = await dbContext.Employees.Include(X => X.Department).FirstOrDefaultAsync(X => X.Id == 1);
            //if (employee != null)
            //{
            //    Console.WriteLine($"Employee Id: {employee.Id}");
            //    Console.WriteLine($"Employee Name: {employee.Name}");
            //    Console.WriteLine($"Employee Salary: {employee.Salary}");
            //    Console.WriteLine($"Employee Department Id: {employee.DepartmentId}");
            //    Console.WriteLine($"Employee Department Id: {employee.Department.Id}");
            //    Console.WriteLine($"Employee Department  Name: {employee.Department.Name}");
            //} 
            #endregion
            #region Example 02
            //var employee = await dbContext.Employees.Include(X => X.Department).Include(X => X.ManagedDepartment)
            //    .FirstOrDefaultAsync(X => X.Id == 1);
            // if(employee !=null)
            //{
            //    Console.WriteLine($"Employee Name:{employee.Name}");
            //    Console.WriteLine($"Employee Department Name :{employee.Department.Name}");
            //    Console.WriteLine($"Employee Managed Department Name :{employee.ManagedDepartment?.Name??"Not A Manager"}");
            //}
            #endregion
            #endregion
            #region Explicit Loading
            #region Reference()
            //var employee = await dbContext.Employees.FirstOrDefaultAsync(X => X.Id == 1);
            //if (employee != null)
            //{
            //    Console.WriteLine($"Employee Id: {employee.Id}");
            //    Console.WriteLine($"Employee Name: {employee.Name}");
            //    Console.WriteLine($"Employee Salary: {employee.Salary}");
            //    Console.WriteLine($"Employee Department Id:{employee.DepartmentId}");
            //    await dbContext.Entry(employee).Reference(X => X.Department).LoadAsync();
            //    Console.WriteLine($"Employee Department Id :{employee.Department.Id}");
            //    Console.WriteLine($"Employee Department Name :{employee.Department.Name}");

            //}
            #endregion
            #region Collection()
            //var department = await dbContext.Departments.FirstOrDefaultAsync(D => D.Id == 1);
            //if (department !=null)
            //{
            //    Console.WriteLine(department.Name);
            //    await dbContext.Entry(department).Collection(d => d.Employees).LoadAsync();
            //    foreach (var employee in department.Employees)
            //    {
            //        Console.WriteLine(employee.Name);
            //    }
            //}
            #endregion
            #region Filtered Collection With Query
            //var department = await dbContext.Departments.FirstOrDefaultAsync(D => D.Id == 1);
            // if(department!=null)
            //{
            //    Console.WriteLine($"Department Name:{department.Name}");
            //    await dbContext.Entry(department).Collection(D => D.Employees).Query().Where(x => x.Salary < 5000).LoadAsync();
            //    foreach (var employee in department.Employees)
            //    {
            //        Console.WriteLine(employee.Name);
            //    }

            //}
            #endregion

            #endregion
            #region Lazy Loading 
            #region Example 01
            //var employee = await dbContext.Employees.FirstOrDefaultAsync(X => X.Id == 1);
            //if (employee != null)
            //{
            //    Console.WriteLine($"Employee Id: {employee.Id}");
            //    Console.WriteLine($"Employee Name: {employee.Name}");
            //    Console.WriteLine($"Employee Salary: {employee.Salary}");
            //    Console.WriteLine($"Employee Department Id: {employee.DepartmentId}");
            //    Console.WriteLine($"Employee Department Id: {employee.Department.Id}");
            //    Console.WriteLine($"Employee Department  Name: {employee.Department.Name}");
            //} 
            #endregion
            #region Example 02
            //var department = await dbContext.Departments.FirstOrDefaultAsync(d => d.Id == 1);
            //Console.WriteLine(department?.Name);
            //foreach (var employee in department?.Employees?? Enumerable.Empty<Employee>())
            //{
            //    Console.WriteLine(employee.Name);
            //}

            #endregion
            #endregion
            #endregion
            #endregion
            #region  LINQ Joins
            #region Inner Join
            #region Query Syntax
            //            var result = from e in dbContext.Employees
            //                         join d in dbContext.Departments
            //                         on e.DepartmentId equals d.Id
            //                         select new
            //                         {
            //EmployeeName=e.Name,
            //DepartmentName=d.Name
            //                         };

            #endregion
            #region Fluent Syntax
            //var result= dbContext.Employees.Join(dbContext.Departments,e=>e.DepartmentId,d=>d.Id,(e,d)=> new
            //{
            //    EmployeeName=e.Name,
            //    DepartmentName=d.Name
            //});
            #endregion
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion
            #region Group Join
            #region Example 01

            //var result=dbContext.Departments.GroupJoin(dbContext.Employees,d=>d.Id,e=>e.DepartmentId,
            //    (dept,employees)=> new
            //    {
            //        DepartmentName = dept.Name,
            //        Employees = employees
            //    }).Where(x=>x.Employees.Count()>2);
            // var result =from d in dbContext.Departments
            //             join e in dbContext.Employees
            //             on d.Id equals e.DepartmentId
            //             into employees
            //             where employees.Count()>2
            //             select new
            //             {
            //                 DepartmentName=d.Name,
            //                 Employees=employees

            //             };
            //foreach (var group in result)
            //{
            //    Console.WriteLine(group.DepartmentName);

            //    Console.WriteLine("=============");
            //    foreach (var employee in group.Employees)
            //    {
            //        Console.WriteLine(employee.Name);
            //    }
            //}


            #endregion
            #region Example 02
            //            var result = dbContext.Departments.GroupJoin(dbContext.Employees, d => d.Id, e => e.DepartmentId,
            //                (dept, employees) => new
            //                {
            //DepartmentName=dept.Name,
            //EmployeesCount=employees.Count(),
            //EmployeesSalaries=employees.Sum(e=>e.Salary)
            //                });
            //            foreach (var item in result)
            //            {
            //                Console.WriteLine(item);
            //            }
            #endregion
            #endregion
            #region Left Join

            //var result =dbContext.Employees.LeftJoin(dbContext.Departments,e=>e.DepartmentId,d=>d.Id, (e, d) => new
            //{
            //    EmployeeName = e.Name,
            //    DepartmentName = d==null?"No Department" : d.Name
            //});
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);  
            //}
            #region Left Join Pre .Net 10
            //var result = dbContext.Employees.GroupJoin(dbContext.Departments, e => e.DepartmentId, d => d.Id,
            //    (e, departments) => new
            //    {
            //        Employee = e,
            //        Departments = departments

            //    }).SelectMany(x => x.Departments.DefaultIfEmpty(),
            //    (x, d) =>
            //    new
            //    {
            //        EmployeeName = x.Employee.Name,
            //        DepartmentName = d == null ? "No Department" : d.Name
            //    });
            //var result02= from e in dbContext.Employees
            //               join d in dbContext.Departments
            //               on e.DepartmentId equals d.Id
            //               into DepartmentGroups
            //               from d in DepartmentGroups.DefaultIfEmpty()
            //               select new
            //               {
            //                   EmployeeName = e.Name,
            //                   DepartmentName = d == null ? "No Department" : d.Name
            //               };

            #endregion
            #endregion
            #region Local And Find()
            ////1) Load All Employees into the dbContexts's Memory (Change Traker)
            //await dbContext.Employees.LoadAsync();
            ////2) Read From memory only -no database call
            //foreach (var employee in dbContext.Employees.Local)
            //{
            //    Console.WriteLine(employee.Name);
            //}
            ////3: FirstOrDefaultAsync=> Always sends a query  to the database,
            //// even if the employee is already loaded in memory
            ////4:FindAsync=> Check Memory local first by primary key,
            ////Queries the Database only if not found

            #endregion

            #endregion
            #endregion
        }
    }
}
