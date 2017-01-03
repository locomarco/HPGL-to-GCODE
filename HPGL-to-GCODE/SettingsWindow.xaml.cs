using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace HPGL_to_GCODE
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        Profile _profile;
        Profile _hblasdfl = new Profile();

        public SettingsWindow(Profile profile)
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            _profile = profile;

            for (int i = 1; i <= 9; i++)
            {
                paperPenetrationComboBox.Items.Add(i * 10);
            }
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            nameTextBox.Text = _profile.Profilename;
            feedrateTextBox.Text = _profile.Feedrate.ToString();
            xOffsetTextBox.Text = _profile.XOffset.ToString();
            yOffsetTextBox.Text = _profile.YOffset.ToString();
            materialThicknessTextBox.Text = _profile.MaterialThickness.ToString();
            paperThicknessTextBox.Text = _profile.PaperThickness.ToString();                 
            paperPenetrationComboBox.SelectedIndex = paperPenetrationComboBox.Items.Cast<int>().ToList().FindIndex(value => value == _profile.PaperPenetraion);
            safeDistanceTextBox.Text = _profile.SafeDistance.ToString();
            startCodeTextBox.Text = _profile.StartCode;
            endCodeTextBox.Text = _profile.EndCode;
            endstopOffsetTextBox.Text = _profile.EndstopOffset.ToString();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            _profile.Profilename = nameTextBox.Text;
            _profile.Feedrate = float.Parse(feedrateTextBox.Text);
            _profile.XOffset = float.Parse(xOffsetTextBox.Text);
            _profile.YOffset = float.Parse(yOffsetTextBox.Text);
            _profile.MaterialThickness = float.Parse(materialThicknessTextBox.Text);
            _profile.PaperThickness = float.Parse(paperThicknessTextBox.Text);
            _profile.PaperPenetraion = (int)(paperPenetrationComboBox.SelectedValue ?? _profile.PaperPenetraion);
            _profile.SafeDistance = float.Parse(safeDistanceTextBox.Text);
            _profile.StartCode = startCodeTextBox.Text;
            _profile.EndCode = endCodeTextBox.Text;
            _profile.EndstopOffset = float.Parse(endstopOffsetTextBox.Text);
            Close();
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+", RegexOptions.None);
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
