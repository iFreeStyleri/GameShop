using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Domain.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }

        public T Data { get; set; }

        public string Description { get; set; }
    }
}
