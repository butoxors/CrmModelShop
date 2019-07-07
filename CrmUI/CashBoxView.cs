using CrmBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUI
{
    public class CashBoxView
    {
        CashDesk CashDesk;

        public Label LeaveCustomersCount { get; set; }
        public Label CashDeskName { get; set; }
        public NumericUpDown Price { get; set; }
        public ProgressBar QueueLength { get; set; }

        public CashBoxView(CashDesk cashDesk, int number, int x, int y)
        {
            this.CashDesk = cashDesk;

            CashDeskName = new Label();
            Price = new NumericUpDown();
            QueueLength = new ProgressBar();
            LeaveCustomersCount = new Label();

            CashDeskName.AutoSize = true;
            CashDeskName.Location = new System.Drawing.Point(x, y);
            CashDeskName.Name = "label1" + number.ToString();
            CashDeskName.Size = new System.Drawing.Size(35, 13);
            CashDeskName.TabIndex = number;
            CashDeskName.Text = cashDesk.ToString();
            // 
            // numericUpDown1
            // 
            Price.Location = new System.Drawing.Point(x + 60, y - 3);
            Price.Name = "numericUpDown" + number;
            Price.Size = new System.Drawing.Size(120, 20);
            Price.TabIndex = number;
            Price.Maximum = 1000000000000;

            QueueLength.Location = new System.Drawing.Point(x + 200, y);
            QueueLength.Name = "progressBar" + number;
            QueueLength.Size = new System.Drawing.Size(133, 25);
            QueueLength.TabIndex = number;
            QueueLength.Value = 1;
            QueueLength.Maximum = cashDesk.MaxQueueLength;

            LeaveCustomersCount.AutoSize = true;
            LeaveCustomersCount.Location = new System.Drawing.Point(x + 400, y);
            LeaveCustomersCount.Name = "label2" + number.ToString();
            LeaveCustomersCount.Size = new System.Drawing.Size(35, 13);
            LeaveCustomersCount.TabIndex = number;
            LeaveCustomersCount.Text = "";

            cashDesk.CheckClosed += CashDesk_CheckClosed;
        }

        private void CashDesk_CheckClosed(object sender, Check e)
        {
            Price.Invoke((Action) delegate {
                Price.Value += e.Price;
                QueueLength.Value = CashDesk.Count;
                LeaveCustomersCount.Text = CashDesk.ExitCustomer.ToString();
            });
        }
    }
}
