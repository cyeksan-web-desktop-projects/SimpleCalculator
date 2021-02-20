using System;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class frmCalculator : Form
    {
        int Val1, Val2, Result;
        string op = "";
        Boolean eqButtonClicked = false;
        Boolean opButtonClicked = false;
        public frmCalculator()
        {
            InitializeComponent();
        }

        //max size of entered number should be 19, since it is long type.
        private void DoNumClick(object sender, EventArgs e)
        {
            Button btnNum = sender as Button;
            
            if (eqButtonClicked) {
                ResetAfterEqualClick();
            }

            if (!opButtonClicked) {
                UpdateTextbox(btnNum);
            } 
            else
            {
                txtValue.Text = "0";
                UpdateTextbox(btnNum);
            }
            
        }
        

        private void DoOperatorClick(object sender, EventArgs e)
        {
            Button btnOp = sender as Button;
            op = btnOp.Text;
            Val1 = int.Parse(txtValue.Text);
            opButtonClicked = true;
        }

        private void BtnEqual_Click(object sender, EventArgs e)
        {
            Val2 = int.Parse(txtValue.Text);
            if (op == "+")
            {
                Result = Val1 + Val2;    
            }
            else if (op == "-")
            {
                Result = Val1 - Val2;
            }
            else if (op == "*")
            {
                Result = Val1 * Val2;
            }
            else if (op == "/")
            {
                Result = Val1 / Val2;
            }

            txtValue.Text = Result.ToString();
            ResetValues();
            eqButtonClicked = true;

        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtValue.Text = "0";
            ResetValues();
        } 

        private void UpdateTextbox(Button btnNum)
        {
            long btnVal = long.Parse(btnNum.Text);
            long txtboxVal = long.Parse(txtValue.Text);
            txtboxVal = 10 * txtboxVal + btnVal;
            txtValue.Text = txtboxVal.ToString();
        }

        private void ResetAfterEqualClick()
        {
            txtValue.Text = "0";
            eqButtonClicked = false;
            opButtonClicked = false;
        }

        private void ResetValues()
        {
            Val1 = 0;
            Val2 = 0;
            op = "";
        }

    }
}
