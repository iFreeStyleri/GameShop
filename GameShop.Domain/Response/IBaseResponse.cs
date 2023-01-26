using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Domain.Response
{
    public interface IBaseResponse<T>
    {
        public HttpStatusCode StatusCode { get; }
        public T Data { get; }
        public string Description { get; }
    }
}
