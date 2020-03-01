
using System.Collections.Generic;
using Unity.UIWidgets;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.Redux;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace WCH
{
    public class WCHApp : UIWidgetsPanel
    {

        protected override void OnEnable()
        {
            //PlayerPrefs.DeleteAll();
            FontManager.instance.addFont(font: Resources.Load<Font>("MaterialIcons-Regular"), familyName: "Material Icons");
            //FontManager.instance.addFont(font: Resources.Load<Font>("TCMI____"), familyName: "TCMI");
            //FontManager.instance.addFont(font: Resources.Load<Font>("TCB_____"), familyName: "TCB");
            //FontManager.instance.addFont(font: Resources.Load<Font>("TCBI____"), familyName: "TCBI");
            //FontManager.instance.addFont(font: Resources.Load<Font>("TCM_____"), familyName: "TCM");
            Debug.Log("---------------------------");

            NetUpdate.init();
            base.OnEnable(); 
        }
           
        protected override Widget createWidget()
        {
            Store<AppState> store = new Store<AppState>(reducer: AppReducer.Reduce
                , initialState: AppState.Load()
                , SaveMiddleware.create<AppState>()
                );
            Common.store = store;
            return new StoreProvider<AppState>(
                 
                    store: store 
                    , child: new MaterialApp(
                        theme: new ThemeData(
                                iconTheme: new IconThemeData(
                                    color: Colors.black
                                    )
                                , primarySwatch: Colors.red
                                , textTheme: new TextTheme(

                                    headline: new TextStyle(

                                        //fontFamily: "TCB",
                                        fontWeight: FontWeight.normal,
                                        fontSize: 16,
                                        color: Colors.black

                                        )

                                    , body1: new TextStyle(

                                        //fontFamily: "TCM",
                                        fontWeight: FontWeight.normal,
                                        fontSize: 14,
                                        color: Colors.black

                                        )
                                    , body2: new TextStyle(

                                        //fontFamily: "TCM",
                                        fontWeight: FontWeight.normal,
                                        fontSize: 12,
                                        color: Colors.black

                                        )

                                    , subtitle: new TextStyle(

                                        //fontFamily: "TCM",
                                        fontWeight: FontWeight.normal,
                                        fontSize: 9,
                                        color: Colors.black

                                        )
                                    , display1: new TextStyle(
                                        //fontFamily: "TCMI",
                                        fontWeight: FontWeight.normal,
                                        fontSize: 18,
                                        color: Colors.black

                                    )

                                    )
                                ),
                            home: new ArticlePanel()
                            //home: new OAPanel()
                            , darkTheme: new ThemeData(primaryColor: Colors.black26)
                        )

                );

        }

    }
    
}

