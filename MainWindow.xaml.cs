using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.IO;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Threading;

namespace CIS.Born
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //  основной функционал 
            InitializeComponent();
            _stage = StageCompile.Initial;
            _uriServerCompile = new Uri("http://maiss.us/Projects/CompileLive.aspx");
            webBrowser1.Source = _uriServerCompile;
            webBrowser1.LoadCompleted += webBrowser1_LoadCompleted;

            _pathInternalFiles = new List<string>();
            _sDirectiveCompilation = String.Empty;
            _sDirectiveLanguage = String.Empty;
            _sDirectiveName = String.Empty;
            _sDirectiveSourceCode = String.Empty;
            _sDirectiveTarget = String.Empty;
            _sDirectiveAttributes = String.Empty;

            this.Closed += new EventHandler(MainWindow_Closed);

            sTarget = (string)(((ComboBoxItem)(comboBoxTarget.SelectedItem)).Content);
            _sDirectiveTarget = "[assembly: AssemblyCompileTarget(TargetPlatform." + sTarget + ")]";
            _sDirectiveName = textBoxName.Text;
            sLangApplication = (string)(((ComboBoxItem)(comboBoxLanguageBuilder.SelectedItem)).Content);
            string s6 = String.Empty;
            switch (sLangApplication)
            {
                case "C#":                          
                    s6 = "Csharp";
                    break;
                case "F#":
                    s6 = "Fsharp";

                    break;
            }
            _sDirectiveLanguage = "[assembly: AssemblyCompileLanguage(LanguageCode." + s6 + ")]";
            _sDirectiveCompilation = "[assembly: AssemblyCompileCompilation(TypeCompilation.exe)]";
        }

        void MainWindow_Closed(object sender, EventArgs e)
        {
            if (App.bDeleteCompilator)
            {
                foreach (string s in _pathInternalFiles)
                {
                    File.Delete(Environment.CurrentDirectory + "\\" + System.IO.Path.GetFileName(s));
                }
            }
        }

        void webBrowser1_LoadCompleted(object sender, NavigationEventArgs e)
        {
            string sb = String.Empty;
            string sc = String.Empty;
            switch (_stage)
            {
                case StageCompile.RequestCompilatorFiles:
                    //webBrowser1.InvokeScript("SetCompilator", sLangApplication);
                    _stage = StageCompile.LoadCompilatorFiles;
                    //webBrowser1.InvokeScript("Go");
                    break;
                case StageCompile.LoadCompilatorFiles:
                    var saCompilatorFiles = ((string)(webBrowser1.InvokeScript("GetFiles"))).Split(' ');
                    if (saCompilatorFiles.Length > 0 && !(String.IsNullOrWhiteSpace(saCompilatorFiles[0])) && !(String.IsNullOrEmpty(saCompilatorFiles[0])))
                    {
                        foreach (var s in saCompilatorFiles)
                        {
                            sb = System.IO.Path.GetFileName(s);
                            sc = sb.Substring(0, sb.Length - 4);
                            if (File.Exists(Environment.CurrentDirectory + "\\" + sc))
                            {
                                _pathInternalFiles.Add(sc);
                                continue;
                            }
                            if (!String.IsNullOrWhiteSpace(s))
                            {
                                _pathInternalFiles.Add(sc);
                                WebRequest request = WebRequest.Create(s);
                                request.Credentials = CredentialCache.DefaultCredentials;
                                WebResponse response = request.GetResponse();
                                Stream dataStream = response.GetResponseStream();
                                var binReader = new BinaryReader(dataStream);
                                var byteFile = new List<byte>();
                                try
                                {
                                    while (true) byteFile.Add(binReader.ReadByte());
                                }
                                catch (EndOfStreamException ee)
                                {

                                }
                                finally
                                {
                                    binReader.Close();
                                    dataStream.Flush();
                                    dataStream.Dispose();
                                    dataStream.Close();
                                }

                                var sa = System.IO.Path.GetFileName(s);
                                var sd = sa.Substring(0, sa.Length - 4);
                                var writer = new BinaryWriter(File.Open(Environment.CurrentDirectory + "\\" + sd, FileMode.Create));
                                writer.Write(byteFile.ToArray());

                                writer.Flush();
                                writer.Close();
                                response.Close();
                                _bCodeCompiled = true;
                            }
                        }
                    }
                    break;
                case StageCompile.ExecuteCompile:
                    Process _proc = Process.Start(textBoxName.Text + ".builder.exe");
                    _proc.WaitForExit();
                    _proc.Dispose();
                    _proc.Close();
                    _stage = StageCompile.Initial;
                    break;
            }
        }

        private void comboBoxTarget_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            sTarget = (string)(((ComboBoxItem)(e.AddedItems[0])).Content);
            _sDirectiveTarget = "[assembly: AssemblyCompileTarget(TargetPlatform." + sTarget + ")]";
        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        { 
            sTypeApplication = "NetModule"; 
            _sDirectiveCompilation = "[assembly: AssemblyCompileCompilation(TypeCompilation.module)]";
        }

        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        { 
            sTypeApplication = "ConsoleApplication";
            _sDirectiveCompilation = "[assembly: AssemblyCompileCompilation(TypeCompilation.exe)]";
        }

        private void radioButton3_Checked(object sender, RoutedEventArgs e)
        { 
            sTypeApplication = "ClassLibrary";
            _sDirectiveCompilation = "[assembly: AssemblyCompileCompilation(TypeCompilation.library)]";
        }

        private void radioButton4_Checked(object sender, RoutedEventArgs e)
        { 
            sTypeApplication = "WPFApplication";
            _sDirectiveCompilation = "[assembly: AssemblyCompileCompilation(TypeCompilation.winexe)]";
        }

        private void comboBoxLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            sLangApplication = (string)(((ComboBoxItem)(e.AddedItems[0])).Content);
            string s6 = String.Empty;
            switch (sLangApplication)
            {
                case "C#":
                    s6 = "Csharp";
                    break;
                case "F#":
                    s6 = "Fsharp";
                    break;
            }
            _sDirectiveLanguage = "[assembly: AssemblyCompileLanguage(LanguageCode." + s6 + ")]";
        }

        private void textBoxName_TextChanged(object sender, TextChangedEventArgs e)
        { sApplicFileName = textBoxName.Text; }

        private void comboBoxLanguageBuilder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { sLangBuilder = (string)(((ComboBoxItem)(e.AddedItems[0])).Content); }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            switch (sLangApplication)
            {
                case "C#":
                    switch (sTypeApplication)
                    {
                        case "NetModule":
                            richCode.SelectAll();
                            richCode.Selection.Text = Codes._csModule;
                            richCode.Selection.Select(richCode.Selection.Start, richCode.Selection.Start);
                            break;
                        case "ConsoleApplication":
                            richCode.SelectAll();
                            richCode.Selection.Text = Codes._csConsole;
                            richCode.Selection.Select(richCode.Selection.Start, richCode.Selection.Start);
                            break;
                        case "ClassLibrary":
                            richCode.SelectAll();
                            richCode.Selection.Text = Codes._csLibrary;
                            richCode.Selection.Select(richCode.Selection.Start, richCode.Selection.Start);
                            break;
                        case "WPFApplication":
                            richCode.SelectAll();
                            richCode.Selection.Text = Codes._csWindows;
                            richCode.Selection.Select(richCode.Selection.Start, richCode.Selection.Start);
                            break;
                    }
                    break;
                case "F#":
                    switch (sTypeApplication)
                    {
                        case "NetModule":
                            richCode.SelectAll();
                            richCode.Selection.Text = Codes._fsModule;
                            richCode.Selection.Select(richCode.Selection.Start, richCode.Selection.Start);
                            break;
                        case "ConsoleApplication":
                            richCode.SelectAll();
                            richCode.Selection.Text = Codes._fsConsole;
                            richCode.Selection.Select(richCode.Selection.Start, richCode.Selection.Start);
                            break;
                        case "ClassLibrary":
                            richCode.SelectAll();
                            richCode.Selection.Text = Codes._fsLibrary;
                            richCode.Selection.Select(richCode.Selection.Start, richCode.Selection.Start);
                            break;
                        case "WPFApplication":
                            richCode.SelectAll();
                            richCode.Selection.Text = Codes._fsWindows;
                            richCode.Selection.Select(richCode.Selection.Start, richCode.Selection.Start);
                            break;
                    }
                    break;
            }
        }

        private void Compile_Click(object sender, RoutedEventArgs e)
        {
            String[] referenceAssemblies = 
            {
                "System.dll", "System.Configuration.dll", "System.Core.dll",
                "System.Data.dll", "System.Data.DataSetExtensions.dll",
                "System.Deployment.dll", "System.Drawing.dll",
                "System.EnterpriseServices.dll", "System.Web.dll",
                "System.Web.ApplicationServices.dll", "System.Web.DynamicData.dll",
                "System.Web.Entity.dll",
                "System.Web.Extensions.dll", "System.Web.Mobile.dll",
                "System.Web.Services.dll", "System.Windows.Forms.dll",
                "System.Xml.dll", "System.Xml.Linq.dll"
            };
            
            CodeDomProvider cdp = CodeDomProvider.CreateProvider("CSharp");
            _pathInternalFiles.Add(textBoxName.Text + ".builder.exe");
            var cp = new CompilerParameters(referenceAssemblies, Environment.CurrentDirectory + "\\" + textBoxName.Text + ".builder.exe", false) 
                { GenerateInMemory = false, TreatWarningsAsErrors = true, WarningLevel = 3, GenerateExecutable = true };

            StringBuilder _sc = new StringBuilder();
            if (!App.bProgrammoid)
            {
                richCode.SelectAll();
                string s2 = richCode.Selection.Text;
                string s3a = s2.Replace("\r\n", " ");
                string s3b = s3a.Replace('\r', ' ');
                string s3c = s3b.Replace('\n', ' ');
                string s3 = s3c.Replace("\"", "\\\"");
                string s4 = String.Empty;
                switch (sLangApplication)
                {
                    case "C#":
                        s4 = "cs";
                        break;
                    case "F#":
                        s4 = "fs";
                        break;
                }
                _sDirectiveSourceCode = "[assembly: AssemblyCompileSourceCode(\"" + sApplicFileName + "." + s4 + "\", \"" + s3 + "\")]";
                if (s4 != "cs") _pathInternalFiles.Add(sApplicFileName + "." + s4);
                _sDirectiveName = "[assembly: AssemblyCompileName(\"" + sApplicFileName + "\")]";
                richAttributes.SelectAll();
                _sDirectiveAttributes = richAttributes.Selection.Text;
                string CodeGenerator0 = _sDirectiveCompilation + _sDirectiveLanguage + _sDirectiveSourceCode + _sDirectiveTarget + _sDirectiveName + _sDirectiveAttributes;
                _sc.Append(Generator.CodeGenerator1);
                _sc.Append(CodeGenerator0);
                _sc.Append(Generator.CodeGenerator3);

                string s1 = _sc.ToString();
            }
            else
            {
                App.sCode = new List<string>();
                if (App.bProgrammoid)
                {
                    if (App.sPathes != null && App.sPathes.Count > 0)
                    {
                        for (int i = 0; i < App.sPathes.Count; i++)
                        {
                            string scode = File.ReadAllText(App.sPathes[i]);
                            _sc.Append(scode);
                        }
                    }
                }
                richCode.SelectAll();
                richCode.Selection.Text = _sc.ToString();
            }

            string sCode = _sc.ToString();
            CompilerResults cr = cdp.CompileAssemblyFromSource(cp, sCode);
            _result = new Result();
            if (cr.Errors.Count > 0)
            {
                _result.SuccessCompile = false;
                foreach (CompilerError ce in cr.Errors) _result.ErrorWarning += ce + Environment.NewLine;
                textBox2.Text = _result.ErrorWarning;
            }
            else
            {
                _result.SuccessCompile = true;
                textBox2.Text = String.Empty;
            }
            _stage = StageCompile.RequestCompilatorFiles;
            //_stage = StageCompile.ExecuteCompile;
            webBrowser1.Source = _uriServerCompile;
        }

        /// <summary>
        /// перечисление типа платформ, на которых исполняется приложение (от этого зависит компиляция приложения)
        /// </summary>
        public enum TargetPlatform
        {
            AnyCPU = 1,
            x86 = 2,
            x64 = 3,
            Itanium = 4
        };

        /// <summary>
        /// список языков программирования, поддерживаемых CIS
        /// </summary>
        public enum Languages
        {
            DefaultValue,
            Csharp,
            Fsharp
        }

        public enum StageCompile 
        { 
            /// <summary>
            /// начальное состояние компиляции приложения
            /// </summary>
            Initial, 

            /// <summary>
            /// состояние, при котором запрашиваются для скачивания файлы компилятора
            /// (поскольку компиляция выполняется только на стороне клиента - ведь знания находятся у него
            /// а общие знания доступны через обращение к серверу)
            /// </summary>
            RequestCompilatorFiles,

            /// <summary>
            /// загрузить файлы компилятора
            /// </summary>
            LoadCompilatorFiles,

            /// <summary>
            /// выполнить процедуру компиляции (файлы для этого готовы)
            /// </summary>
            ExecuteCompile
        };

        private StageCompile _stage;

        private string sApplicFileName;

        public List<string> _pathInternalFiles;

        private string sTarget;
        private string sLangBuilder;
        private string sLangApplication;

        private Uri _uriServerCompile;

        private string _sDirectiveTarget;
        private string _sDirectiveCompilation;
        private string _sDirectiveLanguage;
        private string _sDirectiveSourceCode;
        private string _sDirectiveName;
        private string _sDirectiveAttributes;
        private string sTypeApplication;

        private Result _result;

        public bool _bCodeCompiled { get; set; }
    }
}
