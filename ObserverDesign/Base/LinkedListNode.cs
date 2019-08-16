using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedListNode<T> {
    public LinkedListNode(T value) {
        Value = value;
    }

    public T Value {get; private set;}
    public LinkedListNode<T> Next {get; set;}
    public LinkedListNode<T> Prev {get; set;}
}