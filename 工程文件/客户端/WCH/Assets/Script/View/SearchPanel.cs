        using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.Redux;
using Unity.UIWidgets.widgets;
using UnityEngine;

 namespace WCH
{
    public class SearchPanel : StatelessWidget
    {
        private TextEditingController searchTEController = new TextEditingController();
         
        public override Widget build(BuildContext context)
        {
            return new StoreConnector<AppState, AppState>(
                converter: state => state 
                , builder: (buildContext, model, dispather) =>
                {
                    return new Scaffold(
                       appBar: new AppBar(

                           centerTitle: true
                           , elevation: 3
                           , backgroundColor: Colors.white
                           , iconTheme: Theme.of(context).iconTheme
                           , leading: new IconButton(icon: new Icon(Icons.arrow_back, color: Colors.black)
                               , onPressed: () =>
                               {
                                   Navigator.of(context).pop();
                               })
                          , title: new TextField(decoration: new InputDecoration(
                                      hintText: "请输入要搜索的内容" 
                                      ,hintStyle: new TextStyle(fontSize:16)
                                      , suffixIcon: new IconButton(icon: new Icon(Icons.close, size: 14), color: Colors.grey,iconSize:14
                                            ,alignment: Alignment.center
                                            , onPressed: () => {
                                                searchTEController.clear();
                                            }
                                            )
                                    , contentPadding: EdgeInsets.only(0,16,0,6)
                                )
                              ,controller: searchTEController
                               ,autofocus:true
                              , onChanged: (value) =>
                              {
                                  //if (!string.IsNullOrWhiteSpace(value))
                                  //    dispather.dispatch(new SearchAction(value));
                              }
                              , onSubmitted: (value) => {
                                  NetSvc.instance.Send(new AppMsg() {

                                      cmd = 1,
                                      reqSearchList = new ReqSearchList() {
                                          input_text = value
                                      }


                                  });
                              } 
                              )
                              , actions: new List<Widget>()
                              {
                                   new Icon(Icons.search,color: Colors.transparent)
                              }
                           )

                       , body: ListView.builder(
                           
                           itemCount:model.offcial_account_list.Count
                           , itemBuilder: (mcount, index) => {

                               return new OACard(model.offcial_account_list[index]);
                           }
                           
                           )

                       );

                }
                );

        }
    }

}