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
        public Action AddUser { get; set; }
        public Action EditUser { get; set; }

        public int UserId
        {
            get { return int.Parse(tbUserId.Text); }
            set { tbUserId.Text = value.ToString(); }
        }

        public string UserName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }

        public int UserAge
        {
            get { return (int)nudAge.Value; }
            set { nudAge.Value = value; }
        }

        public EditForm()
        {
            InitializeComponent();
        }

        public void OpenView()
        {
            ShowDialog();
        }

        public void CloseView()
        {
            Close();
        }

        private bool ValidateData()
        {
            if (UserAge <= 0)
                return false;

            if (string.IsNullOrEmpty(UserName))
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

            if (UserId <= 0)
                AddUser?.Invoke();
            else
                EditUser?.Invoke();
            Close();
        }
    }
}
