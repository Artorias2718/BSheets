using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSheets.Models.Custom
{
    [Table("Customers")]
    public partial class CustomerDb
    {
        public int Id { get; set; }
        public string Obj_Data { get; set; }
    }

    public partial class Customer
    {
        public int Id { get; set; }
        [Display(Name = "Company Id")]
        public int Company_Id { get; set; }
        [Display(Name = "Customer Name")]
        public string Customer_Name { get; set; }
        [Display(Name = "Customer Company")]
        public string Customer_Company { get; set; }

        [Display(Name = "Primary Phone")]
        public string Primary_Phone { get; set; }
        [Display(Name = "Alternate Phone")]
        public string Alternate_Phone { get; set; }
        public string Fax { get; set; }

        public string Website { get; set; }

        public string Emails { get; set; }
        public string Terms { get; set; }
        [Display(Name = "Billing Address")]
        public string Billing_Address { get; set; }
        [Display(Name = "Shipping Address")]
        public string Shipping_Address { get; set; }
        [Display(Name = "Preferred Payment Method")]
        public string Payment_Preference { get; set; }
        [Display(Name = "Preferred Delivery Method")]
        public string Delivery_Preference { get; set; }
        [Display(Name = "Exemption Details")]
        public string Exemptions { get; set; }
    }
}