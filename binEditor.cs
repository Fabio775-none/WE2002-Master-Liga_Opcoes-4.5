using System;
using System.IO;
using System.Windows.Forms;

namespace WE2002_Master_Liga_Opcoes_4._5_by_fja
{
    internal class binEditor
    {
        string patch;
        const long offsetMoney = 3266428;
        const long offsetContractions = 3266540;
        const long offsetFourDigitFlag = 3305232;
        const byte fourDigitFlag = 0x04;

        public string loadFile() 
        {
            var opl = new OpenFileDialog();
            opl.Filter = "WE2002(*.bin)|*.bin";

            if (opl.ShowDialog() == DialogResult.OK) 
            {
               return patch = opl.FileName;
            }
            else 
            {
                MessageBox.Show("Selecione o arquivo","Mensagem",MessageBoxButtons.OK,MessageBoxIcon.Exclamation); 
                return "";
            }

        }
        public (ushort money, byte contracts) readFile()
        {
            if (string.IsNullOrEmpty(patch) || !File.Exists(patch))
                return (0, 0);

            using (var fs = new FileStream(patch, FileMode.Open, FileAccess.Read))
            {
                fs.Seek(offsetMoney, SeekOrigin.Begin);
                byte[] buffer = new byte[2];

                if (fs.Read(buffer, 0, 2) != 2)
                    throw new IOException();

                ushort money = BitConverter.ToUInt16(buffer, 0);

                fs.Seek(offsetContractions, SeekOrigin.Begin);
                byte contracts = (byte)fs.ReadByte();

                return (money, contracts);
            }
        }

        public void writeMoney(ushort money) 
        {
            if (string.IsNullOrEmpty(patch) || !File.Exists(patch))
                return;

            using (FileStream fs2 = new FileStream(patch, FileMode.Open, FileAccess.Write))
            {
                fs2.Seek(offsetMoney, SeekOrigin.Begin);
                byte[] buffer = BitConverter.GetBytes(money);
                fs2.Write(buffer,0,buffer.Length);

                fs2.Seek(offsetFourDigitFlag, SeekOrigin.Begin);
                fs2.WriteByte(fourDigitFlag);
            }
        }

        public void writeContractions(byte contractions)
        {
            if (string.IsNullOrEmpty(patch) || !File.Exists(patch))
                return;
            using (FileStream fs2 = new FileStream(patch, FileMode.Open, FileAccess.Write))
            {
                fs2.Seek(offsetContractions, SeekOrigin.Begin);
                fs2.WriteByte(contractions);
            }
        }

        public void restoreFile() 
        {
            if (string.IsNullOrEmpty(patch) || !File.Exists(patch))
                return;
            using (FileStream fs3 = new FileStream(patch, FileMode.Open, FileAccess.Write)) 
            {
                byte[] defaultMoney = { 0x14, 0x00 };
                fs3.Seek(offsetMoney, SeekOrigin.Begin);
                fs3.Write(defaultMoney, 0, defaultMoney.Length);

                const byte defaultContracts = 0x02;
                fs3.Seek(offsetContractions, SeekOrigin.Begin);
                fs3.WriteByte(defaultContracts);

                const byte originalDigitFlag = 0x03;
                fs3.Seek(offsetFourDigitFlag, SeekOrigin.Begin);
                fs3.WriteByte(originalDigitFlag);

            }
        }

      
    }
}
