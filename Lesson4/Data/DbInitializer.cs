using Lesson4.Models;
using Lesson4.Enum;

namespace Lesson4.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            //Look for any Product
            if (context.Products.Any())
            {
                return; // DB was filled
            }

            TypeProduct[] typeProducts = new TypeProduct[]
            {
                new TypeProduct{Type=EnumTypeProduct.flat},
                new TypeProduct{Type=EnumTypeProduct.house},
                new TypeProduct{Type=EnumTypeProduct.car},
            };

            context.TypeProducts.AddRange(typeProducts);
            context.SaveChanges();


        }
    }
}
