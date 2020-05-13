using System;


namespace FixSizeQueue
{
    
    public class FixSizeQueue
    {
    /*
    Class name: FixSizeQueue
    Description: a class that implements a fix size Queue of data type double.
    Size gets determined at the construction of the class
    Method:
    Double Queue(double item) queues the data and returns the oldest data.
    Property: Count returns the size of the queue
    Method:
    Double ElementAt(int index) returns the value At index “index”. If index is 0 it should return the oldest value and index == Count -1 returns latest value.
    You are not supposed to shift or move the data rather play with index to insert and retrieve data.
    You can make the data type generic if you feel comfortable at the end.
    */
    //Assumption1: The queue must be declared and then populated using enquqe immedeately.
    //The queue is never while testing the two methods not completely full. 
        private int _num_elems;
        private int _start_index;
        private int _end_index;
        private double[] q;
        
        public int Count
        {
            get { return this._num_elems; }
        }

        //when iitializing new queue set length, declare array and initialize indices. 
        
        public FixSizeQueue(int size)
        {

            this._start_index = 0;
            this._num_elems = size;
            this._end_index = -1;
            this.q = new double[this._num_elems];

        } 

        public void enqueue(double elem)
        {
            int end_index = this._end_index;

            if(this._end_index+1 > this._num_elems)
            {
                throw new Exception("Queue fully populated");
            }
            //enqueue at the end
            //only used to add elements at the begining
            else
            {
                this._end_index++;
                this.q[this._end_index] = elem;
                // Console.WriteLine(String.Join(",",this.q));

            }
            
        }

        public double dequeue()
        {
            if(this._num_elems == 0)
            {
                throw new Exception("Queue Empty");
            } 
            //dequeue from the start
            return this.q[_start_index];
        }

        //Double Queue(double item) queues the data and returns the oldest data.
        public double Queue(double elem)
        {
            double oldest_element = this.q[this._start_index];
            
            this._start_index = (this._start_index +1) % this._num_elems;
            
            int end_index = ((this._start_index -1)+this._num_elems) % this._num_elems;

            this.q[end_index] = elem;
            // Console.WriteLine(String.Join(",",this.q));
            // Console.WriteLine(this.q[this._start_index]);
            return oldest_element;

        }


        public double ElementAt(int index)
        {
            //returns the value At index “index”. If index is 0 it should return the oldest value and index == Count -1 returns latest value.
            if(index >= this._num_elems)
            {
                throw new Exception("Index out of bounds");
            }
            return this.q[(index+this._start_index)%this._num_elems];
        }
    
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Test1 = "+ ((test1()) ? "PASS" : "FAIL"));
            Console.WriteLine("Test2 = "+ ((test2()) ? "PASS" : "FAIL"));
            Console.WriteLine("Test3 = "+ ((test3()) ? "PASS" : "FAIL"));
            Console.WriteLine("Test4 = "+ ((test4()) ? "PASS" : "FAIL"));


        }

        // test property Count
        static bool test1()
        {
            int queue_size = 5;
            FixSizeQueue q1 = new FixSizeQueue(queue_size);
            double e = 3.1;
            
            for(int i=0; i<queue_size; i++)
            {
                q1.enqueue(e);
                e = e+1.0;
            }

            return (q1.Count == queue_size) ? true : false;
        }

        static bool test2()
        {
            //test method Queue: very basic test. 
            int queue_size = 5;
            FixSizeQueue q1 = new FixSizeQueue(queue_size);
            double e = 3.1;
            
            for(int i=0; i<queue_size; i++)
            {
                q1.enqueue(e);
                e = e+1.0;
            }
            double oldest_value = q1.Queue(4.234);
            
            return (oldest_value == 3.1) ? true : false;
        }

        static bool test3()
        {
            //test method ElementAt: very basic test. 
            int queue_size = 5;
            FixSizeQueue q1 = new FixSizeQueue(queue_size);
            double e = 3.1;
            
            for(int i=0; i<queue_size; i++)
            {
                q1.enqueue(e);
                e = e+1.0;
            }

            double oldest_value = q1.Queue(4.234);//start index = 1
            oldest_value = q1.Queue(3.14); //start index = 2

            if(q1.ElementAt(0)==5.1 && q1.ElementAt(1)==6.1 && q1.ElementAt(2) == 7.1 && q1.ElementAt(3)==4.234 && q1.ElementAt(4) == 3.14)
            {
                return true;
            }
            return false;
        }
        static bool test4()
        {
            //test method ElementAt: very basic test. 
            int queue_size = 5;
            FixSizeQueue q1 = new FixSizeQueue(queue_size);
            double e = 3.1;
            
            for(int i=0; i<queue_size; i++)
            {
                q1.enqueue(e);
                e = e+1.0;
            }

            double oldest_value = q1.Queue(4.234);//start index = 1
            oldest_value = q1.Queue(3.14); //start index = 2
            oldest_value = q1.Queue(16.14); //start index = 3
            oldest_value = q1.Queue(17.14); //start index = 4
            oldest_value = q1.Queue(18.14); //start index = 0
            

            if(q1.ElementAt(0)==4.234 && q1.ElementAt(1)==3.14 && q1.ElementAt(2) == 16.14 && q1.ElementAt(3)==17.14 && q1.ElementAt(4) == 18.14)
            {
                return true;
            }
            return false;
        }
    }


}


