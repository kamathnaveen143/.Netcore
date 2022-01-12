﻿using ExpenseTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Infrastructure.Contracts
{
    public interface IExpenseRepository : IRepository<Expense>
    {
        IEnumerable<Expense> getAllEnpenses();
        //Expense GetExpenses(int id);
        //void SaveExpenses(Expense expences);

        //void DeleteExpense(int id);
    }
}