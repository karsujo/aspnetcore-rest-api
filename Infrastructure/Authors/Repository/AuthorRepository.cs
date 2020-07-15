using Application.Authors;
using AutoMapper;
using Dapper;
using Infrastructure.Authors;
using OdysseyPublishers.Application.Authors;
using OdysseyPublishers.Application.Common;
using OdysseyPublishers.Domain;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace OdysseyPublishers.Infrastructure.Authors
{
    public class AuthorRepository : IAuthorRepository
    {

        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AuthorRepository(IRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<Author> GetAuthors()
        {

            //Get all authors, and for each author get books
            string sql = @" SELECT *
            FROM
              AUTHORS ";
    
            var result = _repository.QueryDatabase<AuthorDbEntity>(sql, null);
            return _mapper.Map<IEnumerable<Author>>(result);
        }

        public IEnumerable<Author> GetAuthors(AuthtorResourceParameters resourceParameters)
        {

            //Get all authors, and for each author get books
            if(string.IsNullOrEmpty(resourceParameters.State) && string.IsNullOrEmpty(resourceParameters.City))
            {
                return GetAuthors();
            }

            StringBuilder sql = new StringBuilder(@" SELECT *
            FROM
              AUTHORS ");
            var parameters = new DynamicParameters();
            bool isStateFilterAdded = false;
            if (!string.IsNullOrEmpty(resourceParameters.State))
            {
                isStateFilterAdded = true;
                sql.Append(@" WHERE State = @State");
                parameters.Add("@State", resourceParameters.State, DbType.String, ParameterDirection.Input, resourceParameters.State.Length);
            }
            if(!string.IsNullOrEmpty(resourceParameters.City))
            {
                if(isStateFilterAdded)
                {
                    sql.Append(@" AND City = @City");
                }
                else
                {
                    sql.Append(@" WHERE City = @City");
                }
                parameters.Add("@City", resourceParameters.City.Trim(), DbType.String, ParameterDirection.Input, resourceParameters.City.Length);
            }
            var result = _repository.QueryDatabase<AuthorDbEntity>(sql.ToString(), parameters);
            return _mapper.Map<IEnumerable<Author>>(result);
        }
        public Author GetAuthor(string authorId)
        {
            string sql = "select* from authors where au_id = @AuthorId";
            var parameters = new DynamicParameters();
            parameters.Add("@AuthorId", authorId, DbType.String, ParameterDirection.Input, authorId.Length);
            var result = _repository.QueryDatabase<AuthorDbEntity>(sql, parameters).FirstOrDefault();
            return _mapper.Map<Author>(result);
        }

        public bool AuthorExists(string authorId)
        {
            string sql = "select* from authors where au_id = @AuthorId";
            var parameters = new DynamicParameters();
            parameters.Add("@AuthorId", authorId, DbType.String, ParameterDirection.Input, authorId.Length);
            var result = _repository.QueryDatabase<AuthorDbEntity>(sql, parameters).FirstOrDefault();
    
            return result == null? false:true;
        }

    }

}
