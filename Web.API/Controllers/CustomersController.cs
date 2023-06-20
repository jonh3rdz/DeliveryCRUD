using Application.Customers.Create;
using Application.Customers.Update;
using Application.Customers.Delete;
using Application.Customers.GetAll;
using Application.Customers.GetById;
using Domain.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("customers")]
public class Customers : ApiController
{
    private readonly ISender _mediator;

    public Customers(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
    {
        var createCustomerResult = await _mediator.Send(command);

        return createCustomerResult.Match(customer => Ok(), errors => Problem(errors));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerCommand command)
    {
        var updateCommand = command with { CustomerId = id };
        var updateCustomerResult = await _mediator.Send(updateCommand);

        return updateCustomerResult.Match(success => Ok(), errors => Problem(errors));
    }


    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, [FromBody] DeleteCustomerCommand command)
    {
        var deleteCommand = command with { CustomerId = id };
        var deleteCustomerResult = await _mediator.Send(deleteCommand);

        return deleteCustomerResult.Match(success => Ok(), errors => Problem(errors));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllCustomerQuery();
        var customers = await _mediator.Send(query);
        return Ok(customers);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetByIdCustomerQuery(new CustomerId(id));
        var customer = await _mediator.Send(query);

        if (customer == null)
        {
            return NotFound();
        }

        return Ok(customer);
    }
}
