using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NATO.DTO
{
    public class HoaDon_DTO
    {
        private int mahd;
        private string username;
        private float tongtien;
        private DateTime date;

        public HoaDon_DTO()
        {
            mahd = 0;
            username = "";
            tongtien = 0;
            date = DateTime.Today;
        }

        public int MaHD { get; set; }
        public string Username {get; set;}
        public float TongTien { get; set; }
        public DateTime Date { get; set; }
    }
}
