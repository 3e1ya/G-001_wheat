using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class QueueTest : MonoBehaviour
{
    private Queue<int> queue = new Queue<int>();
    void Start()
    {
        // Enqueue(T); キューを追加
        // Dequeue(): 先頭のキューを消して取り出す
        // Peek(): 先頭のキューを消さずに取り出す
        // Clear(): キューのデータを消す
        // Contains(T): キューにTは存在するか？
        // Count: キューの個数を数える
        queue.Enqueue(0);
        queue.Enqueue(1);
        foreach (var item in queue)
        {
            Debug.Log("Queue後: " + item);
        }
        //　先頭から値を取得しデータを削除
        int dequeue = queue.Dequeue();
        Debug.Log("Dequeueした値: " + dequeue);
        foreach (var item in queue)
        {
            Debug.Log("Dequeue後: " + item);
        }
        queue.Enqueue(10);
        foreach (var item in queue)
        {
            Debug.Log("10Enqueue後: " + item);
        }
        int peekValue = queue.Peek();
        Debug.Log("Peekした値： " + peekValue);
        foreach (var item in queue)
        {
            Debug.Log("Peek後: " + item);
        }
        //　キューデータをクリア
        queue.Clear();
        foreach (var item in queue)
        {
            Debug.Log("キューデータクリア後: " + item);
        }
        queue.Enqueue(0);
        //　キューに0が存在するか？
        Debug.Log("キューデータに0が存在するか？: " + queue.Contains(0));
        Debug.Log("キューに登録されている数： " + queue.Count);
        foreach (var item in queue)
        {
            Debug.Log("キューに0が存在するか後: " + item);
        }
    }
}
