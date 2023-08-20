using Mc2.CrudTest.Presentation.Core.Entities;

namespace Mc2.CrudTest.AcceptanceTests.MockData
{
   
    public static class moqData
    {
        public static List<Customer> GetAll()
        {
            List<Customer> custmers = new List<Customer>()
            {
                //new Customer{Id=1,FirstName="Narges",LastName="khozooii",DateOfBirth=Convert.ToDateTime("26-05-1983"),PhoneNumber="+41 44 668 18 00",Email="nkhozooii@gmail.com",BankAccountNumber="635802010014976"},
                //new Customer{Id=1,FirstName="Somaye",LastName="khozooii",DateOfBirth=Convert.ToDateTime("03-07-1984"),PhoneNumber="+41 44 668 18 00",Email="skhozooii@gmail.com",BankAccountNumber="1234567890"},
                 new Customer{Id=1,FirstName="Narges",LastName="khozooii",DateOfBirth=null,PhoneNumber="+41 44 668 18 00",Email="nkhozooii@gmail.com",BankAccountNumber="635802010014976"},
               // new Customer{Id=1,FirstName="Somaye",LastName="khozooii",DateOfBirth=Convert.ToDateTime("03-07-1984"),PhoneNumber="+41 44 668 18 00",Email="skhozooii@gmail.com",BankAccountNumber="1234567890"},
            };
            return custmers;
        }
    }
}
#region bank
//Input: str = ”635802010014976”
//Output: True
//Explanation: It matches the correct Bank Account Number.

//Input: str = ” UBIN0563587”
//Output: False
//Explanation: It should not contains any alphabet characters.

//Input: str = ”9136812@895_”
//Output: False
//Explanation: Underscore and special charactersis not allowed.

//Input: str = ”1 2071998”
//Output: False
//Explanation: Whitespaces are not allowed.
//// Test Case 1:
//string str1 = "635802010014976";
//print(isValid_Bank_Acc_Number(str1));

//// Test Case 2:
//string str2 = "9136812895_";
//print(isValid_Bank_Acc_Number(str2));

//// Test Case 3:
//string str3 = "BNZAA2318JM";
//print(isValid_Bank_Acc_Number(str3));

//// Test Case 4:
//string str4 = " 934517865";
//print(isValid_Bank_Acc_Number(str4));

//// Test Case 5:
//string str5 = "UBIN0563587";
//print(isValid_Bank_Acc_Number(str5));

//// Test Case 6:
//string str6 = "654294563";
//print(isValid_Bank_Acc_Number(str6));

//Most of the banks have unique account numbers.
//Account number length varies from 9 digits to 18 digits.
//Most of the banks (67 out of 78) have included branch code as part of the account number structure. Some banks have product code as part of the account number structure.
//40 out of 78 banks do not have check digit as part of the account number structure.
//All banks have purely numeric account numbers, except one or two foreign banks.
//Only in the case of 20 banks, account numbers are formed without any pattern with a unique running serial number.

//^\d{9,18}$
//"[0-9]{9,18}"


#endregion

