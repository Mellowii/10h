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
    public partial class CTHD : Form
    {
        public CTHD()
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
            cmd.CommandText = "select * from CTHoaDon";//Viết câu truy vấn
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dgvCTHD.DataSource = table;
        }
        private void CTHD_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(str);
            cnn.Open();
            getData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();//Tạo 1 truy vấn
            cmd.CommandText = "insert into CTHoaDon values(N'" + txtmahd.Text + "', N'" + txtmasp.Text + "', N'" + txttensp.Text + "', N'" + txtsoluong.Text + "', N'" + txtthanhtien.Text + "');";
            cmd.ExecuteNonQuery();//Câu lệnh dùng để đọc lỗi 
            getData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();//Tạo 1 truy vấn
            cmd.CommandText = "update CTHoaDon set MaSP=N'" + txtmasp.Text + "', TenSP=N'" + txttensp.Text + "', SoLuong=N'" + txtsoluong.Text + "', ThanhTien=N'" + txtthanhtien.Text + "' where MaHD=N'" + txtmahd.Text + "'";
            cmd.ExecuteNonQuery();//Câu lệnh dùng để đọc lỗi 
            getData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();//Tạo 1 truy vấn
            cmd.CommandText = "delete CTHoaDon where MaHD='" + txtmahd.Text + "'";
            cmd.ExecuteNonQuery();//Câu lệnh dùng để đọc lỗi 
            getData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string timkiem = "select * from CTHoaDon where MaHD like '%" + txttimkiem.Text + "%'";
            SqlCommand cmd = new SqlCommand(timkiem, cnn);
            cmd.Parameters.AddWithValue("MaHD", txtmahd.Text);
            cmd.Parameters.AddWithValue("MaSP", txtmasp.Text);
            cmd.Parameters.AddWithValue("TenSP", txttensp.Text);
            cmd.Parameters.AddWithValue("SoLuong", txtsoluong.Text);
            cmd.Parameters.AddWithValue("ThanhTien", txtthanhtien.Text);
            SqlDataReader dr = cmd.ExecuteReader();//Đọc dữ liệu ở bên C#
            DataTable table = new DataTable();
            table.Load(dr);
            dgvCTHD.DataSource = table;
        }

        private void dgvCTHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvCTHD.CurrentRow.Index;
            txtmahd.Text = dgvCTHD.Rows[i].Cells[0].Value.ToString();
            txtmasp.Text = dgvCTHD.Rows[i].Cells[1].Value.ToString();
            txttensp.Text = dgvCTHD.Rows[i].Cells[2].Value.ToString();
            txtsoluong.Text = dgvCTHD.Rows[i].Cells[3].Value.ToString();
            txtthanhtien.Text = dgvCTHD.Rows[i].Cells[4].Value.ToString();
        }

        private void btnQLHD_Click(object sender, EventArgs e)
        {
            QLHD qlhd = new QLHD();
            qlhd.ShowDialog();
        }
    }
}
