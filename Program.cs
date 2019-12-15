using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
// Пространство имен для работы с базами данных Access
using System.Data.OleDb;
using System.Diagnostics;
using System.Xml;

namespace ManyForms
{
    class FormWithManyControls : Form
    {
        TreeView treeView1;
        Panel panel1; 
        //Panel panel2;
            OleDbDataAdapter dataAdapter;

        // Метод-конструктор нашего класса
        public FormWithManyControls()
        {
            // Указываем размеры и заголовок окна

            this.Text = "Final Project in C# class!";
            this.Height = 770; this.Width = 1500;

            // Добавляем элемент TreeView в качестве своеобразного меню

            treeView1 = new TreeView();
            treeView1.BackColor = Color.White;
            treeView1.Dock = DockStyle.Left;
            treeView1.AfterSelect +=
            new System.Windows.Forms.TreeViewEventHandler(treeView1_AfterSelect);

            TreeNode tn = new TreeNode("Elements");
            tn.Expand();

            tn.Nodes.Add(new TreeNode("[Clear]"));
            tn.Nodes.Add(new TreeNode("TabControl"));
            tn.Nodes.Add(new TreeNode("DataGridViewXML"));
            tn.Nodes.Add(new TreeNode("DataGridViewDataBase"));
            tn.Nodes.Add(new TreeNode("MainMenu"));

            treeView1.Nodes.Add(tn);
            treeView1.Width=200;

            this.Controls.Add(treeView1);

            // Добавляем панель для размещения остальных элементов управления

            panel1 = new Panel();
            panel1.Dock = DockStyle.Left;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Width = this.Width - treeView1.Width;

            this.Controls.Add(panel1);

            /*
            panel2 = new Panel();
            panel2.Dock = DockStyle.Left;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Width = this.Width - treeView1.Width-panel1.Width;

            this.Controls.Add(panel2);

            */
        }

        // Обработчик событий, срабатывающий при выборе одного из узлов дерева TreeView
        private void treeView1_AfterSelect
        (object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            // Выполнение соответствующего действия при выборе любого из узлов

            if (e.Node.Text == "[Clear]")
            {
                // Удаляем с панели все элементы управления
                panel1.Controls.Clear();
            }


            else if (e.Node.Text == "DataGridViewXML")
            {

                // Добавляем на панель таблицу, заполненную данными из файла xml
            
            DataSet dataSet1 = new DataSet("Example DataSet");
            dataSet1.ReadXml("../../images/marks.xml");

            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.Width = 300;
            dataGridView1.Height = 300;
            dataGridView1.Location = new Point(30, 350);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = dataSet1;
            dataGridView1.DataMember = "subjects";

            panel1.Controls.Add(dataGridView1);
            }

            
            else if (e.Node.Text == "DataGridViewDatabase")
            {

             // Добавляем элемент DataGridView на форму
/*
             DataGridView dataGridView2 = new DataGridView();
            // dataGridView2 = new DataGridView();
             dataGridView2.Width = 300;
             dataGridView2.Height = 250;
             dataGridView2.Location = new Point(350, 350);
             dataGridView2.AutoResizeColumns();
            //dataGridView2.DataSource = dataSet2;
            //dataGridView2.DataMember = "subjects!!!!!";

            panel1.Controls.Add(dataGridView2);

             // Добавляем командную кнопку
             Button buttonSave = new Button();
             buttonSave.Location = new Point(100, 320);
             buttonSave.Width = 220;
             buttonSave.Text = "Сохранить изменения в базе данных!";
            // buttonSave.Click += 
            // new System.EventHandler(ButtonSave_Click);
             buttonSave.Parent = this;

             panel1.Controls.Add(buttonSave);

             // Формируем запрос к базе данных - 
             //запрашиваем информацию о планетах
             string sql = "SELECT * FROM PLANET";
             string connectionString;
             // DataTable сохраняет данные в памяти как таблицу
             DataTable dataTable = new DataTable();

                //Вариант 2
          // Подключаемся к базе данных Access 2016
        connectionString = "Provider=Microsoft.JET.OLEDB.4.0;" +
            // база данных должна быть где угодно, кроме диска С. Так права на запись ограничены 
            @"Data Source=e:\Planets.mdb";

        OleDbConnection connection = new OleDbConnection(connectionString);

        //Открываем соединение
        connection.Open();

        //Создаем команду 
        //SqlCommand sqlCommand = new SqlCommand(sql, connection);
        OleDbCommand command = new OleDbCommand(sql, connection);
 

        //Создаем адаптер
        // DataAdapter - посредник между базой данных и DataSet
        //dataAdapter = new SqlDataAdapter(sqlCommand);

        dataAdapter = new OleDbDataAdapter(command);

        //Создаем построитель команд
        //Для адаптера становится доступной команда Update 
        //SqlCommandBuilder commandBuilder =
        //    new SqlCommandBuilder(dataAdapter);

        OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(dataAdapter);
        
        // Данные из адаптера поступают в DataTable 
        dataAdapter.Fill(dataTable);
        // Связываем данные с элементом DataGridView
        dataGridView2.DataSource = dataTable;
        // Очистка
        connection.Close();

*/
            DataSet dataSet2 = new DataSet("Example DataSet");
            dataSet2.ReadXml("../../images/marks.xml");


             DataGridView dataGridView2 = new DataGridView();
             dataGridView2.Width = 300;
             dataGridView2.Height = 250;
             dataGridView2.Location = new Point(400, 400);
             //dataGridView2.DataMember = "Table";
            // dataGridView2.AutoResizeColumns();   


            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = dataSet2;
            dataGridView2.DataMember = "subject";

             panel1.Controls.Add(dataGridView2);


            }
            

            else if (e.Node.Text == "TabControl")
            {
                // Добавляем на панель элемент управления вкладками
                // и наполняем каждую вкладку содержимым

                TabControl tabControl1 = new TabControl();
                tabControl1.Location = new Point(30, 30);
                tabControl1.Size = new Size(300, 280);


                TabPage tabPage1 = new TabPage("Elena");
                PictureBox pictureBox1 = new PictureBox();
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = new Bitmap("../../images/Backscreen.jpg");

                pictureBox1.Size = new Size(300, 200);
                tabPage1.Controls.Add(pictureBox1);
                Label labelV = new Label();
                labelV.Top = 200;
                labelV.Size = new Size(300, 50);
                    labelV.Text = "This is Elena's backscreen! She likes the space theme and bake muffins!";
                tabPage1.Controls.Add(labelV);
                tabControl1.TabPages.Add(tabPage1);

                TabPage tabPage2 = new TabPage("Elena's muffins");
                PictureBox pictureBox2 = new PictureBox();
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.Image = new Bitmap("../../images/IMG-5680.jpg");
                pictureBox2.Size = new Size(300, 200);
                tabPage2.Controls.Add(pictureBox2);
                Label labelС = new Label();
                labelС.Top = 200;
                labelС.Size = new Size(300, 50);
                labelС.Text = "This is Elena's muffins! They're so delisious!";
                tabPage2.Controls.Add(labelС);
                tabControl1.TabPages.Add(tabPage2);

                TabPage tabPage3 = new TabPage("Home");
                PictureBox pictureBox3 = new PictureBox();
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox3.Image = new Bitmap("../../images/IMG-5617.jpg");
                pictureBox3.Size = new Size(300, 200);
                tabPage3.Controls.Add(pictureBox3);
                Label labelT = new Label();
                labelT.Top = 200;
                labelT.Size = new Size(300, 50);
                labelT.Text = "This is Elena's thoughts about home in 2019!";
                tabPage3.Controls.Add(labelT);
                tabControl1.TabPages.Add(tabPage3);

                panel1.Controls.Add(tabControl1);
            }

            else if (e.Node.Text == "MainMenu")
            {
                // Добавляем классическое «меню» (появляется в верхней части окна)
                MainMenu mainMenu1 = new MainMenu();

                MenuItem menuItem1 = new MenuItem("File");
                menuItem1.MenuItems.Add("Exit",
                new EventHandler(mainMenu1_Exit_Select));
                mainMenu1.MenuItems.Add(menuItem1);

                this.Menu = mainMenu1;

                MessageBox.Show("File tab added on the top", "For you information");
            }

        }




        // Обработчик события, срабатывающий при выборе в меню пункта "exit"
        void mainMenu1_Exit_Select(object sender, System.EventArgs e)
        {
            if (
            MessageBox.Show("Would you like to quit?",
            "Exit confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            == DialogResult.Yes
           )
            {
                this.Dispose();
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormWithManyControls
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FormWithManyControls";
            this.Load += new System.EventHandler(this.FormWithManyControls_Load);
            this.ResumeLayout(false);

        }

        private void FormWithManyControls_Load(object sender, EventArgs e)
        {

        }

        static void Main()
        {
            // // Создаем и запускаем форму
            Application.Run(new FormWithManyControls());
        }

        //  <LangVersion>8.0</LangVersion> add in 7_ManyForms.cspoj after <TargetFrameworkVersion>v4.7.2</TargetFrameworkVersion>
    
        /*
            void ButtonSave_Click(object sender, System.EventArgs args)
    {
        try
        {
            dataAdapter.Update((DataTable)dataGridView2.DataSource);
            MessageBox.Show("Изменения в базе данных выполнены!",
                "Уведомление о результатах", MessageBoxButtons.OK);
        }
        catch(Exception)
        {
            MessageBox.Show("Изменения в базе данных выполнить не удалось!",
                            "Уведомление о результатах", MessageBoxButtons.OK);
        }
    }
    */
    }
    
}
