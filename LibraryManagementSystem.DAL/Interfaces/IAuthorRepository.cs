﻿using LibraryManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(int id);
        Task AddAsync(Author author);

        Task UpdateAsync(Author author);
        Task DeleteAsync(int id);
    }
}
