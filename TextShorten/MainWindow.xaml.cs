using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace TextShorten
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string input = inputTxt.Text.Replace("{","");
            input = input.Replace("}","");
            string[] words = input.Split( ' ' );
            List<string> wordList = new List<string>();
            foreach(string word in words)
            {
                int foundIndex = 0;
                if ((foundIndex = wordList.FindIndex(0,(a)=>a==word)) != -1)
                {
                    sb.Append(foundIndex);
                } else
                {
                    sb.Append("{");
                    sb.Append(word);
                    sb.Append("}");
                    wordList.Add(word);
                }
                sb.Append(" ");
            }
            outputTxt.Text = sb.ToString();
        }

        Regex regex1 = new Regex("[aeiou]", RegexOptions.Compiled| RegexOptions.IgnoreCase| RegexOptions.Singleline);
        Regex regex2 = new Regex(@"(\w{2})\w+(\w{2})", RegexOptions.Compiled| RegexOptions.IgnoreCase| RegexOptions.Singleline);

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            outputTxt.Text = regex2.Replace(regex1.Replace(inputTxt.Text, ""),"$1$2");
            
        }
    }
}
