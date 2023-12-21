using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace trelloclone
{
    internal class InsideTable
    {
        private string tableName;
        Guna2Panel pnlAllList = new Guna2Panel();
        Guna2Panel pnlFirstList = new Guna2Panel();
        Guna2Button btnAddNewCard = new Guna2Button();
        Guna2Button btnCard = new Guna2Button();
        Guna2Button btnAddNewList = new Guna2Button();
        Guna2Button btnSaveTable = new Guna2Button();
        List<list> listOfDanhSach = new List<list>();
        HScrollBar hScrollBar = new HScrollBar();

        public string TableName { get => tableName; set => tableName = value; }
        public Guna2Panel PnlAllList { get => pnlAllList; set => pnlAllList = value; }
        public Guna2Panel PnlFirstList { get => pnlFirstList; set => pnlFirstList = value; }
        public Guna2Button BtnAddNewCard { get => btnAddNewCard; set => btnAddNewCard = value; }
        public Guna2Button BtnCard { get => btnCard; set => btnCard = value; }
        public Guna2Button BtnAddNewList { get => btnAddNewList; set => btnAddNewList = value; }
        public Guna2Button BtnSaveTable { get => btnSaveTable; set => btnSaveTable = value; }
        public List<list> ListOfDanhSach { get => listOfDanhSach; set => listOfDanhSach = value; }

        public InsideTable(Form1 form, Panel WorkSpace, Panel TableSpace)
        {
            PnlAllList.Size = WorkSpace.Size;
            PnlAllList.AutoScroll = true;
            PnlAllList.AutoScrollMargin = new Size(20, 20);
            pnlAllList.AutoScrollMinSize = new Size(500, 500);
            PnlAllList.BackColor = WorkSpace.BackColor;
            WorkSpace.Controls.Add(PnlAllList);

            PnlAllList.Controls.Add(BtnAddNewList);
            BtnAddNewList.BorderRadius = 5;
            BtnAddNewList.BackColor = Color.Transparent;
            BtnAddNewList.FillColor = Color.FromArgb(224, 224, 224);
            BtnAddNewList.Size = new Size(115, 30);
            BtnAddNewList.Location = new Point(180, 10);
            BtnAddNewList.Image = Image.FromFile(Application.StartupPath + "/Resources/Add.png");
            BtnAddNewList.ImageAlign = HorizontalAlignment.Left;
            BtnAddNewList.ImageOffset = new Point(-10, 0);
            BtnAddNewList.Text = "Thêm danh sách";
            BtnAddNewList.ForeColor = Color.Black;
            BtnAddNewList.TextOffset = new Point(7, 0);
            BtnAddNewList.Click += btnAddNewList_Click;

            PnlAllList.Controls.Add(BtnSaveTable);
            BtnSaveTable.BorderRadius = 5;
            BtnSaveTable.BackColor = Color.Transparent;
            BtnSaveTable.FillColor = Color.FromArgb(224, 224, 224);
            BtnSaveTable.Size = new Size(52, 30);
            BtnSaveTable.Location = new Point(300, 10);
            BtnSaveTable.Image = Image.FromFile(Application.StartupPath + "/Resources/hide.png");
            BtnSaveTable.ImageAlign = HorizontalAlignment.Left;
            BtnSaveTable.ImageOffset = new Point(-8, 0);
            BtnSaveTable.Text = "Ẩn";
            BtnSaveTable.ForeColor = Color.Black;
            BtnSaveTable.TextOffset = new Point(8, 0);
            BtnSaveTable.Click += BtnSaveTable_Click;

            PnlAllList.Controls.Add(hScrollBar);
            hScrollBar.Location = new Point(hScrollBar.Location.X + 1370, hScrollBar.Location.Y + 780);
            hScrollBar.Maximum = 1000;
            hScrollBar.Scroll += HScrollBar_Scroll;

            createTheFirstList(pnlAllList, ListOfDanhSach);
        }
        private void HScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            int newPos = e.NewValue;
            int dif = e.NewValue - e.OldValue;
            PnlAllList.Location = new Point(PnlAllList.Location.X - dif, PnlAllList.Location.Y);
            hScrollBar.Location = new Point(hScrollBar.Location.X + dif, hScrollBar.Location.Y);
            BtnAddNewList.Location = new Point(BtnAddNewList.Location.X + dif, BtnAddNewList.Location.Y);
            BtnSaveTable.Location = new Point(BtnSaveTable.Location.X + dif, BtnSaveTable.Location.Y);
        }

        private void BtnSaveTable_Click(object sender, EventArgs e)
        {
            PnlAllList.Visible = false;
        }

        private void createTheFirstList(Guna2Panel PnlAllList, List<list> listOfDanhSach)
        {
            list firstList = new list(PnlAllList, listOfDanhSach);
            listOfDanhSach.Add(firstList);
            firstList.BtnAddCard.Click += btnAddCard_Click;
            firstList.BtnFirstCard.Click += DynamicButton_Click;
            firstList.BtnDeleteList.Click += btnDeleteList_Click;
            firstList.BtnMoveToLeft.Click += BtnMoveToLeft_Click;
            firstList.BtnMoveToRight.Click += BtnMoveToRight_Click;
        }
        internal void btnAddNewList_Click(object sender, EventArgs e)
        {
            if (ListOfDanhSach.Count != 0)
            {
                list anotherList = new list(PnlAllList, ListOfDanhSach);
                ListOfDanhSach.Add(anotherList);
                anotherList.BtnAddCard.Click += btnAddCard_Click;
                anotherList.BtnFirstCard.Click += DynamicButton_Click;
                anotherList.BtnDeleteList.Click += btnDeleteList_Click;
                anotherList.BtnMoveToLeft.Click += BtnMoveToLeft_Click;
                anotherList.BtnMoveToRight.Click += BtnMoveToRight_Click;
            }
            else
                createTheFirstList(PnlAllList, ListOfDanhSach);
        }

        private void BtnMoveToRight_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = sender as Guna2Button;
            list currentList = list.FindForm(clickedButton);

            if (currentList != null)
            {
                int index = ListOfDanhSach.IndexOf(currentList);
                if (index + 1 == ListOfDanhSach.Count) // check for first and last table
                {
                    return;
                }
                else
                {
                    swap(ListOfDanhSach[index], ListOfDanhSach[index + 1], index, index + 1);
                    list temp = ListOfDanhSach[index];
                    ListOfDanhSach[index] = ListOfDanhSach[index + 1];
                    ListOfDanhSach[index + 1] = temp;
                }
            }
        }

        private void BtnMoveToLeft_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = sender as Guna2Button;
            list currentList = list.FindForm(clickedButton);

            if (currentList != null)
            {
                int index = ListOfDanhSach.IndexOf(currentList);
                if (index == 0) // check for first and last table
                    return;
                else
                {
                    swap(ListOfDanhSach[index - 1], ListOfDanhSach[index], index - 1, index);
                    list temp = ListOfDanhSach[index - 1];
                    ListOfDanhSach[index - 1] = ListOfDanhSach[index];
                    ListOfDanhSach[index] = temp;
                }
            }
        }
        private void swap(list a, list b, int index_a, int index_b)
        {
            Point c = a.Location;
            a.Location = b.Location;
            b.Location = c;
        }

        private void btnAddCard_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = sender as Guna2Button;
            list currentList = list.FindForm(clickedButton);

            if (currentList != null)
            {
                currentList.createOtherCard(currentList.PnlCurrentList);
                currentList.ListOfBtn[currentList.ListOfBtn.Count - 1].Click += DynamicButton_Click;
                currentList.modifyAddCard(currentList.PnlCurrentList);
                currentList.modifyDeleteList(currentList.PnlCurrentList);
            }
        }

        private void btnDeleteList_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = sender as Guna2Button;
            list currentList = list.FindForm(clickedButton);

            if (currentList != null)
            {
                DialogResult result = MessageBox.Show("Thực hiện xóa danh sánh?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (ListOfDanhSach.Count >= 1)
                    {
                        int index = ListOfDanhSach.IndexOf(currentList);
                        ListOfDanhSach.RemoveAt(index);
                        Size oldSize = currentList.Size;
                        Point OldLocation = currentList.Location;
                        pnlAllList.Controls.Remove(currentList);
                        list.moveListAfterDelete(OldLocation, oldSize, ListOfDanhSach);
                    }
                }
            }
        }
        private void DynamicButton_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = sender as Guna2Button;
            list currentList = list.FindForm(clickedButton);

            if (currentList != null)
            {
                int index = currentList.ListOfBtn.IndexOf(clickedButton);
                Card a;
                if (currentList.ListOfData.Count == 0)
                {
                    a = new Card(new AppData());
                    currentList.ListOfData.Add(a.AppData);
                }
                else
                    a = new Card(currentList.ListOfData[index]);

                a.ShowDialog();
                bool deleteCard = !a.Existed;

                if (a.Existed)
                {
                    currentList.ListOfData[index] = a.AppData;
                    currentList.ListOfBtn[index].Text = a.AppData.Title;
                    int indexList = this.ListOfDanhSach.IndexOf(currentList);
                    if (a.MoveToLeft)
                    {
                        if (indexList != 0)
                        {
                            AppData currentData = currentList.ListOfData[index];
                            deleteCard = true;
                            this.ListOfDanhSach[indexList - 1].BtnAddCard.PerformClick();
                            this.ListOfDanhSach[indexList - 1].ListOfData[this.ListOfDanhSach[indexList
                                - 1].ListOfData.Count - 1] = currentData;
                            this.ListOfDanhSach[indexList - 1].ListOfBtn[this.ListOfDanhSach[indexList
                                - 1].ListOfBtn.Count - 1].Text = currentData.Title;
                        }
                    }
                    else if (a.MoveToRight)
                    {
                        if (indexList < this.ListOfDanhSach.Count - 1)
                        {
                            AppData currentData = currentList.ListOfData[index];
                            deleteCard = true;
                            this.ListOfDanhSach[indexList + 1].BtnAddCard.PerformClick();
                            this.ListOfDanhSach[indexList + 1].ListOfData[this.ListOfDanhSach[indexList
                                + 1].ListOfData.Count - 1] = currentData;
                        }
                    }
                    else if (a.MoveUp)
                    {
                        if (index != 0)
                        {
                            AppData temp = currentList.ListOfData[index];
                            currentList.ListOfData[index] = currentList.ListOfData[index - 1];
                            currentList.ListOfData[index - +1] = temp;
                        }
                    }
                    else if (a.MoveDown)
                    {
                        if (index < currentList.ListOfBtn.Count - 1)
                        {
                            AppData temp = currentList.ListOfData[index];
                            currentList.ListOfData[index] = currentList.ListOfData[index + 1];
                            currentList.ListOfData[index + 1] = temp;
                        }
                    }
                    for (int j = 0; j < EventHandlers.ListOfTable.Count; j++)
                    {
                        for (int k = 0; k < EventHandlers.ListOfTable[j].ListOfDanhSach.Count; k++)
                        {
                            for (int l = 0; l < EventHandlers.ListOfTable[j].ListOfDanhSach[k].ListOfBtn.Count; l++)
                            {
                                if (l < EventHandlers.ListOfTable[j].ListOfDanhSach[k].ListOfData.Count)
                                {
                                    EventHandlers.ListOfTable[j].ListOfDanhSach[k].ListOfBtn[l].Text =
                                    EventHandlers.ListOfTable[j].ListOfDanhSach[k].ListOfData[l].Title;
                                }
                            }
                        }
                    }
                }
                if (deleteCard)
                {
                    if (currentList.ListOfBtn.Count == 1)
                    {
                        currentList.ListOfData.RemoveAt(index);
                        currentList.ListOfBtn[index].Text = "Tiêu đề";
                    }
                    else
                    {
                        Point OldLocation = clickedButton.Location;
                        currentList.Controls.Remove(clickedButton);
                        list.moveCardAfterDelete(currentList, OldLocation);
                        currentList.ListOfData.RemoveAt(index);
                        currentList.ListOfBtn.RemoveAt(index);
                    }
                }
            }
        }
        public override string ToString()
        {
            string a = $"{tableName}/{listOfDanhSach.Count}/";
            foreach (var list in listOfDanhSach)
            {
                if (listOfDanhSach.IndexOf(list) + 1 == listOfDanhSach.Count)
                {
                    a += $"{list.TxtBxTitle.Text}/";
                }
                else
                    a += $"{list.TxtBxTitle.Text}_";
            }
            foreach (var list in listOfDanhSach)
            {
                if (listOfDanhSach.IndexOf(list) + 1 == listOfDanhSach.Count)
                {
                    a += $"{list.ListOfBtn.Count}/";
                }
                else
                    a += $"{list.ListOfBtn.Count}_";
            }
            return a;
        }
    }
}
