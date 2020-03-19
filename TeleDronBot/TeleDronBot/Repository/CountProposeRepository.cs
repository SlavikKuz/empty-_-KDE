﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeleDronBot.Base.BaseClass;
using TeleDronBot.DTO;

namespace TeleDronBot.Repository
{
    class CountProposeRepository : BaseProviderImpementation<CountPropose>
    {
        public async ValueTask<int> CountAsync()
        {
            return await db.CountPurpose.CountAsync();
        }
    }
}
