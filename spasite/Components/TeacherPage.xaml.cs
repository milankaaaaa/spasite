using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace spasite.Components
{
    /// <summary>
    /// Логика взаимодействия для TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {
        private Student student;
        private Exam exam;
        public TeacherPage()
        {
            InitializeComponent();
            ExamsDataGrid.ItemsSource = App.db.Exam.ToList();
            ExamsDataGrid.DataContext = App.db.Exam.ToList();
            StudentsComboBox.ItemsSource = App.db.Student.ToList();
            StudentsComboBox.DisplayMemberPath = "Last_name";
            DiscComboBox.ItemsSource = App.db.Discipline.ToList();
            DiscComboBox.DisplayMemberPath = "Name";
            TeachComboBox.ItemsSource = App.db.Employee.ToList();
            TeachComboBox.DisplayMemberPath = "Last_name";
            App.COuntOfExams = App.db.Exam.Count();


        }

        StringBuilder Validator()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (StudentsComboBox.SelectedIndex == -1)
                stringBuilder.AppendLine("Не выбран студент");
            if (DiscComboBox.SelectedIndex == -1)
                stringBuilder.AppendLine("Не выбрана дисциплина");
            if (DateOfExamDp.SelectedDate == null)
                stringBuilder.AppendLine("Не выбрана дата");
            if (AudithoriumTb is null)
                stringBuilder.AppendLine("Не выбрана аудитория");
            return stringBuilder;
        }

        private void AddStudentToExam_Click(object sender, RoutedEventArgs e)
        {
            if (Validator().Length == 0)
            {

                App.db.Exam.Add(new Exam()
                {
                    id_exam = App.db.Exam.Count() + 1,
                    Date_exam = DateOfExamDp.SelectedDate,
                    Id_discipline = (int?)(DiscComboBox.SelectedItem as Discipline).id,
                    Estimation = 0,
                    Id_student = (StudentsComboBox.SelectedItem as Student).Id_student,
                    Id_employee = ((TeachComboBox.SelectedItem) as Employee).Id_employee,
                    Auditorium = AudithoriumTb.Text
                });
                App.db.SaveChanges();
                MessageBox.Show("Успешно");
                App.COuntOfExams += 1;
                Refresh();
            }
            else
                MessageBox.Show(Validator().ToString());
        }
        void Refresh()
        {
            ExamsDataGrid.ItemsSource = null;
            IEnumerable<Exam> exams = App.db.Exam.ToList();
            if (AssessmentCb.SelectedIndex != -1)
            {
                if (AssessmentCb.SelectedIndex == 0)
                    exams = exams.Where(x => x.Estimation == 2);
                if (AssessmentCb.SelectedIndex == 1)
                    exams = exams.Where(x => x.Estimation == 3);
                if (AssessmentCb.SelectedIndex == 2)
                    exams = exams.Where(x => x.Estimation == 4);
                if (AssessmentCb.SelectedIndex == 3)
                    exams = exams.Where(x => x.Estimation == 5);
            }
            if (NameOfDisciplineSearchTb.Text.Length > 0)
            {
                exams = exams.Where(x => x.Discipline.Name.ToLower().Contains(NameOfDisciplineSearchTb.Text.ToLower()));
            }
            ExamsDataGrid.ItemsSource = exams;
        }


        private void GradeBtn_Click(object sender, RoutedEventArgs e)
        {
            {

                Exam ThatOneExam = ExamsDataGrid.SelectedItem as Exam;
                if (GradeCB.SelectedItem == null)
                {
                    MessageBox.Show("Не выбрана оценка");
                }
                else if (ExamsDataGrid.SelectedItem == null)
                {
                    MessageBox.Show("Не выбран экзамен");
                }
                else if (ThatOneExam.Assessment != null)
                {
                    MessageBox.Show("Оценка уже выставлена");
                }

                else
                {
                    int grade;
                    switch (GradeCB.SelectedIndex)
                    {
                        case 0: grade = 5; break;
                        case 1: grade = 4; break;
                        case 2: grade = 3; break;
                        case 3: grade = 2; break;
                        default: grade = 0; break;
                    }
                    App.db.Exam.Find(ThatOneExam.id_exam).Estimation = grade;
                    App.db.SaveChanges();
                    MessageBox.Show("Оценка выставлена");
                    Refresh();
                }
            }
        }

        private void AssessmentCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void ToBaseBtn_Click(object sender, RoutedEventArgs e)
        {
            AssessmentCb.SelectedIndex = -1;
            Refresh();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizatePage());
        }

        private void NameOfDisciplineSearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void ExamsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TeachComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
