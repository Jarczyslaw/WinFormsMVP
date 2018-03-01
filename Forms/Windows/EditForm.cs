using Core.ViewsAbstraction;
using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows.Forms
{
    public partial class EditForm : Form, IEditView
    {
        public Action<User> SaveUser { get; set; }

        private User user;

        public EditForm()
        {
            InitializeComponent();
        }

        public void LoadUser(User user)
        {
            this.user = user;
            if (user.Id <= 0)
                tbUserId.Text = "n/a";
            else
                tbUserId.Text = user.Id.ToString();
            tbName.Text = user.Name;
            nudAge.Value = user.Age;
        }

        public void SetAsNew(bool newUser)
        {
            btnSave.Text = newUser ? "Add new" : "Save changes";
        }

        public void Open()
        {
            ShowDialog();
        }

        private bool ValidateData()
        {
            if (nudAge.Value <= 0)
                return false;

            if (string.IsNullOrEmpty(tbName.Text))
                return false;

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                MessageBox.Show("Invalid data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
            user.Age = (int)nudAge.Value;
            user.Name = tbName.Text;
            SaveUser?.Invoke(user);
            Close();
        }
    }
}
