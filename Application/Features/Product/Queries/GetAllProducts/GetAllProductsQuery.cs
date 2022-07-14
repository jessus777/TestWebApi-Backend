namespace Application.Features.Product.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<Response<IEnumerable<GetAllProductsViewModel>>>
    {

    }

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, Response<IEnumerable<GetAllProductsViewModel>>>
    {
        private readonly IProductRepositoryAsync _productRepositoryAsync;
        public GetAllProductsQueryHandler(IProductRepositoryAsync productRepositoryAsync)
        {
            _productRepositoryAsync = productRepositoryAsync;
        }
        public async Task<Response<IEnumerable<GetAllProductsViewModel>>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
        {
            var getAllProduct = await _productRepositoryAsync.GetAllAsync();
            var ProductsList = new List<GetAllProductsViewModel>();
            if (getAllProduct.Count <= 0)
            {
                return new Response<IEnumerable<GetAllProductsViewModel>>(null) { Succeeded = false, Message = "No hay Productos" };
            }

            foreach (var getProduct in getAllProduct)
            {
                ProductsList.Add((GetAllProductsViewModel)DataMapper.Parse(getProduct, new GetAllProductsViewModel()));
            }

            return new Response<IEnumerable<GetAllProductsViewModel>>(ProductsList);
        }
    }
}
