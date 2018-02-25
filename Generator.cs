using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CIS.Born
{
    public static class Generator
    {
        public static string CodeGenerator1 = 
"using System;" + Environment.NewLine + 
"using System.Collections.Generic;" + Environment.NewLine + 
"using System.Linq;" + Environment.NewLine + 
"using System.Text;" + Environment.NewLine + 
"using System.Reflection;" + Environment.NewLine + 
"using System.IO;" + Environment.NewLine + 
"using System.Diagnostics;" + Environment.NewLine + 
"using System.CodeDom.Compiler;" + Environment.NewLine + 
"" + Environment.NewLine;
        public static string CodeGenerator3 = 
"[AttributeUsage(AttributeTargets.Assembly)]" + Environment.NewLine + 
"public class AssemblyCompileLanguage : Attribute" + Environment.NewLine + 
"{" + Environment.NewLine + 
"    public AssemblyCompileLanguage(LanguageCode langInit)" + Environment.NewLine + 
"    { _lang = langInit; }" + Environment.NewLine + 
"    public LanguageCode _lang;" + Environment.NewLine + 
"}" + Environment.NewLine + 
"" + Environment.NewLine + 
"[AttributeUsage(AttributeTargets.Assembly)]" + Environment.NewLine + 
"public class AssemblyCompileSourceCode : Attribute" + Environment.NewLine + 
"{" + Environment.NewLine + 
"    public AssemblyCompileSourceCode(string headerInit, string codeInit)" + Environment.NewLine + 
"    {" + Environment.NewLine + 
"        _header = headerInit;" + Environment.NewLine + 
"        _code = codeInit;" + Environment.NewLine + 
"        _ext = Path.GetExtension(_header);" + Environment.NewLine + 
"    }" + Environment.NewLine + 
"    public string _header;" + Environment.NewLine + 
"    public string _code;" + Environment.NewLine + 
"    public string _ext;" + Environment.NewLine + 
"}" + Environment.NewLine + 
"" + Environment.NewLine + 
"[AttributeUsage(AttributeTargets.Assembly)]" + Environment.NewLine + 
"public class AssemblyCompileTarget : Attribute" + Environment.NewLine + 
"{" + Environment.NewLine + 
"    public AssemblyCompileTarget(TargetPlatform targetInit)" + Environment.NewLine + 
"    { _target = targetInit; }" + Environment.NewLine + 
"    public TargetPlatform _target;" + Environment.NewLine + 
"}" + Environment.NewLine + 
"" + Environment.NewLine + 
"[AttributeUsage(AttributeTargets.Assembly)]" + Environment.NewLine + 
"public class AssemblyCompileCompilation : Attribute" + Environment.NewLine + 
"{" + Environment.NewLine + 
"    public AssemblyCompileCompilation(TypeCompilation compileInit)" + Environment.NewLine + 
"    { _compile = compileInit; }" + Environment.NewLine + 
"    public TypeCompilation _compile;" + Environment.NewLine + 
"}" + Environment.NewLine + 
"" + Environment.NewLine + 
"[AttributeUsage(AttributeTargets.Assembly)]" + Environment.NewLine + 
"public class AssemblyCompileName : Attribute" + Environment.NewLine + 
"{" + Environment.NewLine + 
"    public AssemblyCompileName(string applicInit)" + Environment.NewLine + 
"    { _applic = applicInit; }" + Environment.NewLine + 
"    public string _applic;" + Environment.NewLine + 
"}" + Environment.NewLine + 
"" + Environment.NewLine + 
"[AttributeUsage(AttributeTargets.Assembly)]" + Environment.NewLine + 
"public class AssemblyCompileOptions : Attribute" + Environment.NewLine + 
"{" + Environment.NewLine + 
"    public AssemblyCompileOptions(string optionsInit)" + Environment.NewLine + 
"    { _options = optionsInit; }" + Environment.NewLine + 
"    public string _options;" + Environment.NewLine + 
"}" + Environment.NewLine + 
"" + Environment.NewLine + 
"[AttributeUsage(AttributeTargets.Assembly)]" + Environment.NewLine + 
"public class AssemblyReferenceToAssembly : Attribute" + Environment.NewLine + 
"{" + Environment.NewLine + 
"    public AssemblyReferenceToAssembly(string sNameAssemblyInit)" + Environment.NewLine + 
"    { sNameAssembly = sNameAssemblyInit; }" + Environment.NewLine + 
"    public string sNameAssembly;" + Environment.NewLine + 
"}" + Environment.NewLine + 
"" + Environment.NewLine + 
"[AttributeUsage(AttributeTargets.Assembly)]" + Environment.NewLine + 
"public class AssemblyReferenceToModule : Attribute" + Environment.NewLine + 
"{" + Environment.NewLine + 
"    public AssemblyReferenceToModule(string sNameModuleInit)" + Environment.NewLine + 
"    { sNameModule = sNameModuleInit; }" + Environment.NewLine + 
"    public string sNameModule;" + Environment.NewLine + 
"}" + Environment.NewLine + 
"" + Environment.NewLine +
"[AttributeUsage(AttributeTargets.Assembly)]" + Environment.NewLine +
"public class AssemblyReferenceToMacro : Attribute" + Environment.NewLine +
"{" + Environment.NewLine +
"    public AssemblyReferenceToMacro(string sNameMacroInit)" + Environment.NewLine +
"    { sNameMacro = sNameMacroInit; }" + Environment.NewLine +
"    public string sNameMacro;" + Environment.NewLine +
"}" + Environment.NewLine + 
"" + Environment.NewLine +
"public enum TargetPlatform { AnyCpu, x86, x64, Itanium };" + Environment.NewLine +
"public enum TypeCompilation { module, library, exe, winexe };" + Environment.NewLine +
"public enum LanguageCode { NotValue, Csharp, Fsharp, Nsharp }; " + Environment.NewLine + 
"" + Environment.NewLine + 
"" + Environment.NewLine + 
"" + Environment.NewLine + 
"namespace CIS.Soul" + Environment.NewLine + 
"{" + Environment.NewLine + 
"    class Program" + Environment.NewLine + 
"    {" + Environment.NewLine + 
"        static void Main(string[] args)" + Environment.NewLine + 
"        {" + Environment.NewLine + 
"            LanguageCode _lang = LanguageCode.NotValue;" + Environment.NewLine + 
"            TargetPlatform _targ = TargetPlatform.AnyCpu;" + Environment.NewLine + 
"            TypeCompilation _cmpl = TypeCompilation.exe;" + Environment.NewLine + 
"            string _name = String.Empty;" + Environment.NewLine + 
"            string _file = String.Empty;" + Environment.NewLine + 
"            List< string > _ref = new List< string >();" + Environment.NewLine + 
"            List< string > _modul = new List< string >();" + Environment.NewLine +
"            List< string > _macr = new List< string >();" + Environment.NewLine + 
"            string _opt = String.Empty;" + Environment.NewLine + 
"            Dictionary< string, string > _codes = new Dictionary< string,string >();" + Environment.NewLine + 
"" + Environment.NewLine + 
"            object[] oa = (Assembly.GetExecutingAssembly()).GetCustomAttributes(false);" + Environment.NewLine + 
"            foreach (Attribute attr in oa)" + Environment.NewLine + 
"            {" + Environment.NewLine + 
"                if (attr.GetType().Name == \"AssemblyCompileLanguage\") _lang = (((AssemblyCompileLanguage)attr)._lang);" + Environment.NewLine + 
"                if (attr.GetType().Name == \"AssemblyCompileName\") _name = (((AssemblyCompileName)attr)._applic);" + Environment.NewLine + 
"                if (attr.GetType().Name == \"AssemblyCompileTarget\") _targ = (((AssemblyCompileTarget)attr)._target);" + Environment.NewLine + 
"                if (attr.GetType().Name == \"AssemblyCompileCompilation\") _cmpl = (((AssemblyCompileCompilation)attr)._compile);" + Environment.NewLine + 
"                if (attr.GetType().Name == \"AssemblyReferenceToAssembly\") _ref.Add(((AssemblyReferenceToAssembly)attr).sNameAssembly);" + Environment.NewLine + 
"                if (attr.GetType().Name == \"AssemblyReferenceToModule\") _modul.Add(((AssemblyReferenceToModule)attr).sNameModule);" + Environment.NewLine +
"                if (attr.GetType().Name == \"AssemblyReferenceToMacro\") _ref.Add(((AssemblyReferenceToMacro)attr).sNameMacro);" + Environment.NewLine + 
"                if (attr.GetType().Name == \"AssemblyCompileOptions\") _opt = (((AssemblyCompileOptions)attr)._options);" + Environment.NewLine + 
"                if (attr.GetType().Name == \"AssemblyCompileSourceCode\") _codes.Add(((AssemblyCompileSourceCode)attr)._header, ((AssemblyCompileSourceCode)attr)._code);" + Environment.NewLine + 
"            }" + Environment.NewLine + 
"" + Environment.NewLine + 
"            //  список сборок, которые подключается к приложению" + Environment.NewLine + 
"            //  принято соглашение, что к процессу компиляции подключаются все системные сборки" + Environment.NewLine + 
"            String[] referenceAssemblies = " + Environment.NewLine + 
"            {" + Environment.NewLine + 
"                \"System.dll\", \"System.Configuration.dll\", \"System.Core.dll\"," + Environment.NewLine + 
"                \"System.Data.dll\", \"System.Data.DataSetExtensions.dll\"," + Environment.NewLine + 
"                \"System.Deployment.dll\", \"System.Drawing.dll\"," + Environment.NewLine + 
"                \"System.EnterpriseServices.dll\", \"System.Web.dll\"," + Environment.NewLine + 
"                \"System.Web.ApplicationServices.dll\", \"System.Web.DynamicData.dll\"," + Environment.NewLine + 
"                \"System.Web.Entity.dll\"," + Environment.NewLine + 
"                \"System.Web.Extensions.dll\", \"System.Web.Mobile.dll\"," + Environment.NewLine + 
"                \"System.Web.Services.dll\", \"System.Windows.Forms.dll\"," + Environment.NewLine + 
"                \"System.Xml.dll\", \"System.Xml.Linq.dll\"" + Environment.NewLine + 
"            };" + Environment.NewLine +
"" + Environment.NewLine + 
"            var sbBuilder = new StringBuilder();" + Environment.NewLine + 
"            switch (_cmpl)" + Environment.NewLine + 
"            {" + Environment.NewLine + 
"                case TypeCompilation.exe:" + Environment.NewLine + 
"                case TypeCompilation.winexe:" + Environment.NewLine + 
"                    _file = _name + \".exe\";" + Environment.NewLine + 
"                    break;" + Environment.NewLine + 
"                case TypeCompilation.library:" + Environment.NewLine + 
"                    _file = _name + \".dll\";" + Environment.NewLine + 
"                    break;" + Environment.NewLine + 
"                case TypeCompilation.module:" + Environment.NewLine + 
"                    _file = _name + \".netmodule\";" + Environment.NewLine + 
"                    break;" + Environment.NewLine + 
"            }" + Environment.NewLine + 
"" + Environment.NewLine + 
"            switch (_lang)" + Environment.NewLine + 
"            {" + Environment.NewLine + 
"                case LanguageCode.Csharp:" + Environment.NewLine + 
"                    CodeDomProvider cdp = CodeDomProvider.CreateProvider(\"CSharp\");" + Environment.NewLine + 
"                    var cp = new CompilerParameters(referenceAssemblies, Environment.CurrentDirectory + \"\\\\\" + _file, false) " + Environment.NewLine + 
"                        { GenerateInMemory = false, TreatWarningsAsErrors = true, WarningLevel = 3, GenerateExecutable = true };" + Environment.NewLine + 
"                    if (_cmpl == TypeCompilation.exe || _cmpl == TypeCompilation.winexe) cp.GenerateExecutable = true; else cp.GenerateExecutable = false;" + Environment.NewLine + 
"" + Environment.NewLine + 
"                    //  установили целевую платформу исполнения файла" + Environment.NewLine + 
"                    switch (_targ)" + Environment.NewLine + 
"                    {" + Environment.NewLine + 
"                        case TargetPlatform.x86:" + Environment.NewLine + 
"                            sbBuilder.Append(\" /platform:x86\");" + Environment.NewLine + 
"                            break;" + Environment.NewLine + 
"                        case TargetPlatform.x64:" + Environment.NewLine + 
"                            sbBuilder.Append(\" /platform:x64\");" + Environment.NewLine + 
"                            break;" + Environment.NewLine + 
"                        case TargetPlatform.Itanium:" + Environment.NewLine + 
"                            sbBuilder.Append(\" /platform:Itanium\");" + Environment.NewLine + 
"                            break;" + Environment.NewLine + 
"                        case TargetPlatform.AnyCpu:" + Environment.NewLine + 
"                            break;" + Environment.NewLine + 
"                        default:" + Environment.NewLine + 
"                            break;" + Environment.NewLine + 
"                    }" + Environment.NewLine +
"                    //  в любом случае допустили unamanged code" + Environment.NewLine + 
"                    sbBuilder.Append(\" /unsafe\");" + Environment.NewLine + 
"" + Environment.NewLine + 
"                    if (_cmpl == TypeCompilation.winexe) " + Environment.NewLine +
"                    {" + Environment.NewLine +
"                       sbBuilder.Append(\" /target:winexe\");            //  запускаем цикл сообщений WM_***" + Environment.NewLine +
"                       sbBuilder.Append(\" /reference:\\\"C:/Program Files (x86)/Reference Assemblies/Microsoft/Framework/.NETFramework/v4.5/PresentationCore.dll\\\"\"); " + Environment.NewLine +
"                       sbBuilder.Append(\" /reference:\\\"C:/Program Files (x86)/Reference Assemblies/Microsoft/Framework/.NETFramework/v4.5/PresentationFramework.dll\\\"\"); " + Environment.NewLine +
"                       sbBuilder.Append(\" /reference:\\\"C:/Program Files (x86)/Reference Assemblies/Microsoft/Framework/.NETFramework/v4.5/WindowsBase.dll\\\"\"); " + Environment.NewLine +
"                       sbBuilder.Append(\" /reference:System.Xaml.dll\"); " + Environment.NewLine +
"                    }" + Environment.NewLine + 
"                    if (_cmpl == TypeCompilation.module) sbBuilder.Append(\" /target:module\");" + Environment.NewLine + 
"" + Environment.NewLine + 
"                    //  если исходный код содержит включаемые модули их необходимо включить в процесс исполнения" + Environment.NewLine + 
"                    if (_modul != null)" + Environment.NewLine + 
"                    {" + Environment.NewLine + 
"                        if (_modul.Count != 0)" + Environment.NewLine + 
"                        {" + Environment.NewLine + 
"                            foreach (string m in _modul)" + Environment.NewLine + 
"                            { sbBuilder.Append(String.Format(\" /addmodule:{0}.netmodule\", m)); }" + Environment.NewLine + 
"                        }" + Environment.NewLine + 
"                    }" + Environment.NewLine + 
"" + Environment.NewLine + 
"                    //  если исходный код содержит ссылки на внешние их необходимо включить в процесс исполнения" + Environment.NewLine + 
"                    if (_ref != null)" + Environment.NewLine + 
"                    {" + Environment.NewLine + 
"                        if (_ref.Count != 0)" + Environment.NewLine + 
"                        {" + Environment.NewLine + 
"                            foreach (string r in _ref)" + Environment.NewLine + 
"                            { sbBuilder.Append(String.Format(\" /reference:{0}.dll\", r)); }" + Environment.NewLine + 
"                        }" + Environment.NewLine + 
"                    }" + Environment.NewLine + 
"" + Environment.NewLine + 
"                    //  в случае, если указаны ручные параметры компиляции добавить их" + Environment.NewLine + 
"                    sbBuilder.Append(\" \");" + Environment.NewLine + 
"                    sbBuilder.Append(_opt);" + Environment.NewLine + 
"" + Environment.NewLine + 
"                    //  собрать все параметры компиляции вместе " + Environment.NewLine + 
"                    cp.CompilerOptions = sbBuilder.ToString();" + Environment.NewLine + 
"                    StringBuilder _sc = new StringBuilder();" + Environment.NewLine + 
"                    foreach (string s in _codes.Values) _sc.Append(s);" + Environment.NewLine + 
"" + Environment.NewLine + 
"                    CompilerResults cr = cdp.CompileAssemblyFromSource(cp, _sc.ToString());" + Environment.NewLine + 
"                    break;" + Environment.NewLine + 
"                case LanguageCode.Fsharp:" + Environment.NewLine + 
"                    foreach (KeyValuePair< string, string > kvp in _codes) File.WriteAllText(kvp.Key, kvp.Value);" + Environment.NewLine + 
"                    //  указать целевую платформу" + Environment.NewLine + 
"                    switch (_targ)" + Environment.NewLine + 
"                    {" + Environment.NewLine + 
"                        case TargetPlatform.x86:" + Environment.NewLine + 
"                            sbBuilder.Append(\" --platform:x86\");" + Environment.NewLine + 
"                            break;" + Environment.NewLine + 
"                        case TargetPlatform.x64:" + Environment.NewLine + 
"                            sbBuilder.Append(\" --platform:x64\");" + Environment.NewLine + 
"                            break;" + Environment.NewLine + 
"                        case TargetPlatform.Itanium:" + Environment.NewLine + 
"                            sbBuilder.Append(\" --platform:Itanium\");" + Environment.NewLine + 
"                            break;" + Environment.NewLine + 
"                        case TargetPlatform.AnyCpu:" + Environment.NewLine + 
"                            break;" + Environment.NewLine + 
"                        default:" + Environment.NewLine + 
"                            break;" + Environment.NewLine + 
"                    }" + Environment.NewLine + 
"" + Environment.NewLine + 
"                    //	добавить все существующие сборки" + Environment.NewLine + 
"                    foreach (string s in referenceAssemblies)" + Environment.NewLine + 
"                    {" + Environment.NewLine + 
"                        string _sTemp = s.Substring(0, s.Length - 4);" + Environment.NewLine + 
"                        sbBuilder.Append(\" --reference:\" + _sTemp);" + Environment.NewLine + 
"                    }" + Environment.NewLine + 
//"                    sbBuilder.Append(\" --reference:FSharp.Core.dll\");" + Environment.NewLine + 
"" + Environment.NewLine + 
"                    //  если исходный код содержит включаемые модули их необходимо включить в процесс исполнения" + Environment.NewLine + 
"                    if (_modul != null)" + Environment.NewLine + 
"                    {" + Environment.NewLine + 
"                        if (_modul.Count != 0)" + Environment.NewLine + 
"                        {" + Environment.NewLine + 
"                            foreach (string m in _modul)" + Environment.NewLine + 
"                            { sbBuilder.Append(String.Format(\" --addmodule:{0}.netmodule\", m)); }" + Environment.NewLine + 
"                        }" + Environment.NewLine + 
"                    }" + Environment.NewLine + 
"" + Environment.NewLine + 
"                    //  если исходный код содержит ссылки на внешние их необходимо включить в процесс исполнения" + Environment.NewLine + 
"                    if (_ref != null)" + Environment.NewLine + 
"                    {" + Environment.NewLine + 
"                        if (_ref.Count != 0)" + Environment.NewLine + 
"                        {" + Environment.NewLine + 
"                            foreach (string r in _ref)" + Environment.NewLine + 
"                            { sbBuilder.Append(String.Format(\" --reference:{0}.dll\", r)); }" + Environment.NewLine + 
"                        }" + Environment.NewLine + 
"                    }" + Environment.NewLine + 
"" + Environment.NewLine + 
"                    if (_cmpl == TypeCompilation.module) sbBuilder.Append(\" --target:module\"); " + Environment.NewLine + 
"                    if (_cmpl == TypeCompilation.winexe) " + Environment.NewLine +
"                    {" + Environment.NewLine +
"                       sbBuilder.Append(\" /target:winexe\");            //  запускаем цикл сообщений WM_***" + Environment.NewLine +
"                       sbBuilder.Append(\" /reference:\\\"C:/Program Files (x86)/Reference Assemblies/Microsoft/Framework/.NETFramework/v4.5/PresentationCore.dll\\\"\"); " + Environment.NewLine +
"                       sbBuilder.Append(\" /reference:\\\"C:/Program Files (x86)/Reference Assemblies/Microsoft/Framework/.NETFramework/v4.5/PresentationFramework.dll\\\"\"); " + Environment.NewLine +
"                       sbBuilder.Append(\" /reference:\\\"C:/Program Files (x86)/Reference Assemblies/Microsoft/Framework/.NETFramework/v4.5/WindowsBase.dll\\\"\"); " + Environment.NewLine +
"                       sbBuilder.Append(\" /reference:System.Xaml.dll\"); " + Environment.NewLine +
"                    }" + Environment.NewLine + 
"			        else if (_cmpl == TypeCompilation.library) sbBuilder.Append(\" --target:library\"); " + Environment.NewLine + 
"			        else if (_cmpl == TypeCompilation.exe) sbBuilder.Append(\" --target:exe\"); " + Environment.NewLine + 
"" + Environment.NewLine + 
"                    //  в случае, если указаны ручные параметры компиляции добавить их" + Environment.NewLine + 
"                    sbBuilder.Append(\" \");" + Environment.NewLine + 
"                    sbBuilder.Append(_opt);" + Environment.NewLine + 
"" + Environment.NewLine + 
"                    StringBuilder _sbsc = new StringBuilder();" + Environment.NewLine + 
"                    foreach (string p in _codes.Keys) " + Environment.NewLine + 
"                    {" + Environment.NewLine + 
"                        _sbsc.Append(\" \");" + Environment.NewLine + 
"                        _sbsc.Append(p);" + Environment.NewLine + 
"                        _sbsc.Append(\" \");" + Environment.NewLine + 
"                    }" + Environment.NewLine + 
"" + Environment.NewLine +
"                    string sCompilerFullOption = String.Format(\" {0} --out:{1} {2}\", _sbsc.ToString(), _file, sbBuilder.ToString());" + Environment.NewLine + 
"" + Environment.NewLine + 
"                    ProcessStartInfo psif = new ProcessStartInfo();" + Environment.NewLine + 
"                    psif.Arguments = sCompilerFullOption;" + Environment.NewLine + 
"                    psif.FileName = \"fsc.exe\";" + Environment.NewLine + 
"" + Environment.NewLine + 
"                    Process proCompile = Process.Start(psif);" + Environment.NewLine + 
"	                 proCompile.WaitForExit();" + Environment.NewLine + 
"                    proCompile.Dispose();" + Environment.NewLine +
"                    proCompile.Close();" + Environment.NewLine +
"                    break;" + Environment.NewLine +
"                case LanguageCode.NotValue:" + Environment.NewLine + 
"                default:" + Environment.NewLine + 
"                    break;" + Environment.NewLine + 
"            }" + Environment.NewLine + 
"" + Environment.NewLine + 
"" + Environment.NewLine + 
"        }" + Environment.NewLine + 
"    }" + Environment.NewLine + 
"}";

    }
}
