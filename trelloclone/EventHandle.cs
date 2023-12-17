using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        private List<RJButton> buttons;
        private List<RJButton> otpBtn;
        public RJButton myTableButton;
        private Panel textBoxPanel;
        //MenuSpace
        private Timer sideBarTimer;
        private FlowLayoutPanel sideBar;
        private RJButton iconButton;
        bool sidebarExpand = true;

        private List<InsideTable> listOfTableSpace = new List<InsideTable>();

        public Panel WorkSpace { get => workSpace; set => workSpace = value; }
        public RJButton MyTableButton { get => myTableButton; set => myTableButton = value; }
        public List<RJButton> Buttons { get => buttons; set => buttons = value; }
        public Panel TableSpace { get => tableSpace; set => tableSpace = value; }
        public List<RJButton> OtpBtn { get => otpBtn; set => otpBtn = value; }
        public Form1 MainForm { get => mainForm; set => mainForm = value; }

        public EventHandlers(Form1 form, Panel WorkSpace, Panel TableSpace, RJButton myTableButton, Timer timer, FlowLayoutPanel sideBar, RJButton iconButton)
        {
            this.MainForm = form;
            //WorkSpace
            this.workSpace = WorkSpace;
            //TableSpace
            this.tableSpace = TableSpace;
            this.myTableButton = myTableButton;
            this.myTableButton.Click += myTableButton_Click;
            Buttons = new List<RJButton>();
            OtpBtn = new List<RJButton>();
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
            RJButton btn = sender as RJButton;
            TaoBang taoBang = new TaoBang(this)
            {
                Location = new Point(TableSpace.Location.X + TableSpace.Width, TableSpace.Location.Y + 100),
            };
            taoBang.ShowDialog();
        }

        public void OptBtn_Click(object sender, EventArgs e)
        {
            RJButton btn = (RJButton)sender;
            int index = buttons.IndexOf(btn);
            MessageBox.Show($"Opt button: {index}");
            Guna2GradientButton deleteTableButton = new Guna2GradientButton()
            {
                Text = "Delete Table",
                Location = new Point(btn.Location.X, btn.Location.Y + btn.Height + 55),
                BorderRadius = 10,
                BackColor = Color.Transparent,
                Tag = btn.Tag,
            };
            MainForm.Controls.Add(deleteTableButton);
            deleteTableButton.BringToFront();
            deleteTableButton.Click += DeleteTableButton_Click;
        }

        private void Update_Location_After_Remove(int index)
        {
            if (index == Buttons.Count - 1)
            {
                Buttons.RemoveAt(Convert.ToInt32(index));
                OtpBtn.RemoveAt(Convert.ToInt32(index));
            }    
            else 
            {
                for (int i = Buttons.Count - 1; i > index; i--)
                {
                    Buttons[i].Location = Buttons[i - 1].Location;
                    Buttons[i].Tag = Buttons[i - 1].Tag;
                    OtpBtn[i].Location = OtpBtn[i - 1].Location;
                    OtpBtn[i].Tag = OtpBtn[i - 1].Tag;
                }
                Buttons.RemoveAt(Convert.ToInt32(index));
                OtpBtn.RemoveAt(Convert.ToInt32(index));
            }
        }

        private void DeleteTableButton_Click(object sender, EventArgs e)
        {         
            Guna2GradientButton btn = (Guna2GradientButton)sender;
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa bảng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                TableSpace.Controls.Remove(Buttons[Convert.ToInt32(btn.Tag)]);
                TableSpace.Controls.Remove(OtpBtn[Convert.ToInt32(btn.Tag)]);
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
