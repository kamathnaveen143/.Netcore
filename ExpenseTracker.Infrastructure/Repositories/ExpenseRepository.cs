﻿using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.ViewModel;
using ExpenseTracker.Infrastructure.Contracts;
using ExpenseTracker.Infrastructure.SqlServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Infrastructure.Repositories
{
    public class ExpenseRepository : Repository<Expense>, IExpenseRepository
    {
        private readonly DataContext _context;
        public ExpenseRepository(DataContext context) : base(context)
        {
            this._context = context;
        }
        public IList<ExpenseVM> getAllExpenses()
        {
            var list = (from a in _context.Expenses
                        join c in _context.ExpenseCategories on a.CategoryID equals c.CategoryID
                        select new ExpenseVM
                        {
                            ExpenseID = a.ExpenseID,
                            CategoryName = c.CategoryName,
                            Amount = a.Amount,
                            ExpenseDate = a.ExpenseDate,
                        }).ToList();
            return list;
        }

        //public IEnumerable<ExpenseVM> getAllExpenses()
        //{
        //    var list = _context.Expenses
        //                 join c in _context.ExpenseCategories on a.CategoryID equals c.CategoryID

        //        select (Ex => new ExpenseVM()
        //        {
        //            ExpenseID = a.ExpenseID,
        //            CategoryName = c.CategoryName,
        //            Amount = a.Amount,
        //            ExpenseDate = a.ExpenseDate
        //        });
        //    }
        //}


        //public void DeleteExpense(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Expense GetExpenses(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public void SaveExpenses(Expense expences)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
