namespace ConsoleSecondQuestion
{
    public class Student
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string programme { get; set; }
        public string[] courses { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Student))
            {
                return false;
            }

            return (this.id == ((Student)obj).id)
                && (this.firstName == ((Student)obj).firstName)
                && (this.lastName == ((Student)obj).lastName)
                && (this.email == ((Student)obj).email)
                && (this.programme == ((Student)obj).programme);
        }

        public override int GetHashCode()
        {
            return id.GetHashCode()
                ^ firstName.GetHashCode()
                ^ lastName.GetHashCode()
                ^ email.GetHashCode()
                ^ programme.GetHashCode();
        }
    }
}
