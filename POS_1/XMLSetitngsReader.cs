using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace POS_1
{
    class XMLSetitngsReader
    {
        private String documentString = "SettingFile.xml";
        public XMLSetitngsReader()
        {
            try
            {
                XDocument d = XDocument.Load(documentString);
            }catch(Exception ex)
            {
                ConfigureForm cf = new ConfigureForm(documentString);
                cf.Visible = true;
            }
        }
        public void InsertItem(String name,String value)
        {
            try
            {
                var doc = XDocument.Load(documentString);
                doc.Root.Element(name).Value = value;
                doc.Save(documentString);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public String ReadValue(String name)
        {
            XDocument doc = XDocument.Load(documentString);
            foreach(var node in doc.DescendantNodes())
            {
                if(node is XElement)
                {
                    XElement xe = (XElement)node;
                    //System.Windows.Forms.MessageBox.Show(xe.Name.ToString(),);
                    if (xe.Name.ToString().Equals(name))
                    {
                        return xe.Value;
                    }
                }
            }
            return null;
        }
    }
}
