using DigitaTexto;
using System;
using System.Collections.Generic;
using System.IO;
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
using WindowsInput;

namespace WpfApp1
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            KeyboardHook.OnKeyDown += KeyboardHook_OnKeyDown;

            KeyboardHook.Inicializa();
        }
        private static void KeyboardHook_OnKeyDown(string vkCode)
        {
            if (vkCode == "101")
            {
                Console.WriteLine("Iniciando a digitação...");
                SimularDigitarTexto(File.ReadAllText(Directory.GetCurrentDirectory() + @"\texto.txt"));
            }

        }
        static void SimularDigitarTexto(string texto)
        {
            InputSimulator inputSimulator = new InputSimulator();

            foreach (char caractere in texto)
            {
                inputSimulator.Keyboard.TextEntry(caractere);
                System.Threading.Thread.Sleep(50); // Intervalo de espera entre cada caractere (em milissegundos)
            }
        }
    }
}
