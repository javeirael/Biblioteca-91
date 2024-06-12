using Dapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi91.Context;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApi91.Services
{
    public class AutoresServices : IAutoreService
    {
        private readonly AplicationDBContext _context;
        public AutoresServices(AplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Autor>>> GetAutores()
        {
            try
            {
                List<Autor> response = new List<Autor>();

                var result = await _context.Database.GetDbConnection().QueryAsync<Autor>("spGetAutores", new {}, commandType: CommandType.StoredProcedure);
                    
                response = result.ToList();

                return new Response<List<Autor>> (response);
            }
            catch (Exception ex)
            {
                throw new Exception("succedio");
            }
        }


        public async Task<Response<Autor>> CreateAutores(Autor i)
        {
            try
            {
                Autor Result = new Autor();
                Result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("spCrearAutor", new { i.Name, i.Nacionalidad }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                return new Response<Autor>(Result);
            }catch(Exception ex)
            {
                throw new Exception("sucedio" + ex.Message);
            }

        }

        public async Task<Response<Autor>> UpdateAutor(int PkAutor, Autor i)
        {
            try
            {
                Autor result = new Autor();

                result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("SpUdateAutores", new { PkAutor, i.Name, i.Nacionalidad }, commandType: CommandType.StoredProcedure)).FirstOrDefault();

                return new Response<Autor>(result);
            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error" + ex.Message);
            }
        }


        public async Task<Response<Autor>> BorrarAutores(int PkAutor)
        {
            try
            {
                Autor result = new Autor();

                result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("SpBorrarAutor", new { PkAutor }, commandType: CommandType.StoredProcedure)).FirstOrDefault();

                return new Response<Autor>(result);
            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error" + ex.Message);
            }
        }
    }
}
