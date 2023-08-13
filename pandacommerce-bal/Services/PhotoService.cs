using pandacommerce_dal.Interface;
using pandacommerce_dal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pandacommerce_bal.Services
{
    public class PhotoService
    {
        public readonly IPhoto product;
        public ProductService(IProduct product)
        {
            this.product = product;
        }
        public async Task<Photo> AddNewPhoto(Photo photos)
        {
            return await photo.Add(photos);
        }

    }
}
