using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using trelloclone;

namespace WindowsFormsApp1
{
    public partial class Card : Form
    {
        private AppData appData;
        private bool modified = false;
        private bool existed;

        bool isResize1 = true;
        bool isResize2 = true;
        bool onSizeBox1 = false;
        bool onSizeBox2 = false;

        Size originalSizeOf_tbxThemMoTaChiTiet, originalSizeOf_tbxVietBinhLuan;
        Size originalSizeOf_pnl_HoatDong, originalSizeOf_pnl_MoTa;
        Point originalPointOf_pnl_HoatDong;


        internal AppData AppData { get => appData; set => appData = value; }
        public bool Modified { get => modified; set => modified = value; }
        public bool Existed { get => existed; set => existed = value; }

        public Card(AppData passInData)
        {
            InitializeComponent();
            appData = passInData;
            rTxtBxTitle.Text = passInData.Title;
            tbxThemMoTaChiTiet.Text = passInData.DescribeContent;
            tbxVietBinhLuan.Text = passInData.ActivityContent;
            existed = true;


            rTxtBxTitle.TextChanged += richTextBox1_TextChanged;
            tbxThemMoTaChiTiet.MouseClick += tbxThemMoTaChiTiet_MouseClick;
            tbxThemMoTaChiTiet.TextChanged += tbxThemMoTaChiTiet_TextChanged;
            tbxVietBinhLuan.MouseClick += tbxVietBinhLuan_MouseClick;
            tbxVietBinhLuan.TextChanged += tbxVietBinhLuan_TextChanged;
            pnlMain.MouseDown += panel1_MouseDown;
            // btnDeleteCard.Click += btnDeleteCard_Click;

            Modified = true;
        }
        private void btnDeleteCard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bye");
            existed = false;
            appData.Existed = false;
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            AppData.Title = rTxtBxTitle.Text;
        }

        private void tbxThemMoTaChiTiet_TextChanged(object sender, EventArgs e)
        {
            AppData.DescribeContent = tbxVietBinhLuan.Text;
        }

        private void tbxVietBinhLuan_TextChanged(object sender, EventArgs e)
        {
            AppData.ActivityContent = tbxVietBinhLuan.Text;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            appData.Title = rTxtBxTitle.Text;
            appData.DescribeContent = tbxThemMoTaChiTiet.Text;
            appData.ActivityContent = tbxVietBinhLuan.Text;
            Close();
        }


        private void tbxThemMoTaChiTiet_MouseClick(object sender, MouseEventArgs e)
        {
            // tbxThemMoTaChiTiet.Text = AppData.DescribeContent;

            originalSizeOf_tbxThemMoTaChiTiet = new System.Drawing.Size(tbxThemMoTaChiTiet.Width, tbxThemMoTaChiTiet.Height);
            originalSizeOf_pnl_MoTa = new System.Drawing.Size(pnlMoTa.Width, pnlMoTa.Height);
            originalPointOf_pnl_HoatDong = new System.Drawing.Point(pnlHoatDong.Location.X, pnlHoatDong.Location.Y);
            onSizeBox1 = true;

            Resize();
        }

        private void tbxVietBinhLuan_MouseClick(object sender, MouseEventArgs e)
        {
            // tbxVietBinhLuan.Text = AppData.ActivityContent;

            originalSizeOf_tbxVietBinhLuan = new System.Drawing.Size(tbxVietBinhLuan.Width, tbxVietBinhLuan.Height);
            originalSizeOf_pnl_HoatDong = new System.Drawing.Size(pnlHoatDong.Width, pnlHoatDong.Height);
            onSizeBox2 = true;

            Resize();
        }

        private void Resize()
        {
            if (isResize1 && onSizeBox1 == true)
            {
                resize_textBox(true, false, true, false);
                pnlFunctions.Hide();
                isResize1 = false;
            }
            else if (isResize2 && onSizeBox2 == true)
            {
                resize_textBox(false, true, true, false);
                pnlFunctions.Hide();
                isResize2 = false;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

            if (isResize1 == false && onSizeBox1 == true)
            {
                resize_textBox(true, false, false, true);
                isResize1 = true;
                pnlFunctions.Show();
                onSizeBox1 = false;
            }
            else if (isResize2 == false && onSizeBox2 == true)
            {
                resize_textBox(false, true, false, true);
                isResize2 = true;
                pnlFunctions.Show();
                onSizeBox2 = false;
            }
        }



        void resize_textBox(bool txtThemMoTaChiTiet, bool txtVietBinhLuan, bool expand, bool shrink)
        {
            if (txtThemMoTaChiTiet && !txtVietBinhLuan)
            {
                if (expand && !shrink)
                {
                    pnlMoTa.Size = new System.Drawing.Size(pnlMoTa.Width, pnlMoTa.Height + 130);
                    tbxThemMoTaChiTiet.Size = new System.Drawing.Size(tbxThemMoTaChiTiet.Width, tbxThemMoTaChiTiet.Height + 130);
                    pnlHoatDong.Location = new System.Drawing.Point(pnlHoatDong.Location.X, pnlHoatDong.Location.Y + 100);
                }
                else if (!expand && shrink)
                {
                    pnlMoTa.Size = new System.Drawing.Size(originalSizeOf_pnl_MoTa.Width, originalSizeOf_pnl_MoTa.Height - 130);
                    tbxThemMoTaChiTiet.Size = new System.Drawing.Size(originalSizeOf_tbxThemMoTaChiTiet.Width, originalSizeOf_tbxThemMoTaChiTiet.Height - 130);
                    pnlHoatDong.Location = new System.Drawing.Point(originalPointOf_pnl_HoatDong.X, originalPointOf_pnl_HoatDong.Y - 100);

                }
            }
            else if (!txtThemMoTaChiTiet && txtVietBinhLuan)
            {
                if (expand && !shrink)
                {
                    tbxVietBinhLuan.Size = new System.Drawing.Size(tbxVietBinhLuan.Width, tbxVietBinhLuan.Height + 130);
                    pnlHoatDong.Size = new System.Drawing.Size(pnlHoatDong.Width, pnlHoatDong.Height + 130);
                }
                else if (!expand && shrink)
                {
                    tbxVietBinhLuan.Size = new System.Drawing.Size(originalSizeOf_tbxVietBinhLuan.Width, originalSizeOf_tbxVietBinhLuan.Height - 130);
                    pnlHoatDong.Size = new System.Drawing.Size(originalSizeOf_pnl_HoatDong.Width, originalSizeOf_pnl_HoatDong.Height - 130);

                }
            }
        }

        private void SaveDataToFile()
        {
            List<string> lines = new List<string>();

            lines.Add($"Them mo ta chi tiet: {tbxThemMoTaChiTiet.Text}");
            lines.Add($"Viet binh luan: {tbxVietBinhLuan.Text}");

            // Get the current directory of the application.
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Write the string array to a new file named "WriteLines.txt" in the current directory.
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(currentDirectory, $"StoryCard.txt")))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }

            //Console.WriteLine("File saved to: " + Path.Combine(currentDirectory, $"StoryCard.txt"));
        }

    }
}
