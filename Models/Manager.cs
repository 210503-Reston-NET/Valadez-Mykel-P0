namespace Models
{
    public class Manager : User
    {
        public Manager(string lName, string fName, string email)
        {
            this.LName = lName;
            this.FName = fName;
            this.Email = email;
        }
    }
}