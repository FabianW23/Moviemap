using Moviemap.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moviemap.Web.Helpers
{
    public interface IChairsHelper
    {
        List<ChairEntity> GetChairslist(int roomId);

        void AddChairsToRoom(RoomEntity room);
    }
}
