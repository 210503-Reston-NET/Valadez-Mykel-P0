namespace Models
{
    public class Customer : User
    {

        public Customer(string lName, string fName, string email)
        {
            this.LName = lName;
            this.FName = fName;
            this.Email = email;
        }

        public void Transactions()
        {

        }
    }
}