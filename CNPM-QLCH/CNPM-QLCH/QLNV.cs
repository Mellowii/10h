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
    public partial class QLNV : Form
    {
        public QLNV()
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
            cmd.CommandText = "select * from NhanVien";//Viết câu truy vấn
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dgvNV.DataSource = table;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string timkiem = "select * from NhanVien where MaNV like '%" + txttimkiem.Text + "%'";
            SqlCommand cmd = new SqlCommand(timkiem, cnn);
            cmd.Parameters.AddWithValue("MaNV", txtmanv.Text);
            cmd.Parameters.AddWithValue("TenNV", txttennv.Text);
            cmd.Parameters.AddWithValue("NgaySinh", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("Cccd", txtcccd.Text);
            cmd.Parameters.AddWithValue("Sdt", txtsdt.Text);
            cmd.Parameters.AddWithValue("DiaChi", txtdiachi.Text);
            cmd.Parameters.AddWithValue("SoGioLamThucTe", txtsogiolamtt.Text);
            cmd.Parameters.AddWithValue("LuongMotGioCong", txtluongmotgiocong.Text);
            cmd.Parameters.AddWithValue("SoGioLamThem", txtsogiolamthem.Text);
            cmd.Parameters.AddWithValue("LuongLamThemGio", txtluonglamthemgio.Text);
            cmd.Parameters.AddWithValue("ThucLinh", txtthuclinh.Text);
            SqlDataReader dr = cmd.ExecuteReader();//Đọc dữ liệu ở bên C#
            DataTable table = new DataTable();
            table.Load(dr);
            dgvNV.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();//Tạo 1 truy vấn
            cmd.CommandText = "insert into NhanVien values(N'" + txtmanv.Text + "', N'" + txttennv.Text + "',N'" + dateTimePicker1.Value.Date + "', N'" + txtcccd.Text + "', N'" + txtsdt.Text + "', N'" + txtdiachi.Text + "', N'" + txtsogiolamtt.Text + "', N'" + txtluongmotgiocong.Text + "', N'" + txtsogiolamthem.Text + "', N'" + txtluonglamthemgio.Text + "', N'" + txtthuclinh.Text + "');";
            cmd.ExecuteNonQuery();//Câu lệnh dùng để đọc lỗi 
            getData();
        }

        private void QLNV_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(str);
            cnn.Open();
            getData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();//Tạo 1 truy vấn
            cmd.CommandText = "update NhanVien set TenNV=N'" + txttennv.Text + "', NgaySinh= N'" + dateTimePicker1.Value.Date + "', Cccd=N'" + txtcccd.Text + "', Sdt=N'" + txtsdt.Text + "', DiaChi=N'" + txtdiachi.Text + "', SoGioLamThucTe=N'" + txtsogiolamtt.Text + "', LuongMotGioCong=N'" + txtluongmotgiocong.Text + "', SoGioLamthem=N'" + txtsogiolamthem.Text + "', LuongLamThemGio=N'" + txtluonglamthemgio.Text + "', ThucLinh=N'" + txtthuclinh.Text + "' where MaNV=N'" + txtmanv.Text + "'";
            cmd.ExecuteNonQuery();//Câu lệnh dùng để đọc lỗi Q
            getData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();//Tạo 1 truy vấn
            cmd.CommandText = "delete NhanVien where MaNV='" + txtmanv.Text + "'";
            cmd.ExecuteNonQuery();//Câu lệnh dùng để đọc lỗi 
            getData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvNV.CurrentRow.Index;
            txtmanv.Text = dgvNV.Rows[i].Cells[0].Value.ToString();
            txttennv.Text = dgvNV.Rows[i].Cells[1].Value.ToString();
            dateTimePicker1.Text = dgvNV.Rows[i].Cells[2].Value.ToString();
            txtcccd.Text = dgvNV.Rows[i].Cells[3].Value.ToString();
            txtsdt.Text = dgvNV.Rows[i].Cells[4].Value.ToString();
            txtdiachi.Text = dgvNV.Rows[i].Cells[5].Value.ToString();
            txtsogiolamtt.Text = dgvNV.Rows[i].Cells[6].Value.ToString();
            txtluongmotgiocong.Text = dgvNV.Rows[i].Cells[7].Value.ToString();
            txtsogiolamthem.Text = dgvNV.Rows[i].Cells[8].Value.ToString();
            txtluonglamthemgio.Text = dgvNV.Rows[i].Cells[9].Value.ToString();
            txtthuclinh.Text = dgvNV.Rows[i].Cells[10].Value.ToString();
        }

        private void txtthuclinh_TextChanged(object sender, EventArgs e)
        {
            //double lamtt = Convert.ToDouble(txtsogiolamtt.Text);
            //double luongtt = Convert.ToDouble(txtluongmotgiocong.Text);
            //double lt = Convert.ToDouble(txtsogiolamthem.Text);
            //double luonglt = Convert.ToDouble(txtluonglamthemgio.Text);
            //double thuclinh = (lamtt * luongtt) + (lt * luonglt);
            //txtthuclinh.Text = ((Convert.ToDouble(txtsogiolamtt.Text) * Convert.ToDouble(txtluongmotgiocong.Text)) + (Convert.ToDouble(txtsogiolamthem.Text) * Convert.ToDouble(txtluonglamthemgio.Text)).ToString();
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            double lamtt = Convert.ToDouble(txtsogiolamtt.Text);
            double luongtt = Convert.ToDouble(txtluongmotgiocong.Text);
            double lt = Convert.ToDouble(txtsogiolamthem.Text);
            double luonglt = Convert.ToDouble(txtluonglamthemgio.Text);
            //double thuclinh = (lamtt * luongtt) + (lt * luonglt);
            txtthuclinh.Text = ((lamtt * luongtt) + (lt * luonglt)).ToString();
        }

        private void btnLamoi_Click(object sender, EventArgs e)
        {
            txtmanv.Text = "";
            txttennv.Text = "";
            dateTimePicker1.Text = "";
            txtcccd.Text = "";
            txtsdt.Text = "";
            txtdiachi.Text = "";
            txtsogiolamtt.Text = "";
            txtluongmotgiocong.Text = "";
            txtsogiolamthem.Text = "";
            txtluonglamthemgio.Text = "";
            txtthuclinh.Text = "";
        }
    }
}
