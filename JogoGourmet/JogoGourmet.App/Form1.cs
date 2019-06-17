using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoGourmet.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Business.FoodNavigator navigator = new Business.FoodNavigator();
            PlayGame(navigator);
        }

        void PlayGame(Business.FoodNavigator navigator)
        {           
            var node = navigator.StartNodes();
            MessageBox.Show("Pense em um prato que gosta");
            while (true)
            {
                if (MessageBox.Show($"O prato que você pensou é: {node.Food} ?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (node.Yes == null)
                    {
                        MessageBox.Show("Acertei de novo");
                        PlayGame(navigator);
                        return;
                    }
                    node = navigator.GetNextYes();
                }
                else
                {
                    var no = navigator.GetNextNo();
                    if (no == null)
                    {
                        var food = "";
                        while (food == "")
                        {
                            food =
                                Microsoft.VisualBasic.Interaction.InputBox("Qual prato você pensou?", "Question", "");
                        }

                        var category = "";
                        while (category == "")
                        {
                            category =
                                Microsoft.VisualBasic.Interaction.InputBox($"{food} é ______ mas {node.Food} não.", "Complete", "");
                        }

                        navigator.AddFood(food, category, node);
                        PlayGame(navigator);
                        return;
                    }
                    else
                    {
                        node = no;
                    }
                }
            }
        }
    }
}
