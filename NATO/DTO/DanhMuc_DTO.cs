using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NATO.DTO
{
    public class DanhMuc_DTO
    {
        private string maDM;
        private string tenDM;
        private string moTa;

        public DanhMuc_DTO()
        {
            maDM = "";
            tenDM = "";
            moTa = "";
        }

        public DanhMuc_DTO(string madm, string tendm, string mota)
        {
            this.maDM = madm;
            this.tenDM = tendm;
            this.moTa = mota;
        }

        public string MaDM { get; set; }
        public string TenDM { get; set; }
        public string MoTa { get; set; }
    }
}
