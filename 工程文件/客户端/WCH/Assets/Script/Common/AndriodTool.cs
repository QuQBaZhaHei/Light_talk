

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace WCH
{
    public class AndriodTool 
    {
        private static AndriodTool m_Instance;
        public static AndriodTool instance {
            get {
                if (m_Instance == null)
                    return new AndriodTool();
                else {
                    return m_Instance;

                } 
            }
           
        }

        public void SaveImg(byte[] imgByte , string name) { 
            try
            {
                MemoryStream ms = new MemoryStream(imgByte);  
                FileStream fs = new FileStream( Application.temporaryCachePath + "/img/" + name + ".png", FileMode.OpenOrCreate);
                ms.WriteTo(fs);
                ms.Close();
                fs.Close();
            }
            catch (System.Exception e)
            {
                Debug.Log(e.Message);
            } 
        }


    }

}

