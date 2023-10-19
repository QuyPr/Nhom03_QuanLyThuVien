using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nhom03_QuanLyThuVien.Models;

namespace Nhom03_QuanLyThuVien
{
    public partial class FormDocGia : Form
    {
        static ThuVienContextDB contextDB = new ThuVienContextDB();
        List<DOCGIA> docGiaList = contextDB.DOCGIAs.ToList();
        public void BindingDocGiaToGirdView(List<DOCGIA> docGia)
        {
            dgvDSDG.Rows.Clear();
            //do data xuong
            foreach (var item in docGia)
            {
                int index = dgvDSDG.Rows.Add();
                dgvDSDG.Rows[index].Cells[0].Value = item.MaDocGia;
                dgvDSDG.Rows[index].Cells[1].Value = item.HoTenDocGia;
                dgvDSDG.Rows[index].Cells[2].Value = item.NgaySinh;
                dgvDSDG.Rows[index].Cells[3].Value = item.DiaChi;
                dgvDSDG.Rows[index].Cells[4].Value = item.Email;
                dgvDSDG.Rows[index].Cells[5].Value = item.NgayLapThe;
                dgvDSDG.Rows[index].Cells[6].Value = item.NgayHetHan;
                dgvDSDG.Rows[index].Cells[7].Value = item.TienNo;
            }
        }
        public FormDocGia()
        {
            InitializeComponent();
            BindingDocGiaToGirdView(docGiaList);
        }
        int rowIndex = -1;
        private void dgvDSDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            if (rowIndex >= 0 && rowIndex < dgvDSDG.Rows.Count)
            {
                txtMaDocGia.Text = dgvDSDG.Rows[rowIndex].Cells[0].Value.ToString();
                txtHoTen.Text = dgvDSDG.Rows[rowIndex].Cells[1].Value.ToString();
                dtpNgaySinh.Value = DateTime.Parse(dgvDSDG.Rows[rowIndex].Cells[2].Value.ToString());
                txtDiaChi.Text = dgvDSDG.Rows[rowIndex].Cells[3].Value.ToString();
                txtEmail.Text = dgvDSDG.Rows[rowIndex].Cells[4].Value.ToString();
                dtpNgayLapThe.Value = DateTime.Parse(dgvDSDG.Rows[rowIndex].Cells[5].Value.ToString());
                dtpNgayHetHan.Value = DateTime.Parse(dgvDSDG.Rows[rowIndex].Cells[6].Value.ToString());
                txtTienNo.Text = dgvDSDG.Rows[rowIndex].Cells[7].Value.ToString();
            }
        }
        private void ReloadDSSV()
        {
            txtMaDocGia.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtTienNo.Text = "";
            List<DOCGIA> docGiaList = contextDB.DOCGIAs.ToList();
            BindingDocGiaToGirdView(docGiaList);
        }
        private bool IsAtLeast12YearsOld(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age))
            {
                age--;
            }
            return (age >= 12) || (age < 150);
        }
        private bool KiemTraRong()
        {
            if (txtHoTen.Text == "" || txtDiaChi.Text == "" || txtEmail.Text == "" || txtTienNo.Text == ""
                || dtpNgayLapThe.Value > dtpNgayHetHan.Value || !IsAtLeast12YearsOld(dtpNgaySinh.Value))
                return true;
            return false;
        }
        private void checkDay()
        {
            if (dtpNgayLapThe.Value > dtpNgayHetHan.Value)
                MessageBox.Show("Ngay het han lon hon ngay lap the");
            if (!IsAtLeast12YearsOld(dtpNgaySinh.Value))
                MessageBox.Show("Doc Gia phai du 12 tuoi, Chọn năm sinh hợp lý");
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTraRong())
                {
                    if (txtHoTen.Text == "" || txtDiaChi.Text == "" || txtEmail.Text == "" || txtTienNo.Text == "")
                        MessageBox.Show("Hay nhap du thong tin");
                    else
                    {
                        checkDay();
                    }
                }
                else
                {
                    MessageBox.Show("Mã đọc giả được tự động cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DOCGIA dg = new DOCGIA
                    {
                        HoTenDocGia = txtHoTen.Text,
                        NgaySinh = dtpNgaySinh.Value,
                        DiaChi = txtDiaChi.Text,
                        Email = txtEmail.Text,
                        NgayLapThe = dtpNgayLapThe.Value,
                        NgayHetHan = dtpNgayHetHan.Value,
                        TienNo = int.Parse(txtTienNo.Text)
                    };
                    contextDB.DOCGIAs.Add(dg);
                    contextDB.SaveChanges();
                    MessageBox.Show("Them Doc Gia Moi Thanh Cong!");
                    ReloadDSSV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (rowIndex >= 0 && rowIndex < dgvDSDG.Rows.Count)
            {
                int selectedMaDocGia = int.Parse(txtMaDocGia.Text);
                var selectedMember = contextDB.DOCGIAs.FirstOrDefault(dg => dg.MaDocGia == selectedMaDocGia);
                if (selectedMember != null && !KiemTraRong())
                {
                    selectedMember.HoTenDocGia = txtHoTen.Text;
                    selectedMember.NgaySinh = dtpNgaySinh.Value;
                    selectedMember.DiaChi = txtDiaChi.Text;
                    selectedMember.Email = txtEmail.Text;
                    selectedMember.NgayLapThe = dtpNgayLapThe.Value;
                    selectedMember.NgayHetHan = dtpNgayHetHan.Value;
                    selectedMember.TienNo = double.Parse(txtTienNo.Text);
                    try
                    {
                        contextDB.SaveChanges();
                        MessageBox.Show("Cập nhật thông tin đọc giả thành công!");
                        rowIndex = -1;
                        ReloadDSSV();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật thông tin đọc giả: " + ex.Message);
                    }
                }
                else
                {
                    if (txtHoTen.Text == "" || txtDiaChi.Text == "" || txtEmail.Text == "" || txtTienNo.Text == "")
                        MessageBox.Show("Hay nhap du thong tin");
                    else
                    {
                        checkDay();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 đọc giả để cập nhật thông tin.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (rowIndex >= 0 && rowIndex < dgvDSDG.Rows.Count)
            {
                int selectedMaDocGia = int.Parse(txtMaDocGia.Text);
                var selectedMember = contextDB.DOCGIAs.FirstOrDefault(dg => dg.MaDocGia == selectedMaDocGia);
                if (selectedMember != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xoá sinh viên này?", "Xác nhận xoá", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        contextDB.DOCGIAs.Remove(selectedMember);
                        contextDB.SaveChanges();
                        MessageBox.Show("Xoá đọc giả thành công!");
                        rowIndex = -1;
                        ReloadDSSV();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 đọc giả để cập nhật thông tin.");
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.ToLower();
            List<DOCGIA> timKiemList = new List<DOCGIA>();
            if (!string.IsNullOrEmpty(keyword))
            {
                timKiemList = contextDB.DOCGIAs
                    .Where(d => d.MaDocGia.ToString().Contains(keyword) ||
                                d.HoTenDocGia.ToLower().Contains(keyword) ||
                                //d.NgaySinh.ToString().Contains(keyword) ||
                                d.DiaChi.ToLower().Contains(keyword) /*||
                                d.NgayLapThe.ToString().Contains(keyword) ||
                                d.NgayHetHan.ToString().Contains(keyword) ||
                                d.TienNo.ToString().Contains(keyword)*/)
                    .ToList();
            }
            else
            {
                timKiemList = contextDB.DOCGIAs.ToList();
            }
            BindingDocGiaToGirdView(timKiemList);
        }

        private void chbLocNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chbLocNo.Checked)
            {
                var DocGiaNoTien = docGiaList.Where(dg => dg.TienNo > 0).ToList();
                BindingDocGiaToGirdView(DocGiaNoTien);
            }
            else
            {
                BindingDocGiaToGirdView(docGiaList);
            }
        }
    }
}
