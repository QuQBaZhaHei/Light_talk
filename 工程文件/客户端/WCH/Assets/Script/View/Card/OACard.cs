using System.Collections;
using System.Collections.Generic;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace WCH
{
    public class OACard : StatelessWidget
    {

        OffcialAccount offcialAccount;

        public OACard(OffcialAccount offcialAccount)
        {
            this.offcialAccount = offcialAccount;
        }

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
                                child:
                                new InkWell(
                                    onTap: () => {
                                        Navigator.of(context).push(new MaterialPageRoute( (buildcontext)=>new OAPanel(offcialAccount)));
                                    }
                                ,child: new Container(
                                    width: width * 0.95f
                                    , child: new Padding(
                                           padding: EdgeInsets.only(8, 8, 8, 8)
                                           , child:
                                                new Row(
                                                    children: new List<Widget>()
                                                    {
                                                        new ClipOval(
                                                            child:string.IsNullOrWhiteSpace(offcialAccount.open_id)?
                                                            Image.asset(
                                                                offcialAccount.headimage??"products/backpack",
                                                                fit: BoxFit.cover,
                                                                width: 80,
                                                                height: 80
                                                            ) :
                                                            Image.network(
                                                                offcialAccount.headimage??"products/backpack",
                                                                fit: BoxFit.cover,
                                                                width: 80,
                                                                height: 80
                                                            )
                                                        )
                                                        ,
                                                        new Expanded(
                                                            child:
                                                                new Column(
                                                                     children: new List<Widget>()
                                                                     {
                                                                         new Container(
                                                                              alignment:Alignment.topLeft
                                                                              ,padding:EdgeInsets.only(8,4,8,4)
                                                                             ,child:new Text(data:offcialAccount.wechat_name??"这是名字",style:Theme.of(context).textTheme.headline)
                                                                        )
                                                                        ,new Container(
                                                                              height:42
                                                                              ,padding:EdgeInsets.only(8,4,8,4)
                                                                              ,alignment:Alignment.topLeft
                                                                             ,child:new Text(data: offcialAccount.introduction??"这是一个帅气的简介这是一个帅气这是一个帅气这是一个帅气这是一个帅气这是一个帅气这是一个帅气"
                                                                                ,style:Theme.of(context).textTheme.body1.copyWith(color:Colors.black54)
                                                                                ,overflow: Unity.UIWidgets.rendering.TextOverflow.ellipsis
                                                                                ,maxLines: 2)
                                                                        )
                                                                 

                                                                     }
                                                                    )
                                                            )
                                                    }
                                                )
                                                )
                                           )
                                )
                        )
                    )
                );
        }
    } 
}
