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

namespace Delegats_Lab_3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SimpleButtonWithDelegats();
        }
        private void SimpleButtonWithDelegats()
        {
            Simple_Button.Click += (s, e) => MessageBox.Show("hi");
            Transparensy_CheckBox.Click += (s, e) => CheckBoxActivated(s as CheckBox, Transparency_Button_Click);
            Back_Color_CheckBox.Click += (s, e) => CheckBoxActivated(s as CheckBox, Back_Color_Button_Click);
            Hello_World_CheckBox.Click += (s, e) => CheckBoxActivated(s as CheckBox, Hello_World_Button_Click);
        }
        private void CheckBoxActivated(CheckBox checkBox, RoutedEventHandler @delegate)
        {
            if (checkBox.IsChecked == true)
                Simple_Button.Click += @delegate;
            else
                Simple_Button.Click -= @delegate;
        }
        bool isColored, isTransparent;
        private void Close_Button_Click(object sender, RoutedEventArgs e) => MW.Close();
        private void Transparency_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!isTransparent)
                MW.Opacity = 0.5;
            else
                MW.Opacity = 1;

            isTransparent = !isTransparent;
        }
        private void Back_Color_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!isColored)
                MW.Background = new SolidColorBrush(Colors.Yellow);
            else
                MW.Background = new SolidColorBrush(Colors.White);

            isColored = !isColored;
        }
        private void Hello_World_Button_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Hello World!");
    }
}