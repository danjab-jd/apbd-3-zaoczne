﻿using APBD3.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APBD3.Services
{
    public class DbService : IDbService
    {
        private const string ConnString = "Data Source=db-mssql;Initial Catalog=jd;Integrated Security=True";
        
        public async Task<IList<Book>> GetBookListAsync()
        {
            List<Book> result = new();

            string sql = "SELECT * FROM Book";

            await using SqlConnection connection = new(ConnString);

            await using SqlCommand comm = new(sql, connection);

            await connection.OpenAsync();

            await using SqlDataReader dr = await comm.ExecuteReaderAsync();

            while(await dr.ReadAsync())
            {
                result.Add(new Book
                {
                    IdBook = int.Parse(dr["IdBook"].ToString()),
                    Title = dr["Title"].ToString()
                }) ;
            }

            return result;
        }
    }
}
