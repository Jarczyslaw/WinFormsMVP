using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms.Controls
{
    public class UsersGridContextMenu : ContextMenu
    {
        public Action<object> EditItem;
        public Action<object> DeleteItem;

        private DataGridView parentGrid;

        private object selectedItem;

        public UsersGridContextMenu(DataGridView dataGridView)
        {
            parentGrid = dataGridView;

            MenuItems.Add(new MenuItem("Edit", (s, e) =>
            {
                if (selectedItem == null)
                    return;
                EditItem?.Invoke(selectedItem);
            }));
            MenuItems.Add(new MenuItem("Delete", (s, e) =>
            {
                if (selectedItem == null)
                    return;
                DeleteItem?.Invoke(selectedItem);
            }));
        }

        public void Show(Point mousePosition)
        {
            int rowIndex = parentGrid.HitTest(mousePosition.X, mousePosition.Y).RowIndex;
            if (rowIndex >= 0)
            {
                parentGrid.Rows[rowIndex].Selected = true;
                selectedItem = parentGrid.Rows[rowIndex].DataBoundItem;
                Show(parentGrid, mousePosition);
            }
            else
                parentGrid.ClearSelection();
        }
    }
}
