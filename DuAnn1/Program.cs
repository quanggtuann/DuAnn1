namespace DuAnn1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            loginForm loginForm = new loginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Form());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}