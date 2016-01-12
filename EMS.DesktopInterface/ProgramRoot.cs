using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;

namespace EMS.DesktopInterface
{
    public class ProgramRoot
    {
        /// <summary>
        /// Program Entry Point and Composition Root
        /// </summary>
        [STAThread]
        public static void Main()
        {
            var container = IoCContainer.CreateContainer();
            AppDomain.CurrentDomain.SetData("DataDirectory", System.Environment.CurrentDirectory);

            RunApplication(container);
        }

        private static void RunApplication(Container container)
        {
                var app = new App();
                var mainWindow = container.GetInstance<MainWindow>();
                app.Run(mainWindow);
        }
    }
}
