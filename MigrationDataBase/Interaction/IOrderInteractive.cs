﻿using MigrationDataBase.Records;
using MigrationDataBase.Filters;

namespace MigrationDataBase.Interaction
{
    public interface IOrderInteractive
    {
        bool Add(Order order);
        bool Set(Order order, Order newOrder);
    }
}
