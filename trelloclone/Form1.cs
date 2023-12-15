using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace trelloclone
{
    public partial class Form1 : Form
    {
        EventHandlers eventHandlers;
       // List<Guna2Button> listOfBtn = new List<Guna2Button>();
        
        

        public EventHandlers EventHandlers { get => eventHandlers; set => eventHandlers = value; }
        public Form1()
        {
            InitializeComponent();
            sizeBar.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            EventHandlers = new EventHandlers(this, WorkSpacePanel, myTablePanel, myTableButton, timerMyTable, sizeBar, iconButton);
            //listOfBtn.Add(btnStoryCard1_List1);
        }

        private void btnAddNewCard_Click(object sender, EventArgs e)
        {

        }

        //private void btnStoryCard1_List1_Click(object sender, EventArgs e)
        //{
        //    Card a = new Card();

        //    a.Show();

        //}

        //private void btnAddNewCard_Click(object sender, EventArgs e)
        //{
        //    pnlList.Size = new Size(pnlList.Width, pnlList.Height + 40);
        //    btnAddNewCard.Location = new Point(0, btnAddNewCard.Location.Y + 40);

        //    Guna2Button btnCard = new Guna2Button();
        //    btnCard.Click += DynamicButton_Click;

        //    btnCard.BackColor = listOfBtn[listOfBtn.Count - 1].BackColor;
        //    btnCard.Size = listOfBtn[listOfBtn.Count - 1].Size;
        //    btnCard.BackColor = Color.Transparent;
        //    btnCard.BorderRadius = listOfBtn[listOfBtn.Count - 1].BorderRadius;
        //    btnCard.FillColor = listOfBtn[listOfBtn.Count - 1].FillColor;
        //    //btnCard.Font.Size = 9;
        //    btnCard.TextAlign = HorizontalAlignment.Left;
        //    btnCard.ForeColor = Color.Black;
        //    btnCard.Text = "Nhu cc";

        //    btnCard.Location = new Point(listOfBtn[listOfBtn.Count - 1].Location.X,
        //        listOfBtn[listOfBtn.Count - 1].Location.Y + 40);
        //    btnCard.Show();
        //    pnlList.Controls.Add(btnCard);
        //    listOfBtn.Add(btnCard);
        //}
        //private static void DynamicButton_Click(object sender, EventArgs e)
        //{
        //    Card a = new Card();

        //    a.Show();
        //}
    }
}
