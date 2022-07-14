namespace Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>().Property(entity => entity.Name).HasMaxLength(50);
            builder.Entity<Customer>().Property(entity => entity.SecondName).HasMaxLength(50);
            builder.Entity<Customer>().Property(entity => entity.FirstLastName).HasMaxLength(50);
            builder.Entity<Customer>().Property(entity => entity.SecondLastName).HasMaxLength(50);
            builder.Entity<Customer>().Property(entity => entity.RFC).HasMaxLength(20);
            builder.Entity<Customer>().Property(entity => entity.Email).HasMaxLength(50);
            builder.Entity<Customer>().Property(entity => entity.Address).HasMaxLength(150);

            builder.Entity<Product>().Property(entity => entity.Name).HasMaxLength(50);
            builder.Entity<Product>().Property(entity => entity.Price).HasPrecision(8, 2);
            builder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Coca-Cola 500 ml",
                    DateCreated = DateTime.Now,
                    Quantity = 10,
                    Price = 12.5000m,
                    Iva = 16
                },
                new Product
                {
                    Id = 2,
                    Name = "Sabritones",
                    DateCreated = DateTime.Now,
                    Quantity = 20,
                    Price = 17.5000m,
                    Iva = 16
                },
                new Product
                {
                    Id = 3,
                    Name = "Monster 400ml",
                    DateCreated = DateTime.Now,
                    Quantity = 10,
                    Price = 35.0000m,
                    Iva = 16
                },
                new Product
                {
                    Id = 4,
                    Name = "Red-bull",
                    DateCreated = DateTime.Now,
                    Quantity = 10,
                    Price = 37.5000m,
                    Iva = 16
                }
                );

            builder.Entity<Order>().Property(entity => entity.SubTotal).HasPrecision(8, 2);
            builder.Entity<Order>().Property(entity => entity.Total).HasPrecision(8, 2);

            builder.Entity<Order>().HasData(
               new Order
               {
                   Id = 1,
                   OrderNumber = 1,
                   SubTotal = 42.50m,
                   Total = 49.30m,
                   DateCreate = DateTime.Now,
                   OrderStatusType = OrderStatusType.Pending,
                   OrderStatusTypeName = Enum.GetName(OrderStatusType.Pending)
               }//,
               //new Order
               //{
               //    //Id = 2,
               //    OrderNumber = 2,
               //    SubTotal = 9,
               //    Total = 10,
               //    DateCreate = DateTime.Now,
               //    OrderStatusType = OrderStatusType.Pending,
               //    OrderStatusTypeName = Enum.GetName(OrderStatusType.Pending)
               //},
               //new Order
               //{
               //    //Id = 3,
               //    OrderNumber = 3,
               //    SubTotal = 9,
               //    Total = 10,
               //    DateCreate = DateTime.Now,
               //    OrderStatusType = OrderStatusType.Pending,
               //    OrderStatusTypeName = Enum.GetName(OrderStatusType.Pending)
               //},
               //new Order
               //{
               //    //Id = 3,
               //    OrderNumber = 4,
               //    SubTotal = 9,
               //    Total = 10,
               //    DateCreate = DateTime.Now,
               //    OrderStatusType = OrderStatusType.Pending,
               //    OrderStatusTypeName = Enum.GetName(OrderStatusType.Pending)
               //}
               );

            builder.Entity<OrderDetail>().Property(entity => entity.SubTotal).HasPrecision(8, 2);
            builder.Entity<OrderDetail>().Property(entity => entity.Total).HasPrecision(8, 2);
            builder.Entity<OrderDetail>().HasData(

                new OrderDetail
                {
                    Id = 1,
                    OrderId = 1,
                    ProductId = 1,
                    Quantity = 2,
                    SubTotal = 25,
                    Total = 29
                },
                 new OrderDetail
                 {
                     Id = 2,
                     OrderId = 1,
                     ProductId = 2,
                     Quantity = 1,
                     SubTotal = 17.50m,
                     Total = 20.30m
                 }
                );

            base.OnModelCreating(builder);
        }
    }
}
