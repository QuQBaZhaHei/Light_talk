using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.material;
using Unity.UIWidgets.Redux;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace WCH
{
    public class MainDrawer : StatelessWidget
    { 
        public override Widget build(BuildContext context)
        {
            return new StoreConnector<AppState, AppState>(
               converter: state => state
               , builder: (buildContext, model, dispatcher) =>
               {
                   return new Drawer(

                               child: new ListView(

                                   children: new List<Widget>() {

                                        new ListTile(
                                            title:new Text(data:"全部文章",style:Theme.of(context).textTheme.body1)
                                            ,leading: new Icon(icon:Icons.book)
                                            ,onTap:()=>{
                                                //dispatcher.dispatch(new ApplyFilterAction(Filter.ByAll()));
                                                Navigator.of(context).pop();
                                            }
                                            )
                                        ,new ExpansionTile(
                                            title:new Text(data:"收藏夹",style:Theme.of(context).textTheme.body1)
                                            ,leading: new Icon(icon:Icons.favorite)
                                            , children: new List<Widget>(){

 
                                            }
                                            )
                                        ,new ExpansionTile(
                                            title:new Text(data:"公众号",style:Theme.of(context).textTheme.body1)
                                            ,leading: new Icon(icon:Icons.priority_high)
                                            , children: new List<Widget>(){
 
                                            }
                                            )
 

                                       }


                                   )
                               );
               }
               );
        }
    }

}
