using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SystemUpdateVersion.Models;

namespace SystemUpdateVersion.Hepler
{
    public class CSL
    {
        /// <summary>
        /// Label字典中获取指定Label，如果获取指点LabelName不存在会throw异常
        /// </summary>
        /// <param name="LabelName">枚举类型LabelName</param>
        /// <returns>Labelvalue</returns>
        public static string Get(Enum LabelName)
        {
            string region = INIHelper.ReadIni("AppLanguage", "Language", "Chinese", 255, Environment.CurrentDirectory + @"/Config.ini");
            string value = string.Empty;
            try
            {
                value = GetEnumAtt(LabelName, region);
            }
            catch (Exception e)
            {
                
            }
            if ("Chinese-Traditional".Equals(region))
            {
                value = LanguageTool.SimplifiedToTraditional(value);
            }
            //value = string.IsNullOrEmpty(value) ? $"{LabelName}" : $"{LabelName}:{value}";
            value = string.IsNullOrEmpty(value) ? $" {LabelName} " : $" {value} ";
            return value;
        }

        /// <summary>
        /// Label字典中获取指定Label，如果获取指点LabelName不存在会throw异常,参数个数小于Label中替换标识数量也会throw异常
        /// <para>
        /// Label获取后接收参入格式化参数，即使用类似string.Format()。需要注意的Label中的【替换标识】必须以#开头，空格结尾；【参数顺序】与【替换标识】顺序保持一致
        /// </para>
        /// <para>
        /// 单个替换标识正确使用：CSL.Get(CLSE.CombineLot_E0002,"20230616001");(CLSE.CombineLot_E0002内容为：#CONTAINER 处于 INTRANSIT 工步 - 不允许合并)
        /// </para>
        /// <para>
        /// 多个替换标识正确使用：CSL.Get(CLSE.CombineLot_E0003,"20230616001",1000);(CLSE.CombineLot_E0002内容为：#CONTAINER 的Qty为：#QTY )
        /// </para>
        /// </summary>
        /// <param name="LabelName">LabelName</param>
        /// <param name="args">参数(0-n)</param>
        /// <returns>格式化后的Value</returns>
        public static string Get(Enum LabelName, params object[] args)
        {
            string region = INIHelper.ReadIni("AppLanguage", "Language", "Chinese", 255, Environment.CurrentDirectory + @"/Config.ini");
            string value = string.Empty;
            string label = string.Empty;
            try
            {
                label = GetEnumAtt(LabelName, region);
            }
            catch (Exception e)
            {
                label = GetEnumAtt(LabelName, region);
            }
            try
            {
                string[] labelParam = ExtractIdentifiers(label);
                if (labelParam.Length > 0)
                {
                    value = RelpaceIdentifiers(label, labelParam, args);
                }
                else
                {
                    value = label;
                }
            }
            catch (Exception e)
            {
                value = e.Message;
            }
            //繁体中文转换
            if ("Chinese-Traditional".Equals(region))
            {
                value = LanguageTool.SimplifiedToTraditional(value);
            }
            //value = string.IsNullOrEmpty(value) ? $"{LabelName}" : $"{LabelName}:{value}";
            value = string.IsNullOrEmpty(value) ? $" {LabelName} " : $" {value} ";
            return value;
        }

        /// <summary>
        /// 获取Label枚举属性上的标签中的labelValue
        /// </summary>
        /// <param name="_key"></param>
        /// <param name="_Language"></param>
        /// <returns></returns>
        private static string GetEnumAtt(Enum _key, string _Language)
        {
            FieldInfo field = _key.GetType().GetField(_key.ToString());
            CL attribute = field
                .GetCustomAttributes(typeof(CL), false)
                .OfType<CL>()
                .FirstOrDefault();
            if (attribute != null)
            {
                string[] comments = { attribute.Chinese ?? _key.ToString(), attribute.English ?? _key.ToString() };
                if ("English".Equals(_Language))
                {
                    if (comments[1].Trim().StartsWith(_Language + ":"))
                    {
                        string _v = string.Empty;
                        try
                        {
                            _v = comments[1].Trim().Substring(_Language.Length + 1);
                        }
                        catch (Exception e)
                        {
                            _v = string.Empty;
                        }
                        return _v;
                    }
                    return comments[1].Trim();
                }

                if ("Chinese".Equals(_Language))
                {
                    if (comments[0].Trim().StartsWith(_Language + ":"))
                    {
                        string _v = string.Empty;
                        try
                        {
                            _v = comments[0].Trim().Substring(_Language.Length + 1);
                        }
                        catch (Exception e)
                        {
                            _v = string.Empty;
                        }
                        return _v;
                    }
                    return comments[0].Trim();
                }
            }
            return _key.ToString().Trim();
        }

        /// <summary>
        /// 清洗获取LabelValue中的替换标签
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string[] ExtractIdentifiers(string input)
        {

            Regex regex = new Regex("#(\\w+)");
            MatchCollection matches = regex.Matches(input);
            string[] identifiers = new string[matches.Count];
            for (int i = 0; i < matches.Count; i++)
            {
                identifiers[i] = matches[i].Groups[1].Value;
            }
            return identifiers;
        }

        /// <summary>
        /// 替换标识标签（按照传参顺序）
        /// </summary>
        /// <param name="input"></param>
        /// <param name="identifiers"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string RelpaceIdentifiers(string input, string[] identifiers, object[] parameters)
        {
            string region = INIHelper.ReadIni("AppLanguage", "Language", "Chinese", 255, Environment.CurrentDirectory + @"/Config.ini");
            if (identifiers.Length > parameters.Length)
            {
                if ("Chinese".Equals(region))
                {
                    throw new Exception($"Label参数数量与替换参数不一致，请检查LabelName或传参！");
                }
                if ("English".Equals(region))
                {
                    throw new Exception($"Label The number of parameters does not match the replacement parameters,Please check the parameter！");
                }
                throw new Exception($"Label The number of parameters does not match the replacement parameters,Please check the parameter！");
            }
            for (int i = 0; i < identifiers.Length; i++)
            {
                string pattern = $"#{identifiers[i]}";
                string replacement = parameters[i].ToString();
                input = Regex.Replace(input, pattern, replacement);
            }
            return input;
        }

        internal static string Get(object r_L_Delect_Error)
        {
            throw new NotImplementedException();
        }
    }
}
