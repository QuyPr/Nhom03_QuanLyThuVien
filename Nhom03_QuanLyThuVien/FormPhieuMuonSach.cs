using Nhom03_QuanLyThuVien.Models;
using Nhom03_QuanLyThuVien.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom03_QuanLyThuVien
{
    public partial class FormPhieuMuonSach : Form
    {
        static ThuVienContextDB contextDB = new ThuVienContextDB();

        List<PHIEUMUONSACH> PhieuMuonList = contextDB.PHIEUMUONSACHes.ToList();
        List<SACH> SachList = contextDB.SACHes.ToList();
        List<DOCGIA> DocGiaList = contextDB.DOCGIAs.ToList();

        int rowIndex = -1;
        private ToolTip toolTip1;

        public FormPhieuMuonSach()
        {
            InitializeComponent();
            BingdingPhieuMuonToDatagridview(PhieuMuonList);
            FillDocGiaToCombobox(DocGiaList);

            cmbMaDocGia.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaDocGia.SelectedIndex = -1;

            toolTip1 = new ToolTip();
            toolTip1.SetToolTip(btnThem, "Thêm phiếu mượn");
            toolTip1.SetToolTip(btnSua, "Sửa phiếu mượn");
            toolTip1.SetToolTip(btnXoa, "Xoá phiếu mượn");
            toolTip1.SetToolTip(btnThoat, "Thoát chương trình");
            toolTip1.SetToolTip(txtTimKiem, "Nhập mã phiếu mượn hệ thống sẽ tự động hiện thị kết quả");
            toolTip1.SetToolTip(txtTimKiem2, "Nhập mã độc giả hệ thống sẽ tự động hiện thị kết quả");
            toolTip1.SetToolTip(label1, "Click để reload lại bảng dữ liệu");
            toolTip1.SetToolTip(dtp_TimTheoThoiGian, "chojnn ngày mượn hệ thống sẽ tự động hiện thị kết quả");

        }
        public void FillDocGiaToCombobox(List<DOCGIA> Docgias)
        {
            cmbMaDocGia.DataSource = Docgias;
            cmbMaDocGia.ValueMember = "MaDocGia";
            cmbMaDocGia.DisplayMember = "TenDocGia";
        }

        public void BingdingPhieuMuonToDatagridview(List<PHIEUMUONSACH> PhieuMuon)
        {
            dgvDSPM.Rows.Clear();
            foreach (var item in PhieuMuon)
            {
                int index = dgvDSPM.Rows.Add();
                dgvDSPM.Rows[index].Cells[0].Value = item.MaPhieuMuon;
                dgvDSPM.Rows[index].Cells[1].Value = item.MaDocGia;
                dgvDSPM.Rows[index].Cells[2].Value = item.NgayMuon;
            }
        }

        private void dgvDSPM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            if (rowIndex >= 0 && rowIndex < dgvDSPM.Rows.Count)
            {
                txtMaPhieuMuon.Text = dgvDSPM.Rows[rowIndex].Cells[0].Value.ToString();
                cmbMaDocGia.Text = dgvDSPM.Rows[rowIndex].Cells[1].Value.ToString();
                dtpNgayMuon.Text = dgvDSPM.Rows[rowIndex].Cells[2].Value.ToString();

            }
        }

        private void ReloadDSPM()
        {
            txtMaPhieuMuon.Text = "";
            List<PHIEUMUONSACH> PhieuMuonLoad = contextDB.PHIEUMUONSACHes.ToList();
            BingdingPhieuMuonToDatagridview(PhieuMuonLoad);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbMaDocGia.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn Mã Độc Giả trước khi thêm phiếu mượn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MessageBox.Show("Mã phiếu mượn được tự động cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PHIEUMUONSACH Pm = new PHIEUMUONSACH()
                {
                    MaDocGia = (int)cmbMaDocGia.SelectedValue,
                    NgayMuon = dtpNgayMuon.Value

                };

                contextDB.PHIEUMUONSACHes.Add(Pm);
                contextDB.SaveChanges();


                MessageBox.Show("Thêm thành công !");
                ReloadDSPM();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (cmbMaDocGia.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Mã Độc Giả trước khi thêm phiếu mượn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (rowIndex >= 0 && rowIndex < dgvDSPM.Rows.Count)
            {
                int selectedMaPhieuMuon = int.Parse(txtMaPhieuMuon.Text);
                var selectedMember = contextDB.PHIEUMUONSACHes.FirstOrDefault(dg => dg.MaPhieuMuon == selectedMaPhieuMuon);
                if (selectedMember != null)
                {
                    selectedMember.MaDocGia = (int)cmbMaDocGia.SelectedValue;
                }
                try
                {
                    contextDB.SaveChanges();
                    MessageBox.Show("Cập nhật thông tin phiếu mượn thành công!");
                    rowIndex = 0;
                    ReloadDSPM();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật thông tin phiếu mượn: " + ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (rowIndex >= 0 && rowIndex < dgvDSPM.Rows.Count)
            {
                int selectedMaPhieuMuon = int.Parse(txtMaPhieuMuon.Text);
                var selectedMember = contextDB.PHIEUMUONSACHes.FirstOrDefault(dg => dg.MaPhieuMuon == selectedMaPhieuMuon);
                if (selectedMember != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xoá phiếu mượn này?", "Xác nhận xoá", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        contextDB.PHIEUMUONSACHes.Remove(selectedMember);
                        contextDB.SaveChanges();
                        MessageBox.Show("Xoá thành công!");
                        rowIndex = -1;
                        ReloadDSPM();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 phiếu mượn để cập nhật thông tin.");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void chbLocTrongNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (chbLocTrongNgay.Checked)
            {
                DateTime today = DateTime.Now.Date;
                List<PHIEUMUONSACH> phiemMuonTrongNgay = contextDB.PHIEUMUONSACHes
                    .Where(p => DbFunctions.TruncateTime(p.NgayMuon) == today)
                    .ToList();

                if (phiemMuonTrongNgay.Count > 0)
                {
                    BingdingPhieuMuonToDatagridview(phiemMuonTrongNgay);
                }
                else
                {
                    MessageBox.Show("Không có phiếu mượn nào trong ngày hôm nay.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chbLocTrongNgay.Checked = false;
                    ReloadDSPM();
                }
            }
            else
            {
                BingdingPhieuMuonToDatagridview(PhieuMuonList);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ReloadDSPM();
        }

        private void txtTimKiem_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTimKiem2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTimKiem_TextChanged_1(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.ToLower();
            List<PHIEUMUONSACH> timKiemList = new List<PHIEUMUONSACH>();
            if (!string.IsNullOrEmpty(keyword))
            {
                timKiemList = contextDB.PHIEUMUONSACHes.Where(d => d.MaPhieuMuon.ToString().Contains(keyword)).ToList();
            }
            else
            {
                timKiemList = contextDB.PHIEUMUONSACHes.ToList();
            }
            BingdingPhieuMuonToDatagridview(timKiemList);
        }

        private void txtTimKiem2_TextChanged_1(object sender, EventArgs e)
        {
            string keyword = txtTimKiem2.Text.ToLower();
            List<PHIEUMUONSACH> timKiemList = new List<PHIEUMUONSACH>();

            if (!string.IsNullOrEmpty(keyword))
            {
                timKiemList = contextDB.PHIEUMUONSACHes.Where(d => d.MaDocGia.ToString().Contains(keyword)).ToList();
            }
            else
            {
                timKiemList = contextDB.PHIEUMUONSACHes.ToList();
            }

            BingdingPhieuMuonToDatagridview(timKiemList);
        }

        private void dtp_TimTheoThoiGian_ValueChanged_1(object sender, EventArgs e)
        {
            DateTime selectedDate = dtp_TimTheoThoiGian.Value.Date;
            DateTime today = DateTime.Now.Date;

            if (selectedDate > today)
            {
                MessageBox.Show("Không thể tìm kiếm trong tương lai.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtp_TimTheoThoiGian.Value = today;
                ReloadDSPM();
            }
            else
            {
                List<PHIEUMUONSACH> phiemMuonTheoThoiGian = contextDB.PHIEUMUONSACHes
                    .Where(p => DbFunctions.TruncateTime(p.NgayMuon) == selectedDate)
                    .ToList();

                if (phiemMuonTheoThoiGian.Count > 0)
                {
                    BingdingPhieuMuonToDatagridview(phiemMuonTheoThoiGian);
                }
                else
                {
                    MessageBox.Show("Không có phiếu mượn nào trong ngày đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReloadDSPM();
                }
            }
        }

        private void FormPhieuMuonSach_Load(object sender, EventArgs e)
        {

        }
    }
}

