namespace oopday2
{
    public class Student
    {
        private int rollNo, age;
        private string name, email, phone;

        //property full style 
        private string nrc;

        public string NRC
        {
            get { return nrc; }
            set
            {
                if (value.Length < 12) throw new ArgumentException("Invalid nrc");
                nrc = value;

            }
        }


        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("Invalid address");
                address = value;
            }
        }

        public int ZipCode { get; set; }
        public bool CheckZipCode()=>ZipCode >= 10 && ZipCode <= 15;
        
        
        
        public int PostalCode { get; set; }//property short style 


        public void SetAge(int Age)
        {
            if (Age < 0)
                throw new ArgumentException("Invalid age");
            age = Age;
        }
        public int GetAge() => age;

        public void SetEmail(string Email)
        {//
            if (!Email.Contains("@") || string.IsNullOrEmpty(Email))
                throw new ArgumentException("Invalid Email");
            email = Email;
        }
        public string GetEmail() => email;
    }
}