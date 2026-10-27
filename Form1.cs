using System;
using System.Windows.Forms;


namespace WE2002_Master_Liga_Opcoes_4._5_by_fja
{
    public partial class Form1 : Form
    {
        readonly binEditor operador = new binEditor(); 

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          string pathFile =  operador.loadFile();
            textBox1.Text = pathFile;

            if (pathFile != "")
            {
                enabledControls(true);
                loadValues();
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new AboutBox1();
            form2.ShowDialog();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            operador.writeMoney(Convert.ToUInt16(comboBox1.Text));
            messageFile("Dinheiro adicionado com sucesso");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            operador.writeContractions(Convert.ToByte(comboBox2.Text));
            messageFile("Contratações adicionadas com sucesso");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            operador.restoreFile();
            messageFile("Valores restaurados com sucesso");

            loadValues();
        }

        void loadCombos() 
        { 
           for(int i = 0; i <= 9999; i++) 
            {
                comboBox1.Items.Add(i);

                if(i <= 255) 
                {
                    comboBox2.Items.Add(i);
                }
                
            }
        
        }

        void loadValues() 
        {
            var data = operador.readFile();
            comboBox1.Text = data.money.ToString();
            comboBox2.Text = data.contracts.ToString();
        }

        void enabledControls(bool on) 
        {
            button2.Enabled = 
            button3.Enabled = 
            button4.Enabled = 
            comboBox1.Enabled = 
            comboBox2.Enabled = on;
        }

        void messageFile(string mensagem)
        {
            MessageBox.Show(mensagem, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            enabledControls(false);
            comboBox1.DropDownStyle =
            comboBox2.DropDownStyle =
            ComboBoxStyle.DropDownList;
            loadCombos();
        }


    }
}
