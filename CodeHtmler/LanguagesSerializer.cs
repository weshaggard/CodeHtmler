// Generated with command >sgen codehtmler.dll /k /force /type:CodeHtmler.Languages
namespace CodeHtmler 
{
    public class XmlSerializationWriterLanguages : System.Xml.Serialization.XmlSerializationWriter {

        public void Write6_Languages(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"Languages", @"");
                return;
            }
            TopLevelElement();
            Write5_Languages(@"Languages", @"", ((global::CodeHtmler.Languages)o), true, false);
        }

        void Write5_Languages(string n, string ns, global::CodeHtmler.Languages o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::CodeHtmler.Languages)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"Languages", @"");
            {
                global::System.Collections.ArrayList a = (global::System.Collections.ArrayList)((global::System.Collections.ArrayList)o.@CodeLanguages);
                if (a != null){
                    WriteStartElement(@"CodeLanguages", @"", null, false);
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        Write4_Language(@"Language", @"", ((global::CodeHtmler.Language)a[ia]), true, false);
                    }
                    WriteEndElement();
                }
            }
            WriteEndElement(o);
        }

        void Write4_Language(string n, string ns, global::CodeHtmler.Language o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::CodeHtmler.Language)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"Language", @"");
            WriteAttribute(@"Name", @"", ((global::System.String)o.@Name));
            WriteAttribute(@"StyleType", @"", Write3_StyleType(((global::CodeHtmler.StyleType)o.@StyleType)));
            WriteAttribute(@"EscapeHtml", @"", System.Xml.XmlConvert.ToString((global::System.Boolean)((global::System.Boolean)o.@EscapeHtml)));
            WriteAttribute(@"UsePreTag", @"", System.Xml.XmlConvert.ToString((global::System.Boolean)((global::System.Boolean)o.@UsePreTag)));
            WriteAttribute(@"ShowLineNumbers", @"", System.Xml.XmlConvert.ToString((global::System.Boolean)((global::System.Boolean)o.@ShowLineNumbers)));
            WriteAttribute(@"LineNumberColor", @"", ((global::System.String)o.@LineNumberColor));
            WriteAttribute(@"LineNumberBackColor", @"", ((global::System.String)o.@LineNumberBackColor));
            WriteAttribute(@"CodeBackColor", @"", ((global::System.String)o.@CodeBackColor));
            WriteAttribute(@"DivInlineStyleFont", @"", ((global::System.String)o.@DivInlineStyleFont));
            {
                global::System.Collections.ArrayList a = (global::System.Collections.ArrayList)((global::System.Collections.ArrayList)o.@CodeElements);
                if (a != null){
                    WriteStartElement(@"CodeElements", @"", null, false);
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        Write2_CodeElement(@"CodeElement", @"", ((global::CodeHtmler.CodeElement)a[ia]), true, false);
                    }
                    WriteEndElement();
                }
            }
            WriteEndElement(o);
        }

        void Write2_CodeElement(string n, string ns, global::CodeHtmler.CodeElement o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::CodeHtmler.CodeElement)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"CodeElement", @"");
            WriteAttribute(@"Name", @"", ((global::System.String)o.@Name));
            WriteAttribute(@"Color", @"", ((global::System.String)o.@Color));
            WriteAttribute(@"BackColor", @"", ((global::System.String)o.@BackColor));
            WriteAttribute(@"Bold", @"", System.Xml.XmlConvert.ToString((global::System.Boolean)((global::System.Boolean)o.@Bold)));
            WriteAttribute(@"Italics", @"", System.Xml.XmlConvert.ToString((global::System.Boolean)((global::System.Boolean)o.@Italics)));
            WriteElementString(@"Pattern", @"", ((global::System.String)o.@Pattern));
            WriteEndElement(o);
        }

        string Write3_StyleType(global::CodeHtmler.StyleType v) {
            string s = null;
            switch (v) {
                case global::CodeHtmler.StyleType.@InlineStyles: s = @"InlineStyles"; break;
                case global::CodeHtmler.StyleType.@InlineTags: s = @"InlineTags"; break;
                case global::CodeHtmler.StyleType.@GlobalStyles: s = @"GlobalStyles"; break;
                default: throw CreateInvalidEnumValueException(((System.Int64)v).ToString(System.Globalization.CultureInfo.InvariantCulture), @"CodeHtmler.StyleType");
            }
            return s;
        }

        protected override void InitCallbacks() {
        }
    }

    public class XmlSerializationReaderLanguages : System.Xml.Serialization.XmlSerializationReader {

        public object Read6_Languages() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                if (((object) Reader.LocalName == (object)id1_Languages && (object) Reader.NamespaceURI == (object)id2_Item)) {
                    o = Read5_Languages(true, true);
                }
                else {
                    throw CreateUnknownNodeException();
                }
            }
            else {
                UnknownNode(null, @":Languages");
            }
            return (object)o;
        }

        global::CodeHtmler.Languages Read5_Languages(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id1_Languages && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::CodeHtmler.Languages o;
            o = new global::CodeHtmler.Languages();
            global::System.Collections.ArrayList a_0 = (global::System.Collections.ArrayList)o.@CodeLanguages;
            bool[] paramsRead = new bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations0 = 0;
            int readerCount0 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (((object) Reader.LocalName == (object)id3_CodeLanguages && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        if (!ReadNull()) {
                            global::System.Collections.ArrayList a_0_0 = (global::System.Collections.ArrayList)o.@CodeLanguages;
                            if (((object)(a_0_0) == null) || (Reader.IsEmptyElement)) {
                                Reader.Skip();
                            }
                            else {
                                Reader.ReadStartElement();
                                Reader.MoveToContent();
                                int whileIterations1 = 0;
                                int readerCount1 = ReaderCount;
                                while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                                    if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                                        if (((object) Reader.LocalName == (object)id4_Language && (object) Reader.NamespaceURI == (object)id2_Item)) {
                                            if ((object)(a_0_0) == null) Reader.Skip(); else a_0_0.Add(Read4_Language(true, true));
                                        }
                                        else {
                                            UnknownNode(null, @":Language");
                                        }
                                    }
                                    else {
                                        UnknownNode(null, @":Language");
                                    }
                                    Reader.MoveToContent();
                                    CheckReaderCount(ref whileIterations1, ref readerCount1);
                                }
                            ReadEndElement();
                            }
                        }
                    }
                    else {
                        UnknownNode((object)o, @":CodeLanguages");
                    }
                }
                else {
                    UnknownNode((object)o, @":CodeLanguages");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations0, ref readerCount0);
            }
            ReadEndElement();
            return o;
        }

        global::CodeHtmler.Language Read4_Language(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Language && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::CodeHtmler.Language o;
            o = new global::CodeHtmler.Language();
            global::System.Collections.ArrayList a_1 = (global::System.Collections.ArrayList)o.@CodeElements;
            bool[] paramsRead = new bool[10];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[0] && ((object) Reader.LocalName == (object)id5_Name && (object) Reader.NamespaceURI == (object)id2_Item)) {
                    o.@Name = Reader.Value;
                    paramsRead[0] = true;
                }
                else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id6_StyleType && (object) Reader.NamespaceURI == (object)id2_Item)) {
                    o.@StyleType = Read3_StyleType(Reader.Value);
                    paramsRead[2] = true;
                }
                else if (!paramsRead[3] && ((object) Reader.LocalName == (object)id7_EscapeHtml && (object) Reader.NamespaceURI == (object)id2_Item)) {
                    o.@EscapeHtml = System.Xml.XmlConvert.ToBoolean(Reader.Value);
                    paramsRead[3] = true;
                }
                else if (!paramsRead[4] && ((object) Reader.LocalName == (object)id8_UsePreTag && (object) Reader.NamespaceURI == (object)id2_Item)) {
                    o.@UsePreTag = System.Xml.XmlConvert.ToBoolean(Reader.Value);
                    paramsRead[4] = true;
                }
                else if (!paramsRead[5] && ((object) Reader.LocalName == (object)id9_ShowLineNumbers && (object) Reader.NamespaceURI == (object)id2_Item)) {
                    o.@ShowLineNumbers = System.Xml.XmlConvert.ToBoolean(Reader.Value);
                    paramsRead[5] = true;
                }
                else if (!paramsRead[6] && ((object) Reader.LocalName == (object)id10_LineNumberColor && (object) Reader.NamespaceURI == (object)id2_Item)) {
                    o.@LineNumberColor = Reader.Value;
                    paramsRead[6] = true;
                }
                else if (!paramsRead[7] && ((object) Reader.LocalName == (object)id11_LineNumberBackColor && (object) Reader.NamespaceURI == (object)id2_Item)) {
                    o.@LineNumberBackColor = Reader.Value;
                    paramsRead[7] = true;
                }
                else if (!paramsRead[8] && ((object) Reader.LocalName == (object)id12_CodeBackColor && (object) Reader.NamespaceURI == (object)id2_Item)) {
                    o.@CodeBackColor = Reader.Value;
                    paramsRead[8] = true;
                }
                else if (!paramsRead[9] && ((object) Reader.LocalName == (object)id13_DivInlineStyleFont && (object) Reader.NamespaceURI == (object)id2_Item)) {
                    o.@DivInlineStyleFont = Reader.Value;
                    paramsRead[9] = true;
                }
                else if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o, @":Name, :StyleType, :EscapeHtml, :UsePreTag, :ShowLineNumbers, :LineNumberColor, :LineNumberBackColor, :CodeBackColor, :DivInlineStyleFont");
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations2 = 0;
            int readerCount2 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (((object) Reader.LocalName == (object)id14_CodeElements && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        if (!ReadNull()) {
                            global::System.Collections.ArrayList a_1_0 = (global::System.Collections.ArrayList)o.@CodeElements;
                            if (((object)(a_1_0) == null) || (Reader.IsEmptyElement)) {
                                Reader.Skip();
                            }
                            else {
                                Reader.ReadStartElement();
                                Reader.MoveToContent();
                                int whileIterations3 = 0;
                                int readerCount3 = ReaderCount;
                                while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                                    if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                                        if (((object) Reader.LocalName == (object)id15_CodeElement && (object) Reader.NamespaceURI == (object)id2_Item)) {
                                            if ((object)(a_1_0) == null) Reader.Skip(); else a_1_0.Add(Read2_CodeElement(true, true));
                                        }
                                        else {
                                            UnknownNode(null, @":CodeElement");
                                        }
                                    }
                                    else {
                                        UnknownNode(null, @":CodeElement");
                                    }
                                    Reader.MoveToContent();
                                    CheckReaderCount(ref whileIterations3, ref readerCount3);
                                }
                            ReadEndElement();
                            }
                        }
                    }
                    else {
                        UnknownNode((object)o, @":CodeElements");
                    }
                }
                else {
                    UnknownNode((object)o, @":CodeElements");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations2, ref readerCount2);
            }
            ReadEndElement();
            return o;
        }

        global::CodeHtmler.CodeElement Read2_CodeElement(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id15_CodeElement && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::CodeHtmler.CodeElement o;
            o = new global::CodeHtmler.CodeElement();
            bool[] paramsRead = new bool[6];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[0] && ((object) Reader.LocalName == (object)id5_Name && (object) Reader.NamespaceURI == (object)id2_Item)) {
                    o.@Name = Reader.Value;
                    paramsRead[0] = true;
                }
                else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id16_Color && (object) Reader.NamespaceURI == (object)id2_Item)) {
                    o.@Color = Reader.Value;
                    paramsRead[2] = true;
                }
                else if (!paramsRead[3] && ((object) Reader.LocalName == (object)id17_BackColor && (object) Reader.NamespaceURI == (object)id2_Item)) {
                    o.@BackColor = Reader.Value;
                    paramsRead[3] = true;
                }
                else if (!paramsRead[4] && ((object) Reader.LocalName == (object)id18_Bold && (object) Reader.NamespaceURI == (object)id2_Item)) {
                    o.@Bold = System.Xml.XmlConvert.ToBoolean(Reader.Value);
                    paramsRead[4] = true;
                }
                else if (!paramsRead[5] && ((object) Reader.LocalName == (object)id19_Italics && (object) Reader.NamespaceURI == (object)id2_Item)) {
                    o.@Italics = System.Xml.XmlConvert.ToBoolean(Reader.Value);
                    paramsRead[5] = true;
                }
                else if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o, @":Name, :Color, :BackColor, :Bold, :Italics");
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations4 = 0;
            int readerCount4 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[1] && ((object) Reader.LocalName == (object)id20_Pattern && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        {
                            o.@Pattern = Reader.ReadElementString();
                        }
                        paramsRead[1] = true;
                    }
                    else {
                        UnknownNode((object)o, @":Pattern");
                    }
                }
                else {
                    UnknownNode((object)o, @":Pattern");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations4, ref readerCount4);
            }
            ReadEndElement();
            return o;
        }

        global::CodeHtmler.StyleType Read3_StyleType(string s) {
            switch (s) {
                case @"InlineStyles": return global::CodeHtmler.StyleType.@InlineStyles;
                case @"InlineTags": return global::CodeHtmler.StyleType.@InlineTags;
                case @"GlobalStyles": return global::CodeHtmler.StyleType.@GlobalStyles;
                default: throw CreateUnknownConstantException(s, typeof(global::CodeHtmler.StyleType));
            }
        }

        protected override void InitCallbacks() {
        }

        string id17_BackColor;
        string id8_UsePreTag;
        string id14_CodeElements;
        string id15_CodeElement;
        string id12_CodeBackColor;
        string id7_EscapeHtml;
        string id19_Italics;
        string id16_Color;
        string id1_Languages;
        string id3_CodeLanguages;
        string id2_Item;
        string id10_LineNumberColor;
        string id5_Name;
        string id4_Language;
        string id9_ShowLineNumbers;
        string id20_Pattern;
        string id13_DivInlineStyleFont;
        string id6_StyleType;
        string id18_Bold;
        string id11_LineNumberBackColor;

        protected override void InitIDs() {
            id17_BackColor = Reader.NameTable.Add(@"BackColor");
            id8_UsePreTag = Reader.NameTable.Add(@"UsePreTag");
            id14_CodeElements = Reader.NameTable.Add(@"CodeElements");
            id15_CodeElement = Reader.NameTable.Add(@"CodeElement");
            id12_CodeBackColor = Reader.NameTable.Add(@"CodeBackColor");
            id7_EscapeHtml = Reader.NameTable.Add(@"EscapeHtml");
            id19_Italics = Reader.NameTable.Add(@"Italics");
            id16_Color = Reader.NameTable.Add(@"Color");
            id1_Languages = Reader.NameTable.Add(@"Languages");
            id3_CodeLanguages = Reader.NameTable.Add(@"CodeLanguages");
            id2_Item = Reader.NameTable.Add(@"");
            id10_LineNumberColor = Reader.NameTable.Add(@"LineNumberColor");
            id5_Name = Reader.NameTable.Add(@"Name");
            id4_Language = Reader.NameTable.Add(@"Language");
            id9_ShowLineNumbers = Reader.NameTable.Add(@"ShowLineNumbers");
            id20_Pattern = Reader.NameTable.Add(@"Pattern");
            id13_DivInlineStyleFont = Reader.NameTable.Add(@"DivInlineStyleFont");
            id6_StyleType = Reader.NameTable.Add(@"StyleType");
            id18_Bold = Reader.NameTable.Add(@"Bold");
            id11_LineNumberBackColor = Reader.NameTable.Add(@"LineNumberBackColor");
        }
    }

    public abstract class XmlSerializer1 : System.Xml.Serialization.XmlSerializer {
        protected override System.Xml.Serialization.XmlSerializationReader CreateReader() {
            return new XmlSerializationReaderLanguages();
        }
        protected override System.Xml.Serialization.XmlSerializationWriter CreateWriter() {
            return new XmlSerializationWriterLanguages();
        }
    }

    public sealed class LanguagesSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"Languages", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriterLanguages)writer).Write6_Languages(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReaderLanguages)reader).Read6_Languages();
        }
    }

    public class XmlSerializerContract : global::System.Xml.Serialization.XmlSerializerImplementation {
        public override global::System.Xml.Serialization.XmlSerializationReader Reader { get { return new XmlSerializationReaderLanguages(); } }
        public override global::System.Xml.Serialization.XmlSerializationWriter Writer { get { return new XmlSerializationWriterLanguages(); } }
        System.Collections.Hashtable readMethods = null;
        public override System.Collections.Hashtable ReadMethods {
            get {
                if (readMethods == null) {
                    System.Collections.Hashtable _tmp = new System.Collections.Hashtable();
                    _tmp[@"CodeHtmler.Languages::"] = @"Read6_Languages";
                    if (readMethods == null) readMethods = _tmp;
                }
                return readMethods;
            }
        }
        System.Collections.Hashtable writeMethods = null;
        public override System.Collections.Hashtable WriteMethods {
            get {
                if (writeMethods == null) {
                    System.Collections.Hashtable _tmp = new System.Collections.Hashtable();
                    _tmp[@"CodeHtmler.Languages::"] = @"Write6_Languages";
                    if (writeMethods == null) writeMethods = _tmp;
                }
                return writeMethods;
            }
        }
        System.Collections.Hashtable typedSerializers = null;
        public override System.Collections.Hashtable TypedSerializers {
            get {
                if (typedSerializers == null) {
                    System.Collections.Hashtable _tmp = new System.Collections.Hashtable();
                    _tmp.Add(@"CodeHtmler.Languages::", new LanguagesSerializer());
                    if (typedSerializers == null) typedSerializers = _tmp;
                }
                return typedSerializers;
            }
        }
        public override System.Boolean CanSerialize(System.Type type) {
            if (type == typeof(global::CodeHtmler.Languages)) return true;
            return false;
        }
        public override System.Xml.Serialization.XmlSerializer GetSerializer(System.Type type) {
            if (type == typeof(global::CodeHtmler.Languages)) return new LanguagesSerializer();
            return null;
        }
    }
}
