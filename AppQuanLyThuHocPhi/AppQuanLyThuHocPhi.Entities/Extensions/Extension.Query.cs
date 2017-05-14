using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AppQuanLyThuHocPhi.Entities.Extensions
{
   public static partial class Extension
    {
        public static IQueryable<T> Including<T>(this IQueryable<T> self, params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            return includeProperties.Aggregate(self, (current, includeProperty) => current.Include(includeProperty));
        }
        public static string ToErrorMessage(this Exception ex)
        {
            if (ex == null) return string.Empty;

            var msg = "Exception: " + ex.Message;
            if (ex.InnerException != null)
            {
                msg += ". Inner_exception: " + ex.InnerException.Message;

                if (ex.InnerException.InnerException != null)
                    msg += ". Deep_exception: " + ex.InnerException.InnerException.Message;
            }

            if (ex.GetType() == typeof(System.Data.Entity.Validation.DbEntityValidationException))
            {
                msg += ". Validation_exception: " + (ex as System.Data.Entity.Validation.DbEntityValidationException)
                    .EntityValidationErrors
                    .SelectMany(e => e.ValidationErrors)
                    .Select(e => string.Format("property: {0} -> {1}", e.PropertyName, e.ErrorMessage))
                    .ToSingle();
            }

            return msg;
        }

        public static string Truncate(this string s, int length = 20, string endOfLine = "...")
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            if (s.Length <= length)
                return s;

            return s.Substring(0, length) + endOfLine;
        }

        /// <summary>
        /// aggregate collection of string into single string, separate by divider
        /// </summary>
        /// <param name="list"></param>
        /// <param name="divider"></param>
        /// <returns></returns>
        public static string ToSingle(this IEnumerable<string> list, string divider = "\r\n")
        {
            if (list == null || list.Any() == false) return string.Empty;
            return list.Aggregate((x, y) => x + divider + y);
        }

        /// <summary>
        /// split given string into list of string by given pattern
        /// </summary>
        /// <param name="s"></param>
        /// <param name="by"></param>
        /// <returns></returns>
        public static List<string> SplitBy(this string s, string by = "\r\n")
        {
            if (string.IsNullOrEmpty(s))
                return new List<string>();

            var temp = Regex.Split(s, by);
            var arr = (from c in temp
                       where !string.IsNullOrEmpty(c) && !string.IsNullOrWhiteSpace(c)
                       select c.Trim()).ToList();

            return arr;

        }

        public static string ToPermalink(this string s, int maxLength = 50)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            string phrase = s;
            string slug = phrase.RemoveMark().ToLower();

            // remove invalid chars
            slug = Regex.Replace(slug, @"[^a-z0-9\s-]", string.Empty);

            // convert multiple spaces into one
            slug = Regex.Replace(slug, @"\s+", " ").Trim();

            // cut and trim
            slug = slug.Substring(0, slug.Length <= maxLength ? slug.Length : maxLength).Trim();

            // hyphens
            slug = Regex.Replace(slug, @"\s", "-").Trim().Trim('-');

            return slug;
        }

        /// <summary>
        /// capitalize input string: 'lorem ipsum dolor sit amet' -> 'Lorem Ipsum Dolor Sit Amet'
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToCapitalize(this string input)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            input = textInfo.ToTitleCase(input);

            return input;
        }

        /// <summary>
        /// remove unicode characters
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string RemoveMark(this string input)
        {
            var regex = new System.Text.RegularExpressions.Regex("\\p{IsCombiningDiacriticalMarks}+");
            var formD = input.Normalize(NormalizationForm.FormD);

            return regex.Replace(formD, string.Empty)
                .Replace('\u0111', 'd')
                .Replace('\u0110', 'D');
        }

        public static int ToInt(this string number, int defaultValue = 0)
        {
            int temp;
            if (int.TryParse(number, out temp))
                return temp;

            return defaultValue;
        }

        public static float ToFloat(this string number, float defaultValue = 0)
        {
            float temp;
            if (float.TryParse(number, out temp))
                return temp;

            return defaultValue;
        }

        public static bool IsGuid(this string s)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
                return false;

            Guid id;
            return Guid.TryParse(s, out id);
        }

        public static Guid ToGuid(this string s)
        {
            if (!IsGuid(s))
                return Guid.Empty;

            return Guid.Parse(s);
        }

        public static string ToFormat(this string format, params object[] args)
        {
            if (string.IsNullOrEmpty(format) || string.IsNullOrWhiteSpace(format))
                return string.Empty;

            return string.Format(format, args);
        }
    }
}
