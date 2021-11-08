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
        public int NumberOfQuestions { set; get; } = 0;
        public string[] Items { set; get; }
        public List<Word> Words { set; get; }
        public int ActualQuestionsIndex { set; get; }
        public List<int> CorrectlyAnsweredQuestionsIndexes { set; get; }
        public string CorrectAnswer { set; get; } // az aktuális kérdés helyes válasza
        public List<int> AnswersIndexes { set; get; }
        public List<int> WrongAnswersIndexes { set; get; }
        public bool IsEndGame { set; get; } = false;
        public int CorrectAnswerCount { set; get; } = 0;

        public Form1()
        {
            InitializeComponent();
            Words = new List<Word>();
            CorrectlyAnsweredQuestionsIndexes = new List<int>();
            AnswersIndexes = new List<int>();
            WrongAnswersIndexes = new List<int>();
        }

        public void Read()
        {
            if (File.Exists("words.txt"))
            {
                try
                {
                    foreach (string item in File.ReadAllLines("words.txt", Encoding.UTF8))
                    {
                        Items = item.Split(';');
                        Word word = new Word(Items[0], Items[1]);
                        Words.Add(word);
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
                answer = Interaction.InputBox("Üdvözöllek a programban! \n\nHány helyes válaszig tartson a feladat? \n(maximum: " + Words.Count + ")", "Learning English", "10");
                success = int.TryParse(answer, out var number);
                NumberOfQuestions = number;
                if (NumberOfQuestions == 0 && success || answer.Length == 0)
                    Environment.Exit(0);
            } while (NumberOfQuestions < 0 || NumberOfQuestions > Words.Count || success == false);
        }

        public void MakeTask()
        {
            UncheckRadioButtons();

            if (!IsEndGame)
                ActualQuestionsIndex = RandomUniqeNumber(0, Words.Count - 1, CorrectlyAnsweredQuestionsIndexes); // véletlen generáljuk a kérdés indexét
            else
            {
                ActualQuestionsIndex = WrongAnswersIndexes[0];
                WrongAnswersIndexes.RemoveAt(0);
            }

            // megkeressük a jó választ, és elmentjük
            CorrectAnswer = Words[ActualQuestionsIndex].EngName;
            // hozzáadjuk a jó válasz indexét
            AnswersIndexes.Add(ActualQuestionsIndex);
            // legeneráljuk a három rossz válasz indexét
            AnswersIndexes = SelectWords(AnswersIndexes, 4);
            // növekvő sorrendbe tesszük a válaszok (index) listáját
            AnswersIndexes.Sort();

            lbQuestion.Text = "Fordítsd le angolra a következő szót, és válaszd ki a helyes választ!\n\n" + Words[ActualQuestionsIndex].HunName;

            DisplayAnswers();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (rB1.Checked || rB2.Checked || rB3.Checked || rB4.Checked == true)
            {
                var checkedButton = rBtnPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                if (checkedButton.Text == CorrectAnswer)
                {
                    rBtnPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).ForeColor = Color.Green;
                    if (!IsEndGame)
                        CorrectAnswerCount++;
                }

                else
                {
                    rBtnPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).ForeColor = Color.Red;
                    rBtnPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Text == CorrectAnswer).ForeColor = Color.Green;
                    WrongAnswersIndexes.Add(ActualQuestionsIndex);
                }
                RadioButtonsVisible();
                CorrectlyAnsweredQuestionsIndexes.Add(ActualQuestionsIndex);
                btnNext.Visible = true;
                btnOk.Visible = false;
            }
            else MessageBox.Show("Először jelölj választ!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CorrectlyAnsweredQuestionsIndexes.Count < NumberOfQuestions || WrongAnswersIndexes.Count > 0)
            {
                UncheckRadioButtons();
                RadioButtonsVisible();
                DeleteColorOfRadioButtons();
                btnOk.Visible = true;
                btnNext.Visible = false;

                if (CorrectlyAnsweredQuestionsIndexes.Count == NumberOfQuestions)
                    IsEndGame = true;

                MakeTask();
            }
            else
            {
                lbQuestion.Text = "Vége! \n\n" + CorrectAnswerCount + " db kérdésre tudtad elsőre a választ!";
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
                index = RandomUniqeNumber(0, Words.Count - 1, list);
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
                rb.Text = Words[AnswersIndexes[counter]].EngName;
                counter++;
            }
            AnswersIndexes.Clear();
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
                    if (!rb.Checked && rb.Text != CorrectAnswer)
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

