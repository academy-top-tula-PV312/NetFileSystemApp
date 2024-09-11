using System.Data;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

string fileJson = @"D:\RPO\object.json";

Employee employee = new() { Name = "Tommy", Birthday =  DateTime.Now, Salary = 150500m };

Company yandex = new() { Title = "Yandex", City = "Moscow" };
Company piterSoft = new() { Title = "Piter Soft", City = "St/ Peterburg" };

List<Employee> employees = new() 
{ 
    new() { 
        Name = "Sammy", 
        Birthday =  DateTime.Now.AddYears(-23), 
        Salary = 90400m,
        Labels = [100, 200, 300],
        Company = yandex,
    },
    new() { 
        Name = "Jonny", 
        Birthday =  DateTime.Now.AddYears(-35), 
        Salary = 75000m,
        Labels = [5, 7],
        Company = piterSoft,
    },
    new() { 
        Name = "Billy", 
        Birthday =  DateTime.Now.AddYears(-41), 
        Salary = 120000m,
        Labels = [1, 2, 3, 4, 5],
        Company = yandex,
    },
};

JsonSerializerOptions options = new()
{
    WriteIndented = true,
};

string json = JsonSerializer.Serialize<List<Employee>>(employees, options);
Console.WriteLine(json);

//using (FileStream writer = File.OpenWrite(fileJson))
//{
//    //JsonSerializer.Serialize<Employee>(writer, employee);
//    await JsonSerializer.SerializeAsync<List<Employee>>(writer, employees, options);
//}

//using (FileStream reader = File.OpenRead(fileJson))
//{
//    List<Employee>? listEmpl = JsonSerializer.Deserialize<List<Employee>>(reader);

//    foreach(var e in listEmpl)
//        Console.WriteLine($"{e.Name} {e.Birthday.ToLongDateString()} {e.Salary}");
//}


[DataContract(Name = "Customer")]
class Employee
{
    [JsonPropertyName("FullName")]
    public string? Name { get; set; }

    public DateTime Birthday { get; set; }

    [JsonIgnore]
    public decimal Salary { get; set; }

    public List<int> Labels { get; set; } = new();

    public Company? Company { get; set; }

}

class Company
{
    public string? Title { get; set; }
    public string? City { get; set; }
}