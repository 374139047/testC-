using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chat.bll;

namespace Chat
{
    public partial class Form1 : Form
    {
        private Client ClientObj = new Client();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Sendbutton.Enabled = false;  
            this.AcceptButton = Sendbutton;
           
        }

        private void Clientbutton_Click(object sender, EventArgs e)
        {
            string nickName = tbName.Text;
            string ip = tbIP.Text;
            string port = tbPort.Text;

            if (string.IsNullOrEmpty(nickName) || string.IsNullOrEmpty(ip) || string.IsNullOrEmpty(port))
            {
                MessageBox.Show("Please ID, IP completed");
                return;
            }
            try
            {
                ClientObj.SendConnection(ip, Convert.ToInt32(port)); 
                ClientObj.receiveEvent += new Client.receiveDelegate(ClientObj_receiveEvent);
                ClientObj.Send(tbName.Text + "  Landed successfully!");

                Sendbutton.Enabled = true;
                Clientbutton.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while connecting：" + ex.Message);
                return;
                
            }
        }

        private void ClientObj_receiveEvent(string receiveData)
        {
            try
            {
                if (this.InvokeRequired) 
                {
                    Client.receiveDelegate update = new Client.
                        receiveDelegate(ClientObj_receiveEvent); 
                    this.Invoke(update, new object[] {receiveData});
                }
                else
                {
                    listBox1.Items.Add(receiveData);  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Receive data error：" + ex.Message);
                return;
            }
        }

        private void Sendbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    return;
                }
                ClientObj.Send(tbName.Text +"  say:   " + textBox1.Text);  
                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sending data error" + ex.Message);
                return;
            }
        }

      
        private void Stopbutton_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Add("Already left the chat room!");
                try
                {
                ClientObj.Send(tbName.Text + "   ( Leave the chat room )");
                ClientObj.StopConnection();
                textBox1.Clear();

                Stopbutton.Enabled = false;
                Sendbutton.Enabled = false;
                Clientbutton.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while connecting：" + ex.Message);
                    return;

                }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
            
        }

    }
}
