using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AkademiPlusMicroserviceProje.Shared.Dtos;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace AkademiPlusMicroserviceProje.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;

        public DiscountService(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSQL"));
        }

        public Task<Response<NoContent>> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Response<List<Models.Discount>>> GetAll()
        {
            var discounts = await _dbConnection.QueryAsync<Models.Discount>("select*from discount");
            return Response<List<Models.Discount>>.Success(200,discounts.ToList());
        }

        public Task<Response<Models.Discount>> GetByCodeWithUserID(string code, string userId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Response<Models.Discount>> GetByID(int id)
        {
            var discounts=(await _dbConnection.QueryAsync<Models.Discount>("Select * from discount where id=@Id", new {Id=id})).SingleOrDefault();
            return Response<Models.Discount>.Success(200, discounts);
        }

        public async Task<Response<NoContent>> Save(Models.Discount discount)
        {
            var status = await _dbConnection.ExecuteAsync("Insert into discount (userid, rate, code) values(@userid, @rate, @code)",discount);
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> Update(Models.Discount discount)
        {
            var status=await _dbConnection.ExecuteAsync("update discount set userId=@userid, code=@code, rate=@rate where id=@id",new {Id=discount.Id, userId=discount.UserID, code=discount.Code, rate=discount.Rate});
            return Response<NoContent>.Success(204);
        }
    }
}
