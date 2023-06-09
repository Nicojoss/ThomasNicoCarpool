﻿using ThomasNicoCarpool.Models;

namespace ThomasNicoCarpool.DAL.IDAL
{
    public interface IRequestDAL
    {
        public List<Request> GetRequests();
        public bool SaveRequest(Request request);
        public Request GetRequestById(int id);
        public bool RemoveRequestById(int id);
    }
}
