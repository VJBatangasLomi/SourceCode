using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VJBatangas.LomiHouse.Common
{
    public class VJUtility
    {
        public void ShowMessage(String message, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            MessageBox.Show(message, VJConstants.MESSAGEBOX_TITLE, buttons, icon);
        }
    }
}
