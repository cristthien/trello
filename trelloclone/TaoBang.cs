using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
using ui;
using Guna.UI2.WinForms;

namespace trelloclone
{
    public partial class TaoBang : Form
    {
        TableBLL tableBLL = new TableBLL();
        Table table = new Table();
        EventHandlers eventHandlers;
        private List<InsideTable> listOfTableSpace = new List<InsideTable>();
        public TaoBang(EventHandlers eventHandlers)
        {
            InitializeComponent();
            this.eventHandlers = eventHandlers;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void createButton_Click(object sender, EventArgs e)
        {
            table.Name_Of_Table = txtNameOfTable.Text;
            string getName = tableBLL.CheckLogicNameOfTable(table);
            if (getName == "require_Name")
            {
                MessageBox.Show("Tên bảng không được để trống");
            }
            else
            {
                //Table button
                Guna2Button newButton = new Guna2Button()
                {
                    Width = eventHandlers.myTableButton.Width,
                    Height = eventHandlers.myTableButton.Height,
                    BorderRadius = 0,
                    BackColor = Color.Transparent,
                    Text = getName,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                    Tag = eventHandlers.Buttons.Count
                };
                if (eventHandlers.Buttons.Count == 0)
                {
                    newButton.Location = new Point(eventHandlers.myTableButton.Location.X, eventHandlers.myTableButton.Location.Y + eventHandlers.myTableButton.Height);
                }
                else
                {
                    int lastIndex = eventHandlers.Buttons.Count - 1;
                    newButton.Location = new Point(eventHandlers.Buttons[lastIndex].Location.X, eventHandlers.Buttons[lastIndex].Location.Y + eventHandlers.Buttons[lastIndex].Height);
                }
                eventHandlers.TableSpace.Controls.Add(newButton);
                newButton.Click += eventHandlers.NewButton_Click;

                //Mark Button
                Guna2Button markBtn = new Guna2Button() {
                    Width = 20,
                    Height = 15,
                    BorderRadius = 10,
                    Location = new Point(newButton.Location.X + newButton.Width - 25, newButton.Location.Y + 10),
                    BackColor = Color.Transparent,
                    BackgroundImage = Image.FromFile(Application.StartupPath + "/Resources/star_empty.png"),
                    BackgroundImageLayout = ImageLayout.Stretch,
                    FillColor = Color.Transparent,
                    Visible = false,
                    Tag = newButton.Tag
                };
                eventHandlers.TableSpace.Controls.Add(markBtn);
                markBtn.BringToFront();
                markBtn.Click += eventHandlers.MarkBtn_Click;


                //Option button
                Guna2Button optBtn = new Guna2Button()
                {
                    Width = 20,
                    Height = 15,
                    BorderRadius = 10,
                    Location = new Point(markBtn.Location.X - markBtn.Width - 5, markBtn.Location.Y),
                    BackColor = Color.Transparent,
                    BackgroundImage = Image.FromFile(Application.StartupPath + "/Resources/....png"),
                    BackgroundImageLayout = ImageLayout.Stretch,
                    FillColor = Color.Transparent,
                    Visible = false,
                    Tag = newButton.Tag
                };
                optBtn.Click += eventHandlers.OptBtn_Click;
                eventHandlers.TableSpace.Controls.Add(optBtn);
                optBtn.BringToFront();
                eventHandlers.WorkSpace.Controls.Remove(textBoxPanel);
                eventHandlers.Buttons.Add(newButton); //Nhet button Table vua tao vao trong mang de quan ly
                eventHandlers.OptBtn.Add(optBtn);
                eventHandlers.MarkBtns.Add(markBtn);

                this.Hide(); //Tao xong thi form nay se bi an di


                InsideTable createdTable = getTable(sender, e);
                listOfTableSpace.Add(createdTable);
            }
        }

        private InsideTable getTable(object sender, EventArgs e)
        {
            InsideTable Table1 = new InsideTable(eventHandlers.MainForm, eventHandlers.WorkSpace, eventHandlers.TableSpace);


            return Table1;
        }
    }
}
