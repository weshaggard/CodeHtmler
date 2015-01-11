/*
 * Author: Wes Haggard
 * Weblog: http://weblogs.asp.net/whaggard/
 * 
 * This project is an open source project and the code can be used and distrubed freely. 
 * All I ask in return is that credit is given where credit is due.
 * 
 * Copyright © 2003-2004, Wes Haggard. All rights reserved. No warranties extended
 * 
 */
using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections;
using System.ComponentModel;
using System.Reflection;

namespace CodeHtmler
{
    /// <summary>
    /// This class holds a collection of languages that can be used to convert
    /// plain text code to html colorized code. It also contains methods for loading/saving
    /// an xml file with all languages so they can be presisted across different executions of 
    /// an application. 
    /// </summary>
    [XmlInclude(typeof(Language))]
    public class Languages
    {
        #region Fields
        public const string UserFilename = "LanguageDefinitions.xml";
        public const string AppFilename = "DefaultLanguageDefinitions.xml";
        private ArrayList codeLanguages = new ArrayList();
        #endregion

        #region Public Interface
        /// <summary>
        /// A list of all the defined languages.
        /// </summary>
        [XmlArrayItem(typeof(Language))]
        [Editor(typeof(LanguageCollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ArrayList CodeLanguages
        {
            get { return codeLanguages; }
        }
        /// <summary>
        /// This method will return a language for with the paricular name/description and if
        /// one deosn't exist then an empty language object is returned.
        /// </summary>
        /// <param name="langName"></param>
        /// <returns></returns>
        public Language FindLanguage(string langName)
        {
            foreach (Language lang in this.CodeLanguages)
                if (lang.Name.Equals(langName))
                    return lang;

            return new Language();
        }
        /// <summary>
        /// This method will return a language for with the paricular name/description and if
        /// one deosn't exist then an empty language object is returned.
        /// </summary>
        /// <param name="langName"></param>
        /// <returns></returns>
        public static Language GetLanguage(string langName)
        {
            Languages langs = Load();

            return langs.FindLanguage(langName);
        }
        /// <summary>
        /// This will load the language definitions from the given file location it will
        /// attempt to do an XML Deserialization of the file.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static Languages Load(string filename)
        {
            Languages langs = null;
            try
            {
                if (File.Exists(filename))
                {
                    using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                    {
                        langs = Load(fs);
                    }
                }
            }
            catch
            {
                return null;
            }
            return langs;
        }
        /// <summary>
        /// This will load the language definitions from the given stream it will
        /// attempt to do an XML Deserialization of the stream.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static Languages Load(Stream stream)
        {
            Languages langs = null;
            try
            {
                if (stream != null)
                {
                    LanguagesSerializer serializer = new LanguagesSerializer();
                    langs = (Languages)serializer.Deserialize(stream);
                }
            }
            catch
            {
                return null;
            }
            return langs;
        }
        /// <summary>
        /// This method will try to load the language definitions from default locations.
        /// Looks in the following directories:
        /// 1) %USERPROFILE%\%APPDATA%\[CurrentAppName]\LanguageDefinitions.xml
        /// 2) [EntryExecutablePath]\DefaultLanguagDefintions.xml
        /// 3) Embedded resource xml file
        /// 
        /// if none of the about work then an empty Languages object is returned.
        /// </summary>
        /// <returns></returns>
        public static Languages Load()
        {
            Languages langs = null;

            langs = Load(GetUserPath());

            if (langs == null || langs.CodeLanguages.Count == 0)
                langs = Load(GetProgramPath());

            if (langs == null || langs.CodeLanguages.Count == 0)
            {
                using (Stream stream = typeof(Languages).Assembly.GetManifestResourceStream("CodeHtmler.DefaultLanguageDefinitions.xml"))
                {
                    langs = Load(stream);
                }
            }

            if (langs == null)
                langs = new Languages();

            return langs;
        }
        /// <summary>
        /// This method will write the current language defintions to the file given.
        /// It will do an XML serialization to write the file. 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool Save(string filename)
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(filename)))
                    Directory.CreateDirectory(Path.GetDirectoryName(filename));

                using (FileStream fs = new FileStream(filename, FileMode.Create))
                {
                    LanguagesSerializer serializer = new LanguagesSerializer();
                    serializer.Serialize(fs, this);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// This method will write the language definitions to the following path:
        /// %USERPROFILE%\%APPDATA%\[CurrentAppName]\LanguageDefinitions.xml
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            return Save(GetUserPath());
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// This will get the user path for retrieve/storing language definition file.
        /// </summary>
        /// <returns></returns>
        private static string GetUserPath()
        {
            try
            {
                string appName = "CodeHtmler";
                if (Assembly.GetEntryAssembly() != null)
                    appName = Assembly.GetEntryAssembly().GetName().Name;

                string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                return Path.Combine(Path.Combine(appData, appName), UserFilename);
            }
            catch (System.Security.SecurityException)
            {
                return UserFilename;
            }
        }
        /// <summary>
        /// This will get the path of the assembly this class is in is running from.
        /// </summary>
        /// <returns></returns>
        private static string GetProgramPath()
        {
            try
            {
                string exePath = Path.GetDirectoryName(typeof(Languages).Assembly.Location);
                return Path.Combine(exePath, AppFilename);
            }
            catch (System.Security.SecurityException)
            {
                return AppFilename;
            }
        }
        #endregion
    }
}
