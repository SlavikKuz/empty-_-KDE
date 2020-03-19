﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleDronBot.Base.BaseClass;

namespace TeleDronBot.DTO
{
    class CountPropose
    {
        [Key]
        public int Id { get; set; }

        public int Count { get; set; }
    }

    class CountProposeHandler : RepositoryProvider
    {
        public async static ValueTask<int> GetCount()
        {
            IEnumerable<CountPropose> c = await countProposeRepository.Get();
            return c.ToList()[0].Count;
        }

        public async Task ChangeProposeCount()
        {
            int countFields = await countProposeRepository.CountAsync();

            if (countFields == 0)
            {
                CountPropose c = new CountPropose();
                c.Count = 1;
                await countProposeRepository.Create(c);
            }

            IEnumerable<CountPropose> entity = await countProposeRepository.Get();
            CountPropose countPropose = entity.ToList()[0];
            countPropose.Count = countPropose.Count + 1;
            await countProposeRepository.Update(countPropose);
        }
    }
}
