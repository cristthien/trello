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

namespace WindowsFormsApp1
{
    public partial class Card : Form
    {
        public Card()
        {
            InitializeComponent();

            tbxThemMoTaChiTiet.MouseClick += tbxThemMoTaChiTiet_MouseClick;
            

            tbxVietBinhLuan.MouseClick += tbxVietBinhLuan_MouseClick;
            

            pnl_Main.MouseDown += panel1_MouseDown;

        }
        bool isResize1 = true;
        bool isResize2 = true;
        bool onSizeBox1 = false;
        bool onSizeBox2 = false;

        Size originalSizeOf_tbxThemMoTaChiTiet, originalSizeOf_tbxVietBinhLuan;
        Size originalSizeOf_pnl_HoatDong, originalSizeOf_pnl_MoTa;
        Point originalPointOf_pnl_HoatDong;

        
        private void btnClose_Click(object sender, EventArgs e)
        {
            ////SaveDataToFile();
            //string currentPath = Application.StartupPath;

            ////MessageBox.Show($"Current Path: {currentPath}", "Current Path", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //SaveDataToFile();
            //Application.Exit();
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

        private void tbxThemMoTaChiTiet_MouseClick(object sender, MouseEventArgs e)
        {
            
            originalSizeOf_tbxThemMoTaChiTiet = new System.Drawing.Size(tbxThemMoTaChiTiet.Width, tbxThemMoTaChiTiet.Height);
            originalSizeOf_pnl_MoTa = new System.Drawing.Size(pnl_MoTa.Width, pnl_MoTa.Height);
            originalPointOf_pnl_HoatDong = new System.Drawing.Point(pnl_HoatDong.Location.X, pnl_HoatDong.Location.Y);
            onSizeBox1 = true;
            
            Resize();

            tbxThemMoTaChiTiet.Focus();
        }

        private void tbxVietBinhLuan_MouseClick(object sender, MouseEventArgs e)
        {
            originalSizeOf_tbxVietBinhLuan = new System.Drawing.Size(tbxVietBinhLuan.Width, tbxVietBinhLuan.Height);
            originalSizeOf_pnl_HoatDong = new System.Drawing.Size(pnl_HoatDong.Width, pnl_HoatDong.Height);
            onSizeBox2 = true;

            Resize();
        }

        private void Resize()
        {
            if (isResize1&&onSizeBox1==true)
            {
                resize_textBox(true, false, true, false);
                pnlFunctions.Hide();
                isResize1 = false;           
            }
            else if (isResize2&&onSizeBox2==true)
            {
                resize_textBox(false, true, true, false);
                pnlFunctions.Hide();
                isResize2 = false;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

            if (isResize1 == false && onSizeBox1==true)
            {
                resize_textBox(true, false, false, true);
                isResize1 = true;
                pnlFunctions.Show();
                onSizeBox1 = false;
            }
            else if (isResize2 == false && onSizeBox2==true)
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
                    pnl_MoTa.Size = new System.Drawing.Size(pnl_MoTa.Width, pnl_MoTa.Height + 130);
                    tbxThemMoTaChiTiet.Size = new System.Drawing.Size(tbxThemMoTaChiTiet.Width, tbxThemMoTaChiTiet.Height + 130);
                    pnl_HoatDong.Location = new System.Drawing.Point(pnl_HoatDong.Location.X, pnl_HoatDong.Location.Y + 100);
                }
                else if (!expand && shrink)
                {
                    pnl_MoTa.Size = new System.Drawing.Size(originalSizeOf_pnl_MoTa.Width, originalSizeOf_pnl_MoTa.Height - 130);
                    tbxThemMoTaChiTiet.Size = new System.Drawing.Size(originalSizeOf_tbxThemMoTaChiTiet.Width, originalSizeOf_tbxThemMoTaChiTiet.Height - 130);
                    pnl_HoatDong.Location = new System.Drawing.Point(originalPointOf_pnl_HoatDong.X, originalPointOf_pnl_HoatDong.Y - 100);

                }
            }
            else if(!txtThemMoTaChiTiet && txtVietBinhLuan)
            {
                if(expand && !shrink)
                {
                    tbxVietBinhLuan.Size = new System.Drawing.Size(tbxVietBinhLuan.Width, tbxVietBinhLuan.Height + 130);
                    pnl_HoatDong.Size = new System.Drawing.Size(pnl_HoatDong.Width, pnl_HoatDong.Height + 130);
                }
                else if(!expand && shrink)
                {
                    tbxVietBinhLuan.Size = new System.Drawing.Size(originalSizeOf_tbxVietBinhLuan.Width, originalSizeOf_tbxVietBinhLuan.Height - 130);
                    pnl_HoatDong.Size = new System.Drawing.Size(originalSizeOf_pnl_HoatDong.Width, originalSizeOf_pnl_HoatDong.Height - 130);

                }
            }
        }

        private void tbxThemMoTaChiTiet_Leave(object sender, EventArgs e)
        {
            string savedText = tbxThemMoTaChiTiet.Text;
            //MessageBox.Show($"savedText:: {savedText}");
        }

        private void tbxVietBinhLuan_Leave(object sender, EventArgs e)
        {
            string savedText = tbxVietBinhLuan.Text;
            //MessageBox.Show($"savedText:: {savedText}");
        }

    }
}
