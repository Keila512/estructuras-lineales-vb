Imports System

Module Program
    Sub Main(args As String())
        Dim maxSize As Integer = 5
        Dim stackArray As Integer() = New Integer(maxSize - 1) {}
        Dim queueArray As Integer() = New Integer(maxSize - 1) {}
        Dim stackTop As Integer = -1
        Dim queueFront As Integer = 0
        Dim queueRear As Integer = -1

        While True
            Console.WriteLine(vbLf & "MENU:")
            Console.WriteLine("1. Insert into Stack")
            Console.WriteLine("2. Remove from Stack")
            Console.WriteLine("3. Show stack")
            Console.WriteLine("4. Insert into queue")
            Console.WriteLine("5. Remove from queue")
            Console.WriteLine("6. Show queue")
            Console.WriteLine("7. Exit")
            Console.Write("Select an option: ")
            Dim choice As Integer = Convert.ToInt32(Console.ReadLine())
            Select Case choice
                Case 1
                    Console.Write("Enter a value to push onto the stack: ")
                    Dim valueToPush As Integer = Convert.ToInt32(Console.ReadLine())
                    Push(stackArray, maxSize, stackTop, valueToPush)
                Case 2
                    Pop(stackArray, stackTop)
                Case 3
                    DisplayStack(stackArray, stackTop)
                Case 4
                    Console.Write("Enter a value to insert into the queue: ")
                    Dim valueToEnqueue As Integer = Convert.ToInt32(Console.ReadLine())
                    Enqueue(queueArray, maxSize, queueRear, valueToEnqueue)
                Case 5
                    Dequeue(queueArray, queueFront, queueRear)
                Case 6
                    DisplayQueue(queueArray, queueFront, queueRear)
                Case 7
                    Environment.[Exit](0)
                Case Else
                    Console.WriteLine("Invalid option. Try again.")
            End Select
        End While
    End Sub

    Private Sub Push(ByVal stack As Integer(), ByVal maxSize As Integer, ByRef top As Integer, ByVal value As Integer)
        If top < maxSize - 1 Then
            stack(System.Threading.Interlocked.Increment(top)) = value
            Console.WriteLine($"{value} has been inserted into the stack.")
        Else
            Console.WriteLine("The stack is full. Cannot insert more elements.")
        End If
    End Sub

    Private Sub Pop(ByVal stack As Integer(), ByRef top As Integer)
        If top >= 0 Then
            Dim poppedValue As Integer = stack(Math.Max(System.Threading.Interlocked.Decrement(top), top + 1))
            Console.WriteLine($"{poppedValue} has been removed from the stack.")
        Else
            Console.WriteLine("The stack is empty. Cannot delete more items.")
        End If
    End Sub

    Private Sub DisplayStack(ByVal stack As Integer(), ByVal top As Integer)
        If top >= 0 Then
            Console.WriteLine("Stack Contents:")

            For i As Integer = top To 0
                Console.WriteLine(stack(i))
            Next
        Else
            Console.WriteLine("The stack is empty.")
        End If
    End Sub

    Private Sub Enqueue(ByVal queue As Integer(), ByVal maxSize As Integer, ByRef rear As Integer, ByVal value As Integer)
        If rear < maxSize - 1 Then
            queue(System.Threading.Interlocked.Increment(rear)) = value
            Console.WriteLine($"{value} has been inserted into the queue.")
        Else
            Console.WriteLine("The queue is full. Cannot insert more elements.")
        End If
    End Sub

    Private Sub Dequeue(ByVal queue As Integer(), ByRef front As Integer, ByVal rear As Integer)
        If front <= rear Then
            Dim dequeuedValue As Integer = queue(Math.Min(System.Threading.Interlocked.Increment(front), front - 1))
            Console.WriteLine($"{dequeuedValue} has been removed from the queue.")
        Else
            Console.WriteLine("The queue is empty. Cannot delete more items.")
        End If
    End Sub

    Private Sub DisplayQueue(ByVal queue As Integer(), ByVal front As Integer, ByVal rear As Integer)
        If front <= rear Then
            Console.WriteLine("Queue content:")

            For i As Integer = front To rear
                Console.WriteLine(queue(i))
            Next
        Else
            Console.WriteLine("The queue is empty.")
        End If
    End Sub
End Module
