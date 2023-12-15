using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trelloclone
{
    internal class list:Panel
    {
        static int numberOfList = 0;
        static List<list> listOfList;
        private List<Guna2Button> listOfBtn;

        public static int NumberOfList { get => numberOfList; set => numberOfList = value; }
        internal static List<list> ListOfList { get => listOfList; set => listOfList = value; }
        public List<Guna2Button> ListOfBtn { get => listOfBtn; set => listOfBtn = value; }

        public list(Panel pnlAllList)
        {
            NumberOfList += 1;
            Panel pnlCurrentList = createCurrentList(pnlAllList);
            createFirstCard(pnlCurrentList);
            modifyAddCard(pnlCurrentList, true); // create and edit the add card button
        }

        private Panel createCurrentList(Panel pnlAllList)
        {
            pnlAllList.Controls.Add(this); //Add panel for list
            this.Size = new Size(260, 110);
            this.Location = new Point(200*NumberOfList, 50);
            this.BackColor = Color.White;
            ListOfList.Add(this); //Add first list to the LIST of panel

            return this;
        }

        private void createFirstCard(Panel pnlCurrentList)
        {
            Guna2Button btnCard = new Guna2Button();
            pnlCurrentList.Controls.Add(btnCard); //Add the card button for list
            btnCard.BackColor = Color.Transparent;
            btnCard.BorderRadius = 5;
            btnCard.FillColor = Color.FromArgb(224, 224, 224);
            btnCard.Location = new Point(5, 40);
            btnCard.Size = new Size(250, 35);
            btnCard.ForeColor = Color.Black;
            btnCard.Text = "Content...";
            btnCard.TextAlign = HorizontalAlignment.Left;
            ListOfBtn.Add(btnCard); //add the btn Card to the LIST of button
        }
        private void createOtherCard(Panel pnlCurrentList)
        {
            Guna2Button btnCard_in = new Guna2Button();
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
        private void modifyAddCard(Panel pnlCurrentList, bool initialize)
        {
            Guna2Button btnAddNewCard = new Guna2Button();

            pnlCurrentList.Controls.Add(btnAddNewCard);
            btnAddNewCard.BorderRadius = 5;
            btnAddNewCard.BackColor = Color.White;
            btnAddNewCard.FillColor = Color.FromArgb(224, 224, 224);
            btnAddNewCard.Size = new Size(100, 20);
            btnAddNewCard.Location = new Point(listOfBtn[listOfBtn.Count - 1].Location.X * numberOfList, listOfBtn[listOfBtn.Count - 1].Location.Y + 40);
            btnAddNewCard.Image = Image.FromFile("C:\\Users\\Dell\\source\\repos\\trelloclone\\trelloclone\\Resources\\Add.png");
            btnAddNewCard.ImageAlign = HorizontalAlignment.Left;
            btnAddNewCard.ImageOffset = new Point(-10, 0);
            btnAddNewCard.Text = "Thêm thẻ";
            btnAddNewCard.ForeColor = Color.Black;
            btnAddNewCard.TextOffset = new Point(-1, 0);
        }
    }
}
