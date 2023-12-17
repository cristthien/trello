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
    internal class list : Panel
    {
        static int numberOfList = 0;
        static List<list> listOfList = new List<list>();
        private List<Guna2Button> listOfBtn = new List<Guna2Button>();
        private List<AppData> listOfData = new List<AppData>();
        private List<bool> listOfmodifiedData = new List<bool>();
        private Guna2Button btnFirstCard;
        private Guna2Button btnAddCard;
        private Guna2Button btnDeleteList;
        private Guna2Button btnMoveToLeft;
        private Guna2Button btnMoveToRight;
        private Panel pnlCurrentList;
        private TextBox txtBxTitle;

        public static int NumberOfList { get => numberOfList; set => numberOfList = value; }
        internal static List<list> ListOfList { get => listOfList; set => listOfList = value; }
        public List<Guna2Button> ListOfBtn { get => listOfBtn; set => listOfBtn = value; }
        internal List<AppData> ListOfData { get => listOfData; set => listOfData = value; }
        public List<bool> ListOfModifiedData { get => listOfmodifiedData; set => listOfmodifiedData = value; }
        public Guna2Button BtnFirstCard { get => btnFirstCard; set => btnFirstCard = value; }
        public Guna2Button BtnAddCard { get => btnAddCard; set => btnAddCard = value; }
        public Guna2Button BtnDeleteList { get => btnDeleteList; set => btnDeleteList = value; }
        public Guna2Button BtnMoveToLeft { get => btnMoveToLeft; set => btnMoveToLeft = value; }
        public Guna2Button BtnMoveToRight { get => btnMoveToRight; set => btnMoveToRight = value; }
        public Panel PnlCurrentList { get => pnlCurrentList; set => pnlCurrentList = value; }
        public TextBox TxtBxTitle { get => txtBxTitle; set => txtBxTitle = value; }

        public list(Panel pnlAllList)
        {
            NumberOfList += 1;
            PnlCurrentList = createCurrentList(pnlAllList);
            TxtBxTitle = createTitle(PnlCurrentList);
            TxtBxTitle.Tag = this;
            BtnFirstCard = createFirstCard(PnlCurrentList);
            BtnAddCard = modifyAddCard(PnlCurrentList); // create and edit the add card button
            BtnAddCard.Tag = this;
            BtnDeleteList = modifyDeleteList(PnlCurrentList);
            BtnDeleteList.Tag = this;
            BtnMoveToLeft = createBtnMoveLeft(pnlCurrentList);
            BtnMoveToLeft.Tag = this;
            BtnMoveToRight = createBtnMoveRight(pnlCurrentList);
            BtnMoveToRight.Tag = this;
        }

        private TextBox createTitle(Panel pnlCurrentList)
        {
            txtBxTitle = new TextBox();
            pnlCurrentList.Controls.Add(txtBxTitle);

            txtBxTitle.Location = new Point(9, 10);
            txtBxTitle.Size = new Size(100, 50);
            txtBxTitle.Text = "Danh sách mới";
            txtBxTitle.TextAlign = HorizontalAlignment.Left;
            txtBxTitle.BorderStyle = BorderStyle.None;
            txtBxTitle.Font = new Font("Segoe UI", 10);

            return txtBxTitle;
        }

        private Guna2Button createBtnMoveLeft(Panel pnlCurrentList)
        {
            BtnMoveToLeft = new Guna2Button();
            pnlCurrentList.Controls.Add(BtnMoveToLeft);
            BtnMoveToLeft.BackColor = Color.Transparent;
            BtnMoveToLeft.Location = new Point(230, 10);
            BtnMoveToLeft.Size = new Size(10, 10);
            BtnMoveToLeft.Image = Image.FromFile("C:\\Users\\Dell\\source\\repos\\trelloclone\\trelloclone\\Resources\\backArrow.png");
            BtnMoveToLeft.ImageSize = new Size(10, 10);
            BtnMoveToLeft.ImageAlign = HorizontalAlignment.Center;
            BtnMoveToLeft.ImageOffset = new Point(1, 0);
            BtnMoveToLeft.FillColor = Color.FromArgb(224, 224, 224);


            return BtnMoveToLeft;
        }
        private Guna2Button createBtnMoveRight(Panel pnlCurrentList)
        {
            BtnMoveToRight = new Guna2Button();
            pnlCurrentList.Controls.Add(BtnMoveToRight);
            BtnMoveToRight.BackColor = Color.Transparent;
            BtnMoveToRight.Location = new Point(243, 10);
            BtnMoveToRight.Size = new Size(10, 10);
            BtnMoveToRight.Image = Image.FromFile("C:\\Users\\Dell\\source\\repos\\trelloclone\\trelloclone\\Resources\\forwardArrow.png");
            BtnMoveToRight.ImageSize = new Size(10, 10);
            BtnMoveToRight.ImageAlign = HorizontalAlignment.Center;
            BtnMoveToRight.FillColor = Color.FromArgb(224, 224, 224);

            return BtnMoveToRight;
        }


        public Panel createCurrentList(Panel pnlAllList)
        {
            pnlAllList.Controls.Add(this); //Add panel for list
            this.Size = new Size(260, 110);

            if (list.ListOfList.Count == 0)
                this.Location = new Point(200, 50);
            else
            {
                //this.Location = new Point(listOfList[NumberOfList-2].Location.X + 
                //    listOfList[NumberOfList-2].Size.Width + 10, 50);

                this.Location = new Point(listOfList[list.ListOfList.Count - 1].Location.X +
                    listOfList[list.ListOfList.Count - 1].Size.Width + 10, 50);
            }

            this.BackColor = Color.White;
            ListOfList.Add(this); //Add first list to the LIST of panel

            return this;
        }

        public Guna2Button createFirstCard(Panel pnlCurrentList)
        {
            Guna2Button btnCard = new Guna2Button();
            pnlCurrentList.Controls.Add(btnCard); //Add the card button for list
            btnCard.BackColor = Color.Transparent;
            btnCard.BorderRadius = 5;
            btnCard.FillColor = Color.FromArgb(224, 224, 224);
            btnCard.Location = new Point(5, 40);
            btnCard.Size = new Size(250, 35);
            btnCard.ForeColor = Color.Black;
            btnCard.Text = "Tiêu đề";
            btnCard.TextAlign = HorizontalAlignment.Left;
            ListOfBtn.Add(btnCard); //add the btn Card to the LIST of button
            ListOfModifiedData.Add(false);
            ListOfData.Add(new AppData());

            btnCard.Tag = this;
            return btnCard;
        }

        public Guna2Button createOtherCard(Panel pnlCurrentList)
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
            btnCard_in.Text = "Tiêu đề";

            this.Controls.Add(btnCard_in);
            listOfBtn.Add(btnCard_in);
            listOfmodifiedData.Add(false);
            ListOfData.Add(new AppData());

            btnCard_in.Tag = this;

            return btnCard_in;
        }

        public Guna2Button modifyAddCard(Panel pnlCurrentList)
        {
            Guna2Button btnAddNewCard = new Guna2Button();

            if (listOfBtn.Count > 1)
            {
                this.Size = new Size(this.Size.Width, this.Size.Height + 40);
                BtnAddCard.Location = new Point(BtnAddCard.Location.X, BtnAddCard.Location.Y + 40);
            }
            else
            {
                pnlCurrentList.Controls.Add(btnAddNewCard);
                btnAddNewCard.BorderRadius = 5;
                btnAddNewCard.BackColor = Color.White;
                btnAddNewCard.FillColor = Color.FromArgb(224, 224, 224);
                btnAddNewCard.Size = new Size(90, 20);
                btnAddNewCard.Location = new Point(5, 80);
                btnAddNewCard.Image = Image.FromFile("C:\\Users\\Dell\\source\\repos\\trelloclone\\trelloclone\\Resources\\Add.png");
                btnAddNewCard.ImageAlign = HorizontalAlignment.Left;
                btnAddNewCard.ImageOffset = new Point(-10, 0);
                btnAddNewCard.Text = "Thêm thẻ";
                btnAddNewCard.ForeColor = Color.Black;
                btnAddNewCard.TextOffset = new Point(-1, 0);
                this.Controls.Add(btnAddNewCard);
            }

            return btnAddNewCard;
        }
        public Guna2Button modifyDeleteList(Panel pnlCurrentList)
        {
            Guna2Button btnRemoveList = new Guna2Button();

            if (listOfBtn.Count > 1)
            {
                btnDeleteList.Location = new Point(btnDeleteList.Location.X, btnDeleteList.Location.Y + 40);
            }
            else
            {
                pnlCurrentList.Controls.Add(btnRemoveList);
                btnRemoveList.BorderRadius = 5;
                btnRemoveList.BackColor = Color.White;
                btnRemoveList.FillColor = Color.FromArgb(224, 224, 224);
                btnRemoveList.Size = new Size(120, 20);
                btnRemoveList.Image = Image.FromFile("C:\\Users\\Dell\\source\\repos\\trelloclone\\trelloclone\\Resources\\delete.png");
                btnRemoveList.ImageAlign = HorizontalAlignment.Left;
                btnRemoveList.Location = new Point(133, 80);
                btnRemoveList.ImageOffset = new Point(-10, 0);
                btnRemoveList.Text = "Xoá danh sách";
                btnRemoveList.ForeColor = Color.Black;
                btnRemoveList.TextOffset = new Point(-1, 0);
                this.Controls.Add(btnRemoveList);
            }
            return btnRemoveList;

        }

        static public list FindForm(Control control)
        {
            while (control != null && !(control is list))
            {
                control = control.Parent;
            }

            return control as list;
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        static public void moveCardAfterDelete(list pnlCurrentList, Point deletedLocation)
        {

            int i = 0;
            while (i < pnlCurrentList.ListOfBtn.Count)
            {
                if (pnlCurrentList.ListOfBtn[i].Location.Y > deletedLocation.Y)
                {
                    pnlCurrentList.ListOfBtn[i].Location = new Point(pnlCurrentList.ListOfBtn[i].Location.X,
                        pnlCurrentList.ListOfBtn[i].Location.Y - 40);
                }
                i += 1;
            }
            pnlCurrentList.btnAddCard.Location = new Point(pnlCurrentList.btnAddCard.Location.X,
                    pnlCurrentList.btnAddCard.Location.Y - 40);
            pnlCurrentList.btnDeleteList.Location = new Point(pnlCurrentList.btnDeleteList.Location.Y,
                pnlCurrentList.btnDeleteList.Location.Y - 40);
        }
        static public void moveListAfterDelete(Point deletedLocation, Size deleteSize)
        {
            int i = 0;
            while (i < listOfList.Count)
            {
                if (listOfList[i].Location.X > deletedLocation.X)
                {
                    listOfList[i].Location = new Point(listOfList[i].Location.X - deleteSize.Width - 10, 50);
                }
                i++;
            }
        }
    }
}
