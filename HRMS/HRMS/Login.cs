using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRMS
{
    public partial class Login : Form
    {
        string id = "";
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {//登录
            if (login())
            {
                textBox1.Visible = false;
                textBox2.Visible = false;
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                if (checkBox1.Checked == true)
                {
                    Tenant tenant = new Tenant(id);
                    tenant.Show();
                    this.Hide();
                }
                if (checkBox2.Checked == true)
                {
                    Owner owner = new Owner(id);
                    owner.Show();
                    this.Hide();
                }
            }
        }

        private bool login()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || (checkBox1.Checked == false && checkBox2.Checked == false))
            {
                MessageBox.Show("请输入完整信息!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (checkBox1.Checked == true && checkBox2.Checked == true)
            {
                MessageBox.Show("只能选择一个身份!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (checkBox1.Checked == true)
            {//租赁者
                string sql = "select * from tenant where tid ='" + textBox1.Text + "' and tpassword = '" + textBox2.Text + "'";
                Dao dao = new Dao();
                IDataReader dr = dao.read(sql);
                
                if (dr.Read())
                {
                    id = dr["tid"].ToString();
                    return true;
                }
                else
                {
                    MessageBox.Show("信息有误！请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (checkBox2.Checked == true)
            {//房主
                
                string sql = "select * from owner where oid ='" + textBox1.Text + "' and opassword = '" + textBox2.Text + "'";
                Dao dao = new Dao();
                IDataReader dr = dao.read(sql);
                
                if (dr.Read())
                {
                    id = dr["oid"].ToString();
                    return true;
                }
                else
                {
                    MessageBox.Show("信息有误！请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
        }


        private bool checkroot()
        {
            if (textBox1.Text == "root" && textBox2.Text == "123")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if(true)
            {
                Root root = new Root();
                root.Show();
                this.Hide();
            }
        }
    }
}
