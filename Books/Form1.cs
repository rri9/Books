using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Books {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "booksDataSet.Literature". При необходимости она может быть перемещена или удалена.
            this.literatureTableAdapter.Fill(this.booksDataSet.Literature);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "booksDataSet.Departments". При необходимости она может быть перемещена или удалена.
            this.departmentsTableAdapter.Fill(this.booksDataSet.Departments);

        }

        private void Form1_Reload() {
            this.literatureTableAdapter.Fill(this.booksDataSet.Literature);
            this.departmentsTableAdapter.Fill(this.booksDataSet.Departments);
        }

        private void button1_Click(object sender, EventArgs e) {
            this.departmentsTableAdapter.Update(this.booksDataSet.Departments);
            this.literatureTableAdapter.Update(this.booksDataSet.Literature);
            this.Form1_Reload();
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e) {
            if (dataGridView2.CurrentRow == null) {
                label_Discount.Text = "...";
            }
            else {
                //string s = (string)dataGridView2.CurrentRow.Cells[3].Value * 0.95;

                object CurBookPrice = dataGridView2.CurrentRow.Cells[3].Value;
                /*int CurRow = dataGridView2.CurrentCell.RowIndex;
                int CurBookPrice = dataGridView2.Rows[CurRow].Cells[3].Value;*/
                double DiscountedPrice = Convert.ToInt32(CurBookPrice) * 0.95;
                label_Discount.Text = DiscountedPrice.ToString();
            }
        }
    }
}
