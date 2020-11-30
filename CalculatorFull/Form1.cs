using System;
using System.Windows.Forms;

namespace CalculatorFull
{
    public partial class Form1 : Form
    {
        string operate = "";
        bool deci=true,oper=true,no=false,s1=true,s2=false;
        double value1 = 0, value2 = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
       

        private void Button_Click(object sender, EventArgs e)
        {
            if (!oper) lblInputDisplay.Text = "";
            Button obj = (Button)sender;
            
            string s = obj.Text;
            if (lblInputDisplay.Text == "0" && obj.Text!=".") lblInputDisplay.Text = "";
            if (!deci && s==".") s = "";
            lblInputDisplay.Text += s;
            if (obj.Text == ".") deci = false;
            oper = true;
        }

        private void Button_Operator(object sender, EventArgs e)
        {
            Button obj = (Button)sender;
            if(lblInputDisplay.Text!="0")lblOutputDisplay.Text += lblInputDisplay.Text;
            deci = true;
            oper = false;
            if (no)
            {
                string[] ar = lblOutputDisplay.Text.Split(operate[1]);
                value1 = Double.Parse(ar[0]);
                value2 = Double.Parse(ar[1]);
                
                lblOutputDisplay.Text = "";
                switch (operate[1])
                {
                    case '+':
                        lblOutputDisplay.Text += (value1 + value2).ToString();
                        break;
                    case '-':
                        lblOutputDisplay.Text += (value1 - value2).ToString();
                        break;
                    case 'x':
                        lblOutputDisplay.Text += (value1 * value2).ToString();
                        break;
                    case '/':
                        lblOutputDisplay.Text += (value1 / value2).ToString();
                        break;
                    default:
                        lblOutputDisplay.Text = "INVALID!";
                        break;
                }
                lblInputDisplay.Text = lblOutputDisplay.Text;
            }
            if (obj.Text == ".") operate = " / ";
            else operate = " " + obj.Text + " ";
            if (lblInputDisplay.Text != "0") lblOutputDisplay.Text += operate;
            no = true;
        }

        private void Button19_Click(object sender, EventArgs e)
        {
            lblInputDisplay.Text = "0";
            deci = true;
        }

        private void ButtonSquare_Click(object sender, EventArgs e)
        {
            value1 = Double.Parse(lblInputDisplay.Text);
            lblInputDisplay.Text = (value1 * value1).ToString();
        }

        private void ButtonPower_Click(object sender, EventArgs e)
        {
            lblInputDisplay.Text += "^";
            operate = " ^ ";
        }

        private void ButtonSQRT_Click(object sender, EventArgs e)
        {
            lblInputDisplay.Text = (Math.Sqrt(Double.Parse(lblInputDisplay.Text))).ToString();
        }

        private void BtnLog_Click(object sender, EventArgs e)
        {
            if (s1) lblInputDisplay.Text = Math.Log10(Double.Parse(lblInputDisplay.Text)).ToString();
            else lblInputDisplay.Text = Math.Log(Double.Parse(lblInputDisplay.Text)).ToString();
        }

        private void Button7_Click(object sender, EventArgs e)
        {

        }

        private void BtnSin_Click(object sender, EventArgs e)
        {
            if(s1)lblInputDisplay.Text = (Math.Sin((Double.Parse(lblInputDisplay.Text)*(Math.PI/180)))).ToString();
            else lblInputDisplay.Text = (Math.Asin(Double.Parse(lblInputDisplay.Text))*180/Math.PI).ToString();
        }

        private void BtnCos_Click(object sender, EventArgs e)
        {
            if(s1)lblInputDisplay.Text = (Math.Cos((Double.Parse(lblInputDisplay.Text) * (Math.PI / 180)))).ToString();
            else lblInputDisplay.Text = (Math.Acos(Double.Parse(lblInputDisplay.Text)) * 180 / Math.PI).ToString();
        }

        private void BtnTan_Click(object sender, EventArgs e)
        {
            if(s1)lblInputDisplay.Text = (Math.Tan((Double.Parse(lblInputDisplay.Text) * (Math.PI / 180)))).ToString();
            else lblInputDisplay.Text = (Math.Atan(Double.Parse(lblInputDisplay.Text)) * 180 / Math.PI).ToString();
        }

        private void ButtonPlusMinus_Click(object sender, EventArgs e)
        {
            lblInputDisplay.Text = (-1*Double.Parse(lblInputDisplay.Text)).ToString();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            lblInputDisplay.Text = Math.Pow(10, Double.Parse(lblInputDisplay.Text)).ToString();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            lblInputDisplay.Text = (Math.E*Double.Parse(lblInputDisplay.Text)).ToString();
        }

        private void Button17_Click(object sender, EventArgs e)
        {

            if (lblInputDisplay.Text.Length >1 && lblInputDisplay.Text!="0") lblInputDisplay.Text = lblInputDisplay.Text.Remove(lblInputDisplay.Text.Length - 1, 1);
            else lblInputDisplay.Text = "0";
        }

        private void ButtonPI_Click(object sender, EventArgs e)
        {
            if(lblInputDisplay.Text=="0")lblInputDisplay.Text = (Math.PI).ToString();
            else lblInputDisplay.Text = ((Double.Parse(lblInputDisplay.Text))*(Math.PI)).ToString();
        }

        private void ButtonFactorial_Click(object sender, EventArgs e)
        {
            value1 = Double.Parse(lblInputDisplay.Text);
            long a = 1;
            for (int i = 1; i <= value1; i++) a *= i;
            lblInputDisplay.Text = a.ToString();
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            lblInputDisplay.Text = "0";
            lblOutputDisplay.Text = "";
            deci = true;
        }

        private void ButtonEquale_Click(object sender, EventArgs e)
        {
            if(operate=="")
            {
                lblInputDisplay.Text = lblInputDisplay.Text;
                return;
            }
            string[] ar = (lblOutputDisplay.Text + lblInputDisplay.Text).Split(operate[1]);
            value1 = Double.Parse(ar[0]);
            value2 = Double.Parse(ar[1]);
            lblInputDisplay.Text = "";
            switch(operate[1])
            {
                case '+':
                    lblInputDisplay.Text += (value1 + value2).ToString();
                    break;
                case '-':
                    lblInputDisplay.Text += (value1 - value2).ToString();
                    break;
                case '/':
                    lblInputDisplay.Text += (value1 / value2).ToString();
                    break;
                case 'x':
                    lblInputDisplay.Text += (value1 * value2).ToString();
                    break;
                case '^':
                    lblInputDisplay.Text += (Math.Pow(value1,value2)).ToString();
                    break;
                default:
                    break;
            }
            lblOutputDisplay.Text = "";
            operate = "";
            no = false;
           // Form abc=new Form();
            //abc.ShowDialog("");
            Form2 f = new Form2(lblInputDisplay.Text);
            f.Show();
        }

        private void ButtonInverse_Click(object sender, EventArgs e)
        {
            bool b=s1;
            s1 = s2;
            s2 = b;
            if (s1) btnSin.Text = "sin";
            else btnSin.Text = "sin-1";
            if (s1) btnCos.Text = "cos";
            else btnCos.Text = "cos-1";
            if (s1) btnTan.Text = "tan";
            else btnTan.Text = "tan-1";
            if (s1) btnLog.Text = "log";
            else btnLog.Text = "ln";
            if (s1) btn10x.BringToFront();
            else btnex.BringToFront();
        }
    }
}
