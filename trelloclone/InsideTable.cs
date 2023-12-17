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
        Panel pnlAllList = new Panel();
        Panel pnlFirstList = new Panel();
        Guna2Button btnAddNewCard = new Guna2Button();
        Guna2Button btnCard = new Guna2Button();
        Guna2Button btnAddNewList = new Guna2Button();

        public Panel PnlAllList { get => pnlAllList; set => pnlAllList = value; }
        public Panel PnlFirstList { get => pnlFirstList; set => pnlFirstList = value; }
        public Guna2Button BtnAddNewCard { get => btnAddNewCard; set => btnAddNewCard = value; }
        public Guna2Button BtnCard { get => btnCard; set => btnCard = value; }
        public Guna2Button BtnAddNewList { get => btnAddNewList; set => btnAddNewList = value; }

        public InsideTable(Form1 form, Panel WorkSpace, Panel TableSpace)
        {
            WorkSpace.Controls.Add(PnlAllList);
            PnlAllList.Size = WorkSpace.Size;
            PnlAllList.BackColor = WorkSpace.BackColor;
            PnlAllList.Controls.Add(BtnAddNewList);

            BtnAddNewList.BorderRadius = 5;
            BtnAddNewList.BackColor = Color.Transparent;
            BtnAddNewList.FillColor = Color.FromArgb(224, 224, 224);
            BtnAddNewList.Size = new Size(130, 30);
            BtnAddNewList.Location = new Point(200, 10);
            BtnAddNewList.Image = Image.FromFile("C:\\Users\\Dell\\source\\repos\\trelloclone\\trelloclone\\Resources\\Add.png");
            BtnAddNewList.ImageAlign = HorizontalAlignment.Left;
            BtnAddNewList.ImageOffset = new Point(-10, 0);
            BtnAddNewList.Text = "Thêm danh sách";
            BtnAddNewList.ForeColor = Color.Black;
            BtnAddNewList.TextOffset = new Point(-1, 0);
            BtnAddNewList.Click += btnAddNewList_Click;

            createTheFirstList(pnlAllList);

        }
        private void createTheFirstList(Panel PnlAllList)
        {
            list firstList = new list(PnlAllList);
            firstList.BtnAddCard.Click += btnAddCard_Click;
            firstList.BtnFirstCard.Click += DynamicButton_Click;
            firstList.BtnDeleteList.Click += btnDeleteList_Click;
            firstList.BtnMoveToLeft.Click += BtnMoveToLeft_Click;
            firstList.BtnMoveToRight.Click += BtnMoveToRight_Click;
        }

        private void BtnMoveToRight_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = sender as Guna2Button;
            list form = list.FindForm(clickedButton);

            if (form != null)
            {
                int index = list.ListOfList.IndexOf(form);

                if (index + 1 == list.ListOfList.Count) // check for first and last table
                {
                    return;
                }
                else
                {
                    swap(list.ListOfList[index], list.ListOfList[index + 1], index, index + 1);
                    list temp = list.ListOfList[index];
                    list.ListOfList[index] = list.ListOfList[index + 1];
                    list.ListOfList[index + 1] = temp;
                }
            }
        }

        private void BtnMoveToLeft_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = sender as Guna2Button;
            list form = list.FindForm(clickedButton);

            if (form != null)
            {
                int index = list.ListOfList.IndexOf(form);
                if (index == 0) // check for first and last table
                    return;
                else
                {
                    swap(list.ListOfList[index - 1], list.ListOfList[index], index - 1, index);
                    list temp = list.ListOfList[index - 1];
                    list.ListOfList[index - 1] = list.ListOfList[index];
                    list.ListOfList[index] = temp;
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
            list form = list.FindForm(clickedButton);

            if (form != null)
            {
                form.createOtherCard(form.PnlCurrentList);
                form.ListOfBtn[form.ListOfBtn.Count - 1].Click += DynamicButton_Click;
                form.modifyAddCard(form.PnlCurrentList);
                form.modifyDeleteList(form.PnlCurrentList);
                form.BtnDeleteList.Click += btnDeleteList_Click;
            }
        }
        private void btnAddNewList_Click(object sender, EventArgs e)
        {
            if (list.ListOfList.Count != 0)
            {
                list anotherList = new list(PnlAllList);
                //pnlList.Add(anotherList);
                anotherList.BtnAddCard.Click += btnAddCard_Click;
                anotherList.BtnFirstCard.Click += DynamicButton_Click;
                anotherList.BtnDeleteList.Click += btnDeleteList_Click;
                anotherList.BtnMoveToLeft.Click += BtnMoveToLeft_Click;
                anotherList.BtnMoveToRight.Click += BtnMoveToRight_Click;
            }
            else
                createTheFirstList(PnlAllList);
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
                    Point oldLocation = currentList.Location;
                    int index = list.ListOfList.IndexOf(currentList);

                    if (list.ListOfList.Count >= 1)
                    {
                        list.ListOfList.RemoveAt(index);
                        Size oldSize = currentList.Size;
                        Point OldLocation = currentList.Location;
                        pnlAllList.Controls.Remove(currentList);
                        list.moveListAfterDelete(OldLocation, oldSize);
                    }
                }
            }
        }
        private static void DynamicButton_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = sender as Guna2Button;
            list form = list.FindForm(clickedButton);

            if (form != null)
            {
                int index = form.ListOfBtn.IndexOf(clickedButton);
                Card a = new Card(form.ListOfData[index]);

                a.ShowDialog();

                if (a.Existed)
                {
                    form.ListOfData[index] = a.AppData;
                    form.ListOfBtn[index].Text = a.AppData.Title;
                }
                else
                {
                    if (index == 0)
                    {
                        form.ListOfData.RemoveAt(index);
                    }
                    else
                    {
                        Point OldLocation = clickedButton.Location;
                        form.Controls.Remove(clickedButton);
                        list.moveCardAfterDelete(form, OldLocation);
                        form.ListOfData.RemoveAt(index);
                        form.ListOfBtn.RemoveAt(index);
                    }
                }
            }
        }

    }
}
