using Application.Interfaces.Repositories;
using Application.Utils;
using Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Queries.GetAllProductsExistens
{
    public class GetAllProductsExistenQuery : IRequest<Response<IEnumerable<GetAllProductsExistenViewModel>>>
    {
    }

    public class GetAllProductsExistenQueryHandler : IRequestHandler<GetAllProductsExistenQuery, Response<IEnumerable<GetAllProductsExistenViewModel>>>
    {
        private readonly IProductRepositoryAsync _productRepositoryAsync;
        public GetAllProductsExistenQueryHandler(IProductRepositoryAsync productRepositoryAsync)
        {
            _productRepositoryAsync = productRepositoryAsync;
        }
        public async Task<Response<IEnumerable<GetAllProductsExistenViewModel>>> Handle(GetAllProductsExistenQuery request, CancellationToken cancellationToken)
        {
            var getAllProducts = await _productRepositoryAsync.GetAllProductsExistentsAsync();
            var ProductsList = new List<GetAllProductsExistenViewModel>();

            foreach (var getProduct in getAllProducts)
            {
                ProductsList.Add((GetAllProductsExistenViewModel)DataMapper.Parse(getProduct, new GetAllProductsExistenViewModel()));
            }

            return new Response<IEnumerable<GetAllProductsExistenViewModel>>(ProductsList);
        }
    }
}
