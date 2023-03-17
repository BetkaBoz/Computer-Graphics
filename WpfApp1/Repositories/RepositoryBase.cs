﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ComputerGraphics.Repositories
{
    public abstract class RepositoryBase
    {
        readonly string _connectionString;
        public RepositoryBase()
        {
            _connectionString = "Server=(local); Database=MVVMLoginDB; Integrated Security=true";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
