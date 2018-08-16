using System;
using System.IO;
using System.Text.RegularExpressions;

namespace TextReplacer
{
    public class TextProcessor
    {
        public string GetVersion(string filePath)
        {
            var regexRow = new Regex(@"\[assembly: AssemblyVersion\(\""\d+.\d+.\d+.\d+\""\)\]");
            var regexVersion = new Regex(@"\d+.\d+.\d+.\d+");

            var alltext = File.ReadAllText(filePath);
            var rowVal = regexRow.Match(alltext);
            var versionVal = regexVersion.Match(rowVal.Value);

            return versionVal.Value;
        }

        public void ReplaceText(string fileName, string sourceText, string targetTExt)
        {
            var position = (int)GetTextPosition(fileName, sourceText);
            if (position < 0)
            {
                throw new AggregateException($"SourceText NOT FOUND in file {fileName}!");;
            }

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                if(fs.Length > int.MaxValue)
                    throw new AggregateException($"Size of file {fileName} is more then integer type size!");

                var rewritingBytesLength = (int)fs.Length - position - sourceText.Length;

                byte[] rewritingBytes = new byte[rewritingBytesLength];

                fs.Seek(position + sourceText.Length, SeekOrigin.Begin);
                fs.Read(rewritingBytes, 0, rewritingBytesLength);
    
                var chTarget = targetTExt.ToCharArray();
                var chTargetBytes = new byte[chTarget.Length];
                for (int i = 0; i < chTarget.Length; i++)
                {
                    chTargetBytes[i] = (byte)chTarget[i];
                }

                fs.Seek(position, SeekOrigin.Begin);
                fs.Write(chTargetBytes, 0, chTargetBytes.Length);
                fs.Write(rewritingBytes, 0, rewritingBytesLength);
            }
        }

        private long GetTextPosition(string fileName, string text)
        {
            const int DEFAULT_VALUE = -1;

            var chSource = text.ToCharArray();
            char[] chResult = new char[chSource.Length];

            long changeStartPosition = DEFAULT_VALUE;

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                int index = 0;//индекс массива символов

                while (fs.Position != fs.Length)
                {
                    var b = (char)fs.ReadByte();
                    chResult[index] = b;
                    if (b == chSource[index])
                    {
                        if (index == 0)
                        {
                            changeStartPosition = fs.Position - 1;//минус 1, т.к. ReadByte переводит позицию вперёд
                        }

                        index++;//если считываемые символы совпадают с исходными, счётчик будет непрерывно увеличиваться
                    }
                    else if(index != 0)
                    {
                        //при первом несовпадении, счётчик сбрасывается
                        index = 0;
                        changeStartPosition = DEFAULT_VALUE;
                    }

                    if (index == chSource.Length)
                        break;//все символы текста найдены
                }

                //если цикл пройдёт до конца файла, но не все символы текста найдены
                if (index != chSource.Length)
                    changeStartPosition = DEFAULT_VALUE;
            }

            return changeStartPosition;
        }
    }
}
