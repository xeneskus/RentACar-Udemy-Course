using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        private IMediator? _mediator; //tek tek her controllerda bunu yapmak yerine buraya yaptık
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>(); //daha önce mediator injecte edilmişse onu döndür nullsa git injeksin ıosi ortamına bak ve karşılıgını ver

    }
}
