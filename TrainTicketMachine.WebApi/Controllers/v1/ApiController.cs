using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TrainTicketMachine.WebApi.Controllers.v1;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public abstract class ApiController : ControllerBase
{
    private IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}