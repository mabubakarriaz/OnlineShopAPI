using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Com.CompanyName.OnlineShop.ComponentLibrary.Data
{
    public interface IAPIController<T>
    {
        IHttpActionResult Get();
        IHttpActionResult Get([FromUri]int id);
        IHttpActionResult Change([FromUri]int id, [FromBody] T aType);
        IHttpActionResult Add([FromBody] T aType);
        IHttpActionResult Remove([FromUri]int id);
    }
}
