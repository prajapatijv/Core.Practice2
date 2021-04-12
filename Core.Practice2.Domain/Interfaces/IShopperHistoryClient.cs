﻿using Core.Practice2.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Practice2.Domain.Interfaces
{
    public interface IShopperHistoryClient
    {
        Task<IList<ShopperHistory>> GetShopperHistor();
    }
}
