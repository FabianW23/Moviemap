using Moviemap.Common.Emuns;
using Moviemap.Web.Data;
using Moviemap.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moviemap.Web.Helpers
{
    public class ChairsHelper : IChairsHelper
    {
        private readonly DataContext _context;

        public ChairsHelper(DataContext context)
        {
            _context = context;
        }

        public List<ChairEntity> GetChairslist(int roomId)
        {
            List<ChairEntity> chairsList = new List<ChairEntity>();
            chairsList.Add(new ChairEntity { Name = "A1", Room = _context.Rooms.Find(roomId), ColumnLocation = 0, RowLocation = 0, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "A2", Room = _context.Rooms.Find(roomId), ColumnLocation = 1, RowLocation = 0, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "A3", Room = _context.Rooms.Find(roomId), ColumnLocation = 2, RowLocation = 0, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "A4", Room = _context.Rooms.Find(roomId), ColumnLocation = 3, RowLocation = 0, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "A5", Room = _context.Rooms.Find(roomId), ColumnLocation = 4, RowLocation = 0, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "A6", Room = _context.Rooms.Find(roomId), ColumnLocation = 5, RowLocation = 0, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "A7", Room = _context.Rooms.Find(roomId), ColumnLocation = 6, RowLocation = 0, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "A8", Room = _context.Rooms.Find(roomId), ColumnLocation = 7, RowLocation = 0, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "B1", Room = _context.Rooms.Find(roomId), ColumnLocation = 0, RowLocation = 1, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "B2", Room = _context.Rooms.Find(roomId), ColumnLocation = 1, RowLocation = 1, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "B3", Room = _context.Rooms.Find(roomId), ColumnLocation = 2, RowLocation = 1, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "B4", Room = _context.Rooms.Find(roomId), ColumnLocation = 3, RowLocation = 1, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "B5", Room = _context.Rooms.Find(roomId), ColumnLocation = 4, RowLocation = 1, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "B6", Room = _context.Rooms.Find(roomId), ColumnLocation = 5, RowLocation = 1, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "B7", Room = _context.Rooms.Find(roomId), ColumnLocation = 6, RowLocation = 1, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "B8", Room = _context.Rooms.Find(roomId), ColumnLocation = 7, RowLocation = 1, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "C1", Room = _context.Rooms.Find(roomId), ColumnLocation = 0, RowLocation = 2, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "C2", Room = _context.Rooms.Find(roomId), ColumnLocation = 1, RowLocation = 2, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "C3", Room = _context.Rooms.Find(roomId), ColumnLocation = 2, RowLocation = 2, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "C4", Room = _context.Rooms.Find(roomId), ColumnLocation = 3, RowLocation = 2, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "C5", Room = _context.Rooms.Find(roomId), ColumnLocation = 4, RowLocation = 2, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "C6", Room = _context.Rooms.Find(roomId), ColumnLocation = 5, RowLocation = 2, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "C7", Room = _context.Rooms.Find(roomId), ColumnLocation = 6, RowLocation = 2, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "C9", Room = _context.Rooms.Find(roomId), ColumnLocation = 7, RowLocation = 2, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "D1", Room = _context.Rooms.Find(roomId), ColumnLocation = 0, RowLocation = 3, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "D2", Room = _context.Rooms.Find(roomId), ColumnLocation = 1, RowLocation = 3, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "D3", Room = _context.Rooms.Find(roomId), ColumnLocation = 2, RowLocation = 3, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "D4", Room = _context.Rooms.Find(roomId), ColumnLocation = 3, RowLocation = 3, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "D5", Room = _context.Rooms.Find(roomId), ColumnLocation = 4, RowLocation = 3, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "D6", Room = _context.Rooms.Find(roomId), ColumnLocation = 5, RowLocation = 3, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "D7", Room = _context.Rooms.Find(roomId), ColumnLocation = 6, RowLocation = 3, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "D8", Room = _context.Rooms.Find(roomId), ColumnLocation = 7, RowLocation = 3, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "E1", Room = _context.Rooms.Find(roomId), ColumnLocation = 0, RowLocation = 4, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "E2", Room = _context.Rooms.Find(roomId), ColumnLocation = 1, RowLocation = 4, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "E3", Room = _context.Rooms.Find(roomId), ColumnLocation = 2, RowLocation = 4, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "E4", Room = _context.Rooms.Find(roomId), ColumnLocation = 3, RowLocation = 4, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "E5", Room = _context.Rooms.Find(roomId), ColumnLocation = 4, RowLocation = 4, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "E6", Room = _context.Rooms.Find(roomId), ColumnLocation = 5, RowLocation = 4, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "E7", Room = _context.Rooms.Find(roomId), ColumnLocation = 6, RowLocation = 4, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "E8", Room = _context.Rooms.Find(roomId), ColumnLocation = 7, RowLocation = 4, ChairType = ChairType.Available.ToString() });
            chairsList.Add(new ChairEntity { Name = "E8", Room = _context.Rooms.Find(roomId), ColumnLocation = 8, RowLocation = 4, ChairType = ChairType.Available.ToString() });
            return chairsList;
        }

        public void AddChairsToRoom(RoomEntity room)
        {
            _context.Chairs.Add(new ChairEntity { Name = "A1", Room = room, ColumnLocation = 0, RowLocation = 0, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "A2", Room = room, ColumnLocation = 1, RowLocation = 0, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "A3", Room = room, ColumnLocation = 2, RowLocation = 0, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "A4", Room = room, ColumnLocation = 3, RowLocation = 0, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "A5", Room = room, ColumnLocation = 4, RowLocation = 0, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "A6", Room = room, ColumnLocation = 5, RowLocation = 0, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "A7", Room = room, ColumnLocation = 6, RowLocation = 0, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "A8", Room = room, ColumnLocation = 7, RowLocation = 0, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "B1", Room = room, ColumnLocation = 0, RowLocation = 1, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "B2", Room = room, ColumnLocation = 1, RowLocation = 1, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "B3", Room = room, ColumnLocation = 2, RowLocation = 1, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "B4", Room = room, ColumnLocation = 3, RowLocation = 1, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "B5", Room = room, ColumnLocation = 4, RowLocation = 1, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "B6", Room = room, ColumnLocation = 5, RowLocation = 1, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "B7", Room = room, ColumnLocation = 6, RowLocation = 1, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "B8", Room = room, ColumnLocation = 7, RowLocation = 1, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "C1", Room = room, ColumnLocation = 0, RowLocation = 2, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "C2", Room = room, ColumnLocation = 1, RowLocation = 2, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "C3", Room = room, ColumnLocation = 2, RowLocation = 2, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "C4", Room = room, ColumnLocation = 3, RowLocation = 2, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "C5", Room = room, ColumnLocation = 4, RowLocation = 2, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "C6", Room = room, ColumnLocation = 5, RowLocation = 2, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "C7", Room = room, ColumnLocation = 6, RowLocation = 2, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "C9", Room = room, ColumnLocation = 7, RowLocation = 2, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "D1", Room = room, ColumnLocation = 0, RowLocation = 3, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "D2", Room = room, ColumnLocation = 1, RowLocation = 3, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "D3", Room = room, ColumnLocation = 2, RowLocation = 3, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "D4", Room = room, ColumnLocation = 3, RowLocation = 3, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "D5", Room = room, ColumnLocation = 4, RowLocation = 3, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "D6", Room = room, ColumnLocation = 5, RowLocation = 3, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "D7", Room = room, ColumnLocation = 6, RowLocation = 3, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "D8", Room = room, ColumnLocation = 7, RowLocation = 3, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "E1", Room = room, ColumnLocation = 0, RowLocation = 4, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "E2", Room = room, ColumnLocation = 1, RowLocation = 4, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "E3", Room = room, ColumnLocation = 2, RowLocation = 4, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "E4", Room = room, ColumnLocation = 3, RowLocation = 4, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "E5", Room = room, ColumnLocation = 4, RowLocation = 4, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "E6", Room = room, ColumnLocation = 5, RowLocation = 4, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "E7", Room = room, ColumnLocation = 6, RowLocation = 4, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "E8", Room = room, ColumnLocation = 7, RowLocation = 4, ChairType = ChairType.Available.ToString() });
            _context.Chairs.Add(new ChairEntity { Name = "E8", Room = room, ColumnLocation = 8, RowLocation = 4, ChairType = ChairType.Available.ToString() });
        }
    }
}
