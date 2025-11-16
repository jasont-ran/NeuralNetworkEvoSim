using Simulation.Brain;

namespace Simulation
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int now = DateTime.Now.Millisecond;
            NeuralNetwork brain = new NeuralNetwork();
            brain.EntityThink(new float[] { 0.5f, 0.8f, 0.2f, 1f });

            int later = DateTime.Now.Millisecond;

            int bryh = (later - now);
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}