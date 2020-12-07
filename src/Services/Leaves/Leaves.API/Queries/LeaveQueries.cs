using Dapper;
using Leaves.Domain.AggregatesModel.LeaveAggregate;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leaves.API.Queries
{
    public class LeaveQueries : ILeaveQueries
    {
        private string _connectionString = string.Empty;

        public LeaveQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<IEnumerable<LeaveTypeViewModel>> GetLeaveTypesAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<LeaveTypeViewModel>("SELECT * FROM leaves_db.LEAVE_TYPES");
            }
        }
    }
}
