using RubiksCube;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 魔方公式转换
{
    public partial class RubiksCubeForm : Form
    {
        public RubiksCubeForm()
        {
            InitializeComponent();
        }

        private void RubiksCubeForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ParseFormula();
            }
        }

        private void ParseFormula()
        {
            string str = Input.Text;
            if (str != null)
            {
                Formula formula = new Formula(str);
                List<string> formulaString = formula._formula;
                try
                {
                    Bitmap pad = new Bitmap(5, 50);
                    Bitmap tem;
                    foreach (string elm in formulaString)
                    {
                        tem = GetPicture(elm);
                        tem = Image.ImageHelper.ReshapeImage(tem, 50, 50);
                        pad = Image.ImageHelper.SpliceImage(pad, tem, true);
                    }
                    ShowFormula(pad);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private Bitmap GetPicture(string name)
        {
            string path;
            if (name[0] <= 90) //大写字母
            {
                path = System.Environment.CurrentDirectory + "\\formula_res\\" + name + ".png";
            }
            else
            {
                path = System.Environment.CurrentDirectory + "\\formula_res\\" + "lower_case\\" + name + ".png";
            }
            return new Bitmap(path);
        }

        private void ShowFormula(Bitmap pic)
        {
            if (this.Width < pic.Width + 20 || Output.Width < pic.Width)
            {
                this.Width = pic.Width + 20;
                Output.Width = pic.Width;
            }
            Graphics g2 = Graphics.FromHwnd(Output.Handle);
            g2.Clear(this.BackColor);
            //显示
            g2.DrawImage(pic, 0, 0);
        }
    
    }
}
