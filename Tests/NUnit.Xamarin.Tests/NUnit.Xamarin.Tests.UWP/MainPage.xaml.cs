using System.IO;
using System.Reflection;
using NUnit.Runner.Services;
using NUnit.Runner.Tests;
using Windows.Storage;

namespace NUnit.Xamarin.Tests.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            var nunit = new Runner.App();

            // If you want to add tests in another assembly, add a reference and
            // duplicate the following line with a type from the referenced assembly
            nunit.AddTestAssembly(typeof(AsyncTests).GetTypeInfo().Assembly);

            // Available options for testing
            nunit.Options = new TestOptions
            {
                // If True, the tests will run automatically when the app starts
                // otherwise you must run them manually.
                AutoRun = true,

                // If True, the application will terminate automatically after running the tests.
                //TerminateAfterExecution = true,

                // Information about the tcp listener host and port.
                // For now, send result as XML to the listening server.
                // NOTE: Your UWP App must have Private Networks capability enabled
                //TcpWriterParameters = new TcpWriterInfo("192.168.0.108", 13000),

                // Creates a NUnit Xml result file on the host file system using PCLStorage library.
                CreateXmlResultFile = true,

                // Choose a different path for the xml result file
                ResultFilePath = Path.Combine(ApplicationData.Current.TemporaryFolder.Path, "Nunit", "Results.xml"),
            };

            LoadApplication(nunit);
        }
    }
}
