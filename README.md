 

# ***\*摘要\****

近年来，Internet迅速发展成为了一个分布于全球的混合信息空间，但同时带来的问题是检索获得信息麻烦，不同的APP富含着不同的信息，用户可能要在不同平台上获取信息。

本产品Light Talk可以帮助用户在不同平台上获取相关信息，节省了用户下载不同APP查询所花费的时间。只需在搜索框内输入关键字，本产品即可在微信、知乎、豆瓣、新浪等多个大型平台上获取资讯，包括文章、公众号、购票信息、影评等，用户可对感兴趣的信息进行关注收藏。

Light Talk体积小，页面简洁，稳定性高，易扩展，便于安装下载，搜索方便，并支持多用户在线使用，现已具备安卓版和ios版，具有良好的应用价值。 



# ***\*一、项目介绍\****

## 1.1作品支撑

Light Talk以以下技术作为支持构建了该作品。

Unity3D是当今绝大多数开发团队首选的的3D引擎，而且它在2D上也有不俗的表现。Unity3D有可定制的IDE环境，可以用C#进行上层逻辑的开发，具有代码驱动的开发模式，以及多平台发布等优点。

UiWidget为一个全新的包，以Flutter作为基础，使用Unity引擎进行前端开发，带来全新体验。

服务器具备承担服务并且保障服务的能力，且相比于PC机而言，服务器在处理能力、稳定性、可靠性、安全性、可扩展性、可管理性等方便较优越。Light Talk采用了服务器进行解析搜索，使得用户可以随时随地的满足搜索需求。

Python是一种跨平台的计算机程序设计语言。是一种面向对象的动态类型语言。P具有大量的第三方库和标准库，可扩充。

## 1.2 设计思路与功能模块

![img](file:///C:\Users\Celia\AppData\Local\Temp\ksohtml\wps6384.tmp.jpg) 

图 1功能模块设计

![img](file:///C:\Users\Celia\AppData\Local\Temp\ksohtml\wps6394.tmp.jpg)

图 2 应用结构设计

# ***\*二、产品设计\****

## 2.1 软件应用Logo

![img](file:///C:\Users\Celia\AppData\Local\Temp\ksohtml\wps63A5.tmp.jpg) 

图 3 Logo

我们应用Logo采取了一种简约的风格，主色调为红色，给人一种醒目的感觉，适当的留白，给人以简单舒适的感受。

## 2.2 主界面

![img](file:///C:\Users\Celia\AppData\Local\Temp\ksohtml\wps63A6.tmp.png) 

图 4 用户关注界面

![img](file:///C:\Users\Celia\AppData\Local\Temp\ksohtml\wps63B6.tmp.jpg) 

图 5 用户订阅界面

主界面简约大方，功能入口明显，提供关注信息和管理订阅功能，右下角的图标代表搜索功能。侧边抽屉栏提供搜藏夹和公众号查看功能。

## 2.3订阅界面

![img](file:///C:\Users\Celia\AppData\Local\Temp\ksohtml\wps63B7.tmp.jpg) 

图 6 订阅页面

![img](file:///C:\Users\Celia\AppData\Local\Temp\ksohtml\wps63C8.tmp.jpg) 

图 7订阅公众号具体内容

 

## 2.4 搜索界面

![img](file:///C:\Users\Celia\AppData\Local\Temp\ksohtml\wps63D9.tmp.jpg) 

图 8 搜索界面

# ***\*三、设计难点与重点\****

## 3.1 服务器端

### 3.1.1 使用Python构建服务器端

服务器端采用Python，并利用PyCharm进行编写。

![img](file:///C:\Users\Celia\AppData\Local\Temp\ksohtml\wps63E9.tmp.jpg) 

图 9 PyCharm图标

之所以选择Python，是因为具有以下优点：

跨平台，对Linux和windows都有不错的支持。

科学计算，数值拟合：Numpy，Scipy

可视化：2d：Matplotlib(做图很漂亮), 3d: Mayavi2

复杂网络：Networkx

统计：与R语言接口：Rpy

Python 有 scrapy 这样成熟的框架，以 Python 简洁的语法和一大波成熟的库为基础，开发速度相对较快，产品也较为稳度。而且Python 数据处理比较方便。不使用任何爬虫框架的情况下，可以使用常用的第三方库自己实现一个简单的爬虫。

### 3.1.2 request的使用

Request结构主要由以下部分组成：URL字段、Header字段、Body字段、Form字段、PostForm字段和MultipartForm字段。
  ***\*URL字段\****
  Request结构中的URL字段用于表示请求行中包含的URL，客户端通过URL的查询参数向服务器传递信息，而URL结构的RawQuery字段记录的就是客户端向服务器传递的查询参数字符串。如 http://www.example.com/post?id=1234&name=chen ，则RawQuery字段的值存储的就是id=1234&name=chen ，要想获取键值对格式的查询参数，要对RawQuery值进行语法分析，但是使用Request结构的Form字段，系统提供了解析RawQuery的方法，将解析的键值对信息会存储在Form字段中。
  ***\*Header字段\****
	通过Header类型的Get方法获取的头信息，其返回的就是字符串形式的首部值。
  ***\*Body字段\****
	请求和响应的主体都是Request结构的Body字段表示，该字段是一个io.ReadCloser接口。
  ***\*From字段\****
	如果直接获取请求体数据，需要自行进行语法分析，解析出键值对数据，而net/http库已经提供了一套用途相当广泛的函数，这些函数一般都能够满足用户对数据提取方面的需求，所以我们很少需要自行对表单数据进行语法分析。
通过调用Request结构提供的方法，用户可以将URL、主体又或者以上两者记录的数据提取到该结构的Form、PostForm和MultipartForm等字段当中。跟我们平常通过POST请求获取到的数据一样，存储在这些字段里面的数据也是以键值对形式表示的。
  ***\*PostFrom字段\*******\*
\**** 如果一个键同时拥有表单键值对和URL键值对，但是用户只想要获取表单键值对而不是URL键值对，那么可以访问Request结构的PostForm字段，这个字段只会包含键的表单值(请求体)，而不包含任何同名键的URL值。
  ***\*MultiparFrom字段\****
 MultipartForm字段只包含表单键值对而不包含URL键值对，所以这次打印出来的只有表单键值对而没有URL键值对。另外需要注意的是，MultipartForm字段的值也不再是一个映射，而是一个包含了两个映射的结构，其中第一个映射的键为字符串，值为字符串组成的切片，而第二个映射这是空的，这个映射之所以会为空，是因为它是用来记录用户上传的文件的。

### 3.1.3 xPath的使用

***\*xPath简介\****

xPath是一门在 XML 文档中查找信息的语言，使用路径表达式在xml和html中进行导航，包含标准函数库，是一个w3c标准。

***\*xPath使用\****

XPath可获取的四种数据类型：

***\*节点集(node-set)\**** 

节点集是通过路径匹配返回的符合条件的一组节点的集合。其它类型的数据不能转换为节点集。

***\*布尔值(boolean)\**** 

由函数或布尔表达式返回的条件匹配值，与一般语言中的布尔值相同，有true和 false两个值。布尔值可以和数值类型、字符串类型相互转换。

***\*字符串(string)\**** 

字符串即包含一系列字符的集合，XPath中提供了一系列的字符串函数。字符串可与数值类型、布尔值类型的数据相互转换。

***\*数值(number)\**** 

在XPath 中数值为浮点数，可以是双精度64位浮点数。另外包括一些数值的特殊描述，如非数值NaN（Not-a-Number）、正无穷大infinity、负无 穷大-infinity、正负0等等。number的整数值可以通过函数取得，另外，数值也可以和布尔类型、字符串类型相互转换。

其中后三种数据类型与其它编程语言中相应的数据类型差不多，只是第一种数据类型是XML文档树的特有产物。

例如程序中用到的li.xpath('div/div[1]/a')就可以通过路径表达式获取a标签内链接。

## 3.2客户端

### 3.2.1 利用Flutter框架在Unity平台进行客户端开发

Unity3D是由Unity Technologies开发的一个让开发者轻松创建诸如建筑可视化、实时[三维动画](https://baike.so.com/doc/5566658-5781774.html)等类型互动内容的多平台的综合型开发工具，其编辑器运行在Windows 和Mac OS X下，可发布游戏至Windows、[Mac](https://baike.so.com/doc/3374403-3552516.html)、[Wii](https://baike.so.com/doc/498230-527490.html)、[iPhone](https://baike.so.com/doc/2358901-2494519.html)、[WebGL](https://baike.so.com/doc/6956505-7178937.html)(需要[HTML5](https://baike.so.com/doc/6702457-6916408.html))、Windows phone 8和Android平台。

框架Flutter是谷歌的移动UI框架，可以快速在iOS和Android上构建高质量的原生用户界面。 Flutter可以与现有的代码一起工作。Flutter Widget采用现代响应式框架构建，这是从 [React](http://facebook.github.io/react/) 中获得的灵感，中心思想是用widget构建你的UI。

![img](file:///C:\Users\Celia\AppData\Local\Temp\ksohtml\wps63EA.tmp.jpg)        ![img](file:///C:\Users\Celia\AppData\Local\Temp\ksohtml\wps63FB.tmp.jpg)

图 10 Flutter图标       图 11 unity图标                 

​	Flutter是一个非常优秀的框架，而Unity具有强大的开发能力，便于发布到各种平台，那么如何各取所需，将两者进行融合，进行联合开发呢？

​	UIWidget是一个不错的选择，UIWidgets是Unity Editor的一个插件包，可帮助开发人员使用Unity Engine创建，调试和部署高效的跨平台应用程序。UIWidgets主要来自[Flutter](https://github.com/flutter/flutter)。但是，利用功能强大的Unity Engine，它为开发人员提供了许多新功能，可以显着改善他们的应用程序和开发工作流程。使用最新的Unity渲染SDK，UIWidgets应用程序可以非常快速地运行并且在大多数时间内保持> 60fps。UIWidgets应用程序可以像任何其他Unity项目一样直接部署在各种平台上，包括PC，移动设备和网页。除了基本的2D UI之外，开发人员还能够将3D模型，音频，粒子系统包含在他们的UIWidgets应用程序中。可以使用许多高级工具（如CPU / GPU分析，FPS分析）直接在Unity编辑器中调试UIWidgets应用程序。

目前这个项目正位于GitHub上，已经开发一年多之久，我们决定将这种新技术应用到我们的项目中去。

### ***\*3\*******\*.2.2\**** ***\*使用\*******\*Socket\*******\*开发\*******\*客户端\****

网络上的两个程序通过一个双向的通信连接实现数据的交换，这个连接的一端称为一个socket。利用Socket编程，客户端可以与服务端实现双向通信。

在Unity平台上，我们使用的是C#语言进行开发，在客户端上，我们需要实现与服务器的连接、发送与接收。

![img](file:///C:\Users\Celia\AppData\Local\Temp\ksohtml\wps640C.tmp.jpg) 

图 12流程图

在进行Socket通信时，会对发送的字节数据进行分包和粘包处理，这是属于一种Socket内部的优化机制。

粘包是指当发送的数据较小且频繁发送时，Socket内部会将字节数据进行粘包处理，把字节小的数据打包成一个包进行发送。分包是指当发送的数据包比较大时，Socket内部会将发送的字节数据进行分包处理，降低内存和性能的消耗。为了解决这类问题，我们在数据包头加上数据长度，然后接上数据类型，最后是发送的消息类容。

在数据类型上，我们目前设计了5种消息类型：

表 1 消息类型

| 编号 | CMD                 | 含义         |
| ---- | ------------------- | ------------ |
| 0    | HOTARTICLECOVERINFO | 获取热门文章 |
| 1    | SEARCHRESULT        | 搜索结果     |
| 2    | ARTICLECONTENT      | 文章内容     |
| 3    | ARTICLECOVERANDOA   | 主页获取     |
| 4    | ORCODE              | 二维码       |

 

在消息内容设计上，我们采取发送消息类AppMsg，无论是发送还是接受，根据cmd的类型，我们到指定的字段进行取值，即可获得我们所需要的信息。

![img](file:///C:\Users\Celia\AppData\Local\Temp\ksohtml\wps641C.tmp.jpg) 

图 13 Amg定义的类

### ***\*3\*******\*.\*******\*2\*******\*.3 实现C#客户端与Python服务端的\*******\*双向通信\****

作为两种不同类型的语言，一种是静态语言，一种是动态语言。之所以选择两种不同的语言进行开发，是为了将两种语言优秀的地方进行融合，各取所需，Python无疑是功能强大，具有众多第三方库，而C#基于.Net平台，能够更加方便的进行界面开发。混合编程的方式很多，我们这里选择了一种最基本的方式，即C#用来开发客户端，Python开发服务器端。而Socket适用于很多不同的语言，让它来实现双向通信是一个错的选择。

然而，在服务器和客户端之间保持消息的正常通信，我们还需要一种两边都可以使用的消息格式，于是选择了Json作为中间媒介。

JSON（JavaScript Object Notation）是一种轻量级的数据交换格式。易于编写，机器也很容易解析和生成。它基于[JavaScript编程语言的一部分](http://javascript.crockford.com/)。JSON是一种完全独立于语言的文本格式，但使用C语言系列程序员熟悉的约定，包括C，C ++，C＃，Java，JavaScript，Perl，Python等等。这些属性使JSON成为理想的数据交换语言。

![img](file:///C:\Users\Celia\AppData\Local\Temp\ksohtml\wps642D.tmp.png)![img](file:///C:\Users\Celia\AppData\Local\Temp\ksohtml\wps642E.tmp.jpg)

图 14 Json结构

在Json中结构分为“key-Value”和 “ordered list of values”两种结构，而这两种结构被不同语言实现，例如：在C#中的对象对应Python中的字典。

表 2

| Python           | JSON   | C#             |
| ---------------- | ------ | -------------- |
| dict             | object | class          |
| list, tuple      | array  | list           |
| str, unicode     | string | string         |
| int, long, float | number | int,long,float |
| True             | true   | true           |
| False            | false  | false          |
| None             | null   | null           |

 

所以，我只需要把要发送和接收的消息以Json的方式进行转换，然后在另外一段进行对应解析，就可在服务器与客户端实现消息的统一，进行流畅沟通。

### ***\*3\*******\*.\*******\*2\*******\*.4\**** ***\*使用\*******\*redux思想编写客户端\****

Redux是由Dan Abramov在2015年创建的科技术语。是受2014年Facebook的Flux架构以及函数式编程语言Elm启发。很快，Redux因其简单易学体积小在短时间内成为最热门的前端架构。

![img](file:///C:\Users\Celia\AppData\Local\Temp\ksohtml\wps643E.tmp.png)![img](file:///C:\Users\Celia\AppData\Local\Temp\ksohtml\wps643F.tmp.jpg)

图 15 Redux

Redux思想把各个功能模块分开，能够更加清晰地进行项目的开发。

在开发中，我们使用State来描述软件当前的状态，并将一些数据模型保存在其中。		

 

 

 

表 3 Article数据类型

| article_id       | 文章标题           |
| ---------------- | ------------------ |
| article_url      | 文章地址           |
| article_imgs     | 文章图片           |
| article_abstract | 文章摘要           |
| gzh_headimage    | 文章来源公众号头像 |
| gzh_id           | 微信id             |

表 4 OffcialAccount数据类型

| open_id      | 唯一ID         |
| ------------ | -------------- |
| headimage    | 头像           |
| wechat_name  | 名称           |
| wechat_id    | 微信ID         |
| post_perm    | 最近一月群发数 |
| introduction | 简介           |

 

Action用来描述变化，action 就像是一种指示器，这样我们可以清晰地知道应用中到底发生了什么。为了把 action 和 state 串起来,我们使用 reducer 处理各种变化，并将state修改为变化之后的状态。

