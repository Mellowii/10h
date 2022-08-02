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
    public partial class BCTK : Form
    {
        public BCTK()
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
            cmd.CommandText = "select * from BCTK";//Viết câu truy vấn
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dgvBCTK.DataSource = table;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();//Tạo 1 truy vấn
            cmd.CommandText = "insert into BCTK values(N'" + txtmabc.Text + "', N'" + txttenbc.Text + "', N'" + txtmanv.Text + "', N'" + txttennv.Text + "', N'" + dateTimePicker1.Value.Date + "');";
            cmd.ExecuteNonQuery();//Câu lệnh dùng để đọc lỗi 
            getData();
        }

        private void BCTK_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(str);
            cnn.Open();
            getData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();//Tạo 1 truy vấn
            cmd.CommandText = "update BCTK set TenBC=N'" + txttenbc.Text + "', MaNV=N'" + txtmanv.Text + "', TenNV=N'" + txttennv.Text + "', NgayThucHien=N'" + dateTimePicker1.Value.Date + "' where MaBC=N'" + txtmabc.Text + "'";
            cmd.ExecuteNonQuery();//Câu lệnh dùng để đọc lỗi 
            getData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();//Tạo 1 truy vấn
            cmd.CommandText = "delete BCTK where MaBC='" + txtmabc.Text + "'";
            cmd.ExecuteNonQuery();//Câu lệnh dùng để đọc lỗi 
            getData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string timkiem = "select * from BCTK where MaBC like '%" + txttimkiem.Text + "%'";
            SqlCommand cmd = new SqlCommand(timkiem, cnn);
            cmd.Parameters.AddWithValue("MaBCTK", txtmabc.Text);
            cmd.Parameters.AddWithValue("TenBC", txttenbc.Text);
            cmd.Parameters.AddWithValue("MaNV", txtmanv.Text);
            cmd.Parameters.AddWithValue("TenNV", txttennv.Text);
            cmd.Parameters.AddWithValue("NgayThucHien", dateTimePicker1.Value.Date);
            SqlDataReader dr = cmd.ExecuteReader();//Đọc dữ liệu ở bên C#
            DataTable table = new DataTable();
            table.Load(dr);
            dgvBCTK.DataSource = table;
        }

        private void dgvBCTK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvBCTK.CurrentRow.Index;
            txtmabc.Text = dgvBCTK.Rows[i].Cells[0].Value.ToString();
            txttenbc.Text = dgvBCTK.Rows[i].Cells[1].Value.ToString();
            txtmanv.Text = dgvBCTK.Rows[i].Cells[2].Value.ToString();
            txttennv.Text = dgvBCTK.Rows[i].Cells[3].Value.ToString();
            dateTimePicker1.Text = dgvBCTK.Rows[i].Cells[4].Value.ToString();
        }

        private void btnTKTC_Click(object sender, EventArgs e)
        {
            BCTHUCHI bctc = new BCTHUCHI();
            bctc.ShowDialog();
        }

        private void btnTKNX_Click(object sender, EventArgs e)
        {
            BCNHAPXUAT bcnx = new BCNHAPXUAT();
            bcnx.ShowDialog();
        }
    }
}
