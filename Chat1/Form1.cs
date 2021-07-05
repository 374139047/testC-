using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chat1.bll;

namespace Chat1
{
    public partial class Form1 : Form
    {
        Server serverObj = new Server();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Sendbutton.Enabled = false;
            try
            {
                serverObj.ConnectEvent += serverObj_ConnectEnent;
                serverObj.ReceiveEvent += serverObj_ReceiveEnent;
                serverObj.Listen(Convert.ToInt32(textBox2.Text)); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load：" + ex.Message);
            }
        }

        private void serverObj_ConnectEnent()
        {
            try
            {
                if (InvokeRequired)
                {
                    Server.ConnectDelegate update = serverObj_ConnectEnent;

                    Invoke(update);
                }
                else
                {
                    listBox1.Items.Add("Connection succeeded");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Handling connection event method error：" + ex.Message);
            }
        }

        private void serverObj_ReceiveEnent(string message)
        {
            try
            {
                if (InvokeRequired)
                {
                    Server.ReceiveDelegate update = serverObj_ReceiveEnent;
                
                    Invoke(update, new object[] {message});
                }
                else
                {
                    listBox1.Items.Add(message);

                    serverObj.Send(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Handling event method errors：" + ex.Message);
            }
        }


     

        private void server_receiveEvents(string ReceiveDatas)
        {
            try
            {
                if (this.InvokeRequired) 
                {
                    Server.receiveDelegates update = new Server.
                        receiveDelegates(server_receiveEvents); 
                    this.Invoke(update, new object[] { ReceiveDatas });
                }
                else
                {
                    listBox1.Items.Add(ReceiveDatas); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Receive data error：" + ex.Message);
                return;
            }
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close();
            
        }

        private void Sendbutton_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    return;
                }
                serverObj.Send(TbName.Text + "  say:   " + textBox1.Text);  
                listBox1.Items.Add(TbName.Text + "  say:  " + textBox1.Text);


                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sending data error" + ex.Message);
                return;
            }
        }

        private void Gobutton_Click(object sender, EventArgs e)
        {
            string nickName = TbName.Text;

            if (string.IsNullOrEmpty(nickName))
            {
                MessageBox.Show("Please ID completed");
                return;
            }
            try
            {
                listBox1.Items.Add(TbName.Text + "  Landed successfully!");
                serverObj.receiveEvent += new Server.receiveDelegates(server_receiveEvents);
                serverObj.Send(TbName.Text + "  Landed successfully!！");

                Sendbutton.Enabled = true;
                Gobutton.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while connecting：" + ex.Message);
                return;

            }
        }
    }
}
