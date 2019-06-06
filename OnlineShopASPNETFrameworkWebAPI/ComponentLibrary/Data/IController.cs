using System.Web.Http;

namespace Com.CompanyName.OnlineShop.ComponentLibrary.Data
{
    public interface IController<T>
    {
        IHttpActionResult Get();
        IHttpActionResult Get([FromUri]int id);
        IHttpActionResult Find([FromUri]string name);
        IHttpActionResult Change([FromUri]int id, [FromBody] T aType);
        IHttpActionResult Add([FromBody] T aType);
        IHttpActionResult Remove([FromUri]int id);
    }
}
