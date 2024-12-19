using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Windows.Forms;
using BrewBreeze.Tabs;
using BrewBreeze.Forms;

namespace BrewBreeze
{
    public partial class AdminPanel : FormShadow
    {
        private string userRole;
        private string userName;

        private IconButton currentBtn;
        private IconButton updateBtn;

        private Panel btnLeftBorder;

        private Rectangle normalBounds;
        private bool isMaximized = false;
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private Panel tabsContainer;
        private Dashboard dashboard;
        private Products products;
        private AddOns addons;
        private PointOfSale pos;
        private Transactions transactions;
        private Sales sales;
        private ManageUsers users;

        private struct RGBColors
        {
            public static Color activeTabs = Color.White;
            public static Color activeSubMenu = Color.White;
        }

        public AdminPanel(string role, string name)
        {
            InitializeComponent();
            userRole = role;
            userName = name;

            //Initial size
            Rectangle screenBounds = Screen.PrimaryScreen.Bounds;
            int initialWidth = Math.Min(1200, screenBounds.Width);
            int initialHeight = Math.Min(675, screenBounds.Height);
            this.Size = new Size(initialWidth, initialHeight);
            this.MinimumSize = new Size(800, 450);

            btnRestore.Visible = false;

            tabsContainer = new Panel
            {
                Location = new Point(200, 35),
                Size = new Size(1000, 640),
            };

            this.Controls.Add(tabsContainer);
            tabsContainer.BackColor = Color.WhiteSmoke;
            tabsContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            dashboard = new Dashboard();
            products = new Products();
            addons = new AddOns();
            pos = new PointOfSale(userName);
            transactions = new Transactions();
            sales = new Sales();
            users = new ManageUsers();

            tabsContainer.Controls.Add(dashboard);
            tabsContainer.Controls.Add(products);
            tabsContainer.Controls.Add(addons);
            tabsContainer.Controls.Add(pos);
            tabsContainer.Controls.Add(transactions);
            tabsContainer.Controls.Add(sales);
            tabsContainer.Controls.Add(users);

            btnLeftBorder = new Panel
            {
                Size = new Size(5, 50)
            };
            SideBar.Controls.Add(btnLeftBorder);

            if(userRole == "Administrator")
            {
                ActivateButton(btnDashboard, RGBColors.activeTabs);
                ShowControl(dashboard);
            } else
            {
                ActivateButton(btnPointOfSale, RGBColors.activeTabs);
                ShowControl(pos);
            }

            panelSubMenu.Visible = false;



            products.OnDataChanged += RefreshPointOfSale;
            pos.OnDataChanged += RefreshProducts;
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            txtName.Text = userName;
            txtRole.Text = userRole;

            if (userRole == "Cashier")
            {
                btnDashboard.Visible = false;
                btnAddOns.Visible = false;
                btnProducts.Visible = false;
                btnSales.Visible = false;
                btnSettings.Visible = false;
                btnTransactions.Visible = false;
            } else
            {
                btnPointOfSale.Visible = false;
            }
        }

        private void RefreshProducts()
        {
            products.RefreshData();
        }
        private void RefreshPointOfSale()
        {
            pos.RefreshData();
        }

        private void ShowControl(Control control)
        {
            foreach (Control c in tabsContainer.Controls)
            {
                if (c is UserControl)
                {
                    c.Visible = false;
                }
            }

            control.Visible = true;
            control.Dock = DockStyle.Fill;
            control.BringToFront();
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(173, 110, 47);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                currentBtn.Padding = new Padding(0, 0, 10, 0);
                // Left border button
                btnLeftBorder.BackColor = color;
                btnLeftBorder.Location = new Point(0, currentBtn.Location.Y);
                btnLeftBorder.Visible = true;
                btnLeftBorder.BringToFront();
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(244, 202, 159);
                currentBtn.ForeColor = Color.FromArgb(64, 64, 64);
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.FromArgb(64, 64, 64);
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                currentBtn.Padding = new Padding(10, 0, 0, 0);
            }
        }

        private void ActiveSettingsSubMenu(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                InactiveSettingsSubMenu();
                updateBtn = (IconButton)senderBtn;
                updateBtn.BackColor = Color.FromArgb(249, 162, 87);
                updateBtn.ForeColor = Color.White;
            }
        }
        private void InactiveSettingsSubMenu()
        {
            if (updateBtn != null)
            {
                updateBtn.BackColor = Color.FromArgb(173, 110, 47);
                updateBtn.ForeColor = RGBColors.activeSubMenu;
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            panelSubMenu.Visible = false;
            InactiveSettingsSubMenu();
            ActivateButton(sender, RGBColors.activeTabs);
            ShowControl(dashboard);
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            panelSubMenu.Visible = false;
            InactiveSettingsSubMenu();
            ActivateButton(sender, RGBColors.activeTabs);
            ShowControl(products);
        }

        private void btnAddOns_Click(object sender, EventArgs e)
        {
            panelSubMenu.Visible = false;
            InactiveSettingsSubMenu();
            ActivateButton(sender, RGBColors.activeTabs);
            ShowControl(addons);
        }

        private void btnPointOfSale_Click(object sender, EventArgs e)
        {
            panelSubMenu.Visible = false;
            InactiveSettingsSubMenu();
            ActivateButton(sender, RGBColors.activeTabs);
            ShowControl(pos);
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            panelSubMenu.Visible = false;
            InactiveSettingsSubMenu();
            ActivateButton(sender, RGBColors.activeTabs);
            ShowControl(transactions);
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            panelSubMenu.Visible = false;
            InactiveSettingsSubMenu();
            ActivateButton(sender, RGBColors.activeTabs);
            ShowControl(sales);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.activeSubMenu);
            panelSubMenu.Visible = true;
        }

        private void btnManageAccount_Click(object sender, EventArgs e)
        {
            ActiveSettingsSubMenu(sender, RGBColors.activeSubMenu);
            UpdateAccount update = new UpdateAccount();
            update.ShowDialog();
            
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            ActiveSettingsSubMenu(sender, RGBColors.activeSubMenu);
            ShowControl(users);
        }

        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging && e.Button == MouseButtons.Left)
            {
                if (isMaximized)
                {
                    this.WindowState = FormWindowState.Normal;
                    this.Bounds = normalBounds;
                    isMaximized = false;
                    btnRestore.Visible = false;
                    btnMaximize.Visible = true;
                }

                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void panelHeader_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (!isMaximized)
            {
                normalBounds = this.Bounds;
                this.WindowState = FormWindowState.Normal;
                this.Bounds = Screen.FromControl(this).WorkingArea;
                isMaximized = true;
            }

            btnMaximize.Visible = false;
            btnRestore.Visible = true;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (isMaximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.Bounds = normalBounds;
                isMaximized = false;

            }

            btnRestore.Visible = false;
            btnMaximize.Visible = true;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            string message;
            string caption = "Log Out";

            message = "Are you sure you want to log out?";

            DialogResult localResult = MessageBox.Show(
                message,
                caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (localResult == DialogResult.Yes)
            {

                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
            else
            {
                return;
            }
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
