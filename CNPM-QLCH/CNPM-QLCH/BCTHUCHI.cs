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
    public partial class BCTHUCHI : Form
    {
        public BCTHUCHI()
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
            cmd.CommandText = "select * from BCThuChi";//Viết câu truy vấn
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dgvBCTC.DataSource = table;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();//Tạo 1 truy vấn
            cmd.CommandText = "insert into BCThuChi values(N'" + txtmabctc.Text + "', N'" + txtmabc.Text + "',N'" + dateTimePicker1.Value.Date + "', N'" + txtsotienthu.Text + "', N'" + txtsotienchi.Text + "');";
            cmd.ExecuteNonQuery();//Câu lệnh dùng để đọc lỗi 
            getData();
        }

        private void BCTHUCHI_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(str);
            cnn.Open();
            getData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();//Tạo 1 truy vấn
            cmd.CommandText = "update BCThuChi set MaBC=N'" + txtmabc.Text + "', NgayThucHien= N'" + dateTimePicker1.Value.Date + "', SoTienThu=N'" + txtsotienthu.Text + "', SoTienChi=N'" + txtsotienchi.Text + "' where MaBCThuChi=N'" + txtmabctc.Text + "'";
            cmd.ExecuteNonQuery();//Câu lệnh dùng để đọc lỗi 
            getData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();//Tạo 1 truy vấn
            cmd.CommandText = "delete BCThuChi where MaBCThuChi='" + txtmabctc.Text + "'";
            cmd.ExecuteNonQuery();//Câu lệnh dùng để đọc lỗi 
            getData();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string timkiem = "select * from BCThuChi where MaBCThuChi like '%" + txttimkiem.Text + "%'";
            SqlCommand cmd = new SqlCommand(timkiem, cnn);
            cmd.Parameters.AddWithValue("MaBCThuChi", txtmabctc.Text);
            cmd.Parameters.AddWithValue("MaBC", txtmabc.Text);
            cmd.Parameters.AddWithValue("NgayThucHien", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("SoTienThu", txtsotienthu.Text);
            cmd.Parameters.AddWithValue("SoTienChi", txtsotienchi.Text);
            SqlDataReader dr = cmd.ExecuteReader();//Đọc dữ liệu ở bên C#
            DataTable table = new DataTable();
            table.Load(dr);
            dgvBCTC.DataSource = table;
        }

        private void dgvBCTC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvBCTC.CurrentRow.Index;
            txtmabctc.Text = dgvBCTC.Rows[i].Cells[0].Value.ToString();
            txtmabc.Text = dgvBCTC.Rows[i].Cells[1].Value.ToString();
            dateTimePicker1.Text = dgvBCTC.Rows[i].Cells[2].Value.ToString();
            txtsotienthu.Text = dgvBCTC.Rows[i].Cells[3].Value.ToString();
            txtsotienchi.Text = dgvBCTC.Rows[i].Cells[4].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtmabctc.Text = "";
            txtmabc.Text = "";
            txtsotienthu.Text = "";
            txtsotienchi.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
