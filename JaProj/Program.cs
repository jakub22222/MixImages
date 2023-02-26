/// <summary>
/// Miksowanie obrazów
/// Alorytm pozwala na po³¹czenie dwóch obrazów o takiej samej rozdzielczoœci i wybranie wspó³czynnika mieszania
/// 2022/2023 Sem.5 Jakub Hoœ gr.2
/// v1.0
/// </summary>
using System;
using System.Windows.Forms;

namespace JaProj
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

        }
    }
}
