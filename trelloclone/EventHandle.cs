using BLL;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ui;
using DTO;
using BLL;

namespace trelloclone
{
    public class EventHandlers
    {
        private Form1 mainForm;
        private TaoBang taobang;
        //WorkSpace
        private Panel workSpace;
        //TableSpace
        private Panel tableSpace;
        private List<Guna2Button> buttons;
        private List<Guna2Button> optBtn;
        private List<Guna2Button> markBtns;
        public Guna2Button myTableButton;
        private Panel textBoxPanel;
        private string textBoxContent = "";
        private Guna2GradientButton deleteTableButton;
        private List<Guna2PictureBox> colorOfTables;
        //MenuSpace
        private Timer sideBarTimer;
        private FlowLayoutPanel sideBar;
        private Guna2Button iconButton;
        bool sidebarExpand = true;

        //listOfDataTable
        static List<InsideTable> listOfTable = new List<InsideTable>();


        private List<InsideTable> listOfTableSpace = new List<InsideTable>();

        public Panel WorkSpace { get => workSpace; set => workSpace = value; }
        public Guna2Button MyTableButton { get => myTableButton; set => myTableButton = value; }
        public List<Guna2Button> Buttons { get => buttons; set => buttons = value; }
        public Panel TableSpace { get => tableSpace; set => tableSpace = value; }
        public List<Guna2Button> OptBtn { get => optBtn; set => optBtn = value; }
        public Form1 MainForm { get => mainForm; set => mainForm = value; }
        public List<Guna2Button> MarkBtns { get => markBtns; set => markBtns = value; }
        public Guna2GradientButton DeleteTableButton { get => deleteTableButton; set => deleteTableButton = value; }
        public List<Guna2PictureBox> ColorOfTables { get => colorOfTables; set => colorOfTables = value; }

        internal static List<InsideTable> ListOfTable { get => listOfTable; set => listOfTable = value; }

        public EventHandlers(Form1 form, Panel WorkSpace, Panel TableSpace, Guna2Button myTableButton, Timer timer, FlowLayoutPanel sideBar, Guna2Button iconButton, TaoBang taobang)
        {
            this.MainForm = form;
            this.taobang = taobang;
            //WorkSpace
            this.workSpace = WorkSpace;
            //TableSpace
            this.tableSpace = TableSpace;
            this.myTableButton = myTableButton;
            this.myTableButton.Click += myTableButton_Click;
            Buttons = new List<Guna2Button>();
            OptBtn = new List<Guna2Button>();
            MarkBtns = new List<Guna2Button>();
            ColorOfTables = new List<Guna2PictureBox>();
            //MenuSpace
            this.sideBarTimer = timer;
            this.sideBarTimer.Interval = 1;
            this.sideBarTimer.Tick += Timer_Tick;
            this.sideBar = sideBar;
            this.iconButton = iconButton;
            this.iconButton.Click += IconButton_Click;

            form.Load += Form_Load;
            form.FormClosed += Form_FormClosed;
        }


        private void Form_Load(object sender, EventArgs e)
        {
            //WindowState = FormWindowState.Maximized;
            retrieveData(sender, e);
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            string filePath1 = "table.txt";
            string filePath2 = "data.txt";
            using (StreamWriter writer = new StreamWriter(filePath1))
            {
                foreach (var table in ListOfTable)
                {
                    int indexTable = ListOfTable.IndexOf(table);
                    writer.WriteLine($"{table.ToString()}");
                }
            }
            using (StreamWriter writer = new StreamWriter(filePath2))
            {
                foreach (var table in ListOfTable)
                {
                    int indexTable = ListOfTable.IndexOf(table);
                    foreach (list danhSach in table.ListOfDanhSach)
                    {
                        int indexDanhSach = table.ListOfDanhSach.IndexOf(danhSach);
                        foreach (AppData dataToWrite in danhSach.ListOfData)
                        {
                            int indexCard = danhSach.ListOfData.IndexOf(dataToWrite);
                            dataToWrite.IndexTable = indexTable;
                            dataToWrite.IndexDanhSach = indexDanhSach;
                            dataToWrite.IndexCard = indexCard;
                            writer.WriteLine($"{dataToWrite.ToString()}");
                        }
                    }
                }
            }
        }

        private void IconButton_Click(object sender, EventArgs e)
        {
            sideBarTimer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Set the Minimum and maxim
            if(sidebarExpand)
            {
                //if sidebar is expand, minimize
                sideBar.Width -= 10;
                if(sideBar.Width == sideBar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sideBarTimer.Stop();
                }    
            }
            else
            {
                sideBar.Width += 10;
                if (sideBar.Width == sideBar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sideBarTimer.Stop();
                }
            }    
        }

        //Khi click vào nút "các bảng của bạn"
        public void myTableButton_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            //CreateTextBox(btn, "");
            taobang = new TaoBang(this);
            taobang.Location = new Point(300, 100);
            taobang.ShowDialog();
        }

        /*
        private void CreateTextBox(Guna2Button btn, string oldTitle)
        {
            textBoxPanel = new Panel()
            {
                Width = Const.panelTextBoxWidth,
                Height = Const.panelTextBoxHeight,
                Location = new Point(Const.myTableWidth, 0),
                BackgroundImage = Image.FromFile(Application.StartupPath + "/Resources/myTablePanel.png"),
                BackgroundImageLayout = ImageLayout.Stretch,
                BackColor = Color.Transparent
            };
            WorkSpace.Controls.Add(textBoxPanel);
            textBoxPanel.BringToFront();

            Label headLabel = new Label()
            {
                Text = "Tạo Bảng",
                Width = Const.panelTextBoxWidth,
                Location = new Point(0, 25),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            };

            Label titleLabel = new Label()
            {
                Text = "Tiêu đề bảng",
                Width = Const.panelTextBoxWidth,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(25, textBoxPanel.Location.Y + 75),
            };

            TextBox text = new TextBox()
            {
                Width = Const.panelTextBoxWidth - 50,
                Location = new Point(25, textBoxPanel.Location.Y + 100),
            };

            //new code
            if (oldTitle == "")
                text.TextChanged += Text_TextChanged;
            else
            {
                text.TextChanged += Text_TextChanged;
                text.Text = oldTitle;
            }
            //text.TextChanged += Text_TextChanged;
            Label noteLineLabel = new Label()
            {
                Text = "Tiêu đề bảng là bắt buộc",
                Width = Const.panelTextBoxWidth,
                Location = new Point(25, text.Location.Y + text.Height + 10),
            };

            Guna2Button newBtn = new Guna2Button()
            {
                Width = Const.panelTextBoxWidth - 50,
                Height = 50,
                BackColor = Color.Gray,
                Location = new Point(25, textBoxPanel.Location.Y + (textBoxPanel.Height / 3) * 2),
                Text = "Tạo Bảng Mới",
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            };
            //new code
            if (oldTitle == "")
                newBtn.Click += CreateTable_Click;
            else
            {

                newBtn.Click += CreateTable_Click;
                newBtn.PerformClick();
            }
            //newBtn.Click += CreateTable_Click;
            textBoxPanel.Controls.Add(headLabel);
            textBoxPanel.Controls.Add(titleLabel);
            textBoxPanel.Controls.Add(text);
            textBoxPanel.Controls.Add(noteLineLabel);
            textBoxPanel.Controls.Add(newBtn);
        }

        private void Text_TextChanged(object sender, EventArgs e)
        {
            // Lưu nội dung của TextBox vào biến
            textBoxContent = ((TextBox)sender).Text;
        }
        
        private void CreateTable_Click(object sender, EventArgs e)
        {
            if (textBoxContent == "")
            {
                MessageBox.Show("Tiêu đề không được để trống");
            }
            else
            {
                Guna2Button newButton = new Guna2Button()
                {
                    Width = myTableButton.Width,
                    Height = myTableButton.Height,
                    BorderRadius = 0,
                    BackColor = Color.Transparent,
                    Text = textBoxContent,
                    Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                    Tag = Buttons.Count
                };
                if (Buttons.Count == 0)
                {
                    newButton.Location = new Point(myTableButton.Location.X, myTableButton.Location.Y + myTableButton.Height);
                }
                else
                {
                    int lastIndex = Buttons.Count - 1;
                    newButton.Location = new Point(Buttons[lastIndex].Location.X, Buttons[lastIndex].Location.Y + Buttons[lastIndex].Height);

                    //Hide the last table
                    for (int i = 0; i < ListOfTable.Count; i++)
                    {
                        ListOfTable[i].PnlAllList.Visible = false;
                    }
                }
                TableSpace.Controls.Add(newButton);
                Guna2Button optBtn = new Guna2Button()
                {
                    Width = 25,
                    Height = 20,
                    BorderRadius = 10,
                    Location = new Point(newButton.Location.X + newButton.Width - 30, newButton.Location.Y + 10),
                    BackColor = Color.Transparent,
                    BackgroundImage = Image.FromFile(Application.StartupPath + "/Resources/....png"),
                    BackgroundImageLayout = ImageLayout.Stretch,
                    Tag = newButton.Tag
                };
                newButton.Click += NewButton_Click;
                optBtn.Click += OptBtn_Click;
                TableSpace.Controls.Add(optBtn);
                optBtn.BringToFront();
                WorkSpace.Controls.Remove(textBoxPanel);

                getTable(sender, e);

                textBoxContent = "";
                Buttons.Add(newButton); //Nhet button Table vua tao vao trong mang de quan ly
                OptBtn.Add(optBtn);
            }
        }
        */

        public void CreateFunctionTable(Guna2Button btn)
        {
            if (btn != null)
            {
                //Color
                Guna2PictureBox colorTable = new Guna2PictureBox()
                {
                    Width = 20,
                    Height = 20,
                    Location = new Point(btn.Location.X + 10, btn.Location.Y + 10),
                    //FillColor = taobang.tempColorTable,
                    Visible = false,
                    Tag = btn.Tag
                };
                TableSpace.Controls.Add(colorTable);
                colorTable.BringToFront();

                //Mark Button
                Guna2Button markBtn = new Guna2Button()
                {
                    Width = 20,
                    Height = 15,
                    BorderRadius = 10,
                    Location = new Point(btn.Location.X + btn.Width - 25, btn.Location.Y + 10),
                    BackColor = Color.Transparent,
                    BackgroundImage = Image.FromFile(Application.StartupPath + "/Resources/star_empty.png"),
                    BackgroundImageLayout = ImageLayout.Stretch,
                    FillColor = Color.Transparent,
                    Visible = false,
                    Tag = btn.Tag
                };
                TableSpace.Controls.Add(markBtn);
                markBtn.BringToFront();
                markBtn.Click += MarkBtn_Click;


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
                    Tag = btn.Tag
                };
                optBtn.Click += OptBtn_Click;
                TableSpace.Controls.Add(optBtn);
                optBtn.BringToFront();
                OptBtn.Add(optBtn);
                MarkBtns.Add(markBtn);
                ColorOfTables.Add(colorTable);

                getTable();
            }
        }

        // Hàm so sánh hai hình ảnh
        private bool AreImagesEqual(Image image1, Image image2)
        {
            if (image1 == null || image2 == null)
            {
                return false;
            }

            using (MemoryStream memoryStream1 = new MemoryStream(), memoryStream2 = new MemoryStream())
            {
                image1.Save(memoryStream1, ImageFormat.Png);
                image2.Save(memoryStream2, ImageFormat.Png);

                return memoryStream1.ToArray().SequenceEqual(memoryStream2.ToArray());
            }
        }

        public void NewButton_Click(object sender, EventArgs e)
        {
            Guna2Button btn = (Guna2Button)sender;
            for (int i = 0; i < Buttons.Count; i++) 
            {
                if (OptBtn[i].Visible == true)
                {
                    OptBtn[i].Visible = false;
                    MarkBtns[i].Visible = false;
                    ColorOfTables[i].Visible = false;
                }
            }    
            OptBtn[Convert.ToInt32(btn.Tag)].Visible = true;
            MarkBtns[Convert.ToInt32(btn.Tag)].Visible = true;
            ColorOfTables[Convert.ToInt32(btn.Tag)].Visible = true;

            int index = buttons.IndexOf(btn);
            if (index >= 0)
            {
                //MessageBox.Show("New btn");
                for (int i = 0; i < ListOfTable.Count; i++)
                {
                    //MessageBox.Show($"Off {i}");
                    if (i != index)
                    {
                        ListOfTable[i].PnlAllList.Visible = false;

                        for (int j = 0; j < listOfTable.Count; j++)
                        {
                            for (int k = 0; k < listOfTable[j].ListOfDanhSach.Count; k++)
                            {
                                for (int l = 0; l < listOfTable[j].ListOfDanhSach[k].ListOfBtn.Count; l++)
                                {
                                    if (l < listOfTable[j].ListOfDanhSach[k].ListOfData.Count)
                                    {
                                        listOfTable[j].ListOfDanhSach[k].ListOfBtn[l].Text =
                                        listOfTable[j].ListOfDanhSach[k].ListOfData[l].Title;
                                    }
                                }
                            }
                        }
                    }
                }
                ListOfTable[index].PnlAllList.Visible = true;
            }


        }

        public void MarkBtn_Click(object sender, EventArgs e)
        {
            Guna2Button btn = (Guna2Button)sender;
            Image expectedImage = Image.FromFile(Application.StartupPath + "/Resources/star_filled.png");
            if (AreImagesEqual(btn.BackgroundImage, expectedImage))
            {
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "/Resources/star_empty.png");
            }
            else
                btn.BackgroundImage = Image.FromFile(Application.StartupPath + "/Resources/star_filled.png");
            
        }

        public void OptBtn_Click(object sender, EventArgs e)
        {
            Guna2Button btn = (Guna2Button)sender;
            if (DeleteTableButton == null)
            {
                DeleteTableButton = new Guna2GradientButton()
                {
                    Text = "Delete Table",
                    Location = new Point(btn.Location.X, btn.Location.Y + btn.Height + 55),
                    BorderRadius = 10,
                    BackColor = Color.Transparent,
                    Tag = btn.Tag,
                };
                MainForm.Controls.Add(DeleteTableButton);
                DeleteTableButton.BringToFront();
                DeleteTableButton.Click += DeleteTableButton_Click;
            }
            else
            {
                MainForm.Controls.Remove(DeleteTableButton);
                DeleteTableButton = null;
            }

        }

        private void Update_Location_After_Remove(int index)
        {
            if (index == Buttons.Count - 1)
            {
                Buttons.RemoveAt(Convert.ToInt32(index));
                OptBtn.RemoveAt(Convert.ToInt32(index));
                MarkBtns.RemoveAt(Convert.ToInt32(index));
                ColorOfTables.RemoveAt(Convert.ToInt32(index));
            }    
            else 
            {
                for (int i = Buttons.Count - 1; i > index; i--)
                {
                    Buttons[i].Location = Buttons[i - 1].Location;
                    Buttons[i].Tag = Buttons[i - 1].Tag;
                    OptBtn[i].Location = OptBtn[i - 1].Location;
                    OptBtn[i].Tag = OptBtn[i - 1].Tag;
                    MarkBtns[i].Location = MarkBtns[i - 1].Location;
                    MarkBtns[i].Tag = MarkBtns[i - 1].Tag;
                    ColorOfTables[i].Location = ColorOfTables[i - 1].Location;
                    ColorOfTables[i].Tag = ColorOfTables[i - 1].Tag;
                }
                Buttons.RemoveAt(Convert.ToInt32(index));
                OptBtn.RemoveAt(Convert.ToInt32(index));
                MarkBtns.RemoveAt(Convert.ToInt32(index));
                ColorOfTables.RemoveAt(Convert.ToInt32(index));
            }
        }

        private void DeleteTableButton_Click(object sender, EventArgs e)
        {         
            Guna2GradientButton btn = (Guna2GradientButton)sender;
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa bảng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                TableSpace.Controls.Remove(Buttons[Convert.ToInt32(btn.Tag)]);
                TableSpace.Controls.Remove(OptBtn[Convert.ToInt32(btn.Tag)]);
                TableSpace.Controls.Remove(MarkBtns[Convert.ToInt32(btn.Tag)]);
                TableSpace.Controls.Remove(ColorOfTables[Convert.ToInt32(btn.Tag)]);
                Update_Location_After_Remove(Convert.ToInt32(btn.Tag));
            }
            MainForm.Controls.Remove(btn);
        }

        private void getTable()
        {
            InsideTable Table1 = new InsideTable(this.mainForm, this.workSpace, this.tableSpace);
            Table1.TableName = textBoxContent;
            ListOfTable.Add(Table1);
        }

        private void reSizeTableSpace(bool expand)
        {
            int resize_length = 0;
            if (expand)
            {
                resize_length = 160;
            }
            else
            {
                resize_length = -160;
            }
            foreach (var table in ListOfTable)
            {
                if (table.PnlAllList.Visible)
                {
                    for (int index = 0; index < table.ListOfDanhSach.Count; index++)
                    {
                        table.ListOfDanhSach[index].Location = new Point(table.ListOfDanhSach[index].Location.X + resize_length,
                        table.ListOfDanhSach[index].Location.Y);
                    }
                    table.BtnAddNewList.Location = new Point(table.BtnAddNewList.Location.X + resize_length,
                             table.BtnAddNewList.Location.Y);
                    table.BtnSaveTable.Location = new Point(table.BtnSaveTable.Location.X + resize_length,
                             table.BtnSaveTable.Location.Y);
                }
            }
        }

        void retrieveData(object sender, EventArgs e)
        {
            string tablePath = Application.StartupPath + "/table.txt";
            string dataPath = Application.StartupPath + "/data.txt";
            // Read data from the file
            using (StreamReader reader = new StreamReader(tablePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    int slashIndex = line.IndexOf('/');
                    string tableName = "";
                    int numberOfList = 0;
                    List<string> listOfListName = new List<string>();
                    List<int> listOfNumberOfCard = new List<int>();
                    int count = 0;
                    int moc = 0;
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] == '/')
                        {
                            if (count == 0)
                            {
                                tableName = line.Substring(0, i);
                                count += 1;
                                moc = i + 1;
                            }
                            else if (count == 1)
                            {
                                if (i - moc != 0)
                                {
                                    numberOfList = int.Parse(line.Substring(moc, i - moc));
                                }
                                count += 1;
                                moc = i + 1;
                            }
                            else if (count == 2)
                            {
                                int moc2 = moc;
                                for (int j = moc; j < line.Length; j++)
                                {
                                    if (line[j] == '/')
                                    {
                                        if (j - moc2 != 0)
                                        { listOfListName.Add(line.Substring(moc2, j - moc2)); }
                                        moc = j + 1;
                                        break;
                                    }
                                    else
                                    {
                                        if (line[j] == '_')
                                        {
                                            if (j - moc2 != 0)
                                            { listOfListName.Add(line.Substring(moc2, j - moc2)); }
                                            moc2 = j + 1;
                                        }
                                    }
                                }
                                count += 1;
                            }
                            else if (count == 3)
                            {
                                int moc2 = moc;
                                for (int j = moc; j < line.Length; j++)
                                {
                                    if (line[j] == '/')
                                    {
                                        if (j - moc2 != 0)
                                        { listOfNumberOfCard.Add(int.Parse(line.Substring(moc2, j - moc2))); }
                                        moc = j + 1;
                                        break;
                                    }
                                    else
                                    {
                                        if (line[j] == '_')
                                        {
                                            if (j - moc2 != 0)
                                            { listOfNumberOfCard.Add(int.Parse(line.Substring(moc2, j - moc2))); }
                                            moc2 = j + 1;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (tableName == "")
                        return;
                    Guna2Button newButton = new Guna2Button()
                    {
                        Width = myTableButton.Width,
                        Height = myTableButton.Height,
                        BorderRadius = 0,
                        BackColor = Color.Transparent,
                        Text = $"{tableName}",
                        Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                        Tag = Buttons.Count
                    };
                    if (Buttons.Count == 0)
                    {
                        newButton.Location = new Point(myTableButton.Location.X, myTableButton.Location.Y + myTableButton.Height);
                    }
                    else
                    {
                        int lastIndex = Buttons.Count - 1;
                        newButton.Location = new Point(Buttons[lastIndex].Location.X, Buttons[lastIndex].Location.Y + Buttons[lastIndex].Height);
                    }
                    TableSpace.Controls.Add(newButton);
                    newButton.Click += NewButton_Click;
                    Buttons.Add(newButton); //Nhet button Table vua tao vao trong mang de quan ly

                    CreateFunctionTable(newButton);

                    InsideTable Table1 = ListOfTable[buttons.Count - 1];
                    for (int i = 0; i < numberOfList - 1; i++)
                    {
                        Table1.BtnAddNewList.PerformClick();
                    }
                    for (int i = 0; i < listOfListName.Count; i++)
                    {
                        if (Table1.ListOfDanhSach[i].TxtBxTitle.Text != null && i < listOfListName.Count)
                        {
                            Table1.ListOfDanhSach[i].TxtBxTitle.Text = listOfListName[i];
                        }
                    }
                    
                    for (int y = 0; y < listOfNumberOfCard.Count; y += 1)
                    {
                        for (int i = 0; i < listOfNumberOfCard[y] - 1; i++)
                        {
                            Table1.ListOfDanhSach[y].BtnAddCard.PerformClick();
                        }
                    }
                    
                }
            }

            using (StreamReader reader = new StreamReader(dataPath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    int indexTable = -1;
                    int indexDanhSach = -1;
                    int indexCard = -1;
                    string title = "";
                    string describeContent = "";
                    string activityContent = "";
                    string label = "";
                    List<string> listOfMember = new List<string>();
                    List<string> listOfToDoList = new List<string>();
                    int count = 0;
                    int moc = 0;
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] == '/')
                        {
                            if (count == 0)
                            {
                                indexTable = int.Parse(line.Substring(0, i));
                                count += 1;
                                moc = i + 1;
                            }
                            else if (count == 1)
                            {
                                if (i - moc != 0)
                                {
                                    indexDanhSach = int.Parse(line.Substring(moc, i - moc));
                                }
                                count += 1;
                                moc = i + 1;
                            }
                            else if (count == 2)
                            {
                                if (i - moc != 0)
                                {
                                    indexCard = int.Parse(line.Substring(moc, i - moc));
                                }
                                count += 1;
                                moc = i + 1;
                            }
                            else if (count == 3)
                            {
                                if (i - moc != 0)
                                {
                                    title = line.Substring(moc, i - moc);
                                }
                                count += 1;
                                moc = i + 1;
                            }
                            else if (count == 4)
                            {
                                if (i - moc != 0)
                                {
                                    describeContent = line.Substring(moc, i - moc);
                                }
                                count += 1;
                                moc = i + 1;
                            }
                            else if (count == 5)
                            {
                                if (i - moc != 0)
                                {
                                    activityContent = line.Substring(moc, i - moc);
                                }
                                count += 1;
                                moc = i + 1;
                            }
                            else if (count == 6)
                            {
                                int moc2 = moc;
                                for (int j = moc; j < line.Length; j++)
                                {
                                    if (line[j] == '/')
                                    {
                                        if (j - moc2 != 0)
                                        {
                                            listOfMember.Add(line.Substring(moc2, j - moc2));
                                        }
                                        moc = j + 1;
                                        break;
                                    }
                                    else
                                    {
                                        if (line[j] == '_')
                                        {
                                            if (j - moc2 != 0)
                                            {
                                                listOfMember.Add(line.Substring(moc2, j - moc2));
                                            }
                                            moc2 = j + 1;
                                        }
                                    }
                                }
                                count += 1;
                            }
                            else if (count == 7)
                            {
                                if (i - moc != 0)
                                {
                                    label = line.Substring(moc, i - moc);
                                }
                                count += 1;
                                moc = i + 1;
                            }
                            else if (count == 8)
                            {
                                int moc2 = moc;
                                for (int j = moc; j < line.Length; j++)
                                {
                                    if (line[j] == '/')
                                    {
                                        if (j - moc2 != 0)
                                        {
                                            listOfToDoList.Add(line.Substring(moc2, j - moc2));
                                        }
                                        moc = j + 1;
                                        break;
                                    }
                                    else
                                    {
                                        if (line[j] == '_')
                                        {
                                            if (j - moc2 != 0)
                                            {
                                                listOfToDoList.Add(line.Substring(moc2, j - moc2));
                                            }
                                            moc2 = j + 1;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (title == "")
                        return;
                    ListOfTable[indexTable].ListOfDanhSach[indexDanhSach].ListOfData[indexCard] = new AppData(title, describeContent,
                        activityContent, label, listOfMember, listOfToDoList);
                }
            }
            
        }

    }
}
