﻿using System.Linq.Expressions;

namespace MoneyControl.WebAPI.Data.Contracts.Utilities
{
    public interface IPredicateBuilder
    {
        public Expression<Func<T, bool>> True<T>();
        public Expression<Func<T, bool>> False<T>();
        public Expression<Func<T, bool>> And<T>(Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2);
        public Expression<Func<T, bool>> Or<T>(Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2);
    }
}
