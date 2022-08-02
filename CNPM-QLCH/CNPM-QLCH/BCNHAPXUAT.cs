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
    public partial class BCNHAPXUAT : Form
    {
        public BCNHAPXUAT()
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
            cmd.CommandText = "select * from BCNhapXuat";//Viết câu truy vấn
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dgvNX.DataSource = table;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();//Tạo 1 truy vấn
            cmd.CommandText = "insert into BCNhapXuat values(N'" + txtmabcnx.Text + "', N'" + txtmabc.Text + "', N'" + txtmasp.Text + "', N'" + txttensp.Text + "', N'" + txtsoluongnhap.Text + "', N'" + dateTimePickernhap.Value.Date + "', N'" + txtsoluongxuat.Text + "', N'" + dateTimePickerxuat.Value.Date + "');";
            cmd.ExecuteNonQuery();//Câu lệnh dùng để đọc lỗi 
            getData();
        }

        private void BCNHAPXUAT_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(str);
            cnn.Open();
            getData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();//Tạo 1 truy vấn
            cmd.CommandText = "update BCNhapXuat set MaBC=N'" + txtmabc.Text + "', MaSP=N'" + txtmasp.Text + "', TenSP=N'" + txttensp.Text + "', SoLuongNhap=N'" + txtsoluongnhap.Text + "', NgayNhap= N'" + dateTimePickernhap.Value.Date + "', SoLuongXuat=N'" + txtsoluongxuat.Text + "', NgayXuat=N'" + dateTimePickerxuat.Value.Date + "' where MaBCNhapXuat=N'" + txtmabcnx.Text + "'";
            cmd.ExecuteNonQuery();//Câu lệnh dùng để đọc lỗi 
            getData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();//Tạo 1 truy vấn
            cmd.CommandText = "delete BCNhapXuat where MaBCNhapXuat='" + txtmabcnx.Text + "'";
            cmd.ExecuteNonQuery();//Câu lệnh dùng để đọc lỗi 
            getData();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string timkiem = "select * from BCNhapXuat where MaBCNhapXuat like '%" + txttimkiem.Text + "%'";
            SqlCommand cmd = new SqlCommand(timkiem, cnn);
            cmd.Parameters.AddWithValue("MaBCNhapXuat", txtmabcnx.Text);
            cmd.Parameters.AddWithValue("MaBC", txtmabc.Text);
            cmd.Parameters.AddWithValue("MaSP", txtmasp.Text);
            cmd.Parameters.AddWithValue("TenSP", txttensp.Text);
            cmd.Parameters.AddWithValue("SoLuongNhap", txtsoluongnhap.Text);
            cmd.Parameters.AddWithValue("NgayNhap", dateTimePickernhap.Value.Date);
            cmd.Parameters.AddWithValue("SoLuongXuat", txtsoluongxuat.Text);
            cmd.Parameters.AddWithValue("NgayXuat", dateTimePickerxuat.Value.Date);
            SqlDataReader dr = cmd.ExecuteReader();//Đọc dữ liệu ở bên C#
            DataTable table = new DataTable();
            table.Load(dr);
            dgvNX.DataSource = table;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvNX_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvNX.CurrentRow.Index;
            txtmabcnx.Text = dgvNX.Rows[i].Cells[0].Value.ToString();
            txtmabc.Text = dgvNX.Rows[i].Cells[1].Value.ToString();
            txtmasp.Text = dgvNX.Rows[i].Cells[2].Value.ToString();
            txttensp.Text = dgvNX.Rows[i].Cells[3].Value.ToString();
            txtsoluongnhap.Text = dgvNX.Rows[i].Cells[4].Value.ToString();
            dateTimePickernhap.Text = dgvNX.Rows[i].Cells[5].Value.ToString();
            txtsoluongxuat.Text = dgvNX.Rows[i].Cells[6].Value.ToString();
            dateTimePickerxuat.Text = dgvNX.Rows[i].Cells[7].Value.ToString();
        }
    }
}
