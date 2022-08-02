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
    public partial class QLHD : Form
    {
        public QLHD()
        {
            InitializeComponent();
        }
        SqlConnection cnn;
        SqlCommand cmd;
        string str = @"Data Source=LAPTOP-PK4QUC28;Initial Catalog=QLCH;User ID=sa;Password=123456";
        SqlDataAdapter adapter = new SqlDataAdapter();//Bộ chuyển đổi dữ liệu
        DataTable table = new DataTable();
        void getData()
        {
            cmd = cnn.CreateCommand();//Tạo 1 truy vấn
            cmd.CommandText = "select * from HoaDon";//Viết câu truy vấn
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dgvQLHD.DataSource = table;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();//Tạo 1 truy vấn
            cmd.CommandText = "insert into HoaDon values(N'" + txtmahd.Text + "', N'" + txtmanv.Text + "', N'" + txttennv.Text + "', N'" + txttongtien.Text + "');";
            cmd.ExecuteNonQuery();//Câu lệnh dùng để đọc lỗi 
            getData();
        }

        private void QLHD_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(str);
            cnn.Open();
            getData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();//Tạo 1 truy vấn
            cmd.CommandText = "update HoaDon set MaNV=N'" + txtmanv.Text + "', TenNV=N'" + txttennv.Text + "', TongTien=N'" + txttongtien.Text + "' where MaHD=N'" + txtmahd.Text + "'";
            cmd.ExecuteNonQuery();//Câu lệnh dùng để đọc lỗi 
            getData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();//Tạo 1 truy vấn
            cmd.CommandText = "delete HoaDon where MaHD='" + txtmahd.Text + "'";
            cmd.ExecuteNonQuery();//Câu lệnh dùng để đọc lỗi 
            getData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string timkiem = "select * from HoaDon where MaHD like '%" + txtTimkiem.Text + "%'";
            SqlCommand cmd = new SqlCommand(timkiem, cnn);
            cmd.Parameters.AddWithValue("MaHD", txtmahd.Text);
            cmd.Parameters.AddWithValue("MaNV", txtmanv.Text);
            cmd.Parameters.AddWithValue("TenNV", txttennv.Text);
            cmd.Parameters.AddWithValue("TongTien", txttongtien.Text);
            SqlDataReader dr = cmd.ExecuteReader();//Đọc dữ liệu ở bên C#
            DataTable table = new DataTable();
            table.Load(dr);
            dgvQLHD.DataSource = table;
        }

        private void dgvQLHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvQLHD.CurrentRow.Index;
            txtmahd.Text = dgvQLHD.Rows[i].Cells[0].Value.ToString();
            txtmanv.Text = dgvQLHD.Rows[i].Cells[1].Value.ToString();
            txttennv.Text = dgvQLHD.Rows[i].Cells[2].Value.ToString();
            txttongtien.Text = dgvQLHD.Rows[i].Cells[3].Value.ToString();
        }

        private void btnCTHD_Click(object sender, EventArgs e)
        {
            CTHD cthd = new CTHD();
            cthd.ShowDialog();
        }
    }
}
