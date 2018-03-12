using Demo.API.Models;

namespace Demo.API.Controllers
{
    public abstract class BaseController
    {
        internal UserJwtModel CurrentUser { get; set; }
    }
}
