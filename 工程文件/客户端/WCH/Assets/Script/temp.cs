using System.Collections;
using System.Collections.Generic;
using UIWidgetsSample;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;
 
namespace WCH
{

    public class temp : UIWidgetsPanel
    {

        protected override Widget createWidget()
        {
            return new MaterialApp(
                home: new Text(data: "sssssss")
                //darkTheme: new ThemeData(primaryColor: Colors.black26)
            );
        }
         
        protected override void OnEnable()
        {
            FontManager.instance.addFont(Resources.Load<Font>(path: "MaterialIcons-Regular"), "Material Icons");
            base.OnEnable();
        }
    }
}
