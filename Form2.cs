using QRCodeRAW.DemoQrCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRCodeRAW
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
                this.pictureBox1.Load(textBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("请选择要读取的二维码图片");
                return;
            }
            Bitmap myBitmap = new Bitmap(textBox1.Text);
            this.textBox2.Text = BarcodeHelper.DecodeQrCode(myBitmap);// ((Bitmap)this.pictureBox1.Image);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("请输入要生成二维码的数据");
            }
            pictureBox2.Image = BarcodeHelper.Generate1("https://p.12306.cn/tservice/qr/travel/v1?c="+textBox2.Text+"-"+ textBox3.Text + "-"+textBox4.Text+"&w=h", 160, 140);
            
            saveFileDialog1.ShowDialog();
            string filename = saveFileDialog1.FileName;
            pictureBox2.Image.Save(filename);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();

        }
    }
}
