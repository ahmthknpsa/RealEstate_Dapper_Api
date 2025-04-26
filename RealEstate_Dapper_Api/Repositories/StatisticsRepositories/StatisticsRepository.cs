using Dapper;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly Context _context;

        public StatisticsRepository(Context context)
        {
            _context = context;
        }
        public int ActiveCategoryCount()  // Aktif Kategori Sayısı
        {
            string query = "Select Count(*) From Category where CategoryStatus=1";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ActiveEmployeeCount()  // Aktif Personel Sayısı
        {
            string query = "Select Count(*) From Employee where Status=1"; 
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ApartmentCount()
        {
            string query = "Select Count(*) From Product where Title like '%Daire%'";  // Toplam Daire Sayısı
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public decimal AverageProductPriceByRent()  // Ortalama Kiralık Fiyatı
        {
            string query = "Select Avg(Price) From Product where Type='Kiralık'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public decimal AverageProductPriceBySale()     // Ortalama Satılık Fiyatı
        {
            string query = "Select Avg(Price) From Product where Type='Satılık'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public int AverageRoomCount()
        {
            string query = "Select Avg(RoomCount) From ProductDetails";  // Ortalama Oda Sayısı
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int CategoryCount()
        {
            string query = "Select Count(*) From Category";        // Toplam Kategori Sayısı
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string CategoryNameByMaxProductCount()   // En Fazla Ürünü Olan Kategori İsmi
        {
            string query = "Select top(1) CategoryName,Count(*) From Product inner join Category On Product.ProductCategory=Category.CategoryID Group By CategoryName order by Count(*) Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public string CityNameByMaxProductCount() // En Fazla Ürünü Olan Şehir İsmi
        {
            string query = "Select top(1) City,Count(*) as 'product_count' From Product Group By City order by product_count Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public int DifferentCityCount()   // Toplamda Kaç Farklı Şehir Var
        {
            string query = "Select Count(Distinct(City)) From Product ";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string EmployeeNameByMaxProductCount() // En Fazla İlanı Olan Personel
        {
            string query = "Select Name,Count(*) 'product_count' From Product Inner Join Employee On Product.EmployeeID=Employee.EmployeeID Group By Name Order By product_count Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public decimal LastProductPrice()  // Son Eklenen Ürünün Fiyatı
        {
            string query = "Select Top(1) Price From Product Order By ProductId Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public string NewestBuildingYear()   // En Yeni Bina Yılı
        {
            string query = "Select Top(1) BuildYear From ProductDetails Order By BuildYear Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public string OldestBuildingYear()   // En Eski Bina Yılı
        {
            string query = "Select Top(1) BuildYear From ProductDetails Order By BuildYear Asc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public int PassiveCategoryCount()  // Pasif Kategori Sayısı
        {
            string query = "Select Count(*) From Category Where CategoryStatus=0";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ProductCount()  // Toplam Ürün Sayısı
        {
            string query = "Select Count(*) From Product";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }
    }
}
