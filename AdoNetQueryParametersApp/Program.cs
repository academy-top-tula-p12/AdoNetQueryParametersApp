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

//string lastName = "Никулин";
//string firstName = "Юрий";
//string phone = "(903) 555-33-88";
//DateTime birthDate = new(1979, 3, 9);
//int departId = 5;
//int salary = 123000;

//string commandString = @"INSERT INTO Teacher
//                         (last_name, first_name, birth_date, phone, department_id, salary)
//                         VALUES
//                         (@last_name, @first_name, @birth_date, @phone, @department_id, @salary);
//                         SET @id = SCOPE_IDENTITY()";

//using (var connection = new SqlConnection(connectionString))
//{
//    await connection.OpenAsync();

//    var command = connection.CreateCommand();
//    command.CommandText = commandString;

//    var paramLastName = new SqlParameter("@last_name", SqlDbType.NVarChar, 50);
//    paramLastName.Value = lastName;

//    var paramFirstName = new SqlParameter("@first_name", SqlDbType.NVarChar, 50);
//    paramFirstName.Value = firstName;

//    var paramPhone = new SqlParameter("@phone", SqlDbType.NVarChar, 50);
//    paramPhone.Value = phone;

//    var paramBirthDate = new SqlParameter("@birth_date", SqlDbType.DateTime2);
//    paramBirthDate.Value = birthDate;

//    var paramSalary = new SqlParameter("@salary", SqlDbType.Decimal, 8);
//    paramSalary.Value = salary;

//    var paramDepartId = new SqlParameter("@department_id", SqlDbType.Int);
//    paramDepartId.Value = departId;

//    var paramId = new SqlParameter("@id", SqlDbType.Int);
//    paramId.Direction = ParameterDirection.Output;

//    command.Parameters.AddRange(new[] { paramLastName,
//                                        paramFirstName,
//                                        paramBirthDate,
//                                        paramPhone,
//                                        paramDepartId,
//                                        paramSalary,
//                                        paramId });

//    await command.ExecuteNonQueryAsync();

//    Console.WriteLine($"Id new teacher = { paramId.Value }");
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
//}

//string firstName, lastName, phone;
//int departId, salary, day, month, year;

//List<string> departments = new List<string>();

//using (var connection = new SqlConnection(connectionString))
//{
//    await connection.OpenAsync();

//    SqlCommand command = connection.CreateCommand();
//    command.CommandText = "SELECT * FROM Department";
//    using(SqlDataReader reader = await command.ExecuteReaderAsync())
//    {
//        if(reader.HasRows)
//        {
//            while(await reader.ReadAsync())
//                departments.Add($"{reader.GetInt32(0).ToString()}: {reader.GetString(1)}");
//        }
//    }
//}

//Console.Write("Input last name of teacher: ");
//lastName = Console.ReadLine();
//Console.Write("Input first name of teacher: ");
//firstName = Console.ReadLine();

//Console.Write("Input birth date of teacher. Day: ");
//day = Int32.Parse(Console.ReadLine());
//Console.Write("Input birth date of teacher. Month: ");
//month = Int32.Parse(Console.ReadLine());
//Console.Write("Input birth date of teacher. Year: ");
//year = Int32.Parse(Console.ReadLine());

//Console.WriteLine("Departments:");
//foreach(var d in departments)
//    Console.WriteLine($"\t{d}");
//Console.Write("Input id department of teacher: ");
//departId = Int32.Parse(Console.ReadLine());

//Console.Write("Input phone of teacher: ");
//phone = Console.ReadLine();

//Console.Write("Input salary of teacher: ");
//salary = Int32.Parse(Console.ReadLine());

//SqlParameter paramLastName = new()
//{
//    ParameterName = "@last_name",
//    Value = lastName
//};

//SqlParameter paramFirstName = new()
//{
//    ParameterName = "@first_name",
//    Value = firstName
//};

//SqlParameter paramBirthDate = new()
//{
//    ParameterName = "@birth_date",
//    Value = new DateTime(year, month, day)
//};

//SqlParameter paramPhone = new()
//{
//    ParameterName = "@phone",
//    Value = phone
//};

//SqlParameter paramDepartId = new()
//{
//    ParameterName = "@department_id",
//    Value = departId
//};

//SqlParameter paramSalary = new()
//{
//    ParameterName = "@salary",
//    Value = salary
//};


//using (var connection = new SqlConnection(connectionString))
//{
//    await connection.OpenAsync();

//    SqlCommand command = connection.CreateCommand();
//    //command.Parameters.AddRange(new[] { paramLastName, paramFirstName,
//    //                                    paramBirthDate, paramPhone,
//    //                                    paramDepartId, paramSalary});
//    command.Parameters.Add(new("@last_name", "'Авилов'"));
//    command.CommandType = CommandType.StoredProcedure;
//    command.CommandText = "AddTeacher";

//    var id = command.ExecuteScalar();
//    Console.WriteLine($"id = {id}");
//}

//using (var connection = new SqlConnection(connectionString))
//{
//    await connection.OpenAsync();
//    SqlCommand command = connection.CreateCommand();
//    command.CommandType = CommandType.StoredProcedure;
//    command.CommandText = "ViewTeachers";

//    using(SqlDataReader reader = command.ExecuteReader())
//    {
//        if (!reader.HasRows) return;

//        Console.WriteLine(new String('-', 50));

//        Console.Write("| ");
//        for (int i = 0; i < reader.FieldCount; i++)
//            Console.Write($"{reader.GetName(i)}\t| ");
//        Console.WriteLine();

//        Console.WriteLine(new String('-', 50));

//        while(await reader.ReadAsync())
//        {
//            Console.Write("| ");
//            for (int i = 0; i < reader.FieldCount; i++)
//            {
//                var item = reader.GetValue(i);
//                Console.Write($"{item}");
//                string tabs = "\t";
//                if (item.ToString().Length <= 8) tabs += "\t";
//                tabs += "| ";
//                Console.Write(tabs);
//            }

//            Console.WriteLine();
//        }
//    }
//}

using (var connection = new SqlConnection(connectionString))
{
    await connection.OpenAsync();
    SqlCommand command = connection.CreateCommand();

    SqlTransaction transaction = connection.BeginTransaction();
    command.Transaction = transaction;

    try
    {
        command.CommandText = "UPDATE BankAccount SET amount = amount - 1000 WHERE id = 123";
        await command.ExecuteNonQueryAsync();
        command.CommandText = "UPDATE BankAccount SET amount = amount + 1000 WHERE id = 321";
        await command.ExecuteNonQueryAsync();

        await transaction.CommitAsync();
    }
    catch(Exception ex)
    {
        await transaction.RollbackAsync();
    }
}

