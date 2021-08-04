using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NATO.DAO;
using NATO.DTO;

namespace NATO.BUS
{
    public class MatHang_BUS
    {
        public static MatHang_BUS instance;
        public static MatHang_BUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new MatHang_BUS();
                return instance;
            }
        }

        MatHang_DAO mhdao = new MatHang_DAO();

        public bool themMatHang(MatHang_DTO mh)
        {
            return mhdao.themmatHang(mh);
        }

        public List<MatHang_DTO> getAllMatHang()
        {
            return mhdao.getAllMatHang();
        }

        public List<MatHang_DTO> getMHbyDM(string mdm)
        {
            return mhdao.getMHbyDM(mdm);
        }

        public List<MatHang_DTO> searchMatHang(string str)
        {
            return mhdao.searchMatHang(str);
        }

        public MatHang_DTO getMHbyMaMH(string mmh)
        {
            return mhdao.getMHbyMaMH(mmh);
        }

        public bool capNhatMH(MatHang_DTO mhm, string mmh)
        {
            return mhdao.capNhatMH(mhm, mmh);
        }

        public bool xoaMH(string mmh)
        {
            return mhdao.xoaMatHang(mmh);
        }
    }
}
