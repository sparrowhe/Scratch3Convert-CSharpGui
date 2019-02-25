using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;



namespace Scratch3Convet
{
    public partial class Scratch3Convert : Form
    {
        [DllImport("scratch3convert.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int sc3convert_convert(IntPtr file);
       
        public Scratch3Convert()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public static int convert(string file)
        {
            IntPtr arg = Marshal.StringToHGlobalAnsi(file);
            int result = sc3convert_convert(arg);
            //Marshal.FreeHGlobal(arg);
            //Marshal.ReleaseComObject(arg);
            //DisplayMemory();
            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            //string str;
            string path = string.Empty;
            var openFileDialog = new Microsoft.Win32.OpenFileDialog()
            {
                Filter = "Files (*.sb3)|*.sb3"
            };
            var result = openFileDialog.ShowDialog();
            if (result == true)
            {
                path = openFileDialog.FileName;
            }
            //Console.WriteLine(path);
            if (convert(path) == 1)
            {
                MessageBox.Show("Success!");
            }
            else
            {
                MessageBox.Show("Error!");
            }
          }
    }
}
