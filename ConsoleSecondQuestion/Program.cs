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
            //Program p = new Program();
            //Student s = new Student();
            //s.id = 101;
            //s.firstName = "werrrrrrr";
            //s.lastName = "werrrrrrr";
            //s.email = "werrrrrrr@massaQuisqueporttitor.org";
            //s.programme = "Financial Analysis";
            //s.courses = new string[] { "Accounting", "Statistics" };

            //p.IsFirstStudentAsync(s).GetAwaiter().GetResult();
            //var studentApi = p.studentApi;
            //var isEqual = studentApi.Equals(s);

            //await p.CreateStudentAsync(s);
            //await p.GetStudentById(107);

            //Console.WriteLine(p);
            //Console.WriteLine(p.studentApi);

            //Console.WriteLine($"is Equal: {s.Equals(p.studentApi)}");
            
            //await p.GetStudentAsync(1);

            //p.GetStudentApi().email = "updated_@test.com";

            //await p.UpdateStudentAsync(p.GetStudentApi());
        }

        public Student GetStudentApi() { return studentApi; }

        /// <summary>
        /// Search method but there is an API that help us to get any student Id
        /// </summary>
        /// <param name="studentId">Id from student</param>
        /// <returns>Update StudentApi variable if student has been found in Api</returns>
        private async Task<Student> GetStudentById(int studentId)
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

            return studentApi;
        }

        public async Task<Student> GetStudentByName(string studentName)
        {
            var uri = new Uri("http://localhost:8080/student/list");
            Student studentFromApi = null;

            var jsonString = await client.GetStringAsync(uri);
            List<Student> json = JsonConvert.DeserializeObject<List<Student>>(jsonString);

            foreach (var student in json)
            {
                if (student.firstName.Equals(studentName))
                {
                    studentFromApi = student;
                    break;
                }
            }

            return studentFromApi;
        }

        private HttpContent ConvertObjectToHttpContent(object obj)
        {
            var studentJson = JsonConvert.SerializeObject(obj);
            var buffer = System.Text.Encoding.UTF8.GetBytes(studentJson);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return byteContent;
        }

        public async Task<bool> CreateStudentAsync(Student student)
        {
            var byteContent = ConvertObjectToHttpContent(student);

            HttpResponseMessage response = await client.PostAsync("http://localhost:8080/student", byteContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {
            var byteContent = ConvertObjectToHttpContent(student);

            HttpResponseMessage response = await client.PutAsync($"http://localhost:8080/student/{student.id}", byteContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<Student> GetStudentAsync(int studentId)
        {
            var jsonString = await client.GetStringAsync($"http://localhost:8080/student/{studentId}");
            var studentJson = JsonConvert.DeserializeObject<Student>(jsonString);

            return studentJson;
        }

        public Task<bool> IsFirstStudent(Student student)
        {
            return Task.Run(async () =>
             {
                 var result = false;
                 await GetStudentAsync(student.id);

                 if (student.id == studentApi.id)
                 {
                     result = true;
                 }

                 return result;
             });
        }
    }
}
