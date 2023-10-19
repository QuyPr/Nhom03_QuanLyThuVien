using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom03_QuanLyThuVien
{
    public partial class TrangChuThuVien : Form
    {
        public TrangChuThuVien()
        {
            InitializeComponent();
        }
        private void btnDocGia_Click(object sender, EventArgs e)
        {
            lblDocGia_Click(sender, e);
        }
        private void lblDocGia_Click(object sender, EventArgs e)
        {
            FormDocGia frm = new FormDocGia();
            frm.ShowDialog();
        }
        private void btnBangCap_Click(object sender, EventArgs e)
        {
            lblBangCap_Click((object)sender, e);
        }
        private void lblBangCap_Click(object sender, EventArgs e)
        {
            FormBangCap frm = new FormBangCap();
            frm.ShowDialog();
        }

        private void lblNhanVien_Click(object sender, EventArgs e)
        {
            FormNhanVien frm = new FormNhanVien();
            frm.ShowDialog();
        }
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            lblNhanVien_Click((object)sender, e);
        }
        private void lblMuonSach_Click(object sender, EventArgs e)
        {
            FormPhieuMuonSach frm = new FormPhieuMuonSach();
            frm.ShowDialog();
        }
        private void btnMuonSach_Click(object sender, EventArgs e)
        {
            lblMuonSach_Click((object)sender, e);  
        }
        private void lblPhieuThuTien_Click(object sender, EventArgs e)
        {
            FormPhieuThuTien frm = new FormPhieuThuTien();
            frm.ShowDialog();
        }
        private void btnPhieuThuTien_Click(object sender, EventArgs e)
        {
            lblPhieuThuTien_Click((object)sender, e);
        }
        private void lblSach_Click(object sender, EventArgs e)
        {
            FormSach frm = new FormSach();
            frm.ShowDialog();
        }
        private void btnSach_Click(object sender, EventArgs e)
        {
            lblSach_Click((object)sender, e);
        }
    }
}
