using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Enums;
using Domain.Entities;
using Application.Utils;
using System.Linq;

namespace Application.Features.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string RFC { get; set; }
        public GenderType GenderType { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response<int>>
    {

        private readonly ICustomerRepositoryAsync _customerRepository;
        public CreateCustomerCommandHandler(ICustomerRepositoryAsync customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Response<int>> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            string message;
            bool success;
            var customer = new Domain.Entities.Customer();

            var validatorCustomer = new CreateCustomerCommandValidator();
            var resultValidator = await validatorCustomer.ValidateAsync(command, cancellationToken);

            if (!resultValidator.IsValid)
            {
                List<string> errors = new();
                errors.AddRange(resultValidator.Errors.Select(error => error.ErrorMessage));
                return new Response<int>(null) { Message = "", Succeeded = false, Errors = errors };
            }

            var isUnique = await _customerRepository.IsUniqueCustomerAsync(command.Email);
            if (isUnique)
            {
                success = false;
                message = "Ya existe un cliente con este correo";
                return new Response<int>(null) { Message = message, Succeeded = success };
            }
            else
            {
                customer = (Domain.Entities.Customer)DataMapper.Parse(command, new Domain.Entities.Customer());

                await _customerRepository.AddAsync(customer);
                success = true;
                message = "Se agrego correctamente";
            }

            return new Response<int>(customer.Id) { Message = message, Succeeded = success };
        }
    }
}
