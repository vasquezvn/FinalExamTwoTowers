using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleSecondQuestion
{
    public class Program
    {
        private HttpClient client = new HttpClient();
        private Student studentApi = new Student();

        public Program()
        {
            client.BaseAddress = new Uri("http://localhost:8080/");
        }

        static async Task Main(string[] args)
        {
            Program p = new Program();
            Student s = new Student();
            s.id = 101;
            s.firstName = "werrrrrrr";
            s.lastName = "werrrrrrr";
            s.email = "werrrrrrr@massaQuisqueporttitor.org";
            s.programme = "Financial Analysis";
            s.courses = new string[] { "Accounting", "Statistics" };

            p.IsFirstStudentAsync(s).GetAwaiter().GetResult();
            var studentApi = p.studentApi;
            var isEqual = studentApi.Equals(s);

            await p.CreateStudentAsync(s);
            await p.GetStudentById(107);

            Console.WriteLine(p);
            Console.WriteLine(p.studentApi);

            Console.WriteLine($"is Equal: {s.Equals(p.studentApi)}");
        }

        public Student GetStudentApi() { return studentApi; }

        private async Task GetStudentById(int studentId)
        {
            var uri = new Uri("http://localhost:8080/student/list");

            var jsonString = await client.GetStringAsync(uri);
            List<Student> json = JsonConvert.DeserializeObject<List<Student>>(jsonString);

            foreach (var student in json)
            {
                if (student.id == studentId)
                {
                    studentApi = student;
                    break;
                }
            }
        }

        public async Task GetStudentByName(string studentName)
        {
            var uri = new Uri("http://localhost:8080/student/list");

            var jsonString = await client.GetStringAsync(uri);
            List<Student> json = JsonConvert.DeserializeObject<List<Student>>(jsonString);

            foreach (var student in json)
            {
                if (student.firstName.Equals(studentName))
                {
                    studentApi = student;
                    break;
                }
            }
        }

        public async Task<bool> IsFirstStudentAsync(Student student)
        {
            var result = false;

            await GetStudentById(1);

            if (studentApi.id == student.id)
                result = true;

            return result;
        }

        public async Task<Uri> CreateStudentAsync(Student student)
        {
            var studentJson = JsonConvert.SerializeObject(student);
            var buffer = System.Text.Encoding.UTF8.GetBytes(studentJson);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await client.PostAsync("http://localhost:8080/student", byteContent);

            // return URI of the created resource.
            return response.Headers.Location;
        }
    }
}
