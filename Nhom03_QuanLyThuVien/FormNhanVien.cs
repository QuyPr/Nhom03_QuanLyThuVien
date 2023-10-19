using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nhom03_QuanLyThuVien.Models;
using Nhom03_QuanLyThuVien.Models;

namespace Nhom03_QuanLyThuVien
{
    public partial class FormNhanVien : Form
    {
        static ThuVienContextDB contextDB = new ThuVienContextDB();
        List<NHANVIEN> DanhSachNhanVien = contextDB.NHANVIENs.ToList();
        List<BANGCAP> DanhSachBangCap = contextDB.BANGCAPs.ToList();

        public FormNhanVien()
        {
            InitializeComponent();

        }
        public void BingdingToGridView(List<NHANVIEN> nhanvien)
        {
            // xoa toan bi gridview
            dgvDSDG.Rows.Clear();

            // do du lieu xuong 
            foreach (var item in nhanvien)
            {
                int index = dgvDSDG.Rows.Add(); // them 1 dong moi
                dgvDSDG.Rows[index].Cells[0].Value = item.MaNhanVien;
                dgvDSDG.Rows[index].Cells[1].Value = item.HoTenNhanVien;
                dgvDSDG.Rows[index].Cells[2].Value = item.NgaySinh;
                dgvDSDG.Rows[index].Cells[3].Value = item.DiaChi;
                dgvDSDG.Rows[index].Cells[4].Value = item.DienThoai;
            }
        }
        public void BindingInvoiceToGridView1(List<NHANVIEN> NV)
        {
            for (int i = 0; i < NV.Count; i++)
            {
                dgvDSDG.Rows[i].Cells[5].Value = GetTenBangCap((int)NV[i].MaBangCap);
            }
        }

        // Phương thức để lấy tên bằng cấp dựa trên MaBangCap
        private string GetTenBangCap(int maBangCap)
        {
            // Tìm bằng cấp tương ứng từ danh sách DanhSachBangCap
            BANGCAP bangCap = DanhSachBangCap.FirstOrDefault(bc => bc.MaBangCap == maBangCap);

            // Kiểm tra xem bằng cấp có tồn tại và trả về tên bằng cấp hoặc một giá trị mặc định nếu không tìm thấy.
            return bangCap != null ? bangCap.TenBangCap : "Không xác định";
        }
        public void fillFacultyToCombobox(List<BANGCAP> dsbangcap)
        {
            comboBox1.DataSource = dsbangcap;
            comboBox1.ValueMember = "MaBangCap";
            comboBox1.DisplayMember = "TenBangCap";
        }

        private void dgvDSDG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DocGiaForm_Load(object sender, EventArgs e)
        {
            BingdingToGridView(DanhSachNhanVien);
            BindingInvoiceToGridView1(DanhSachNhanVien);
            fillFacultyToCombobox(DanhSachBangCap);
        }

        private void dgvDSDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra xem có phải dòng tiêu đề không
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dgvDSDG.Rows[e.RowIndex];

                // Lấy giá trị từ các ô của dòng được chọn
                string maNhanVien = selectedRow.Cells[0].Value.ToString();
                string hoTen = selectedRow.Cells[1].Value.ToString();
                string ngaySinhStr = selectedRow.Cells[2].Value.ToString();
                string diaChi = selectedRow.Cells[3].Value.ToString();
                string dienThoai = selectedRow.Cells[4].Value.ToString();
                string tenBangCap = selectedRow.Cells[5].Value.ToString(); // Điều này có thể không cần nếu bạn đã cập nhật dữ liệu từ BindingInvoiceToGridView1



                // Kiểm tra xem ngày sinh có định dạng hợp lệ hay không và chuyển đổi nó thành kiểu DateTime
                DateTime ngaySinh;
                if (DateTime.TryParse(ngaySinhStr, out ngaySinh))
                {
                    dtpNgaySinh.Value = ngaySinh;
                }
                else
                {
                    // Xử lý trường hợp ngày sinh không hợp lệ
                    // Ví dụ: Thiết lập DateTimePicker thành một giá trị mặc định
                    dtpNgaySinh.Value = DateTime.Now;
                }

                // Đổ dữ liệu vào các TextBox
                txtMaNhanVien.Text = maNhanVien;
                txtHoTen.Text = hoTen;
                txtDiaChi.Text = diaChi;
                txtDienThoai.Text = dienThoai;
                comboBox1.Text = tenBangCap;
            }
        }
        public bool checkNull()
        {
            if (string.IsNullOrEmpty(txtHoTen.Text) ||
             string.IsNullOrEmpty(txtDiaChi.Text) ||
             string.IsNullOrEmpty(txtDienThoai.Text)
              )
            {
                MessageBox.Show("khong de rong thong tin");
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool checkSDT()
        {
            if (txtDienThoai.Text.Length != 10)
            {

                MessageBox.Show("nhap du 10 so");
                return true;
            }
            return false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!checkNull() && !checkSDT())
            {
                // Lấy giá trị từ TextBox, ComboBox và DateTimePicker
                string hoTen = txtHoTen.Text;
                string diaChi = txtDiaChi.Text;
                string dienThoai = txtDienThoai.Text;
                int maBangCap = (int)comboBox1.SelectedValue; // Chú ý: Điều này giả định rằng ComboBox đã được cấu hình đúng
                DateTime ngaySinh = dtpNgaySinh.Value;

                // Kiểm tra xem ngày sinh có lớn hơn thời gian hiện tại không
                if (ngaySinh > DateTime.Now)
                {
                    MessageBox.Show("Ngày sinh không được lớn hơn thời gian hiện tại.");
                    return; // Dừng việc thêm khi ngày sinh không hợp lệ
                }

                // Tạo đối tượng NHANVIEN mới
                NHANVIEN newNhanVien = new NHANVIEN
                {
                    HoTenNhanVien = hoTen,
                    DiaChi = diaChi,
                    DienThoai = dienThoai,
                    MaBangCap = maBangCap,
                    NgaySinh = ngaySinh // Thêm ngày sinh vào đối tượng NHANVIEN
                };


                // Xóa các giá trị đã nhập trên giao diện
                txtHoTen.Text = "";
                txtDiaChi.Text = "";
                txtDienThoai.Text = "";
                comboBox1.SelectedIndex = -1;
                dtpNgaySinh.Value = DateTime.Now; // Đặt lại DateTimePicker thành thời gian hiện tạ
                MessageBox.Show("Thêm nhân viên thành công.");
                contextDB.NHANVIENs.Add(newNhanVien);
                contextDB.SaveChanges();
                reset();

            }
            else
            {
                MessageBox.Show("loi them nhan vien ");
            }
        }

        private void reset()
        {
            dgvDSDG.Rows.Clear();
            List<NHANVIEN> nv = contextDB.NHANVIENs.ToList();
            List<BANGCAP> bc = contextDB.BANGCAPs.ToList();
            BingdingToGridView(nv);
            BindingInvoiceToGridView1(nv);
            fillFacultyToCombobox(bc);
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Nếu ký tự không phải là số, hủy sự kiện KeyPress
                e.Handled = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!checkNull() && !checkSDT())
            {
                // Lấy giá trị từ TextBox, ComboBox và DateTimePicker
                string maNhanVien = txtMaNhanVien.Text;
                string hoTen = txtHoTen.Text;
                string diaChi = txtDiaChi.Text;
                string dienThoai = txtDienThoai.Text;
                int maBangCap = (int)comboBox1.SelectedValue;
                DateTime ngaySinh = dtpNgaySinh.Value;

                // Kiểm tra xem ngày sinh có lớn hơn thời gian hiện tại không
                if (ngaySinh > DateTime.Now)
                {
                    MessageBox.Show("Ngày sinh không được lớn hơn thời gian hiện tại.");
                    return; // Dừng việc cập nhật khi ngày sinh không hợp lệ
                }

                // Tìm nhân viên trong danh sách DanhSachNhanVien dựa vào mã nhân viên
                NHANVIEN nhanVienCanSua = DanhSachNhanVien.FirstOrDefault(nv => nv.MaNhanVien.ToString() == maNhanVien);

                if (nhanVienCanSua != null)
                {
                    // Cập nhật thông tin của nhân viên
                    nhanVienCanSua.HoTenNhanVien = hoTen;
                    nhanVienCanSua.DiaChi = diaChi;
                    nhanVienCanSua.DienThoai = dienThoai;
                    nhanVienCanSua.MaBangCap = maBangCap;
                    nhanVienCanSua.NgaySinh = ngaySinh;

                    // Lưu các thay đổi vào cơ sở dữ liệu
                    contextDB.SaveChanges();

                    MessageBox.Show("Sửa thông tin nhân viên thành công.");

                    // Reset giao diện và cập nhật danh sách nhân viên
                    reset();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã nhân viên cần sửa.");
                }
            }
            else
            {
                MessageBox.Show("Lỗi sửa thông tin nhân viên.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNhanVien = txtMaNhanVien.Text;

            // Kiểm tra xem mã nhân viên có được nhập không
            if (!checkNull() && !checkSDT())
            {
                // Tìm nhân viên trong danh sách DanhSachNhanVien dựa vào mã nhân viên
                NHANVIEN nhanVienCanXoa = DanhSachNhanVien.FirstOrDefault(nv => nv.MaNhanVien.ToString() == maNhanVien);

                if (nhanVienCanXoa != null)
                {
                    // Hiển thị hộp thoại xác nhận xóa
                    var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?",
                        "Xác nhận xóa nhân viên",
                        MessageBoxButtons.YesNo);

                    if (confirmResult == DialogResult.Yes)
                    {
                        // Xóa nhân viên
                        contextDB.NHANVIENs.Remove(nhanVienCanXoa);
                        contextDB.SaveChanges();

                        MessageBox.Show("Xóa nhân viên thành công.");

                        // Reset giao diện và cập nhật danh sách nhân viên
                        reset();
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã nhân viên cần xóa.");
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận trước khi thoát
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                // Đóng cửa sổ hiện tại (ứng dụng sẽ thoát nếu không còn cửa sổ nào)
                this.Close();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.Trim().ToLower();

            // Nếu ô tìm kiếm rỗng, hiển thị lại toàn bộ danh sách nhân viên
            if (string.IsNullOrEmpty(searchText))
            {
                BingdingToGridView(DanhSachNhanVien);
                return;
            }

            // Tạo danh sách tìm kiếm mới
            var searchResults = DanhSachNhanVien
                .Where(nv => nv.HoTenNhanVien.ToLower().Contains(searchText) || nv.MaNhanVien.ToString().Contains(searchText))
                .ToList();

            // Hiển thị danh sách tìm kiếm
            BingdingToGridView(searchResults);
        }

    }
}
