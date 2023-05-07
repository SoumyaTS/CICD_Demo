using SampleAppCICD.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
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


namespace SampleAppCICD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string filePath = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
            filePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            Details details = new Details();
            details.name = nameTxt.Text;
            details.phoneNum = phn.Text;
            details.email = emaillbl.Text;
            details.dob = dobtxt.Text;
            details.address = addressTxt.Text;
            detailserlization(details);
        }
        public void detailserlization(Details details)
        {
            var json = JsonSerializer.Serialize(details);
            string combinefilePath = filePath + "\\RegistrationDetail.json";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            System.IO.File.WriteAllText(combinefilePath, json);
        }
    }
}
