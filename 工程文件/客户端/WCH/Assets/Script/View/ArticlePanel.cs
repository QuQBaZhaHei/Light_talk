using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.Redux;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace WCH { 
    public class ArticlePanel : StatefulWidget
    {
        public ArticlePanel() {

        }
        public override State createState()
        {
            return new ArticleState();
        }
    }

    public class ArticleState : State<ArticlePanel>
    {

        private TextStyle pageOneSytle;
        private TextStyle pageTwoSytle;

        public ArticleState(){

        }

        public override void initState()
        {
            base.initState();

            pageOneSytle = Theme.of(context).textTheme.headline.copyWith(fontWeight: FontWeight.bold);
            pageTwoSytle = Theme.of(context).textTheme.body1;


        }

        public override Widget build(BuildContext context)
        { 

            return new StoreConnector<AppState, AppState>(
                    converter: state => state
                    , builder: (buildContext, model, dispatcher) =>
                    { 
                        return new Scaffold(

                            appBar: new AppBar(

                                title:new Container(
                                    alignment:Alignment.center
                                    ,child: new Row(
                                        mainAxisAlignment: MainAxisAlignment.center 
                                        ,children: new List<Widget>()
                                        {
                                            new Padding(
                                                padding: EdgeInsets.all(16)
                                                ,child: 
                                                      new Text(data:"关注",style:pageOneSytle)
                                                    
                                            
                                            ) 
                                            ,
                                            new Padding(
                                                padding: EdgeInsets.all(16)
                                                ,child: new Text(data:"订阅",style:pageTwoSytle)
                                                  
                                                )

                                        }

                                        )
                                    ) 
                                , centerTitle: true
                                , elevation: 0
                                , backgroundColor: Colors.white
                                , iconTheme: Theme.of(context).iconTheme
                                , actions: new List<Widget>()
                                {
                                    new IconButton(icon:new Icon(icon:Icons.refresh)
                                    ,onPressed:()=>{

                                        NetSvc.instance.Send(new AppMsg()
                                        { //测试点二：先定向爬取
                                            //cmd = 1
                                            //,
                                            //reqHotList = new ReqHotList()
                                            //{
                                            //    wechat_id_list = new List<string>() { "" }
                                            //}
                                        });
                                    }
                                    )  
                                }

                                )
                            , drawer: new MainDrawer()
                            , floatingActionButton: new FloatingActionButton(
                                    child: new Icon(Icons.search, color: Colors.white)
                                    , onPressed: () =>
                                    {
                                        Navigator.of(context).push(new MaterialPageRoute(
                                            builder: mbuildContext => new SearchPanel()
                                        ));
                                    }
                                    , backgroundColor: Colors.red
                                    ,elevation:0
                                    , shape: new CircleBorder(
                                        side: new BorderSide(
                                                color: Colors.white
                                                , width: 4
                                            )
                                        )
                                )  
                            , body: new PageView(
                                children: new List<Widget>() {
                                    new HotListPage()
                                    ,
                                    new SubscriptionPage()
                                }
                                , onPageChanged: (index) => {
                                    if(index == 0)
                                    {
                                        pageOneSytle = Theme.of(context).textTheme.headline.copyWith(fontWeight: FontWeight.bold);
                                        pageTwoSytle = Theme.of(context).textTheme.body1;
                                    }
                                    else
                                    {
                                        pageOneSytle = Theme.of(context).textTheme.body1;
                                        pageTwoSytle = Theme.of(context).textTheme.headline.copyWith(fontWeight: FontWeight.bold);
                                    }
                                    this.setState();

                                }

                            )
                        );
                    }
                    );
        }

    }

}

