
using System;
using System.Linq;
using System.Text;
using UnityEngine;

namespace WCH
{
    public class DealMessage
    { 
        public byte[] head = new byte[4];
        public int headLen = 4;
        public int headIndex = 0;

        public byte[] body = null;
        public int bodyLen = 0;
        public int bodyIndex = 0;

        public int headRemain {
            get
            {
                return headLen - headIndex;
            }

        }
        public int bodyRemain
        {
            get
            {
                return bodyLen - bodyIndex;
            }

        }
        public void InitBody()
        {
            Debug.Log("-->" + head[0] + " " + head[1] + " " + head[2] + " " + head[3]);
            Array.Reverse(head);
            bodyLen = BitConverter.ToInt32(head, 0);
            Debug.Log(bodyLen);
            body = new byte[bodyLen];
        }
        public void ResetData()
        {
            headIndex = 0;
            bodyLen = 0;
            body = null;
            bodyIndex = 0;
        }
        public static byte[] PackLenInfo(byte[] data)
        {
            int len = data.Length;
            //Debug.Log("->" + len);
            byte[] pkg = new byte[len + 4];
            byte[] head = BitConverter.GetBytes(len);
            Array.Reverse(head); 
            //Debug.Log("-->" + head[0]+" " + head[1]+" "+head[2] +" " +head[3]);
            head.CopyTo(pkg, 0);
            data.CopyTo(pkg, 4);
            return pkg;
        }
    }

}

