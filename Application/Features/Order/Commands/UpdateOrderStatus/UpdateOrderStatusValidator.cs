using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Order.Commands.UpdateOrderStatus
{
    public class UpdateOrderStatusValidator : AbstractValidator<UpdateOrderStatusCommand>
    {
        public UpdateOrderStatusValidator()
        {
            RuleFor(validator => validator.Id)
            .Must(IsGreatTo1).WithMessage("Error: el numero de order debe ser mayor a 1");

            RuleFor(validator => validator.StatusType)
                .Must(IsGreatTo1Enum).WithMessage("Error: el tipo de status no existe");
        }

        private bool IsGreatTo1(int id)
        {
            return id >= 1;
        }
        private bool IsGreatTo1Enum(int statusType)
        {
            return statusType >= 0 && statusType <= 4;
        }
    }
}
