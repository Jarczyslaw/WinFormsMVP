using Core.ViewsAbstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.Models;
using Forms.Controls;

namespace Windows.Forms
{
    public partial class MainForm : Form, IMainView
    {
        public Action<IEditView> AddAction { get; set; }
        public Action<IEditView, User> EditAction { get; set; }
        public Action<User> DeleteAction { get; set; }

        private UsersGridContextMenu contextMenu;

        public MainForm()
        {
            InitializeComponent();
            contextMenu = new UsersGridContextMenu(dgvUsers);
            RegisterContextMenuEvents();
            dgvUsers.DataBindingComplete += DgvUsers_DataBindingComplete;
        }

        private void RegisterContextMenuEvents()
        {
            contextMenu.DeleteItem = (o) =>
            {
                var result = MessageBox.Show("Do you really want to remove selected item?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var user = o as User;
                    DeleteAction?.Invoke(user);
                }
            };
            contextMenu.EditItem = (o) =>
            {
                var user = o as User;
                EditUser(user);
            };
        }

        private void EditUser(User user)
        {
            IEditView editView = new EditForm();
            EditAction?.Invoke(editView, user);
        }

        public void Open()
        {
            Application.Run(this);
        }

        public void UpdateUsers(IList<User> users)
        {
            var source = new BindingSource();
            source.DataSource = users;
            dgvUsers.DataSource = source;
        }

        private void dgvUsers_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenu.Show(new Point(e.X, e.Y));
        }

        private void DgvUsers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvUsers.ClearSelection();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            IEditView editView = new EditForm();
            AddAction?.Invoke(editView);
        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var user = dgvUsers.Rows[e.RowIndex].DataBoundItem as User;
                EditUser(user);
            }
        }
    }
}
