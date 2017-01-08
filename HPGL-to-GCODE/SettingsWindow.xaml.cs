using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HPGL_to_GCODE
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class SettingsWindow
    {
        private Profile _profile;

        public SettingsWindow(Profile profile)
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            _profile = profile;

            for (int i = 10; i <= 90; i += 10)
                paperPenetrationComboBox.Items.Add(i);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            nameTextBox.Text = _profile.Profilename;
            cutFeedrateTextBox.Text = _profile.CutFeedrate.ToString();
            moveFeedrateTextBox.Text = _profile.MoveFeedrate.ToString();
            paperThicknessTextBox.Text = _profile.PaperThickness.ToString("0.00");
            vinylThicknessTextBox.Text = _profile.VinylThickness.ToString("0.00");
            paperPenetrationComboBox.SelectedIndex = paperPenetrationComboBox.Items.Cast<int>().ToList().FindIndex(value => value == _profile.PaperPenetraion);
            safeDistanceTextBox.Text = _profile.RetractHeight.ToString("0.0");
            startCodeTextBox.Text = _profile.StartCode;
            endCodeTextBox.Text = _profile.EndCode;
            endstopOffsetTextBox.Text = _profile.EndstopOffset.ToString("0.00");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            _profile.Profilename = nameTextBox.Text;
            _profile.CutFeedrate = float.Parse(cutFeedrateTextBox.Text);
            _profile.MoveFeedrate = float.Parse(moveFeedrateTextBox.Text);
            _profile.PaperThickness = float.Parse(paperThicknessTextBox.Text);
            _profile.VinylThickness = float.Parse(vinylThicknessTextBox.Text);
            _profile.PaperPenetraion = (int)(paperPenetrationComboBox.SelectedValue ?? _profile.PaperPenetraion);
            _profile.RetractHeight = float.Parse(safeDistanceTextBox.Text);
            _profile.StartCode = startCodeTextBox.Text;
            _profile.EndCode = endCodeTextBox.Text;
            _profile.EndstopOffset = float.Parse(endstopOffsetTextBox.Text);
            Close();
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.-]+", RegexOptions.None);
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBox_SelectText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.SelectAll();
        }

        private void MetroWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}