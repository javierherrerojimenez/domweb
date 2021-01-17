using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Duties.API.Queries
{
    public class DutiesQueries : IDutiesQueries
    {
        private string _connectionString = string.Empty;

        public DutiesQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<IEnumerable<ResourcesOfDutiesViewModel>> GetResourcesOfDutiesAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<ResourcesOfDutiesViewModel>(@"SELECT r.ResourceCode, d.Name, d.DateStart, d.CreatedTime
                                                                                    FROM duties_db.DUTIES d
                                                                                    INNER JOIN duties_db.RESOURCES r
                                                                                        ON r.Id = d.ResourceId");
            }
        }
    }
}
