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
