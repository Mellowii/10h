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
    public partial class QLSP : Form
    {
        public QLSP()
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
            cmd.CommandText = "select * from SanPham";//Viết câu truy vấn
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dgvSP.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();//Tạo 1 truy vấn
            cmd.CommandText = "insert into SanPham values(N'" + txtmasp.Text + "', N'" + txttensp.Text + "',N'" + txtsotonkho.Text + "', N'" + txtgianhap.Text + "', N'" + txtgiaban.Text + "', N'" + txtmota.Text + "');";
            cmd.ExecuteNonQuery();//Câu lệnh dùng để đọc lỗi 
            getData();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();//Tạo 1 truy vấn
            cmd.CommandText = "update SanPham set TenSP=N'" + txttensp.Text + "', SoTonKho= N'" + txtsotonkho.Text + "', GiaNhap=N'" + txtgianhap.Text + "', GiaBan=N'" + txtgiaban.Text + "' where MaSP=N'" + txtmasp.Text + "'";
            cmd.ExecuteNonQuery();//Câu lệnh dùng để đọc lỗi 
            getData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();//Tạo 1 truy vấn
            cmd.CommandText = "delete SanPham where MaSP='" + txtmasp.Text + "'";
            cmd.ExecuteNonQuery();//Câu lệnh dùng để đọc lỗi 
            getData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string timkiem = "select * from SanPham where MaSP like '%" + txttimkiem.Text + "%'";
            SqlCommand cmd = new SqlCommand(timkiem, cnn);
            cmd.Parameters.AddWithValue("MaSP", txtmasp.Text);
            cmd.Parameters.AddWithValue("TenSP", txttensp.Text);
            cmd.Parameters.AddWithValue("SoTonKho", txtsotonkho.Text);
            cmd.Parameters.AddWithValue("GiaNhap", txtgianhap.Text);
            cmd.Parameters.AddWithValue("GiaBan", txtgiaban.Text);
            cmd.Parameters.AddWithValue("Mota", txtmota.Text);
            SqlDataReader dr = cmd.ExecuteReader();//Đọc dữ liệu ở bên C#
            DataTable table = new DataTable();
            table.Load(dr);
            dgvSP.DataSource = table;
        }

        private void dgvSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvSP.CurrentRow.Index;
            txtmasp.Text = dgvSP.Rows[i].Cells[0].Value.ToString();
            txttensp.Text = dgvSP.Rows[i].Cells[1].Value.ToString();
            txtsotonkho.Text = dgvSP.Rows[i].Cells[2].Value.ToString();
            txtgianhap.Text = dgvSP.Rows[i].Cells[3].Value.ToString();
            txtgiaban.Text = dgvSP.Rows[i].Cells[4].Value.ToString();
            txtmota.Text = dgvSP.Rows[i].Cells[5].Value.ToString();

        }

        private void QLSP_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(str);
            cnn.Open();
            getData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtmasp.Text = "";
            txttensp.Text = "";
            txtsotonkho.Text = "";
            txtgianhap.Text = "";
            txtgiaban.Text = "";
            txtmota.Text = "";
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook wk = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet sht = null;


                sht = wk.Sheets["Sheet1"];
                sht = wk.ActiveSheet;
                app.Visible = true;
                sht.Cells[1, 1] = "DANH SÁCH SẢN PHẨM";
                sht.Cells[2, 1] = "Mã sản phẩm";
                sht.Cells[2, 2] = "Tên sản phẩm";
                sht.Cells[2, 3] = "Số tồn kho";
                sht.Cells[2, 4] = "Giá nhập";
                sht.Cells[2, 5] = "Giá bán";
                sht.Cells[2, 6] = "Mô tả";
                

                for (int i = 0; i < dgvSP.RowCount - 1; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        sht.Cells[i + 3, 1] = i + 1;
                        sht.Cells[i + 3, j + 2] = dgvSP.Rows[i].Cells[j].Value;
                    }
                }
            }
        }
    }
}
