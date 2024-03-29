using HRSystems.DataModel;
using HRSystems.Entity;
using HRSystems.ViewModel;
using Microsoft.EntityFrameworkCore;
using SSquare_HRSystem.DataRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace HRSystems
{
    public class HRSystemsData : IHRSystemsData
    {
        public HRSystemsData() 
        { }

        public List<EmployeeInfo> GetAllEmployeesInfo()
        {
            List<EmployeeInfo> listEmployeeInfo = [];
            try
            {
                listEmployeeInfo = GetAllEmployeesInfoFromDB();
            }
            catch (Exception)
            {
                throw;
            }

            return listEmployeeInfo;
        }


        private List<EmployeeInfo> GetEmployeesInfo(int employeeId)
        {
            List<EmployeeInfo> listEmployeeInfo = [];
            List<Employee> listEmployees = [];
            List<EmployeeRoles> listEmployeeRoles = [];
            //List<Roles> listRoles = [];

            try
            {

                if (employeeId == 0)
                {
                    // Get all the emplyees info
                    listEmployees = GetAllEmployeesData();
                    listEmployeeRoles = GetAllEmployeesRoles();
                    //listRoles = GetAllRoles();

                    listEmployeeInfo = Employees_Roles_Mapping(listEmployees, listEmployeeRoles);
                    //bool bEmployeesRolesMap = Employees_Roles_Mapping(listEmployees, listEmployeeRoles, listRoles);
                }
                else
                {
                    // Get the emplyees info based on the employeeId
                    listEmployees = GetEmployeeInfo(employeeId);
                    listEmployeeRoles = GetEmployeeRoles(employeeId);

                    listEmployeeInfo = Employees_Roles_Mapping(listEmployees, listEmployeeRoles);
                }
            }
            catch(Exception)
            {
                throw;
            }

            return listEmployeeInfo;
        }

        public List<EmployeeInfo> GetManagerEmployeesAssociationInfo(int employeeId)
        {
            List<EmployeeInfo> listEmployeeInfo = [];
            List<ManagerEmployees> managerEmployeesAssociationInfo = new List<ManagerEmployees>();
            List<Employee> listEmployees = [];
            try
            {
                if (employeeId == 0)
                {
                    throw new ArgumentException("GetManagerEmployeesAssociationInfo: EmployeeId was not passed - " + employeeId);
                }

                listEmployeeInfo = GetManagerEmployeesAssociationInfoFromDB(employeeId);

                /*
                listEmployees = GetAllEmployeesData();
                managerEmployeesAssociationInfo = GetAllManagerEmployeesAssociation();
                List<ManagerEmployees> managerEmployeesList = managerEmployeesAssociationInfo.Where(emp => emp.ManagerId == employeeId).ToList();

                ManagerEmployees managerEmployees = new ManagerEmployees();
                if (managerEmployeesList.Count > 0)
                {
                    managerEmployees = managerEmployeesList[0];
                }
                
                foreach (var emp in listEmployees)
                {
                    foreach (var empId in managerEmployees.EmployeeIds)
                    {
                        if (empId == emp.EmployeeId)
                        {
                            listEmployeeInfo.Add(new EmployeeInfo 
                            { 
                                EmployeeId = emp.EmployeeId,
                                FirstName = emp.FirstName,
                                LastName = emp.LastName
                            });
                        }
                    }
                }
                */
            }
            catch (Exception) { throw;  }

            return listEmployeeInfo;
        }

        public List<EmployeeInfo> AddEmployeeInfo(EmployeeInfo employeeInfo)
        {
            List<EmployeeInfo> listEmployeeInfo = [];
            try
            {
                if (employeeInfo == null)
                {
                    throw new ArgumentNullException(nameof(employeeInfo));
                }

                int employeeId = AddEmployeeInfoInDB(employeeInfo);
                listEmployeeInfo = GetAllEmployeesInfoFromDB();
            }
            catch (Exception)
            {
                throw;
            }

            return listEmployeeInfo;
        }

        private static List<EmployeeInfo> Employees_Roles_Mapping(List<Employee> listEmployees, List<EmployeeRoles> listEmployeeRoles)
        {
            List<EmployeeInfo> listEmployeeInfo = [];
            try
            {
                List<Roles> listRoles = [];

                listEmployees.ForEach(employee =>
                {
                    EmployeeInfo employeeInfo = new EmployeeInfo();
                    employeeInfo.EmployeeId = employee.EmployeeId;
                    employeeInfo.FirstName = employee.FirstName;
                    employeeInfo.LastName = employee.LastName;
                    employeeInfo.IsManager = employee.IsManager;

                    var employeeRoles = listEmployeeRoles.Where<EmployeeRoles>(role => role.EmployeeId == employeeInfo.EmployeeId).ToList();
                    //employeeInfo.ListRoles = listRoles.Where<Roles>(role => role.EmployeeId == employeeInfo.EmployeeId).ToList();

                    var emplRoleNames =
                        from role in listRoles
                        join empRoles in listEmployeeRoles on role.RoleId equals empRoles.RoleId
                        select new
                        {
                            role.RoleId,
                            role.RoleName
                        };

                    foreach (var empRole in emplRoleNames)
                    {
                        employeeInfo.ListRoles.Add(new Roles()
                        {
                            RoleId = empRole.RoleId,
                            RoleName = empRole.RoleName

                        });
                    }

                    listEmployeeInfo.Add(employeeInfo);
                });
            }
            catch(Exception)
            {
                throw;
            }

            return listEmployeeInfo;
        }

        private List<EmployeeRoles> GetEmployeeRoles(int employeeId)
        {
            List<EmployeeRoles> employeeRoles = [];
            try
            {
                if (employeeId == 0)
                {
                    throw new ArgumentException("EmployeeId was not passed - " + employeeId);
                }

                List<EmployeeRoles> listEmployeeRoles = GetAllEmployeesRoles();
                employeeRoles = listEmployeeRoles.Where<EmployeeRoles>(role => role.EmployeeId == employeeId).ToList();
            }
            catch(Exception)
            {
                throw;
            }

            return employeeRoles;

        }

        private List<Employee> GetEmployeeInfo(int employeeId)
        {
            List<Employee> employeeInfo = [];
            try
            {
                if (employeeId == 0)
                {
                    throw new ArgumentException("EmployeeId was not passed - " + employeeId);
                }
                List<Employee> listEmployees = GetAllEmployeesData();
                employeeInfo = listEmployees.Where<Employee>(emp => emp.EmployeeId == employeeId).ToList();
            }
            catch(Exception)
            {
                throw;
            }

            return employeeInfo;
        }

        private List<ManagerEmployees> GetAllManagerEmployeesAssociation()
        {
            List<ManagerEmployees> managerEmployeesAssociation = new List<ManagerEmployees>();
            List<int> employeeIds = new List<int>();

            employeeIds = [1001, 1002, 1003, 1004, 1005, 1006, 1007, 1008, 1009];
            managerEmployeesAssociation.Add(new ManagerEmployees()
            {
                ManagerId = 1000,
                EmployeeIds = employeeIds
            });

            employeeIds = [1003, 1005, 1007];
            managerEmployeesAssociation.Add(new ManagerEmployees()
            {
                ManagerId = 1001,
                EmployeeIds = employeeIds
            });

            employeeIds = [1004, 1006, 1008, 1009];
            managerEmployeesAssociation.Add(new ManagerEmployees()
            {
                ManagerId = 1002,
                EmployeeIds = employeeIds
            });

            return managerEmployeesAssociation;
        }

        private List<EmployeeRoles> GetAllEmployeesRoles()
        {
            List<Roles> listRoles = GetAllRoles();
            List<EmployeeRoles> listEmployeeRoles = [];


            listEmployeeRoles.Add(new EmployeeRoles() 
            { 
                EmployeeId = 1000,
                RoleId = 102
            });

            listEmployeeRoles.Add(new EmployeeRoles() 
            { 
                EmployeeId = 1001,
                RoleId = 102
            });

            listEmployeeRoles.Add(new EmployeeRoles() 
            { 
                EmployeeId = 1002,
                RoleId = 102
            });

            listEmployeeRoles.Add(new EmployeeRoles() 
            { 
                EmployeeId = 1003,
                RoleId = 103
            });
            listEmployeeRoles.Add(new EmployeeRoles() 
            { 
                EmployeeId = 1003,
                RoleId = 105
            });

            listEmployeeRoles.Add(new EmployeeRoles() 
            { 
                EmployeeId = 1004,
                RoleId = 105
            });

            listEmployeeRoles.Add(new EmployeeRoles() 
            { 
                EmployeeId = 1005,
                RoleId = 101
            });

            listEmployeeRoles.Add(new EmployeeRoles() 
            { 
                EmployeeId = 1006,
                RoleId = 100
            });

            listEmployeeRoles.Add(new EmployeeRoles() 
            { 
                EmployeeId = 1007,
                RoleId = 100
            });
            listEmployeeRoles.Add(new EmployeeRoles() 
            { 
                EmployeeId = 1007,
                RoleId = 104
            });

            listEmployeeRoles.Add(new EmployeeRoles() 
            { 
                EmployeeId = 1008,
                RoleId = 103
            });
            listEmployeeRoles.Add(new EmployeeRoles() 
            { 
                EmployeeId = 1008,
                RoleId = 104
            });

            listEmployeeRoles.Add(new EmployeeRoles() 
            { 
                EmployeeId = 1009,
                RoleId = 101
            });

            return listEmployeeRoles;
        }

        private List<Roles> GetAllRoles()
        {
            List<Roles> listRoles = [];
            
            listRoles.Add(new Roles() 
            { 
                RoleId = 100,
                RoleName = "Analyst"
            });

            listRoles.Add(new Roles() 
            { 
                RoleId = 101,
                RoleName = "Accounting"
            });

            listRoles.Add(new Roles() 
            { 
                RoleId = 102,
                RoleName = "Director"
            });

            listRoles.Add(new Roles() 
            { 
                RoleId = 103,
                RoleName = "IT"
            });

            listRoles.Add(new Roles() 
            { 
                RoleId = 104,
                RoleName = "Sales"
            });

            listRoles.Add(new Roles() 
            { 
                RoleId = 105,
                RoleName = "Support"
            });


            return listRoles;
        }

        private List<Employee> GetAllEmployeesData()
        {
            List<Employee> listEmployees = [];

            listEmployees.Add(new Employee() 
                {
                    EmployeeId = 1000,
                    FirstName = "Jeffrey",
                    LastName = "Wells",
                    IsManager = true
                } 
            );

            listEmployees.Add(new Employee() 
                {
                    EmployeeId = 1001,
                    FirstName = "Victor",
                    LastName = "Atkins",
                    IsManager = true
                } 
            );

            listEmployees.Add(new Employee() 
                {
                    EmployeeId = 1002,
                    FirstName = "Kelli",
                    LastName = "Hamilton",
                    IsManager = true
                } 
            );

            listEmployees.Add(new Employee() 
                {
                    EmployeeId = 1003,
                    FirstName = "Adam",
                    LastName = "Braun",
                    IsManager = false
                } 
            );

            listEmployees.Add(new Employee() 
                {
                    EmployeeId = 1004,
                    FirstName = "Lois",
                    LastName = "Martinez",
                    IsManager = false
                } 
            );

            listEmployees.Add(new Employee() 
                {
                    EmployeeId = 1005,
                    FirstName = "Brian",
                    LastName = "Cruz",
                    IsManager = false
                } 
            );

            listEmployees.Add(new Employee() 
                {
                    EmployeeId = 1006,
                    FirstName = "Michael",
                    LastName = "Lind",
                    IsManager = false
                } 
            );

            listEmployees.Add(new Employee() 
                {
                    EmployeeId = 1007,
                    FirstName = "Kristen",
                    LastName = "Floyd",
                    IsManager = false
                } 
            );

            listEmployees.Add(new Employee() 
                {
                    EmployeeId = 1008,
                    FirstName = "Eric",
                    LastName = "Bay",
                    IsManager = false
                } 
            );

            listEmployees.Add(new Employee() 
                {
                    EmployeeId = 1009,
                    FirstName = "Brandon",
                    LastName = "Young",
                    IsManager = false
                } 
            );

            return listEmployees;
        }

        //public DbContext GetDbContext(SqlConnection sqlConnection)
        //{
        //    DbContext dbContext = null;
        //    var _dbContextOptionsBuilder = new DbContextOptionsBuilder<DbContext>();

        //    if (sqlConnection != null)
        //    {
        //        var conn1 = _dbContextOptionsBuilder.  .UseSqlServer(sqlConnection);

        //        dbContext = System.Activator.CreateInstance(typeof(DbContext), _dbContextOptionsBuilder.Options);
        //    }

        //    return dbContext;
        //}

        private List<Employee> GetEmployeesInfoFromDB(int employeeId)
        {
            List<Employee> employeeInfo = [];
            try
            {
                if (employeeId == 0)
                {
                    throw new ArgumentException("GetEmployeesInfoFromDB: EmployeeId was not passed - " + employeeId);
                }
                List<Employee> listEmployees = GetAllEmployeesData();
                employeeInfo = listEmployees.Where<Employee>(emp => emp.EmployeeId == employeeId).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return employeeInfo;
        }

        private List<EmployeeInfo> GetAllEmployeesInfoFromDB()
        {
            List<EmployeeInfo> listEmployeesInfo = new List<EmployeeInfo>();
            try
            {
                HRSystemsContext hrSystemsContext = new HRSystemsContext();

                string _procedureName = "[dbo].[GetAllEmployeesInfo]";

                List<EmployeeEntity> listEmployeesEntity = hrSystemsContext.EmployeesEntity
                                    .FromSqlRaw(@"EXEC" + _procedureName)
                                    .ToListAsync().Result;

                if (listEmployeesEntity != null)
                {
                    listEmployeesEntity.ForEach(empInfo =>
                    {
                        EmployeeInfo employeeInfo = new EmployeeInfo();
                        employeeInfo.EmployeeId = empInfo.EmployeeId;
                        employeeInfo.FirstName = empInfo.FirstName;
                        employeeInfo.LastName = empInfo.LastName;
                        listEmployeesInfo.Add(employeeInfo);
                    });
                }

                /*
                //List<EmployeeInfoEntity> listEmployeesInfoEntity = new List<EmployeeInfoEntity>();
                //listEmployeesInfo = hrSystemsContext.EmployeesInfo.FromSql("dbo.GetAllEmployeesInfo").ToList();
                //listEmployeesInfoEntity = hrSystemsContext.EmployeesInfoEntity
                //                    .FromSqlRaw(@"EXEC" + _procedureName)
                //                    .ToListAsync().Result;

                if (listEmployeesInfoEntity != null)
                {
                    listEmployeesInfoEntity.ForEach(empInfo =>
                    {
                        EmployeeInfo employeeInfo = new EmployeeInfo();
                        employeeInfo.EmployeeId = empInfo.EmployeeId;
                        employeeInfo.FirstName = empInfo.FirstName;
                        employeeInfo.LastName = empInfo.LastName;
                        //employeeInfo.ListRoles = empInfo.ListRoles;
                        empInfo.ListRoles.ForEach(role => { 
                            Roles roles = new Roles();
                            roles.RoleId = role.RoleId;
                            roles.RoleName = role.RoleName;
                            employeeInfo.ListRoles.Add(roles);
                        });
                        listEmployeesInfo.Add(employeeInfo);
                    });
                }
                */

            }
            catch (Exception)
            {
                throw;
            }

            return listEmployeesInfo;
        }

        private List<EmployeeInfo> GetManagerEmployeesAssociationInfoFromDB(int employeeId)
        {
            List<EmployeeInfo> listEmployeesInfo = new List<EmployeeInfo>();
            try
            {
                HRSystemsContext hrSystemsContext = new HRSystemsContext();

                string _procedureName = "[dbo].[GetAllEmployeesInfoForManager]";
                List<Microsoft.Data.SqlClient.SqlParameter> sqlParam = new List<Microsoft.Data.SqlClient.SqlParameter> {
                    new Microsoft.Data.SqlClient.SqlParameter("@EmployeeId",employeeId)
                };

                List<EmployeeEntity> listEmployeesEntity = hrSystemsContext.EmployeesEntity
                                    .FromSqlRaw(@"EXEC" + _procedureName + "@EmployeeId", sqlParam.ToArray())
                                    .ToListAsync().Result;

                if (listEmployeesEntity != null)
                {
                    listEmployeesEntity.ForEach(empInfo =>
                    {
                        EmployeeInfo employeeInfo = new EmployeeInfo();
                        employeeInfo.EmployeeId = empInfo.EmployeeId;
                        employeeInfo.FirstName = empInfo.FirstName;
                        employeeInfo.LastName = empInfo.LastName;
                        listEmployeesInfo.Add(employeeInfo);
                    });
                }

            }
            catch (Exception)
            {
                throw;
            }

            return listEmployeesInfo;
        }
        private int AddEmployeeInfoInDB(EmployeeInfo employeeInfo)
        {
            int noOfRows = 0;
            try
            {
                HRSystemsContext hrSystemsContext = new HRSystemsContext();

                string _procedureName = "[dbo].[AddEmployee]";

                string arrRoles = String.Empty;
                foreach (Roles role in employeeInfo.ListRoles)
                {
                    arrRoles += "," + role.RoleId;
                }
                arrRoles = arrRoles.Substring(1);

                List<Microsoft.Data.SqlClient.SqlParameter> sqlParam = new List<Microsoft.Data.SqlClient.SqlParameter> {
                    new Microsoft.Data.SqlClient.SqlParameter("@FirstName", employeeInfo.FirstName),
                    new Microsoft.Data.SqlClient.SqlParameter("@LastName", employeeInfo.LastName),
                    new Microsoft.Data.SqlClient.SqlParameter("@RoleIDs", arrRoles)
                };

                var result = hrSystemsContext.Database
                                    .ExecuteSqlRaw(@"EXEC" + _procedureName + "@FirstName,@LastName,@RoleIDs", sqlParam.ToArray());

                noOfRows = int.Parse(result.ToString());
            }
            catch (Exception)
            {
                throw;
            }

            return noOfRows;
        }

    }
}