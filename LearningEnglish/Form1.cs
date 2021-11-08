using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;

namespace LearningEnglish
{
    public partial class Form1 : Form
    {
        private int _numberOfQuestions = 0;
        private string[] _items;
        private List<Word> _words;
        private int _actualQuestionsIndex;
        private List<int> _correctlyAnsweredQuestionsIndexes;
        private string _correctAnswer;  // az aktuális kérdés helyes válasza
        private List<int> _answersIndexes;
        private List<int> _wrongAnswersIndexes;
        private bool _isEndGame  = false;
        private int _correctAnswerCount = 0;

        public Form1()
        {
            InitializeComponent();
            _words = new List<Word>();
            _correctlyAnsweredQuestionsIndexes = new List<int>();
            _answersIndexes = new List<int>();
            _wrongAnswersIndexes = new List<int>();
        }

        public void Read()
        {
            if (File.Exists("words.txt"))
            {
                try
                {
                    foreach (string item in File.ReadAllLines("words.txt", Encoding.UTF8))
                    {
                        _items = item.Split(';');
                        Word word = new Word(_items[0], _items[1]);
                        _words.Add(word);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nem sikerült az adatok beolvasása a fájlból.\n\n" + ex.Message, "Hibaüzenet",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }
            else
            {
                MessageBox.Show("Hiba történt az adatok beolvasása közben. Nem található a keresett fájl.", "Hibaüzenet",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Read();
            AskNumber();
            MakeTask();
        }

        public void AskNumber()
        {
            bool success = false;
            string answer;
            do
            {
                answer = Interaction.InputBox("Üdvözöllek a programban! \n\nHány helyes válaszig tartson a feladat? \n(maximum: " + _words.Count + ")", "Learning English", "10");
                success = int.TryParse(answer, out var number);
                _numberOfQuestions = number;
                if (_numberOfQuestions == 0 && success || answer.Length == 0)
                    Environment.Exit(0);
            } while (_numberOfQuestions < 0 || _numberOfQuestions > _words.Count || success == false);
        }

        public void MakeTask()
        {
            UncheckRadioButtons();

            if (!_isEndGame)
                _actualQuestionsIndex = RandomUniqeNumber(0, _words.Count - 1, _correctlyAnsweredQuestionsIndexes); // véletlen generáljuk a kérdés indexét
            else
            {
                _actualQuestionsIndex = _wrongAnswersIndexes[0];
                _wrongAnswersIndexes.RemoveAt(0);
            }

            // megkeressük a jó választ, és elmentjük
            _correctAnswer = _words[_actualQuestionsIndex].EngName;
            // hozzáadjuk a jó válasz indexét
            _answersIndexes.Add(_actualQuestionsIndex);
            // legeneráljuk a három rossz válasz indexét
            _answersIndexes = SelectWords(_answersIndexes, 4);
            // növekvő sorrendbe tesszük a válaszok (index) listáját
            _answersIndexes.Sort();

            lbQuestion.Text = "Fordítsd le angolra a következő szót, és válaszd ki a helyes választ!\n\n" + _words[_actualQuestionsIndex].HunName;

            DisplayAnswers();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (rB1.Checked || rB2.Checked || rB3.Checked || rB4.Checked == true)
            {
                var checkedButton = rBtnPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                if (checkedButton.Text == _correctAnswer)
                {
                    rBtnPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).ForeColor = Color.Green;
                    if (!_isEndGame)
                        _correctAnswerCount++;
                }

                else
                {
                    rBtnPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).ForeColor = Color.Red;
                    rBtnPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Text == _correctAnswer).ForeColor = Color.Green;
                    _wrongAnswersIndexes.Add(_actualQuestionsIndex);
                }
                RadioButtonsVisible();
                _correctlyAnsweredQuestionsIndexes.Add(_actualQuestionsIndex);
                btnNext.Visible = true;
                btnOk.Visible = false;
            }
            else MessageBox.Show("Először jelölj választ!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_correctlyAnsweredQuestionsIndexes.Count < _numberOfQuestions || _wrongAnswersIndexes.Count > 0)
            {
                UncheckRadioButtons();
                RadioButtonsVisible();
                DeleteColorOfRadioButtons();
                btnOk.Visible = true;
                btnNext.Visible = false;

                if (_correctlyAnsweredQuestionsIndexes.Count == _numberOfQuestions)
                    _isEndGame = true;

                MakeTask();
            }
            else
            {
                lbQuestion.Text = "Vége! \n\n" + _correctAnswerCount + " db kérdésre tudtad elsőre a választ!";
                rBtnPanel.Visible = false;
                btnNext.Visible = false;
                if (MessageBox.Show("Folytatod a tanulást?", "Kérdés", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Application.Restart();
                    Environment.Exit(0);
                }
                else Application.Exit();

            }
        }

        public int RandomUniqeNumber(int min, int max, List<int> list)
        {
            int randomUniqeNumber;
            Random r = new Random();
            do
            {
                randomUniqeNumber = r.Next(min, max + 1);
            } while (list.Contains(randomUniqeNumber));

            return randomUniqeNumber;
        }

        public List<int> SelectWords(List<int> list, int piece)
        {
            int index;
            do
            {
                index = RandomUniqeNumber(0, _words.Count - 1, list);
                list.Add(index);
            } while (list.Count != piece);
            return list;
        }

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrls => GetAll(ctrls, type)).Concat(controls).Where(c => c.GetType() == type);
        }

        public void UncheckRadioButtons()
        {
            rB1.Checked = true;
            rBtnPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Checked = false;
        }

        public void DeleteColorOfRadioButtons()
        {
            rB1.Checked = true;
            var controls = GetAll(this, typeof(RadioButton));
            foreach (Control control in controls)
            {
                RadioButton rb = (RadioButton)control;
                rb.ForeColor = Color.Black;
            }
        }

        public void DisplayAnswers()
        {
            int counter = 0;
            var controls = GetAll(this, typeof(RadioButton));
            foreach (Control control in controls)
            {
                RadioButton rb = (RadioButton)control;
                rb.Text = _words[_answersIndexes[counter]].EngName;
                counter++;
            }
            _answersIndexes.Clear();
        }

        //public void RadioButtonsSwitch()
        //{
        //    var controls = GetAll(this, typeof(RadioButton));
        //    foreach (Control control in controls)
        //    {
        //        RadioButton rb = (RadioButton)control;
        //        if (rb.Enabled)
        //            rb.Enabled = false;
        //        else rb.Enabled = true;
        //    }
        //}

        public void RadioButtonsVisible()
        {
            var controls = GetAll(this, typeof(RadioButton));
            foreach (Control control in controls)
            {
                RadioButton rb = (RadioButton)control;
                if (rBtnPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked) != null)
                {
                    if (!rb.Checked && rb.Text != _correctAnswer)
                    {
                        rb.Visible = false;
                    }
                    else rb.Visible = true;
                }
                else rb.Visible = true;
            }
        }
    }
}

