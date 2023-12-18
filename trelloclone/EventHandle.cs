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

namespace trelloclone
{
    public class EventHandlers
    {
        private Form1 mainForm;

        //WorkSpace
        private Panel workSpace;
        //TableSpace
        private Panel tableSpace;
        private List<Guna2Button> buttons;
        private List<Guna2Button> optBtn;
        private List<Guna2Button> markBtns;
        public Guna2Button myTableButton;
        private Guna2GradientButton deleteTableButton;
        private bool dltIsExist = false;
        private List<Guna2PictureBox> colorOfTables;
        //MenuSpace
        private Timer sideBarTimer;
        private FlowLayoutPanel sideBar;
        private Guna2Button iconButton;
        bool sidebarExpand = true;

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

        public EventHandlers(Form1 form, Panel WorkSpace, Panel TableSpace, Guna2Button myTableButton, Timer timer, FlowLayoutPanel sideBar, Guna2Button iconButton)
        {
            this.MainForm = form;
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
            TaoBang taoBang = new TaoBang(this);
            taoBang.Location = new Point(300, 100);
            taoBang.ShowDialog();
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
            if (dltIsExist == false)
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
                dltIsExist = true;
            }
            else
            {
                MainForm.Controls.Remove(DeleteTableButton);
                dltIsExist = false;
            }

        }

        private void Update_Location_After_Remove(int index)
        {
            if (index == Buttons.Count - 1)
            {
                Buttons.RemoveAt(Convert.ToInt32(index));
                OptBtn.RemoveAt(Convert.ToInt32(index));
                MarkBtns.RemoveAt(Convert.ToInt32(index));
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
                }
                Buttons.RemoveAt(Convert.ToInt32(index));
                OptBtn.RemoveAt(Convert.ToInt32(index));
                MarkBtns.RemoveAt(Convert.ToInt32(index));
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
                Update_Location_After_Remove(Convert.ToInt32(btn.Tag));
            }
            MainForm.Controls.Remove(btn);
        }
        private InsideTable getTable(object sender, EventArgs e)
        {
            InsideTable Table1 = new InsideTable(this.MainForm, this.workSpace, this.tableSpace);
                

            return Table1;
        }
    }
}
