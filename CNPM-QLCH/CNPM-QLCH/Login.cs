using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CNPM_QLCH
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Bước 1 Tạo kết nối
                string str = @"Data Source=LAPTOP-PK4QUC28;
                Initial Catalog=QLCH;User ID=sa;Password=123456";
                SqlConnection cnn = new SqlConnection(str);//Để kết nối CSDL
                //Bước 2 Mở kết nối
                cnn.Open();
                //Bước 3 Tạo truy vấn
                string tk = txtTaiKhoan.Text;
                string mk = txtMatKhau.Text;
                string query = "select count(*) from NguoiDung where TaiKhoan=@tk and MatKhau=@mk";
                //Bước 4 Thực thi truy vấn
                SqlCommand cmd = new SqlCommand(query, cnn);//Đọc dữ liệu
                cmd.Parameters.Add(new SqlParameter("@tk", tk));
                cmd.Parameters.Add(new SqlParameter("@mk", mk));
                int SoLuong = (int)cmd.ExecuteScalar();
                //Bước 5 Đóng kết nối
                cnn.Close();
                if (SoLuong == 1)
                {
                    MessageBox.Show("Đăng Nhập Thành Công");
                    this.Hide();
                    Menu tt = new Menu();
                    tt.Show();

                }
                else
                {
                    MessageBox.Show("Đăng Nhập Thất Bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }
    }
}
