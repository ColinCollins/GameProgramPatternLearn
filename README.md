# GameProgramPatternLearn
Learn From Game Program Pattern Learn



### 寻求平衡
    - 获取一个良好的架构，在项目的生命周期中会更容易的理解代码
    - 运行时的性能足够快速
    - 希望快速的完成当前进度

### 2019.8.15
第二章模式介绍：
命令模式。
享元模式
观察者模式
原型模式
单例模式
状态模式


#### 命令模式
- 将一个请求封装成为一个对象。
从而允许你使用不同的请求、队列或者日志将客户端参数化，同时支持请求操作的撤销与恢复。
- 命令就是面向对象化的回调。

- 反射是一个对象化的类型系统？？
一些语言的反射系统可以使用户在运行时命令式的处理系统中的类型。用户可以获取到一个对象，这个对象代表着某些其他对象的类。可以通过上文中的对象进行功能尝试。

从我的理解上而言，就是将一个指令操作封装成为一个对象。就像我们 AudioSystem 里面做的那样，尽管外部资源管理我们做的并不够仔细，但是指令封装倒是还行。

核心功能实现： redo / undo 撤销与回复功能。
将指令存入数据池中，以便能够撤销某些错误的实现或者操作。
当用户撤销操作之后，若没有执行新的指令，那么被认为是回复。
若采取的不是回复操作而是新指令，那么当前指向指令之后的所有指令状态将被丢弃，同时将新指令传入列表。



#### 享元模式
在图形渲染中用的比较多，类似于合批技巧。

- 与类型对象模式不同。类型对象模式说是通过将可复用的数据封装成为一个对象，由多个对象进行共同持有。从而达到内存共享。
- 享元模式更注重效率。

c# 目前来说我对这种语言的指针操作还比较模糊，说不清楚。那么要实现享元模式，首先就要知道，他获取数据要求对象存储一个内存共享的数据指针。通过指针直接对比或者操作生成数据。
因为享元至于枚举，在使用之前需要针对当前的语言进行判断是否一定会加快运行效率。因此是否使用似乎还需要实际考虑。

#### 观察者模式
在对象间定义一种一对多的依赖关系。以便当某种对象的状态发生改变时，与之相关的所有对象都能够接收到通知并且自动进行调用。
最常见的使用框架为 MVC 框架。

``` js
// presudocode
Target.emit("Some Event", this); // => the listener need to catch the target

Listener.on("Some Event", Callback); // -> instaniate a new ListenerNode to Dic.
Listener.off("Some Event"); // -> delete own callback in EventPool

// 要保持很好的独立性，那么 ListenerSystem 除了原有功能其它 Dic 就是通过 private 封锁在 class 内。
ListenerSystem -> static EventPool -> Dic("Some Event", ListenerNode); 

/*
 * 我更乐意多设计一个 createEvent | deleteEvent 然后在 Init 调用。
 * 因为这样就可以更好的控制 Event Count;
 */

ListenerNode -> {
    Object obj;
    Callback callback;
}

try {
    callback
}
catch () {
    Debug.LogError();
    return false;
}

Dic.foreach();
```


优先使用接口而不是使用一个具有具体状态的类是一个不错的选择。

这里对于 Dic 的实现，比较简单的办法是直接使用 Dictionary.
第二种实现方案是自定义管理。在 IEnumerable 的实现类中实现 __自主定义链表__。

观察者模式实现过程中还有一个需要注意的原则：若两个观察者观察同一个对象，那么多个观察者对象之间的注册顺序不应该影响他们之间的关系。

若注册顺序对监听回调产生了影响，那就表示两个观察者之间产生了耦合关系。那就有可能带来不必要的影响。

观察者模式是把双刃剑，因为会造成持有数据者的增加。
结合 C# 相关数据，我认为可以尝试实现一版对应的观察着模式，内容。
要求引用指针管理 观察列表。

------------------------------------------------------------