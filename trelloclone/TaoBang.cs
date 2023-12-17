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
                RJButton newButton = new RJButton()
                {
                    Width = eventHandlers.myTableButton.Width,
                    Height = eventHandlers.myTableButton.Height,
                    BorderRadius = 0,
                    BorderSize = 0,
                    BackColor = Color.Transparent,
                    Text = getName,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleLeft,
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
                RJButton optBtn = new RJButton()
                {
                    Width = 25,
                    Height = 20,
                    BorderRadius = 10,
                    BorderSize = 0,
                    Location = new Point(newButton.Location.X + newButton.Width - 30, newButton.Location.Y + 10),
                    BackColor = Color.Transparent,
                    BackgroundImage = Image.FromFile(Application.StartupPath + "/Resources/....png"),
                    BackgroundImageLayout = ImageLayout.Stretch,
                    Tag = newButton.Tag
                };
                optBtn.Click += eventHandlers.OptBtn_Click;
                eventHandlers.TableSpace.Controls.Add(optBtn);
                optBtn.BringToFront();
                eventHandlers.WorkSpace.Controls.Remove(textBoxPanel);
                eventHandlers.Buttons.Add(newButton); //Nhet button Table vua tao vao trong mang de quan ly
                eventHandlers.OtpBtn.Add(optBtn);
                this.Hide();

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
