﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleDronBot.Base.BaseClass;
using TeleDronBot.DTO;
using TeleDronBot.Repository;

namespace TeleDronBot.Bot
{
    class HubsHandler : RepositoryProvider
    {
        public async static ValueTask<long> GetReceviedChatId(long chatid)
        {
            HubDTO hub = await HubRepository.FindById(chatid);
            return hub.ChatIdReceiver;
        }

        public async ValueTask<long[]> GetChatId(long chatid)
        {
            HubDTO hub1 = await hubRepository.FindById(chatid);
            long[] res = new long[2];
            res[0] = hub1.ChatIdCreater;
            res[1] = hub1.ChatIdReceiver;
            return res;
        }

        public async ValueTask<bool> IsChatActive(long chatid)
        {
            HubDTO hub1 = await hubRepository.FindById(chatid);

            if (hub1 == null || hub1.ChatIdReceiver == 0)
            {
                return false;
            }

            IEnumerable<HubDTO> hubs = await hubRepository.Get(i => i.ChatIdCreater == hub1.ChatIdReceiver);
            return hubs == null ? false : true;
        }
    }
}
