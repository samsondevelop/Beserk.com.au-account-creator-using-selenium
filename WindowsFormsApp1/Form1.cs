using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] characters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "r", "2", "1", "2", "4", "7", "9"};

        
        Random rnd = new Random();
        string Generate(int input)
        {
            //key 1 = name 2 = email 3 = password
            int length = 0;
            switch (input)
            {
                case 1:
                    length = 5;
                    break;
                    case 2:
                    length = 6;
                    break;
                    case 3:
                    length = 8;
                    break;

            }
            string output = String.Empty;
            for(int i = 0; i < length; i++)
            {
                output += characters[rnd.Next(characters.Length)];
            }
            if (input == 2)
            {
                output += "@gmail.com";
            }
            return output;
        }
        void DelayType(string input)
        {
            char[] stringstest = input.ToCharArray();

            foreach(char s in stringstest)
            {
                SendKeys.Send(s.ToString());
                Thread.Sleep(150);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = Generate(2);
            string pword = Generate(3);
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-notifications");
            WebDriver driver = new ChromeDriver(options);
            
            driver.Navigate().GoToUrl("https://www.beserk.com.au/account/login?checkout_url=/#!");
            bool popup = false;
            while (popup == false)
            {
                Thread.Sleep(200);
                try
                {
                    IWebElement close = driver.FindElement(By.Name("phone-number"));
                    popup = true;
                }
                catch (Exception)
                {

                }
            }
            SendKeys.Send("{ESC}");
            IWebElement register_tab = driver.FindElement(By.Id("register-tab"));
            
            register_tab.Click();
            IWebElement first_name = driver.FindElement(By.Id("first_name"));
            first_name.Click();
            


            DelayType(Generate(1));


            IWebElement last_name = driver.FindElement(By.Id("last_name"));
            SendKeys.Send("{ENTER}");
            last_name.Click();
            DelayType(Generate(1));
            
            IWebElement email1 =  driver.FindElement(By.Name("customer[email]"));
            email1.Click();
            DelayType(email);
            IWebElement password = driver.FindElement(By.Id("password"));
            password.Click();
            DelayType(pword);
            SendKeys.Send("{ENTER}");
            Thread.Sleep(8000);
            driver.Quit();
            textBox2.Text = email;
            textBox3.Text = pword;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread.Sleep(3000);
            SendKeys.Send("BALLsACK");
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            DelayType(textBox1.Text);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
