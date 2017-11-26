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

namespace CustomRadioButton
{
    /// <summary>
    /// Interaction logic for IconRadioButton.xaml
    /// </summary>
    public partial class IconRadioButton : UserControl
    {


        public string RadioGroupName
        {
            get { return (string)GetValue(RadioGroupNameProperty); }
            set { SetValue(RadioGroupNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RadioGroupName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RadioGroupNameProperty =
            DependencyProperty.Register("RadioGroupName", typeof(string), typeof(IconRadioButton), new PropertyMetadata(""));



        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(IconRadioButton), new PropertyMetadata(""));


        public string SourceOn
        {
            get { return (string)GetValue(SourceOnProperty); }
            set { SetValue(SourceOnProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SourceOn.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourceOnProperty =
            DependencyProperty.Register("SourceOn", typeof(string), typeof(IconRadioButton), new PropertyMetadata(""));


        public string SourceOff
        {
            get { return (string)GetValue(SourceOffProperty); }
            set { SetValue(SourceOffProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SourceOff.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourceOffProperty =
            DependencyProperty.Register("SourceOff", typeof(string), typeof(IconRadioButton), new PropertyMetadata(""));

        public IconRadioButton()
        {
            InitializeComponent();
        }
    }
}
