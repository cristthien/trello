using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace trelloclone
{
    internal class InsideTable
    {
        List<Guna2Button> listOfBtn = new List<Guna2Button>();
        List<Panel> listOfList = new List<Panel>();

        
        Panel pnlAllList = new Panel();
        Panel pnlFirstList = new Panel();
        
        Guna2Button btnAddNewCard = new Guna2Button();
        Guna2Button btnCard = new Guna2Button();
        //listOfBtn.add(btnCard);
        Guna2Button btnAddNewList = new Guna2Button();

        

        private void btnStoryCard1_List1_Click(object sender, EventArgs e)
        {
            Card a = new Card();

            a.Show();

        }
        public InsideTable(Form1 form, Panel WorkSpace, Panel TableSpace)
        { 

            WorkSpace.Controls.Add(pnlAllList);
            pnlAllList.Size = WorkSpace.Size;
            // pnlAllList.BackColor = WorkSpace.BackColor;
            pnlAllList.BackColor = WorkSpace.BackColor;

            pnlAllList.Controls.Add(pnlFirstList); //Add panel for list
            pnlFirstList.Size = new Size(260, 110);
            pnlFirstList.Location = new Point(200, 50);
            pnlFirstList.BackColor = Color.White;
            listOfList.Add(pnlFirstList); //Add first list to the LIST of panel

            pnlAllList.Controls.Add(btnAddNewList);
            btnAddNewList.BorderRadius = 5;
            btnAddNewList.BackColor = Color.Transparent;
            btnAddNewList.FillColor = Color.FromArgb(224, 224, 224);
            btnAddNewList.Size = new Size(130, 30);
            btnAddNewList.Location = new Point(200, 10);
            btnAddNewList.Image = Image.FromFile(Application.StartupPath + "/Resources/Add.png");
            btnAddNewList.ImageAlign = HorizontalAlignment.Left;
            btnAddNewList.ImageOffset = new Point(-10, 0);
            btnAddNewList.Text = "Thêm danh sách";
            btnAddNewList.ForeColor = Color.Black;
            btnAddNewList.TextOffset = new Point(-1, 0);

            pnlFirstList.Controls.Add(btnCard); //Add the card button for list
            btnCard.BackColor = Color.Transparent;
            btnCard.BorderRadius = 5;
            btnCard.FillColor = Color.FromArgb(224, 224, 224);
            btnCard.Location = new Point(5, 40);
            btnCard.Size = new Size(250, 35);
            btnCard.ForeColor = Color.Black;
            btnCard.Text = "Content...";
            btnCard.TextAlign = HorizontalAlignment.Left;
            listOfBtn.Add(btnCard); //add the btn Card to the LIST of button

            pnlFirstList.Controls.Add(btnAddNewCard);
            btnAddNewCard.BorderRadius = 5; 
            btnAddNewCard.BackColor = Color.White;
            btnAddNewCard.FillColor = Color.FromArgb(224, 224, 224);
            btnAddNewCard.Size = new Size(100, 20);
            btnAddNewCard.Location = new Point(listOfBtn[listOfBtn.Count - 1].Location.X, listOfBtn[listOfBtn.Count - 1].Location.Y+40);
            btnAddNewCard.Image = Image.FromFile(Application.StartupPath + "/Resources/Add.png");
            btnAddNewCard.ImageAlign = HorizontalAlignment.Left;
            btnAddNewCard.ImageOffset = new Point(-10, 0);
            btnAddNewCard.Text = "Thêm thẻ";
            btnAddNewCard.ForeColor = Color.Black;
            btnAddNewCard.TextOffset = new Point(-1, 0);

            btnAddNewCard.Click += btnAddNewCard_Click;
            btnAddNewList.Click += btnAddNewList_Click;
        }
        private void btnAddNewList_Click(object sender, EventArgs e)
        {

            MessageBox.Show("...");

            //pnlFirstList.Controls.Add(btnCard); //Add the card button for list
            //btnCard.BackColor = Color.Transparent;
            //btnCard.BorderRadius = 5;
            //btnCard.FillColor = Color.FromArgb(224, 224, 224);
            //btnCard.Location = new Point(5, 40);
            //btnCard.Size = new Size(450, 35);
            //btnCard.ForeColor = Color.Black;
            //btnCard.Text = "Content...";
            //btnCard.TextAlign = HorizontalAlignment.Left;
            //listOfBtn.Add(btnCard); //add the btn Card to the LIST of button

            //pnlFirstList.Controls.Add(btnAddNewCard);
            //btnAddNewCard.BorderRadius = 5;
            //btnAddNewCard.BackColor = Color.White;
            //btnAddNewCard.FillColor = Color.FromArgb(224, 224, 224);
            //btnAddNewCard.Size = new Size(100, 20);
            //btnAddNewCard.Location = new Point(listOfBtn[listOfBtn.Count - 1].Location.X, listOfBtn[listOfBtn.Count - 1].Location.Y + 40);
            //btnAddNewCard.Image = Image.FromFile("C:\\Users\\Dell\\source\\repos\\trelloclone\\trelloclone\\Resources\\Add.png");
            //btnAddNewCard.ImageAlign = HorizontalAlignment.Left;
            //btnAddNewCard.ImageOffset = new Point(-10, 0);
            //btnAddNewCard.Text = "Thêm thẻ";
            //btnAddNewCard.ForeColor = Color.Black;
            //btnAddNewCard.TextOffset = new Point(-1, 0);
        }

        private void btnAddNewCard_Click(object sender, EventArgs e)
        {
            listOfList[listOfList.Count-1].Size = new Size(listOfList[listOfList.Count - 1].Size.Width, listOfList[listOfList.Count - 1].Size.Height+40);
            btnAddNewCard.Location = new Point(btnAddNewCard.Location.X, btnAddNewCard.Location.Y + 40);

            Guna2Button btnCard_in = new Guna2Button();
            btnCard.Click += DynamicButton_Click;
            btnCard_in.Click += DynamicButton_Click;
            btnCard_in.Location = new Point(listOfBtn[listOfBtn.Count - 1].Location.X,
                listOfBtn[listOfBtn.Count - 1].Location.Y + 40);
            btnCard_in.BackColor = listOfBtn[listOfBtn.Count - 1].BackColor;
            btnCard_in.Size = listOfBtn[listOfBtn.Count - 1].Size;
            btnCard_in.BackColor = Color.Transparent;
            btnCard_in.BorderRadius = listOfBtn[listOfBtn.Count - 1].BorderRadius;
            btnCard_in.FillColor = listOfBtn[listOfBtn.Count - 1].FillColor;
            btnCard_in.TextAlign = HorizontalAlignment.Left;
            btnCard_in.ForeColor = Color.Black;
            btnCard_in.Text = "Content...";

            listOfList[listOfList.Count - 1].Controls.Add(btnCard_in);
            listOfBtn.Add(btnCard_in);

        }
        private static void DynamicButton_Click(object sender, EventArgs e)
        {
            Card a = new Card();
            MessageBox.Show("hel");
            a.Show();
        }
    }
}
