using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nhom03_QuanLyThuVien.Models;
using System.Runtime.Remoting.Contexts;
using Nhom03_QuanLyThuVien.Models;

namespace Nhom03_QuanLyThuVien
{
    public partial class FormSach : Form
    {
        static ThuVienContextDB context = new ThuVienContextDB();
        List<SACH> SachList = context.SACHes.ToList();
        public FormSach()
        {
            InitializeComponent();
            BindingSachToGirdView(SachList);

        }
        private void BindingSachToGirdView(List<SACH> listSach)
        {
            dgvDSSach.Rows.Clear();
            foreach (var item in listSach)
            {
                int index = dgvDSSach.Rows.Add();
                dgvDSSach.Rows[index].Cells[0].Value = item.MaSach;
                dgvDSSach.Rows[index].Cells[1].Value = item.TenSach;
                dgvDSSach.Rows[index].Cells[2].Value = item.TacGia;
                dgvDSSach.Rows[index].Cells[3].Value = item.NamXuatBan;
                dgvDSSach.Rows[index].Cells[4].Value = item.NhaXuatBan;
                dgvDSSach.Rows[index].Cells[5].Value = item.TriGia;
                dgvDSSach.Rows[index].Cells[6].Value = item.NgayNhap;
            }
        }
        private void ReloadDSSV()
        {

            txtTenSach.Text = "";
            txtTacGia.Text = "";
            txtNamXB.Text = "";
            txtNhaXB.Text = "";
            txtTriGia.Text = "";
            List<SACH> SachList = context.SACHes.ToList();
            BindingSachToGirdView(SachList);
        }
        private bool KiemTraRong()
        {
            if (txtTenSach.Text == "" || txtTacGia.Text == "" || txtNamXB.Text == ""
                || txtNhaXB.Text == "" || txtTriGia.Text == "")
                return true;
            return false;
        }
        private SACH KiemTraTonTai(String tenSach)
        {
            SACH kt = context.SACHes.FirstOrDefault(e => e.TenSach == tenSach);
            return kt;
        }
        int index = 0;
        private void dgvDSSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index >= 0 && index < dgvDSSach.Rows.Count)
            {
                txtMaSach.Text = dgvDSSach.Rows[index].Cells[0].Value.ToString();
                txtTenSach.Text = dgvDSSach.Rows[index].Cells[1].Value.ToString();
                txtTacGia.Text = dgvDSSach.Rows[index].Cells[2].Value.ToString();
                txtNamXB.Text = dgvDSSach.Rows[index].Cells[3].Value.ToString();
                txtNhaXB.Text = dgvDSSach.Rows[index].Cells[4].Value.ToString();
                txtTriGia.Text = dgvDSSach.Rows[index].Cells[5].Value.ToString();
                dtpNgayNhap.Value = DateTime.Parse(dgvDSSach.Rows[index].Cells[6].Value.ToString());
            }
        }

        private void ptbThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTraRong())
                {
                    if (txtTenSach.Text == "" || txtTacGia.Text == "" || txtNamXB.Text == "" || txtNhaXB.Text == ""
                        || txtTriGia.Text == "")
                        MessageBox.Show("Hay nhap du thong tin");
                }
                else
                {
                    SACH kt = KiemTraTonTai(txtTenSach.Text);
                    if (kt != null)
                    {
                        MessageBox.Show("Sach da ton tai , nhap sach khac!");
                    }
                    else
                    {
                        MessageBox.Show("Mã Sách đã được tự động cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SACH s = new SACH
                        {
                            TenSach = txtTenSach.Text,
                            TacGia = txtTacGia.Text,
                            NamXuatBan = int.Parse(txtNamXB.Text),
                            NhaXuatBan = txtNhaXB.Text,
                            TriGia = float.Parse(txtTriGia.Text),
                            NgayNhap = dtpNgayNhap.Value,
                        };
                        context.SACHes.Add(s);
                        context.SaveChanges();
                        MessageBox.Show("Them Sach Moi Thanh Cong!");
                        ReloadDSSV();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        private void ptbSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (index >= 0 && index < dgvDSSach.Rows.Count)
                {
                    int selectedSach = int.Parse(txtMaSach.Text);
                    var updateBook = context.SACHes.FirstOrDefault(s => s.MaSach == selectedSach);
                    if (updateBook != null && !KiemTraRong())
                    {
                        updateBook.TenSach = txtTenSach.Text;
                        updateBook.TacGia = txtTacGia.Text;
                        updateBook.NamXuatBan = int.Parse(txtNamXB.Text);
                        updateBook.NhaXuatBan = txtNhaXB.Text;
                        updateBook.TriGia = float.Parse(txtTriGia.Text);
                        updateBook.NgayNhap = dtpNgayNhap.Value;
                        context.SaveChanges();
                        MessageBox.Show(" Cập nhật thông tin sách thành công ", "Thông Báo !");
                        ReloadDSSV();

                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy Sách ", "Thông Báo !");
                    }
                }
                else
                {
                    MessageBox.Show(" Hay Nhap Du Thong Tin Sach", " Thong Bao !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;

            }
        }

        private void ptbXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (index >= 0 && index < dgvDSSach.Rows.Count)
                {
                    int selectedSach = int.Parse(txtMaSach.Text);
                    var DeleteSach = context.SACHes.FirstOrDefault(s => s.MaSach == selectedSach);
                    if (DeleteSach != null)
                    {
                        DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xoá sách này?", "Xác nhận xoá", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            context.SACHes.Remove(DeleteSach);
                            context.SaveChanges();
                            MessageBox.Show("Xoá sách thành công!");
                            ReloadDSSV();
                        }
                    }

                }
                else
                {
                    MessageBox.Show(" Khong tim Thay Sach Can Xoa");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }
        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtFind.Text.ToLower();
                List<SACH> SachList = new List<SACH>();
                if (!string.IsNullOrEmpty(keyword))
                {
                    SachList = context.SACHes
                        .Where(d => d.MaSach.ToString().Contains(keyword) ||
                                    d.TenSach.ToLower().Contains(keyword) ||
                                    d.TacGia.ToString().Contains(keyword) ||
                                    d.NamXuatBan.ToString().Contains(keyword) ||
                                    d.NhaXuatBan.ToString().Contains(keyword) ||
                                    d.TriGia.ToString().Contains(keyword) ||
                                    d.NgayNhap.Value.ToString().Contains(keyword)
                                 )

                        .ToList();
                }
                else
                {
                    SachList = context.SACHes.ToList();
                }
                BindingSachToGirdView(SachList);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        private void ptbThoat_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Ban Co Muon Thoat Khong ?", "Xac Nhan Thoat", MessageBoxButtons.OK);
            this.Close();
        }
        private void txtNamXB_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự nhập vào có phải là số hoặc các ký tự liên quan đến số không
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Loại bỏ ký tự không hợp lệ
                MessageBox.Show("Vui long chi nhap so", "Thong Bao !");
            }
        }
        private void txtTriGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự nhập vào có phải là số hoặc các ký tự liên quan đến số không
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Loại bỏ ký tự không hợp lệ
                MessageBox.Show("Vui long chi nhap so", "Thong Bao !");
            }
        }
    }
}
