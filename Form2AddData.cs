using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using WindowsFormsApp1.FolderModel;

namespace Foto_EF_Prog
{
    public partial class Form2AddData : Form
    {
        public Form2AddData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Переходим на форму 1
            Form1Show form1 = new Form1Show();
            form1.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Проверяем поля на наличие данных
            if (String.IsNullOrWhiteSpace(textBox1.Text) || String.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Не задан файл с фотографией!");
                return;
            }

            // Создаём экземпляр модели для работы с БД
            Model1 model = new Model1();
            // Создаем новый объект класса Student
            Student student = new Student();
            // Задаем свойства нового объекта
            student.Name = textBox1.Text;
            student.Group_ = textBox2.Text;

            // Создаем массив байтов из свойства Image PictureBox при помощи класса ImageConverter и метода ConvertTo()
            byte[] bImg = (byte[])new ImageConverter().ConvertTo(pictureBox1.Image, typeof(byte[]));
            // Присваиваем свойству изображение в формате byte[]
            student.Photo = bImg;

            // Добавляем новый объект к коллекции
            model.Student.Add(student);

            try
            {
                // Сохраняем данные
                model.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MessageBox.Show("Сохранено");

            // Присваиваем полям пустые значения
            textBox1.Text = "";
            textBox2.Text = "";
            pictureBox1.Image = null;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog(); // Класс который открывает окно для работы с файлами
            ofd.Title = "Выберите фото сотрудника"; // Задаём заголовок окна
            ofd.Filter = "Файлы JPG, PNG|*.jpg;*.png|Все файлы (*.*)|*.*"; // Задаём фильтр для отображаемых файлов

            if (ofd.ShowDialog() == DialogResult.OK) // Если нажали OK
                pictureBox1.Image = Image.FromFile(ofd.FileName); // Показываем выбранный файл в pictureBox1
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2AddData_Load(object sender, EventArgs e)
        {

        }
    }
}
