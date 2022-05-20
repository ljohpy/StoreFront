using GadgetStore.DATA.EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StoreFront.DATA.EF.Metadata
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
        private class BodyStylesMetadata
        {
        }
    }
    #endregion

    #region UserDetails
    [ModelMetadataType(typeof(UserDetailsMetadata))]
    public partial class UserDetails
    {
        private class UserDetailsMetadata
        {
        }
    }
    #endregion
}


