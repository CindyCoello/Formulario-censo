using Dapper;
using FormCenso.DataAccess.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FormCenso.DataAccess.Repositories
{
    public class CensoRepository
    {
        public UDP_tbCensoList_BuscarResult Search(string identidad)
        {
            const string query = @"UDP_tbCensoList_Buscar";
            var parameters = new DynamicParameters();
            parameters.Add("@identidad", identidad, DbType.String, ParameterDirection.Input);
            using (var db = new SqlConnection(FormCensoDbContext.ConnectionString))
            {
                var resultado = db.QueryFirstOrDefault<UDP_tbCensoList_BuscarResult>(query, parameters, commandType: CommandType.StoredProcedure);
                return resultado;
            }
        }

        public string Voto(int id)
        {
            const string query = @"UDP_tbCenso_Voto";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
            using (var db = new SqlConnection(FormCensoDbContext.ConnectionString))
            {
                var resultado = db.ExecuteScalar<string>(query, parameters, commandType: CommandType.StoredProcedure);
                return resultado;
            }
        }
    }
}
