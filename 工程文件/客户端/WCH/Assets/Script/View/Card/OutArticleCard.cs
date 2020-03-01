

using System.Collections.Generic;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;

namespace WCH
{
    public class OutArticleCard : StatelessWidget
    {
        private float? width;
        public override Widget build(BuildContext context)
        {
            if (width == null)
            {
                width = MediaQuery.of(context).size.width;

            }
            return
                new Container(
                   child: new Center(
                            child: new Card(
                                shape: new RoundedRectangleBorder(
                                    borderRadius: BorderRadius.all(5.0f)
                                ),
                                child: new Container(
                                    width: width * 0.95f
                                    , child: new Padding(
                                           padding: EdgeInsets.only(8, 8, 8, 8)
                                           , child:
                                                new Column(
                                                    children: new List<Widget>()
                                                    {

                                                         new Container(
                                                            alignment:Alignment.centerLeft
                                                            ,padding:EdgeInsets.only(0,4,0,4)
                                                            ,child:new Text(data:"这是名字标题",style:Theme.of(context).textTheme.headline)
                                                        )

                                                        ,new Row(
                                                            children: new List<Widget>()
                                                            {
                                                                Image.asset(
                                                                    "products/backpack",
                                                                    fit: BoxFit.cover,
                                                                    width: 60,
                                                                    height: 60
                                                                )
                                                                ,
                                                                new Expanded(
                                                                    child:
                                                                        new Column(
                                                                             children: new List<Widget>()
                                                                             {
                                                                                 new Container(
                                                                                      height:60
                                                                                      ,padding:EdgeInsets.only(12,4,12,4)
                                                                                      ,alignment:Alignment.topLeft
                                                                                     ,child:new Text(data:"这是一个帅气的简介这是一个帅气这是一个帅气这是一个帅气这是一个帅气这是一个帅气这是一个帅气"
                                                                                        ,style:Theme.of(context).textTheme.body1.copyWith(color:Colors.black54)
                                                                                        ,overflow: Unity.UIWidgets.rendering.TextOverflow.ellipsis
                                                                                        ,maxLines: 2)
                                                                                )


                                                                             }
                                                                            )
                                                                    )
                                                            }

                                                        )

                                                    }
                                                )

                                           )
                                )
                        )
                    )
                );
        }
    }

}


