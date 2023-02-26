/// <summary>
/// Miksowanie obraz�w
/// Alorytm pozwala na po��czenie dw�ch obraz�w o takiej samej rozdzielczo�ci i wybranie wsp�czynnika mieszania
/// 2022/2023 Sem.5 Jakub Ho� gr.2
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
