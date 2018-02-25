using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS.Born
{
    public static class Codes
    {
        public static string _csConsole =
"using System;" + Environment.NewLine +
"using System.Collections.Generic;" + Environment.NewLine +
"using System.Linq;" + Environment.NewLine +
"using System.Text;" + Environment.NewLine +
"using System.Threading.Tasks;" + Environment.NewLine +
Environment.NewLine + Environment.NewLine +
"namespace ConsoleApplication1" + Environment.NewLine +
"{" + Environment.NewLine +
"    class Program" + Environment.NewLine +
"    {" + Environment.NewLine +
"        static void Main(string[] args)" + Environment.NewLine +
"        {" + Environment.NewLine +
"        }" + Environment.NewLine +
"    }" + Environment.NewLine +
"}";

        public static string _csLibrary =
"using System;" + Environment.NewLine +
"using System.Collections.Generic;" + Environment.NewLine +
"using System.Linq;" + Environment.NewLine +
"using System.Text;" + Environment.NewLine +
"using System.Threading.Tasks;" + Environment.NewLine +
Environment.NewLine +
"namespace ClassLibrary1" + Environment.NewLine +
"{" + Environment.NewLine +
"    public class Class1" + Environment.NewLine +
"    {" + Environment.NewLine +
"    }" + Environment.NewLine +
"}";

        public static string _csModule =
"using System;" + Environment.NewLine +
"using System.Collections.Generic;" + Environment.NewLine +
"using System.Linq;" + Environment.NewLine +
"using System.Text;" + Environment.NewLine +
"using System.Threading.Tasks;" + Environment.NewLine +
Environment.NewLine +
"namespace ClassLibrary1" + Environment.NewLine +
"{" + Environment.NewLine +
"    public class Class1" + Environment.NewLine +
"    {" + Environment.NewLine +
"    }" + Environment.NewLine +
"}";

        public static string _csWindows =
"using System;" + Environment.NewLine +
"using System.Collections.Generic;" + Environment.NewLine +
"using System.Linq;" + Environment.NewLine +
"using System.Text;" + Environment.NewLine +
"using System.Threading.Tasks;" + Environment.NewLine +
"using System.Windows;" + Environment.NewLine +
"using System.Windows.Controls;" + Environment.NewLine +
"using System.Windows.Data;" + Environment.NewLine +
"using System.Windows.Documents;" + Environment.NewLine +
"using System.Windows.Input;" + Environment.NewLine +
"using System.Windows.Media;" + Environment.NewLine +
"using System.Windows.Media.Imaging;" + Environment.NewLine +
"using System.Windows.Navigation;" + Environment.NewLine +
"using System.Windows.Shapes;" + Environment.NewLine +
"using System.Configuration;" + Environment.NewLine +
"using System.Data;" + Environment.NewLine +
Environment.NewLine + Environment.NewLine +
"namespace WpfApplication1" + Environment.NewLine +
"{" + Environment.NewLine +
"    public class App : Application" + Environment.NewLine +
"    {" + Environment.NewLine +
"        public void InitializeComponent()" + Environment.NewLine +
"        {" + Environment.NewLine +
"        }" + Environment.NewLine +
"        [STAThreadAttribute()]" + Environment.NewLine +
"        public static void Main()" + Environment.NewLine +
"        {" + Environment.NewLine +
"            Window w = new Window();" + Environment.NewLine +
"            w.Show();" + Environment.NewLine +
"            App app = new App();" + Environment.NewLine +
"            app.InitializeComponent();" + Environment.NewLine +
"            app.Run();" + Environment.NewLine +
"        }" + Environment.NewLine +
"    }" + Environment.NewLine +
"}";

        public static string _fsConsole =
"// Learn more about F# at http://fsharp.net" + Environment.NewLine +
"// See the 'F# Tutorial' project for more help." + Environment.NewLine +
"open System" + Environment.NewLine +
Environment.NewLine +
"module Program =" + Environment.NewLine +
"    begin" + Environment.NewLine +
"    [< EntryPoint >]" + Environment.NewLine +
"    let main argv = " + Environment.NewLine +
"        begin" + Environment.NewLine +
"        Console.WriteLine(\"message\");" + Environment.NewLine +
"        Console.ReadLine() |> ignore; 0; // return an integer exit code" + Environment.NewLine +
"    end" + Environment.NewLine +
"end";

        public static string _fsLibrary =
"namespace Library" + Environment.NewLine +
 Environment.NewLine +
"type Class1() = " + Environment.NewLine +
"    member this.X = \"F#;\"";

        public static string _fsModule =
"namespace Netmodule" + Environment.NewLine +
 Environment.NewLine +
"type Class1() = " + Environment.NewLine +
"    member this.X = \"F#;\"";

        public static string _fsWindows =
"#light \"off\"" + Environment.NewLine +
Environment.NewLine +
"open System" + Environment.NewLine +
"open System.Windows" + Environment.NewLine +
"open System.Windows.Controls" + Environment.NewLine +
Environment.NewLine +
"module MainWindow =" + Environment.NewLine +
"    begin let initControls (window:Window) = (); end" + Environment.NewLine +
Environment.NewLine +
"module Main =" + Environment.NewLine +
"    begin" + Environment.NewLine +
"        [< STAThread >]" + Environment.NewLine +
"        [< EntryPoint >]" + Environment.NewLine +
"        do" + Environment.NewLine +
"        begin" + Environment.NewLine +
"            let application = new Application(); in" + Environment.NewLine +
"            let w = new Window(); in" + Environment.NewLine +
"            w.Height<-300.0;" + Environment.NewLine +
"            w.Width<-300.0;" + Environment.NewLine +
"            w.Activate() |> ignore;" + Environment.NewLine +
"            w.Show();" + Environment.NewLine +
"            application.MainWindow<-w;" + Environment.NewLine +
Environment.NewLine +
"            application.Activated |> Event.add (fun _ -> MainWindow.initControls application.MainWindow);" + Environment.NewLine +
"            application.Run() |> ignore" + Environment.NewLine +
"        end" + Environment.NewLine +
"   end";
    }
}
