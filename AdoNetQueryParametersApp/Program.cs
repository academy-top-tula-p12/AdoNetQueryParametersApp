using Azure.Core.Extensions;
using Microsoft.Data.SqlClient;
using System.Data;

string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AcademyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;";


//string departmentTitle = "Ландшафтный дизайн";
//string departmentTitle = @"Ландшафтный дизайн');
//            INSERT INTO Module (title) VALUE (N'Фигня фигня";


//string commandString = $@"INSERT INTO Department
//                              (title)
//                              VALUES
//                              (@title)";

string lastName = "Никулин";
string firstName = "Юрий";
string phone = "(903) 555-33-88";
DateTime birthDate = new(1979, 3, 9);
int departId = 5;
int salary = 123000;

string commandString = @"INSERT INTO Teacher
                         (last_name, first_name, birth_date, phone, department_id, salary)
                         VALUES
                         (@last_name, @first_name, @birth_date, @phone, @department_id, @salary);
                         SET @id = SCOPE_IDENTITY()";

using (var connection = new SqlConnection(connectionString))
{
    await connection.OpenAsync();

    var command = connection.CreateCommand();
    command.CommandText = commandString;

    var paramLastName = new SqlParameter("@last_name", SqlDbType.NVarChar, 50);
    paramLastName.Value = lastName;

    var paramFirstName = new SqlParameter("@first_name", SqlDbType.NVarChar, 50);
    paramFirstName.Value = firstName;

    var paramPhone = new SqlParameter("@phone", SqlDbType.NVarChar, 50);
    paramPhone.Value = phone;

    var paramBirthDate = new SqlParameter("@birth_date", SqlDbType.DateTime2);
    paramBirthDate.Value = birthDate;

    var paramSalary = new SqlParameter("@salary", SqlDbType.Decimal, 8);
    paramSalary.Value = salary;

    var paramDepartId = new SqlParameter("@department_id", SqlDbType.Int);
    paramDepartId.Value = departId;

    var paramId = new SqlParameter("@id", SqlDbType.Int);
    paramId.Direction = ParameterDirection.Output;

    command.Parameters.AddRange(new[] { paramLastName, 
                                        paramFirstName,
                                        paramBirthDate,
                                        paramPhone,
                                        paramDepartId,
                                        paramSalary,
                                        paramId });

    await command.ExecuteNonQueryAsync();

    Console.WriteLine($"Id new teacher = { paramId.Value }");
    //command.CommandText = commandString;
    //var paramTitle = new SqlParameter("@title", departmentTitle);

    //command.Parameters.Add(paramTitle);

    //int records = await command.ExecuteNonQueryAsync();

    //commandString = "SELECT * FROM Department";
    //command.CommandText = commandString;
    //command.Parameters.Clear();

    //using (var reader = command.ExecuteReader())
    //{
    //    while (await reader.ReadAsync())
    //        Console.WriteLine(reader.GetString(1));
    //}


    //command.CommandText = "DELETE Department WHERE id = 9";
    //command.ExecuteNonQuery();
}