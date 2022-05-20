using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;//Added for access to required, display, etc...

namespace GadgetStore.DATA.EF.Models
{
    //internal class Metadata
    //{
    //}

    #region ProductStatuses
    public class ProductStatusesMetadata
    {
        //since this PK, we should never see it in a view, or have to enter a value when creating/editing.
        //For those reasons, we will not need to apply any metadata to pk
        public int StatusID { get; set; }

        [Required(ErrorMessage = "StatusID is required")]
        [MaxLength(50)]
        [Display(Name = "StatusName")]
        public string StatusName { get; set; } = null!;

        [MaxLength(500)]

        public string? Description { get; set; }
    }
    #endregion

    #region Orders
    public class OrdersMetadata
    {

        public int OrderID { get; set; }


        public string UserID { get; set; } = null!;

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d")]//0:d => MM/dd/yyyy
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [StringLength(100)]
        [Display(Name = "Ship To")]
        [Required]
        public string ShipToName { get; set; } = null!;

        [StringLength(50)]
        [Display(Name = "City")]
        [Required]
        public string ShipCity { get; set; } = null!;
        [StringLength(2)]
        [Display(Name = "State")]
        [Required]
        public string? ShipState { get; set; }
        [StringLength(5)]
        [Display(Name = "Zip")]
        [DataType(DataType.PostalCode)]
        [Required]
        public string ShipZip { get; set; } = null!;
    }

    #endregion

    #region Cars
    public class CarsMetadata
    {

        public int CarID { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Make")]
        public string Make { get; set; } = null!;

        [Required]
        public string Model { get; set; }

        [StringLength(4)]
        [Display(Name = "Year")]
        public string Year { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "ExteriorColor")]
        public string ExteriorColor { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Miles")]
        public string Miles { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "VinNumber")]
        public String VinNumber { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "InteriorColor")]
        public String InteriorColor { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Description")]
        public String? Description { get; set; }

        [Required]
        [Display(Name = "StatusID")]
        public int StatusID { get; set; }

        [Required]

        [Display(Name = "StyleID")]
        public int StyleID { get; set; }


        #endregion

        #region OrderProducts 
        public class OrderProductsMetadata
        {
            public int OrderProductID { get; set; }

            [Required]

            [Display(Name = "CarID")]
            public int CarID { get; set; }

            [Required]

            [Display(Name = "OrderID")]
            public int OrderID { get; set; }

            [Required]

            [Display(Name = "Quanity")]
            public int Quanity { get; set; }


            [Display(Name = "Money")]
            [Required]
            public string Money { get; set; }

        }
        #endregion

        #region UserDetails
        public class UserDetailsMetadata
        {
            public string UserId { get; set; } = null!;

            [Required]
            [StringLength(50)]
            [Display(Name = "Firstname")]
            public string FirstName { get; set; } = null!;

            [Required]
            [StringLength(50)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; } = null!;


            [StringLength(150)]
            [Display(Name = "Address")]
            public string? Address { get; set; }

            [StringLength(50)]
            [Display(Name = "City")]
            public string? City { get; set; }

            [StringLength(2)]
            [Display(Name = "State")]
            public string? State { get; set; }

            [StringLength(5)]
            [Display(Name = "Zip")]
            [DataType(DataType.PostalCode)]
            public string? Zip { get; set; }

            [StringLength(24)]
            [Display(Name = "Phone")]
            [DataType(DataType.PhoneNumber)]
            public string? Phone { get; set; }
        }
        #endregion

    }
}