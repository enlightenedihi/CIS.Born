using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS.Born
{
    /// <summary>
    /// класс, описывающий результаты компиляции (основной объект)
    /// </summary>
    public class Result
    {
        /// <summary>
        /// строка сообщений об ошибках и предупреждениях 
        /// </summary>
        public string ErrorWarning;

        /// <summary>
        /// строка ссылки на полученную сборку (в виде URI)
        /// </summary>
        public string ReferenceToAssembly;

        /// <summary>
        /// имя скомпилированного файла
        /// </summary>
        public string NameFile;

        /// <summary>
        /// признак успешности компиляции
        /// </summary>
        public bool SuccessCompile;
    }
}
