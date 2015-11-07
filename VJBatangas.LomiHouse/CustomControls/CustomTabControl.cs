using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace VJBatangas.LomiHouse
{
    public class CustomTabControl: TabControl
    {
        private Point lastClickPosition;
        private ContextMenuStrip CMS;

        public CustomTabControl()
        {
            CMS = GetCMS();
        }

        private ContextMenuStrip GetCMS()
        {
            ContextMenuStrip _cms = new ContextMenuStrip();
            _cms.Items.Add("Close", null, new EventHandler(Item_Clicked));

            return _cms;
        }

        private void Item_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < this.TabCount; i++)
            {
                Rectangle rec = this.GetTabRect(i);
                //if (rec.Contains(this.PointToClient(Cursor.Position)))
                if(rec.Contains(this.PointToClient(lastClickPosition)))
                {
                    this.TabPages.RemoveAt(i);
                }
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                lastClickPosition = Cursor.Position;
                CMS.Show(Cursor.Position);
            }
        }
    }
}
