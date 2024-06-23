using System;
using Microsoft.Maui.Controls;

namespace SGPACalculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void CalculateSGPA_Clicked(object sender, EventArgs e)
        {
            try
            {
                var grades = new[]
                {
                    Grade1.Text,
                    Grade2.Text,
                    Grade3.Text,
                    Grade4.Text,
                    Grade5.Text,
                    Grade6.Text,
                    Grade7.Text,
                    Grade8.Text,
                    Grade9.Text
                };

                var credits = new[] { 4, 4, 4, 3, 3, 2, 1, 1, 2 };
                var gradePoints = new Dictionary<string, int>
                {
                    { "A++", 10 },
                    { "A+", 9 },
                    { "A", 8 },
                    { "B+", 7 },
                    { "B", 6 },
                    { "C+", 5 }
                };

                double totalGradePoints = 0;
                int totalCredits = 24;

                for (int i = 0; i < grades.Length; i++)
                {
                    totalGradePoints += gradePoints[grades[i]] * credits[i];
                }

                double sgpa = totalGradePoints / totalCredits;
                SGPAResult.Text = $"SGPA Sem III: {sgpa:F3}";
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void CalculateCGPA_Clicked(object sender, EventArgs e)
        {
            try
            {
                double sem1SGPA = double.TryParse(Sem1SGPA.Text, out var s1) ? s1 : 0;
                double sem2SGPA = double.TryParse(Sem2SGPA.Text, out var s2) ? s2 : 0;

                double sgpa = double.TryParse(SGPAResult.Text?.Split(':')?[1].Trim(), out var s3) ? s3 : 0;

                double cgpa = (sem1SGPA + sem2SGPA + sgpa) / 3;
                CGPAResult.Text = $"CGPA I II III: {cgpa:F3}";
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
