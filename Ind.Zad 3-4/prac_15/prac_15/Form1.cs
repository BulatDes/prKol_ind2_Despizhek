using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prac_15
{
    public partial class Form1 : Form
    {
        private Subject_Index index;
        private readonly string LoadFile = "file1.txt";
        public Form1()
        {
            InitializeComponent();
            index = new Subject_Index();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(wordBox.Text) || string.IsNullOrEmpty(strBox.Text))
            { MessageBox.Show("Заполните все поля.", "Внимание!"); return; }

            string word = wordBox.Text.Trim();
            string[] pageNumberStrings = strBox.Text.Split(new char[] { ',', ';' },
                StringSplitOptions.RemoveEmptyEntries);
            int[] pageNumbers = new int[pageNumberStrings.Length];
            for (int i = 0; i < pageNumberStrings.Length; i++)
            {
                if (!int.TryParse(pageNumberStrings[i], out pageNumbers[i]))
                {
                    MessageBox.Show("Неверная строка чисел. Пример заполнения: '1, 2, 3, 4'.", "Ошибка.");
                    return;
                }
            }

            int prevNumber = int.MinValue;
            foreach (int number in pageNumbers)
            {
                if (number <= prevNumber)
                {
                    MessageBox.Show("Числа должны быть по возрастанию и не повторяться.", "Ошибка.");
                    return;
                }
                prevNumber = number;
            }

            if (pageNumbers.Length > 10)
            {
                MessageBox.Show("Количество номеров страниц, относящихся к одному слову," +
                                                           " — от одного до десяти.", "Ошибка."); return;
            }

            index.AddEntry(word, pageNumbers);
            wordBox.Text = "";
            strBox.Text = "";
            index.FillListBox(listBox1);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string word = wordBox.Text.Trim();
            if (string.IsNullOrEmpty(word))
            {
                MessageBox.Show("Для удаления слова, впишите его в поле 'Слово'.",
                "Внимание!");
            }
            else
            if (!index.Contains(word))
            {
                MessageBox.Show($"Слово '{word}' не обнаружено в указателе. Его не удастся удалить.",
                "Внимание!");
            }
            else
            {
                index.RemoveEntry(word);
                index.FillListBox(listBox1);
                MessageBox.Show($"Слово '{word}' успешно удалено.",
               "Внимание!");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string word = wordBox.Text.Trim();
            if (index.Contains(word))
            {
                string pageNumbersString = string.Join(", ", index.GetPageNumbers(word));
                MessageBox.Show($"Слово '{word}' имеется. Оно встречается на страницах: {pageNumbersString}",
                    "Результат поиска.");
            }
            else MessageBox.Show($"Слово '{word}' не имеется.", "Результат поиска.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            index.LoadFromFile(LoadFile);
            index.FillListBox(listBox1);
            MessageBox.Show($"Слова были загружены из файла: '{LoadFile}'.", "Внимание!");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            index.SaveToFile(LoadFile);
            index.FillListBox(listBox1);
        }
    }
}
