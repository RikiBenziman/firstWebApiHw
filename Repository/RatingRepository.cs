using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RatingRepository : IRatingRepository
    {
        IConfiguration _configuration;
        public RatingRepository( IConfiguration configuration)
        {
           
            _configuration =configuration;
        }

        public async Task creatRatingAsync(Rating rating)
        {

            string? HOST, METHOD, PATH, REFERER, USER_AGENT;
            DateTime? Record_Date;
            HOST = rating.Host;
            METHOD = rating.Method;
            PATH = rating.Path;
            REFERER = rating.Referer;
            USER_AGENT = rating.UserAgent;
            Record_Date = rating.RecordDate;
            string query = "insert into RATING(HOST,METHOD,PATH,REFERER,USER_AGENT,Record_Date)" +
            "Values(@HOST,@METHOD,@PATH,@REFERER,@USER_AGENT,@Record_Date)";
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("MySchool")))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@HOST", SqlDbType.NVarChar, 50).Value = HOST;
                cmd.Parameters.Add("@METHOD", SqlDbType.NChar, 10).Value = METHOD;
                cmd.Parameters.Add("@PATH", SqlDbType.NVarChar, 50).Value = PATH;
                cmd.Parameters.Add("@REFERER", SqlDbType.NVarChar, 100).Value = REFERER;
                cmd.Parameters.Add("@USER_AGENT", SqlDbType.NVarChar, int.MaxValue).Value = USER_AGENT;
                cmd.Parameters.Add("@Record_Date", SqlDbType.DateTime).Value = Record_Date;
                cn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}
