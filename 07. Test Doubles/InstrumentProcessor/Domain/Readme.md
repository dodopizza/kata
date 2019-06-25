# Instrument Processor by Urs Enzler7

In the Instrument Processor kata, we are going to implement a class that gets tasks from a TaskDispatcher and executes them on an Instrument.8

The InstrumentProcessor must implement the following interface:

```c#
1 public interface IInstrumentProcessor
2 {
3   void Process();
4 }
```
The task dispatcher must have the following interface:

```c#
1 public interface ITaskDispatcher
2 {
3   string GetTask();
4   void FinishedTask(string task);
5 }
```

The GetTask method returns the next task to execute on the instrument.

After the task was successfully executed on the instrument, the FinishedTask method must be called by the InstrumentProcessor passing the task that was completed as the method argument.

The InstrumentProcessor has the following interface:

```c#
1 public interface IInstrument
2 {
3   void Execute(string task);
4   event EventHandler Finished;
5   event EventHandler Error;
6 }
```
The Execute method starts the instrument, which will begin to execute the task passed to it. The method will return immediately (we assume that the instrument implementation is asynchronous).

The Execute method will throw an ArgumentNullException if the task passed in is null.

When the instrument finishes executing then the Finished event is fired.

When the instrument detects an error situation during executing (note that the Execute method will already have returned the control flow to the caller due to its asynchronous implementation) then it fires the Error event.

The exercise is to implement the InstrumentProcessor in a way that:

* When the method Process is called then the InstrumentProcessor gets the next task from the task dispatcher and executes it on the instrument.
* When the Execute method of the instrument throws an exception then this exception is passed on to the caller of the Process method.
* When the instrument fires the finished event then the InstrumentProcessor calls the task dispatcher’s FinishedTask method with the correct task.
* When the instrument fires the Error event then the InstrumentProcessor writes the string “Error occurred” to the console.

_Excerpt From: Pedro Moreira Santos, Marco Consolaro and Alessandro Di Gioia. “Agile Technical Practices Distilled”. Apple Books._ 

 