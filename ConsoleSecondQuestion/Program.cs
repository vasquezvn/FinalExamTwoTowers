using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleSecondQuestion
{
    public class Program
    {
        private HttpClient client = new HttpClient();
        private Student studentApi = new Student();

        static void Main(string[] args)
        {
            Program p = new Program();
            Student s = new Student();
            s.id = 1;
            s.firstName = "Vernon";
            s.lastName = "Harper";
            s.email = "egestas.rhoncus.Proin@massaQuisqueporttitor.org";
            s.programme = "Financial Analysis";
            s.courses = new string[] { "Accounting", "Statistics" };

            p.IsFirstStudentAsync(s).GetAwaiter().GetResult();

            var studentApi = p.studentApi;

            var isEqual = studentApi.Equals(s);

            Console.WriteLine($"is Equal: {isEqual}");
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

        public async Task<bool> IsFirstStudentAsync(Student student)
        {
            var result = false;

            await GetStudentById(1);

            if (studentApi.id == student.id)
                result = true;

            return result;
        }
    }
}
