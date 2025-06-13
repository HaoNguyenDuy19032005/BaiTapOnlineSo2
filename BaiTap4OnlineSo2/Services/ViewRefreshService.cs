using BaiTap4OnlineSo2.Models;
using Microsoft.EntityFrameworkCore;

namespace BaiTap4OnlineSo2.Services
{
    public class ViewRefreshService
    {
        private readonly BaiTapOnlineSo2Context _context;

        public ViewRefreshService(BaiTapOnlineSo2Context context)
        {
            _context = context;
        }

        public void RefreshMaterializedViews()
        {
            // Thực thi lệnh SQL để làm mới các Materialized View trong PostgreSQL
            _context.Database.ExecuteSqlRaw("REFRESH MATERIALIZED VIEW thongke_dichvu");
            _context.Database.ExecuteSqlRaw("REFRESH MATERIALIZED VIEW thongke_sudung_nhiemvu");
            _context.Database.ExecuteSqlRaw("REFRESH MATERIALIZED VIEW thongke_nhiemvu_theothietbi");
        }
    }
}