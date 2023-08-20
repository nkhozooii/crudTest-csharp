using Mc2.CrudTest.Presentation.Core.DefineAttributes;
using Mc2.CrudTest.Presentation.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Core.Entities
{
    public class Customer:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateOfBirth { get; set; }
        [Column(TypeName = "VARCHAR")]
        [MaxLength(20)]
        [PhoneNumber]
        public virtual string PhoneNumber { get; set; }

        [Display(Name = "Email address")]
        //[Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [MaxLength(50)]
        public string? Email { get; set; }
        [MaxLength(25)]
        [RegularExpression(@"^[0-9]{9,18}$", ErrorMessage = "Invalid Bank Account Number.")]
        public  string? BankAccountNumber { get; set; }
    }
}
