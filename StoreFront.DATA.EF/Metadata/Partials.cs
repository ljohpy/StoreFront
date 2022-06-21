using StoreFront.DATA.EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StoreFront.DATA.EF.Models.CarsMetadata;

namespace StoreFront.DATA.EF.Models
{
    //internal class Partials
    //{
    //}
    #region ProductStatuses
    [ModelMetadataType(typeof(ProductStatusesMetadata))]
    public partial class Category { }
    #endregion

    #region Orders
    [ModelMetadataType(typeof(OrdersMetadata))]
    public partial class Order { }
    #endregion

    #region OrderProducts
    [ModelMetadataType(typeof(OrderProductsMetadata))]
    public partial class OrderProducts
    {
        [NotMapped]
        public IFormFile? Image { get; set; }

        private class OrderProductsMetadata
        {
        }
    }
    #endregion

    #region BodyStyles
    [ModelMetadataType(typeof(BodyStylesMetadata))]
    public partial class BodyStyles
    {
       
    }
    public class BodyStylesMetadata
    {
        //public int StyleId { get; set; }
        public string StyleName { get; set; } = null!;
        public string? Description { get; set; }
    }

    #endregion

    #region UserDetails
    [ModelMetadataType(typeof(UserDetailMetadata))]
    public partial class UserDetail
    {
        
            public string FullName { get { return $"{FirstName} {LastName}"; } }
        
    }
    #endregion

    #region Cars
    [ModelMetadataType(typeof(CarsMetadata))]
    public partial class Cars
    {
        [NotMapped]
        public IFormFile? Image { get; set; }
    }
    #endregion
}


