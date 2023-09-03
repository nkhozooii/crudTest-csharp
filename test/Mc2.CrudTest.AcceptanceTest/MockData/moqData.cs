using Mc2.CrudTest.Presentation.Core.Entities;

namespace Mc2.CrudTest.AcceptanceTests.MockData
{
   
    public static class moqData
    {
        public static List<Customer> GetAll()
        {
            var customers = new List<Customer>
            {
               new Customer{Id=1,FirstName="Narges",LastName="khozooii",DateOfBirth=new DateTime(1983,05,26),PhoneNumber="+41 44 668 18 00",Email="nkhozooii@gmail.com",BankAccountNumber="635802010014976"},
               new Customer{Id=2,FirstName="Somaye",LastName="khozooii",DateOfBirth=new DateTime(1984,07,03),PhoneNumber="+41 33 668 11 00",Email="skhozooii@gmail.com",BankAccountNumber="1234567890"},

            };
            return customers;
            
        }

    }
}

